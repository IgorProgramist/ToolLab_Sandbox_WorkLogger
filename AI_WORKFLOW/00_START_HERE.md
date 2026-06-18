# AI_WORKFLOW — Start Here
<!-- ToolLab_Sandbox_WorkLogger | V4.3 | Updated: 2026-06-18 -->

## What is this folder?

`AI_WORKFLOW/` is the single source of truth for AI agent coordination on this project.
Read this file first. Do not start coding without reading the relevant batch file.

---

## Quick orientation

| File | Purpose |
|------|---------|
| PROJECT_PROFILE.md | Stack, identity, conventions |
| CURRENT_STATE.md | What is done, what is in progress RIGHT NOW |
| ACTION_PLAN.md | Next 5 batches (L01–L05) |
| WORK_LOG.md | Running log of all AI agent actions |
| DECISIONS.md | Approved decisions — do not re-litigate |
| BLOCKERS.md | Known blockers and dependencies |
| REGISTRY_INDEX.md | Pointer to ToolLab utility registry |
| PROJECT_FILE_INDEX.md | Canonical file locations |
| COMMIT_PROTOCOL.md | What to stage, what never to stage |
| PROMPT_HISTORY.md | Prompts that produced results |
| HANDOFF.md | State to pass between AI sessions |
| CHANGELOG.md | What changed and when |
| REPORTS/ | Agent-specific return reports |
| BATCHES/ | Per-batch task breakdowns |

---

## Current route

**Registry route is ACTIVE.**
`Assets/ToolLab/Registry/**` and `Assets/ToolLab/Docs/**` are approved scope.
`AI_WORKFLOW/**` is approved workflow scope.

Old CLAUDE.md narrow scope (Runtime/Logging + Tests only) is **superseded** for registry route.
See DECISIONS.md entry D-003.

---

## Hard rules (always active)

1. `Assets/ToolLab/Runtime/**` — DO_NOT_TOUCH (this prompt)
2. `Assets/ToolLab/Tests/**` — DO_NOT_TOUCH (this prompt)
3. TMP_001 — CLOSED_BY_OPERATOR. Do NOT reopen.
4. No git stage / commit / push without explicit Igor approval.
5. No final-readiness or BUG_FIXED_ACTIVE claims.
6. Read COMMIT_PROTOCOL.md before any staging attempt.
