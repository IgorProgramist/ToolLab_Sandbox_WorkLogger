using System;
using System.IO;
using UnityEngine;

namespace UnityToolLab.Logging
{
    public static class ToolLabWorkLogger
    {
        public const string SchemaVersion = "1.2";

        // One GUID for the entire editor/domain session — never regenerated per call.
        private static readonly string _sessionId = Guid.NewGuid().ToString();

        private static readonly string[] _redactionMarkers =
        {
            "bearer", "sk-", "ghp_", "cloudtoken"
        };

        public static void Log(
            string toolId,
            string action,
            string summary,
            string type     = "action",
            string level    = "INFO",
            string lane     = "UTL",
            string riskLane = "SANDBOX_FIRST"
        )
        {
            // RedactionGuard — check before any I/O.
            foreach (var marker in _redactionMarkers)
            {
                if (summary != null &&
                    summary.IndexOf(marker, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    throw new InvalidOperationException("RedactionGuard: secret blocked");
                }
            }

            var id  = Guid.NewGuid().ToString();
            var ts  = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            var day = DateTime.UtcNow.ToString("yyyyMMdd");

            var logFolder = Path.Combine(Application.dataPath, "Logs");
            if (!Directory.Exists(logFolder))
                Directory.CreateDirectory(logFolder);

            var filePath = Path.Combine(logFolder, "toollab_" + day + ".jsonl");
            var line     = BuildLine(id, ts, type, level, toolId, lane, riskLane, action, summary);

            File.AppendAllText(filePath, line + "\n");
        }

        // ── helpers ──────────────────────────────────────────────────────────

        // Backslash must be replaced first to avoid double-escaping.
        private static string Escape(string s)
        {
            return s
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n",  "\\n")
                .Replace("\r",  "\\r")
                .Replace("\t",  "\\t");
        }

        private static string JS(string value)
        {
            return value == null ? "null" : "\"" + Escape(value) + "\"";
        }

        private static string BuildLine(
            string id,      string ts,      string type,    string level,
            string toolId,  string lane,    string riskLane,
            string action,  string summary)
        {
            return "{"
                + "\"schema_version\":"  + JS(SchemaVersion) + ","
                + "\"id\":"              + JS(id)            + ","
                + "\"ts\":"              + JS(ts)            + ","
                + "\"session_id\":"      + JS(_sessionId)    + ","
                + "\"type\":"            + JS(type)          + ","
                + "\"level\":"           + JS(level)         + ","
                + "\"actor\":"           + JS("tool")        + ","
                + "\"tool_id\":"         + JS(toolId)        + ","
                + "\"lane\":"            + JS(lane)          + ","
                + "\"risk_lane\":"       + JS(riskLane)      + ","
                + "\"action\":"          + JS(action)        + ","
                + "\"target\":null,"
                + "\"status\":null,"
                + "\"verdict\":null,"
                + "\"summary\":"         + JS(summary)       + ","
                + "\"payload\":null,"
                + "\"duration_ms\":null,"
                + "\"tags\":null,"
                + "\"artifact\":null"
                + "}";
        }
    }
}
