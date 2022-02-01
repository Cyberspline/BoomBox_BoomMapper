using NUnit.Framework;
using System.Collections;
using Tests.Util;
using UnityEngine.TestTools;

namespace Tests
{
    public class NotesContainerTest
    {
        [UnityOneTimeSetUp]
        public IEnumerator LoadMap()
        {
            return TestUtils.LoadMapper();
        }

        [TearDown]
        public void ContainerCleanup()
        {
            TestUtils.CleanupNotes();
        }

        private void UpdateNote(BeatmapNoteContainer container, int lineIndex, int lineLayer, int cutDirection)
        {
            BeatmapNote note = (BeatmapNote)container.ObjectData;
            note.LineIndex = lineIndex;
            note.LineLayer = lineLayer;
            note.CutDirection = cutDirection;
            container.UpdateGridPosition();
            container.transform.localEulerAngles = BeatmapNoteContainer.Directionalize(note);
        }

        [Test]
        public void ShiftInTime()
        {
            BeatmapObjectContainerCollection notesContainer = BeatmapObjectContainerCollection.GetCollectionForType(BeatmapObject.ObjectType.Note);
            UnityEngine.Transform root = notesContainer.transform.root;

            BeatmapNote noteA = new BeatmapNote
            {
                Time = 2,
                Type = BeatmapNote.NoteTypeA
            };
            notesContainer.SpawnObject(noteA);

            BeatmapNote noteB = new BeatmapNote
            {
                Time = 3,
                Type = BeatmapNote.NoteTypeA
            };
            notesContainer.SpawnObject(noteB);

            SelectionController.Select(noteB, false, false, false);

            SelectionController selectionController = root.GetComponentInChildren<SelectionController>();
            selectionController.MoveSelection(-2);

            notesContainer.DeleteObject(noteB);

            Assert.AreEqual(1, notesContainer.LoadedContainers.Count);
            Assert.AreEqual(1, notesContainer.LoadedObjects.Count);
        }
    }
}
