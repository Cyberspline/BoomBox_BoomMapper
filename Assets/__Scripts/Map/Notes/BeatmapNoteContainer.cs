using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BeatmapNoteContainer : BeatmapObjectContainer
{
    private static readonly Color unassignedColor = new Color(0.1544118f, 0.1544118f, 0.1544118f);

    private static readonly int alwaysTranslucent = Shader.PropertyToID("_AlwaysTranslucent");

    [FormerlySerializedAs("mapNoteData")] public BeatmapNote MapNoteData;

    [SerializeField] private GameObject simpleBlock;
    [SerializeField] private GameObject complexBlock;

    [SerializeField] private List<MeshRenderer> noteRenderer;
    [SerializeField] private MeshRenderer bombRenderer;

    private bool currentState;

    public override BeatmapObject ObjectData { get => MapNoteData; set => MapNoteData = (BeatmapNote)value; }

    public override void Setup()
    {
        base.Setup();

        if (simpleBlock != null)
        {
            simpleBlock.SetActive(Settings.Instance.SimpleBlocks);
            complexBlock.SetActive(!Settings.Instance.SimpleBlocks);

            MaterialPropertyBlock.SetFloat("_Lit", Settings.Instance.SimpleBlocks ? 0 : 1);

            UpdateMaterials();
        }

        CheckTranslucent();
    }

    internal static Vector3 Directionalize(BeatmapNote mapNoteData)
    {
        if (mapNoteData == null) return Vector3.zero;

        var yaw = 0f;
        switch (mapNoteData.RadialIndex)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
                yaw = -145f;
                break;
            case 5:
            case 9:
                yaw = -140f;
                break;
            case 6:
            case 7:
            case 8:
                yaw = -130f;
                break;
            case 10:
            case 11:
                yaw = -130f;
                break;
        }

        return new Vector3(yaw, 0, RadialIndexTable.Instance.GetNoteInwardRotation(mapNoteData.RadialIndex));
    }

    public void SetBomb(bool b)
    {
        simpleBlock.SetActive(!b && Settings.Instance.SimpleBlocks);
        complexBlock.SetActive(!b && !Settings.Instance.SimpleBlocks);

        bombRenderer.gameObject.SetActive(b);
        bombRenderer.enabled = b;
    }

    public static BeatmapNoteContainer SpawnBeatmapNote(BeatmapNote noteData, ref GameObject notePrefab)
    {
        var container = Instantiate(notePrefab).GetComponent<BeatmapNoteContainer>();
        container.MapNoteData = noteData;
        container.transform.localEulerAngles = Directionalize(noteData);
        return container;
    }

    public override void UpdateGridPosition()
    {
        transform.localPosition = (Vector3)MapNoteData.GetPosition() +
                                  new Vector3(0, 0.5f, MapNoteData.Time * EditorScaleController.EditorScale);
        transform.localScale = MapNoteData.GetScale() + new Vector3(0.5f, 0.5f, 0.5f);
        UpdateCollisionGroups();
        SetRotation(AssignedTrack != null ? AssignedTrack.RotationValue.y : 0);
    }

    public void CheckTranslucent()
    {
        var newState = transform.parent != null && transform.localPosition.z + transform.parent.localPosition.z <=
            BeatmapObjectContainerCollection.TranslucentCull;
        if (newState != currentState)
        {
            MaterialPropertyBlock.SetFloat(alwaysTranslucent, newState ? 1 : 0);
            UpdateMaterials();
            currentState = newState;
        }
    }

    public void SetColor(Color? color)
    {
        MaterialPropertyBlock.SetColor(BeatmapObjectContainer.color, color ?? unassignedColor);
        UpdateMaterials();
    }

    public override void AssignTrack(Track track)
    {
        if (AssignedTrack != null) AssignedTrack.TimeChanged -= CheckTranslucent;

        base.AssignTrack(track);
        track.TimeChanged += CheckTranslucent;
    }

    internal override void UpdateMaterials()
    {
        foreach (var renderer in noteRenderer) renderer.SetPropertyBlock(MaterialPropertyBlock);
        foreach (var renderer in SelectionRenderers) renderer.SetPropertyBlock(MaterialPropertyBlock);
        bombRenderer.SetPropertyBlock(MaterialPropertyBlock);
    }
}
