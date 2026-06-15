using System;
using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityToolLab.Logging;

namespace UnityToolLab.Tests.Editor
{
    public class WorkLoggerTests
    {
        private string _logFolder;

        [SetUp]
        public void SetUp()
        {
            _logFolder = Path.Combine(Application.dataPath, "Logs");
            // Wipe only toollab_*.jsonl files so each test starts clean.
            if (Directory.Exists(_logFolder))
            {
                foreach (var f in Directory.GetFiles(_logFolder, "toollab_*.jsonl"))
                    File.Delete(f);
            }
        }

        [TearDown]
        public void TearDown()
        {
            if (Directory.Exists(_logFolder))
            {
                foreach (var f in Directory.GetFiles(_logFolder, "toollab_*.jsonl"))
                    File.Delete(f);
            }
        }

        // T1 — Log() creates Assets/Logs/ and a non-empty toollab_*.jsonl file.
        [Test]
        public void T1_Log_Creates_LogsFolder_And_NonEmptyJsonlFile()
        {
            ToolLabWorkLogger.Log("UTL-TEST", "t1_action", "T1 summary");

            Assert.IsTrue(Directory.Exists(_logFolder),
                "Assets/Logs/ directory must exist after Log()");

            var files = Directory.GetFiles(_logFolder, "toollab_*.jsonl");
            Assert.IsTrue(files.Length > 0,
                "At least one toollab_*.jsonl file must be created");

            Assert.IsTrue(new FileInfo(files[0]).Length > 0,
                "Log file must not be empty");
        }

        // T2 — Written line starts with '{', ends with '}', structurally valid.
        [Test]
        public void T2_LogLine_StartsWithBrace_EndsWithBrace()
        {
            ToolLabWorkLogger.Log("UTL-TEST", "t2_action", "T2 summary");

            var files = Directory.GetFiles(_logFolder, "toollab_*.jsonl");
            Assert.IsTrue(files.Length > 0, "Log file must exist");

            var raw   = File.ReadAllText(files[0]).Trim();
            var line  = raw.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries)[0].Trim();

            Assert.IsTrue(line.StartsWith("{"),
                "Line must start with '{'");
            Assert.IsTrue(line.EndsWith("}"),
                "Line must end with '}'");
        }

        // T3 — Line contains "schema_version":"1.2".
        [Test]
        public void T3_LogLine_Contains_SchemaVersion_1_2()
        {
            ToolLabWorkLogger.Log("UTL-TEST", "t3_action", "T3 summary");

            var content = File.ReadAllText(
                Directory.GetFiles(_logFolder, "toollab_*.jsonl")[0]);

            StringAssert.Contains("\"schema_version\":\"1.2\"", content);
        }

        // T4 — Line contains "level":"INFO" (default).
        [Test]
        public void T4_LogLine_Contains_DefaultLevel_INFO()
        {
            ToolLabWorkLogger.Log("UTL-TEST", "t4_action", "T4 summary");

            var content = File.ReadAllText(
                Directory.GetFiles(_logFolder, "toollab_*.jsonl")[0]);

            StringAssert.Contains("\"level\":\"INFO\"", content);
        }

        // T5 — Line contains "actor":"tool".
        [Test]
        public void T5_LogLine_Contains_Actor_tool()
        {
            ToolLabWorkLogger.Log("UTL-TEST", "t5_action", "T5 summary");

            var content = File.ReadAllText(
                Directory.GetFiles(_logFolder, "toollab_*.jsonl")[0]);

            StringAssert.Contains("\"actor\":\"tool\"", content);
        }

        // T6 — RedactionGuard throws InvalidOperationException on "bearer token 123".
        [Test]
        public void T6_RedactionGuard_Throws_OnBearerToken()
        {
            Assert.Throws<InvalidOperationException>(() =>
                ToolLabWorkLogger.Log("UTL-TEST", "t6_action", "bearer token 123"));
        }

        // T7 — session_id is identical across two Log() calls in the same session.
        [Test]
        public void T7_SessionId_IsIdentical_AcrossTwoLogCalls()
        {
            ToolLabWorkLogger.Log("UTL-TEST", "t7_action_one", "T7 first call");
            ToolLabWorkLogger.Log("UTL-TEST", "t7_action_two", "T7 second call");

            var files = Directory.GetFiles(_logFolder, "toollab_*.jsonl");
            Assert.IsTrue(files.Length > 0, "Log file must exist");

            var rawLines = File.ReadAllText(files[0])
                .Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            Assert.IsTrue(rawLines.Length >= 2,
                "Two Log() calls must produce at least two lines");

            var sid1 = ExtractStringField(rawLines[0], "session_id");
            var sid2 = ExtractStringField(rawLines[1], "session_id");

            Assert.IsNotNull(sid1, "session_id must be present in line 1");
            Assert.IsNotNull(sid2, "session_id must be present in line 2");
            Assert.AreEqual(sid1, sid2,
                "session_id must be identical across both Log() calls");
        }

        // ── helpers ──────────────────────────────────────────────────────────

        // Minimal string-field extractor — works for GUID values (no escaping needed).
        private static string ExtractStringField(string json, string field)
        {
            var key   = "\"" + field + "\":\"";
            var start = json.IndexOf(key, StringComparison.Ordinal);
            if (start < 0) return null;
            start += key.Length;
            var end = json.IndexOf("\"", start, StringComparison.Ordinal);
            return end < 0 ? null : json.Substring(start, end - start);
        }
    }
}
