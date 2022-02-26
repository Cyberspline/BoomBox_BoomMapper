using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TracksManager : MonoBehaviour
{
    [FormerlySerializedAs("TrackPrefab")] [SerializeField] private GameObject trackPrefab;
    [FormerlySerializedAs("TracksParent")] [SerializeField] private Transform tracksParent;

    private readonly Dictionary<Vector3, Track> loadedTracks = new Dictionary<Vector3, Track>();

    private readonly List<BeatmapObjectContainerCollection> objectContainerCollections =
        new List<BeatmapObjectContainerCollection>();

    private float position;

    public float LowestRotation { get; private set; }
    public float HighestRotation { get; private set; }

    // Start is called before the first frame update
    private void Start()
    {
        objectContainerCollections.Add(BeatmapObjectContainerCollection.GetCollectionForType(BeatmapObject.ObjectType.Note));
        objectContainerCollections.Add(BeatmapObjectContainerCollection.GetCollectionForType(BeatmapObject.ObjectType.Obstacle));
    }

    /// <summary>
    ///     Create a new <see cref="Track" /> with the specified global rotation. If a track already exists with that rotation,
    ///     it will simply return that track.
    /// </summary>
    /// <param name="rotation">Global euler rotation</param>
    /// <returns></returns>
    public Track CreateTrack(Vector3 rotation)
    {
        if (loadedTracks.TryGetValue(rotation, out var track)) return track;

        track = Instantiate(trackPrefab, tracksParent).GetComponent<Track>();
        track.gameObject.name = $"Track [{rotation.x}, {rotation.y}, {rotation.z}]";
        track.AssignRotationValue(rotation);
        track.UpdatePosition(position);
        loadedTracks.Add(rotation, track);
        return track;
    }

    public Track GetTrackAtTime(float _) => CreateTrack(Vector3.zero);

    public void RefreshTracks()
    {
        foreach (var collection in objectContainerCollections)
        {
            foreach (var container in collection.LoadedContainers.Values)
            {
                var track = GetTrackAtTime(container.ObjectData.Time);
                track.AttachContainer(container);
            }
        }
    }

    // Take our position from AudioTimeSyncController and broadcast that to every track.
    public void UpdatePosition(float position)
    {
        this.position = position;
        foreach (var track in loadedTracks.Values) track.UpdatePosition(position);
    }
}
