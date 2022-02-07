using NUnit.Framework;
using SimpleJSON;
using System.Collections;
using System.Linq;
using Tests.Util;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    // TODO: Rewrite tests
    public class SimpleMirrorTest
    {
        private BeatmapActionContainer _actionContainer;
        private MirrorSelection _mirror;

        [UnityOneTimeSetUp]
        public IEnumerator LoadMap()
        {
            yield return TestUtils.LoadMapper();

            _actionContainer = Object.FindObjectOfType<BeatmapActionContainer>();
            _mirror = Object.FindObjectOfType<MirrorSelection>();
        }

        [TearDown]
        public void ContainerCleanup()
        {
            BeatmapActionContainer.RemoveAllActionsOfType<BeatmapAction>();
            TestUtils.CleanupNotes();
            TestUtils.CleanupEvents();
            TestUtils.CleanupObstacles();
        }
    }
}
