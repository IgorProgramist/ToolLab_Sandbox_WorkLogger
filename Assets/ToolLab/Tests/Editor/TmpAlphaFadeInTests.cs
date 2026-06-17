using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityToolLab.TMP;

namespace UnityToolLab.Tests.Editor
{
    public class TmpAlphaFadeInTests
    {
        private string _logFolder;
        private List<GameObject> _createdObjects;

        [SetUp]
        public void SetUp()
        {
            _createdObjects = new List<GameObject>();
            _logFolder = Path.Combine(Application.dataPath, "Logs");
            if (!Directory.Exists(_logFolder))
                return;

            foreach (var file in Directory.GetFiles(_logFolder, "toollab_*.jsonl"))
                File.Delete(file);
        }

        [TearDown]
        public void TearDown()
        {
            foreach (var go in _createdObjects)
            {
                if (go != null)
                    Object.DestroyImmediate(go);
            }

            _createdObjects.Clear();

            if (!Directory.Exists(_logFolder))
                return;

            foreach (var file in Directory.GetFiles(_logFolder, "toollab_*.jsonl"))
                File.Delete(file);
        }

        [Test]
        public void T1_ComponentCanBeCreated_WithTextMeshProUGUI()
        {
            var go = CreateGameObject("TMP_Test");
            var tmp = go.AddComponent<TextMeshProUGUI>();
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            Assert.IsNotNull(fade);
            Assert.IsNotNull(tmp);
            Assert.IsNotNull(go.GetComponent<TextMeshProUGUI>());
        }

        [Test]
        public void T2_SetAlpha_ClampsAndSetsAlphaCorrectly()
        {
            var go = CreateTmpGameObject();
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            fade.SetAlpha(0.5f);
            Assert.AreEqual(0.5f, go.GetComponent<TextMeshProUGUI>().color.a, 0.001f);

            fade.SetAlpha(1.5f);
            Assert.AreEqual(1f, go.GetComponent<TextMeshProUGUI>().color.a, 0.001f);

            fade.SetAlpha(-0.25f);
            Assert.AreEqual(0f, go.GetComponent<TextMeshProUGUI>().color.a, 0.001f);
        }

        [Test]
        public void T3_FadeInImmediate_SetsAlphaToOne()
        {
            var go = CreateTmpGameObject(0f);
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            fade.FadeInImmediate();
            Assert.AreEqual(1f, go.GetComponent<TextMeshProUGUI>().color.a, 0.001f);
        }

        [Test]
        public void T4_FadeOutImmediate_SetsAlphaToZero()
        {
            var go = CreateTmpGameObject(1f);
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            fade.FadeOutImmediate();
            Assert.AreEqual(0f, go.GetComponent<TextMeshProUGUI>().color.a, 0.001f);
        }

        [Test]
        public void T5_MissingTmpReference_HandledSafely()
        {
            var go = CreateGameObject("NoTMP");
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            Assert.IsFalse(fade.TrySetAlpha(0.5f));
            Assert.DoesNotThrow(() => fade.SetAlpha(0.5f));
            Assert.DoesNotThrow(() => fade.FadeInImmediate());
            Assert.DoesNotThrow(() => fade.FadeOutImmediate());
        }

        [Test]
        public void T6_NoCanvasGroupRequiredOrAdded()
        {
            var go = CreateTmpGameObject();
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            Assert.IsNull(go.GetComponent<CanvasGroup>());
            fade.FadeInImmediate();
            Assert.IsNull(go.GetComponent<CanvasGroup>());
        }

        [Test]
        public void T7_WorkLoggerIntegration_DoesNotBreakUtility()
        {
            var go = CreateTmpGameObject(0f);
            var fade = go.AddComponent<TmpAlphaFadeIn>();

            fade.SetAlpha(0.75f);

            Assert.AreEqual(0.75f, go.GetComponent<TextMeshProUGUI>().color.a, 0.001f);
            Assert.IsTrue(Directory.Exists(_logFolder), "Assets/Logs/ must exist after SetAlpha");

            var files = Directory.GetFiles(_logFolder, "toollab_*.jsonl");
            Assert.IsTrue(files.Length > 0, "WorkLogger must write a log entry");

            var content = File.ReadAllText(files[0]);
            StringAssert.Contains("\"tool_id\":\"TMP_001\"", content);
        }

        private GameObject CreateGameObject(string name)
        {
            var go = new GameObject(name);
            _createdObjects.Add(go);
            return go;
        }

        private GameObject CreateTmpGameObject(float alpha = 0.5f)
        {
            var go = CreateGameObject("TMP_AlphaTest");
            var tmp = go.AddComponent<TextMeshProUGUI>();
            var color = tmp.color;
            color.a = alpha;
            tmp.color = color;
            return go;
        }
    }
}
