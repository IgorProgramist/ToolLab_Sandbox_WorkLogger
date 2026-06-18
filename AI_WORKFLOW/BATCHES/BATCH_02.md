# Batch L02 — TMP Testing
<!-- ToolLab_Sandbox_WorkLogger | AI_WORKFLOW/BATCHES/ | Updated: 2026-06-18 -->

## Overview

**Goal:** Expand TMP utility test coverage. Implement TmpTypewriter and TmpRichTagStripper.
**Status:** PLANNED
**Depends on:** UTL-011 TmpAlphaFadeIn (CLOSED_BY_OPERATOR ✓ — use as reference pattern only)

---

## Tasks

| ID | Task | File | Status | Test file |
|----|------|------|--------|-----------|
| L02-T1 | TmpTypewriter implementation | Assets/ToolLab/Runtime/TMP/TmpTypewriter.cs | PLANNED | L02-T2 |
| L02-T2 | TmpTypewriter EditMode tests | Assets/ToolLab/Tests/Editor/TmpTypewriterTests.cs | PLANNED | — |
| L02-T3 | TmpRichTagStripper implementation | Assets/ToolLab/Runtime/TMP/TmpRichTagStripper.cs | PLANNED | L02-T4 |
| L02-T4 | TmpRichTagStripper tests | Assets/ToolLab/Tests/Editor/TmpRichTagStripperTests.cs | PLANNED | — |
| L02-T5 | TmpFontSizer tests | Assets/ToolLab/Tests/Editor/TmpFontSizerTests.cs | PLANNED | — |

---

## Implementation notes

- Namespace: `UnityToolLab.TMP`
- TmpTypewriter: coroutine-based character reveal, speed configurable via `[SerializeField]`
- TmpRichTagStripper: static utility, strips `<tag>` patterns for safe logging
- Do NOT modify TmpAlphaFadeIn.cs or TmpAlphaFadeInTests.cs (TMP_001 — CLOSED)
- All text components: `TextMeshProUGUI` only

---

## Verify criteria

1. TmpTypewriter reveals text character by character in Play mode.
2. TmpRichTagStripper.Strip("Hello <b>world</b>") returns "Hello world".
3. No regressions in TmpAlphaFadeIn tests.
4. All L02-T2/T4/T5 tests pass.

---

## Definition of done

- [ ] TmpTypewriter.cs compiles, zero errors
- [ ] TmpRichTagStripper.cs compiles, zero errors
- [ ] TmpTypewriterTests.cs — all pass
- [ ] TmpRichTagStripperTests.cs — all pass
- [ ] TmpAlphaFadeInTests.cs — still all pass (regression check)
- [ ] Registry rows UTL-013, UTL-015 updated to DONE
- [ ] WORK_LOG.md entry added
