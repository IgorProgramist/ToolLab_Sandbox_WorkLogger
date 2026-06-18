# Action Plan — Next 5 Batches
<!-- ToolLab_Sandbox_WorkLogger | Updated: 2026-06-18 -->

## Batch overview

| Batch | Name | Focus | Status |
|-------|------|-------|--------|
| L01 | WorkLogger UX | Editor window + log viewer | PLANNED |
| L02 | TMP Testing | TMP utility tests coverage | PLANNED |
| L03 | Test Runner Tools | Automation of edit/play tests | PLANNED |
| L04 | Editor QA | Project/scene validation tools | PLANNED |
| L05 | Debug / Profiling | Diagnostics and profiling HUD | PLANNED |

See BATCHES/ for per-batch task breakdowns.

---

## L01 — WorkLogger UX

**Goal:** Surface the JSONL log to the developer via a Unity Editor window.

| Task | Description | Files |
|------|-------------|-------|
| L01-T1 | WorkLoggerWindow EditorWindow | Assets/ToolLab/Editor/WorkLoggerWindow.cs |
| L01-T2 | Log entry list view (ScrollView) | Same file |
| L01-T3 | Filter by level (INFO/WARN/ERROR/GATE) | Same file |
| L01-T4 | Export to CSV button | Same file |
| L01-T5 | Unit tests for WorkLoggerWindow | Assets/ToolLab/Tests/Editor/WorkLoggerWindowTests.cs |

**Verify:** Open window via menu, entries appear, filter works, CSV export writes file.

---

## L02 — TMP Testing

**Goal:** Expand TMP utility test coverage beyond TmpAlphaFadeIn.

| Task | Description | Files |
|------|-------------|-------|
| L02-T1 | TmpTypewriter implementation | Assets/ToolLab/Runtime/TMP/TmpTypewriter.cs |
| L02-T2 | TmpTypewriter EditMode tests | Assets/ToolLab/Tests/Editor/TmpTypewriterTests.cs |
| L02-T3 | TmpRichTagStripper implementation | Assets/ToolLab/Runtime/TMP/TmpRichTagStripper.cs |
| L02-T4 | TmpRichTagStripper tests | Assets/ToolLab/Tests/Editor/TmpRichTagStripperTests.cs |
| L02-T5 | TmpFontSizer tests | Assets/ToolLab/Tests/Editor/TmpFontSizerTests.cs |

**Verify:** All new tests pass. No regressions in TmpAlphaFadeIn tests.

---

## L03 — Test Runner Tools

**Goal:** Automate running EditMode and PlayMode tests from an Editor menu.

| Task | Description | Files |
|------|-------------|-------|
| L03-T1 | TestRunnerMenu — trigger UTR from menu | Assets/ToolLab/Editor/TestRunnerMenu.cs |
| L03-T2 | TestResultLogger — write results to JSONL | Assets/ToolLab/Runtime/Logging/TestResultLogger.cs |
| L03-T3 | TestResultLogger tests | Assets/ToolLab/Tests/Editor/TestResultLoggerTests.cs |
| L03-T4 | Gate verdict writer | Assets/ToolLab/Editor/GateVerdictWriter.cs |
| L03-T5 | TestRunner integration test | Assets/ToolLab/Tests/Editor/TestRunnerMenuTests.cs |

**Verify:** Menu triggers test run, results appear in JSONL with type=`test_result`.

---

## L04 — Editor QA

**Goal:** Validate project structure and catch common editor issues early.

| Task | Description | Files |
|------|-------------|-------|
| L04-T1 | MissingScriptFinder | Assets/ToolLab/Editor/MissingScriptFinder.cs |
| L04-T2 | FolderStructureValidator | Assets/ToolLab/Editor/FolderStructureValidator.cs |
| L04-T3 | AssetSizeAuditor | Assets/ToolLab/Editor/AssetSizeAuditor.cs |
| L04-T4 | MissingScriptFinder tests | Assets/ToolLab/Tests/Editor/MissingScriptFinderTests.cs |
| L04-T5 | FolderStructureValidator tests | Assets/ToolLab/Tests/Editor/FolderStructureValidatorTests.cs |

**Verify:** Each tool finds known issues in a test fixture scene/folder.

---

## L05 — Debug / Profiling

**Goal:** Add runtime diagnostics visible in Editor and logged to JSONL.

| Task | Description | Files |
|------|-------------|-------|
| L05-T1 | FrameRateMonitor | Assets/ToolLab/Runtime/Diagnostics/FrameRateMonitor.cs |
| L05-T2 | MemoryUsageReporter | Assets/ToolLab/Runtime/Diagnostics/MemoryUsageReporter.cs |
| L05-T3 | DiagnosticsHud (uGUI overlay) | Assets/ToolLab/Runtime/Diagnostics/DiagnosticsHud.cs |
| L05-T4 | FrameRateMonitor tests | Assets/ToolLab/Tests/Editor/FrameRateMonitorTests.cs |
| L05-T5 | MemoryUsageReporter tests | Assets/ToolLab/Tests/Editor/MemoryUsageReporterTests.cs |

**Verify:** HUD displays FPS + memory. JSONL receives `type=action, level=INFO` entries.

---

## Definition of Done (all batches)

1. C# file at declared path, compiles with zero errors.
2. EditMode test written — happy path + one failure case.
3. Tests pass (no failures, no skips).
4. Registry row updated: status → DONE, commit_sha filled.
5. WORK_LOG.md entry added.
6. If tool touches WorkLogger → JSONL sample verified.
