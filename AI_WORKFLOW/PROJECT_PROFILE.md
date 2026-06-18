# Project Profile
<!-- ToolLab_Sandbox_WorkLogger | V4.3 | Updated: 2026-06-18 -->

## Identity

| Key | Value |
|-----|-------|
| Project | ToolLab_Sandbox_WorkLogger |
| Short name | ToolLab |
| Unity version | 6000.3.9f1 |
| Render pipeline | HDRP |
| Environment | Disposable sandbox (NOT production) |
| Primary role | WorkLogger utilities, logging, testing, QA |
| Namespace | `UnityToolLab.Logging` |
| Registry version | V4.3 |
| Total planned utilities | 100 (UTL-001 to UTL-100) |

---

## Stack

- **Language:** C# (.NET Standard 2.1 / Unity 6)
- **UI:** uGUI / Canvas / RectTransform — NOT UI Toolkit
- **Text:** TextMeshProUGUI for ALL UI text
- **Logging:** LOG_SCHEMA v1.2 (19 fields), JSONL output
- **Output path:** `Assets/Logs/toollab_YYYYMMDD.jsonl`
- **Write mode:** `File.AppendAllText` only — never overwrite

---

## Canonical files

| Role | Path |
|------|------|
| Logger (runtime) | `Assets/ToolLab/Runtime/Logging/ToolLabWorkLogger.cs` |
| Logger tests | `Assets/ToolLab/Tests/Editor/WorkLoggerTests.cs` |
| TMP utility | `Assets/ToolLab/Runtime/TMP/TmpAlphaFadeIn.cs` |
| TMP tests | `Assets/ToolLab/Tests/Editor/TmpAlphaFadeInTests.cs` |
| Registry (MD) | `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md` |
| Registry (CSV) | `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv` |
| Action plan | `Assets/ToolLab/Docs/TOOLLAB_ACTION_PLAN.md` |

---

## LOG_SCHEMA v1.2 — field summary

### Required (12)
| Field | Value / constraint |
|-------|--------------------|
| schema_version | `"1.2"` hardcoded |
| id | Unique Guid or sequential |
| ts | ISO-8601 UTC |
| session_id | ONE static GUID per domain reload |
| type | `action`\|`session`\|`file_op`\|`test_result`\|`gate`\|`decision`\|`error`\|`security`\|`source` |
| level | `INFO`\|`WARN`\|`ERROR`\|`GATE`\|`SECURITY` |
| actor | `"tool"` hardcoded |
| tool_id | Identifies which tool wrote the entry |
| lane | `"UTL"` |
| risk_lane | `"SANDBOX_FIRST"` |
| action | Verb phrase — what happened |
| summary | Human-readable description |

### Optional (7)
`target`, `status`, `verdict`, `payload`, `duration_ms`, `tags`, `artifact`

### RedactionGuard
THROW `InvalidOperationException` if `summary` contains (case-insensitive):
`"bearer"`, `"sk-"`, `"ghp_"`, `"cloudtoken"`
Guard = throw. NOT a flag, NOT a boolean field.

---

## Conventions

- VALIDATE_FIRST for all Unity API claims before implementing
- No features beyond what was asked
- No abstractions for single-use code
- No "while I'm here" improvements
- Every changed line must trace to the request
- Tests are the definition of done
