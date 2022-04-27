using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoxSelectionPlacementController : PlacementController<BeatmapNote, BeatmapNoteContainer, NotesContainer>,
    CMInput.IBoxSelectActions
{
    public static bool IsSelecting { get; private set; }

    private readonly HashSet<BeatmapObject> selected = new HashSet<BeatmapObject>();

    private readonly List<BeatmapObject.ObjectType> selectedTypes = new List<BeatmapObject.ObjectType>();
    private HashSet<BeatmapObject> alreadySelected = new HashSet<BeatmapObject>();

    private bool keybindPressed;
    private Vector3 originPos;
    private Intersections.IntersectionHit previousHit;
    private Vector3 transformed;
    private float startBeat;

    [HideInInspector] protected override bool CanClickAndDrag { get; set; } = false;

    public override bool IsValid => Settings.Instance.BoxSelect && (keybindPressed || IsSelecting);

    public override int PlacementXMin => int.MinValue;

    public override int PlacementXMax => int.MaxValue;

    /*
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying || instantiatedContainer is null) return;
        Gizmos.color = Color.red;
        var boxyBoy = instantiatedContainer.GetComponentInChildren<IntersectionCollider>().BoundsRenderer;
        var bounds = new Bounds
        {
            center = boxyBoy.bounds.center,
            size = instantiatedContainer.transform.lossyScale / 2f
        };
        Gizmos.DrawMesh(instantiatedContainer.GetComponentInChildren<MeshFilter>().mesh, bounds.center,
            instantiatedContainer.transform.rotation, bounds.size);
    }*/

    public void OnActivateBoxSelect(InputAction.CallbackContext context) => keybindPressed = context.performed;

    public override BeatmapAction GenerateAction(BeatmapObject spawned, IEnumerable<BeatmapObject> conflicting) => null;

    public override BeatmapNote GenerateOriginalData() => new BeatmapNote(float.MaxValue, 69, 420, 1337, -1);

    protected override bool TestForType<T>(Intersections.IntersectionHit hit, BeatmapObject.ObjectType type)
    {
        if (base.TestForType<T>(hit, type))
        {
            selectedTypes.Add(type);
            return true;
        }

        return false;
    }

    public override void OnPhysicsRaycast(Intersections.IntersectionHit hit, Vector3 transformedPoint)
    {
        previousHit = hit;
        transformed = transformedPoint;

        var roundedHit = ParentTrack.InverseTransformPoint(hit.Point);
        roundedHit = new Vector3(
            Mathf.Ceil(Math.Min(Math.Max(roundedHit.x, Bounds.min.x + 0.01f), Bounds.max.x)),
            Mathf.Ceil(Math.Min(Math.Max(roundedHit.y, 0.01f), 3f)),
            roundedHit.z
        );
        instantiatedContainer.transform.localPosition = roundedHit - new Vector3(0.5f, 1, 0);
        if (!IsSelecting)
        {
            Bounds = default;
            selectedTypes.Clear();

            TestForType<NotePlacement>(hit, BeatmapObject.ObjectType.Note);
            TestForType<ObstaclePlacement>(hit, BeatmapObject.ObjectType.Obstacle);
            TestForType<BPMChangePlacement>(hit, BeatmapObject.ObjectType.BpmChange);

            instantiatedContainer.transform.localPosition = new Vector3(Bounds.min.x, 0, RoundedTime * EditorScaleController.EditorScale);
            instantiatedContainer.transform.localScale = new Vector3(Bounds.max.x - Bounds.min.x, 0.1f, 0);
        }
        else
        {
            var endBeat = RoundedTime;

            if (startBeat > endBeat) (startBeat, endBeat) = (endBeat, startBeat);

            instantiatedContainer.transform.localPosition = originPos;

            var scale = instantiatedContainer.transform.localScale;
            instantiatedContainer.transform.localScale = new Vector3(scale.x, scale.y,
                (endBeat - startBeat) * EditorScaleController.EditorScale);

            SelectionController.ForEachObjectBetweenTimeByGroup(startBeat, endBeat, true, true, true, (bocc, bo) =>
            {
                if (!selectedTypes.Contains(bo.BeatmapType)) return; // Must be a type we can select

                if (!alreadySelected.Contains(bo) && selected.Add(bo))
                    SelectionController.Select(bo, true, false, false);
            });

            foreach (var combinedObj in SelectionController.SelectedObjects.ToArray())
            {
                if (!selected.Contains(combinedObj) && !alreadySelected.Contains(combinedObj))
                    SelectionController.Deselect(combinedObj, false);
            }

            selected.Clear();
        }
    }

    public override void OnMousePositionUpdate(InputAction.CallbackContext context)
    {
        if (!IsValid && IsSelecting)
            StartCoroutine(WaitABitFuckOffOtherPlacementControllers());
        base.OnMousePositionUpdate(context);
    }

    internal override void PlaceObjectPrimary()
    {
        if (!IsSelecting)
        {
            IsSelecting = true;
            startBeat = RoundedTime;
            originPos = instantiatedContainer.transform.localPosition;
            alreadySelected = new HashSet<BeatmapObject>(SelectionController.SelectedObjects);
        }
        else
        {
            StartCoroutine(WaitABitFuckOffOtherPlacementControllers());
            SelectionController.RefreshSelectionMaterial(selected.Any());
            SelectionController.SelectionChangedEvent?.Invoke();
            OnPhysicsRaycast(previousHit, transformed);
        }
    }

    private IEnumerator WaitABitFuckOffOtherPlacementControllers()
    {
        yield return new WaitForSeconds(0.1f);
        IsSelecting = false;
        selected.Clear(); // oh shit turned out i didnt need to rewrite the whole thing, just move it over here
        OnPhysicsRaycast(previousHit, transformed);
    }

    public override void CancelPlacement()
    {
        IsSelecting = false;
        foreach (var selectedObject in selected) SelectionController.Deselect(selectedObject);
    }

    public override void TransferQueuedToDraggedObject(ref BeatmapNote dragged, BeatmapNote queued) { }
}
