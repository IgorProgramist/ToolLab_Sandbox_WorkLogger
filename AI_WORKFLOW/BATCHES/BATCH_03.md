# Batch L03 — Test Runner Tools
<!-- ToolLab_Sandbox_WorkLogger | AI_WORKFLOW/BATCHES/ | Updated: 2026-06-18 -->

## Overview

**Goal:** Automate running EditMode and PlayMode tests from an Editor menu, with results written to JSONL.
**Status:** PLANNED
**Depends on:** L01 (WorkLogger window, for optional result display); UTL-001 WorkLogger (DONE ✓)

---

## Tasks

| ID | Task | File | Status | Test file |
|----|------|------|--------|-----------|
| L03-T1 | TestRunnerMenu — trigger UTC from Editor menu | Assets/ToolLab/Editor/TestRunnerMenu.cs | PLANNED | L03-T5 |
| L03-T2 | TestResultLogger — write results to JSONL | Assets/ToolLab/Runtime/Logging/TestResultLogger.cs | PLANNED | L03-T3 |
| L03-T3 | TestResultLogger tests | Assets/ToolLab/Tests/Editor/TestResultLoggerTests.cs | PLANNED | — |
| L03-T4 | GateVerdictWriter — write gate PASS/FAIL entry | Assets/ToolLab/Editor/GateVerdictWriter.cs | PLANNED | — |
| L03-T5 | TestRunnerMenu integration test | Assets/ToolLab/Tests/Editor/TestRunnerMenuTests.cs | PLANNED | — |

---

## Implementation notes

- Namespace: `UnityToolLab.Editor` (menu) / `UnityToolLab.Logging` (result logger)
- Use `UnityEditor.TestTools.TestRunner.Api.TestRunnerApi` to trigger tests
- JSONL entry type for results: `type = "test_result"`, `level = "GATE"`
- Verdict field: `"PASS"` | `"FAIL"` | `"REWORK_REQUIRED"`
- Do NOT modify ToolLabWorkLogger.cs — TestResultLogger wraps it

---

## Verify criteria

1. Menu item triggers an EditMode test run.
2. JSONL file receives new entries with `type="test_result"`.
3. Gate verdict entry is written at end of run.
4. L03-T3/T5 tests pass.

---

## Definition of done

- [ ] TestRunnerMenu.cs compiles, zero errors
- [ ] TestResultLogger.cs compiles, zero errors
- [ ] GateVerdictWriter.cs compiles, zero errors
- [ ] TestResultLoggerTests.cs — all pass
- [ ] TestRunnerMenuTests.cs — all pass
- [ ] JSONL sample with test_result entry verified
- [ ] Registry rows UTL-082 (TestRunner) updated
- [ ] WORK_LOG.md entry added
