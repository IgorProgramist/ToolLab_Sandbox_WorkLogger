# Batch L05 — Debug / Profiling
<!-- ToolLab_Sandbox_WorkLogger | AI_WORKFLOW/BATCHES/ | Updated: 2026-06-18 -->

## Overview

**Goal:** Add runtime diagnostics visible as an on-screen HUD and logged to JSONL.
**Status:** PLANNED
**Depends on:** UTL-001 WorkLogger (DONE ✓); uGUI Canvas in scene

---

## Tasks

| ID | Task | File | Status | Test file |
|----|------|------|--------|-----------|
| L05-T1 | FrameRateMonitor | Assets/ToolLab/Runtime/Diagnostics/FrameRateMonitor.cs | PLANNED | L05-T4 |
| L05-T2 | MemoryUsageReporter | Assets/ToolLab/Runtime/Diagnostics/MemoryUsageReporter.cs | PLANNED | L05-T5 |
| L05-T3 | DiagnosticsHud (uGUI overlay) | Assets/ToolLab/Runtime/Diagnostics/DiagnosticsHud.cs | PLANNED | — |
| L05-T4 | FrameRateMonitor tests | Assets/ToolLab/Tests/Editor/FrameRateMonitorTests.cs | PLANNED | — |
| L05-T5 | MemoryUsageReporter tests | Assets/ToolLab/Tests/Editor/MemoryUsageReporterTests.cs | PLANNED | — |

---

## Implementation notes

- Namespace: `UnityToolLab.Diagnostics`
- FrameRateMonitor: samples `Time.deltaTime` each frame, logs average every N seconds
- MemoryUsageReporter: calls `GC.GetTotalMemory(false)` + `UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong()`
- DiagnosticsHud: Canvas overlay (Screen Space - Overlay), TextMeshProUGUI text fields
- Log entries: `type="action"`, `level="INFO"`, `tool_id="diagnostics"`
- Do NOT add allocation pressure inside Update() — cache values, log on interval

---

## Verify criteria

1. HUD appears in Play mode showing FPS and memory.
2. JSONL receives entries at configured interval.
3. No GC allocs per frame from the monitor scripts.
4. L05-T4/T5 tests pass.

---

## Definition of done

- [ ] FrameRateMonitor.cs compiles, zero errors
- [ ] MemoryUsageReporter.cs compiles, zero errors
- [ ] DiagnosticsHud.cs compiles, zero errors
- [ ] FrameRateMonitorTests.cs — all pass
- [ ] MemoryUsageReporterTests.cs — all pass
- [ ] JSONL sample with diagnostics entries verified
- [ ] Registry rows UTL-071, UTL-072, UTL-079 updated
- [ ] WORK_LOG.md entry added
