# Handoff
<!-- ToolLab_Sandbox_WorkLogger | Updated: 2026-06-18 | Pass this to the next AI session -->

## State at handoff

**Phase:** Registry route active. AI_WORKFLOW bootstrapped.
**Last action:** AI_WORKFLOW folder created (20 files). CLAUDE.md updated with scope override.
**Next action:** Start L01 — WorkLogger UX (WorkLoggerWindow EditorWindow).

---

## Critical context for next session

1. **TMP_001 is CLOSED_BY_OPERATOR.** Do NOT reopen. Do NOT modify TmpAlphaFadeIn.cs.
2. **Runtime and Tests are DO_NOT_TOUCH** for registry/workflow tasks.
3. **Registry route is active.** Files_ALLOWED includes Registry/**, Docs/**, AI_WORKFLOW/**.
4. **Old CLAUDE.md narrow scope is superseded** — see DECISIONS.md D-003.
5. **Nothing is committed yet.** Registry, Docs, AI_WORKFLOW are all untracked. Igor must approve staging.

---

## Files the next agent should read first

1. `AI_WORKFLOW/00_START_HERE.md`
2. `AI_WORKFLOW/CURRENT_STATE.md`
3. `AI_WORKFLOW/ACTION_PLAN.md` (specifically L01 section)
4. `AI_WORKFLOW/BATCHES/BATCH_01.md`
5. `AI_WORKFLOW/DECISIONS.md` (D-003, D-004)

---

## Next batch: L01 — WorkLogger UX

**First task:** Create `Assets/ToolLab/Editor/WorkLoggerWindow.cs`
- EditorWindow that reads `Assets/Logs/toollab_*.jsonl`
- Displays log entries in a ScrollView
- Filter by level
- Export to CSV button
- Namespace: `UnityToolLab.Editor`

**Verify:** Window opens via Unity menu, displays JSONL entries.

---

## Commit status

Not committed. See COMMIT_PROTOCOL.md for what to stage when Igor approves.
