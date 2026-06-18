# Batch L01 — WorkLogger UX
<!-- ToolLab_Sandbox_WorkLogger | AI_WORKFLOW/BATCHES/ | Updated: 2026-06-18 -->

## Overview

**Goal:** Surface the JSONL log to the developer via a Unity Editor window.
**Status:** PLANNED
**Depends on:** UTL-001 ToolLabWorkLogger (DONE ✓)

---

## Tasks

| ID | Task | File | Status | Test file |
|----|------|------|--------|-----------|
| L01-T1 | WorkLoggerWindow EditorWindow skeleton | Assets/ToolLab/Editor/WorkLoggerWindow.cs | PLANNED | — |
| L01-T2 | Log entry list view (uGUI ScrollView) | Same | PLANNED | — |
| L01-T3 | Filter toolbar (INFO / WARN / ERROR / GATE) | Same | PLANNED | — |
| L01-T4 | Export to CSV button | Same | PLANNED | — |
| L01-T5 | EditMode tests for WorkLoggerWindow | Assets/ToolLab/Tests/Editor/WorkLoggerWindowTests.cs | PLANNED | — |

---

## Implementation notes

- Namespace: `UnityToolLab.Editor`
- Menu path: `ToolLab > WorkLogger Window`
- Reads from: `Assets/Logs/toollab_*.jsonl` (glob all daily files)
- Parse each line as `JsonUtility.FromJson<WorkLogEntry>`
- Do NOT modify `ToolLabWorkLogger.cs` — read-only consumer

---

## Verify criteria

1. Window opens without errors via menu.
2. Entries from an existing JSONL file appear in the list.
3. Filter by level hides/shows correct entries.
4. Export button writes a `.csv` file to `Assets/Logs/`.
5. L01-T5 tests pass.

---

## Definition of done

- [ ] WorkLoggerWindow.cs compiles, zero errors
- [ ] Tests in WorkLoggerWindowTests.cs — all pass
- [ ] Registry row UTL-021 (EditorWindowBase) marked IN_PROGRESS or DONE
- [ ] WORK_LOG.md entry added
- [ ] Registry CSV updated
