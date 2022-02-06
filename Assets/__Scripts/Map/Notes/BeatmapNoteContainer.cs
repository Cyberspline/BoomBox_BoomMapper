using UnityEngine;
using UnityEngine.Serialization;

public class BeatmapNoteContainer : BeatmapObjectContainer
{
    private static readonly Color unassignedColor = new Color(0.1544118f, 0.1544118f, 0.1544118f);

    private static readonly int emissionColor = Shader.PropertyToID("_EmissionColor");
    private static readonly int alwaysTranslucent = Shader.PropertyToID("_AlwaysTranslucent");
    private static readonly int translucentAlpha = Shader.PropertyToID("_TranslucentAlpha");

    [FormerlySerializedAs("mapNoteData")] public BeatmapNote MapNoteData;

    private bool currentState;

    public override BeatmapObject ObjectData { get => MapNoteData; set => MapNoteData = (BeatmapNote)value; }

    public override void Setup()
    {
        base.Setup();
        CheckTranslucent();
    }

    // TODO: Make this not static, do on UpdateGridPosition instaed
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

        var pitch = RadialIndexTable.Instance.GetNoteInwardRotation(mapNoteData.RadialIndex);

        // DO NOT TOUCH THIS. THE ORDER MATTERS.
        return (Quaternion.Euler(0, 0, pitch) * Quaternion.Euler(yaw, 0, 0)).eulerAngles;
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
                                  new Vector3(0, 0, MapNoteData.Time * EditorScaleController.EditorScale);
        transform.localScale = MapNoteData.GetScale();
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
        MaterialPropertyBlock.SetColor(emissionColor, color ?? unassignedColor);
        UpdateMaterials();
    }

    public void SetAlpha(float alpha, bool forceTranslucent = false)
    {
        MaterialPropertyBlock.SetFloat(alwaysTranslucent, forceTranslucent ? 1 : 0);
        MaterialPropertyBlock.SetFloat(translucentAlpha, alpha);
        UpdateMaterials();
    }

    public override void AssignTrack(Track track)
    {
        if (AssignedTrack != null) AssignedTrack.TimeChanged -= CheckTranslucent;

        base.AssignTrack(track);
        track.TimeChanged += CheckTranslucent;
    }
}
