# Decisions
<!-- ToolLab_Sandbox_WorkLogger | Approved decisions — do not re-litigate -->

---

## D-001 — WorkLogger gate complete
**Date:** 2026-06-18
**Decision:** T1–T7 gate tests passing. ToolLabWorkLogger.cs is stable at LOG_SCHEMA v1.2.
**Status:** LOCKED
**Do not:** Reopen gate tests or modify schema without Igor's explicit approval.

---

## D-002 — TMP_001 closed
**Date:** 2026-06-18
**Decision:** TMP_001 (TmpAlphaFadeIn + tests) is CLOSED_BY_OPERATOR. Alpha handling is correct.
**Status:** LOCKED
**Do not:** Reopen TMP_001. Do not modify TmpAlphaFadeIn.cs or TmpAlphaFadeInTests.cs.

---

## D-003 — Registry route override (CRITICAL)
**Date:** 2026-06-18
**Decision:** Old CLAUDE.md narrow scope (Runtime/Logging + Tests only) is superseded for the registry route.
**Approved scope for registry/workflow tasks:**
- `Assets/ToolLab/Registry/**` — approved
- `Assets/ToolLab/Docs/**` — approved
- `AI_WORKFLOW/**` — approved
- `CLAUDE.md` — approved for scope updates
- `AGENTS.md` — approved for creation
- `.cursor/rules/**` — approved
**Rationale:** OpenCode returned FAIL due to stale-scope mismatch. Igor approved registry route explicitly.
**Status:** ACTIVE
**Do not:** Interpret old FILES_ALLOWED as blocking registry/docs/workflow files.

---

## D-004 — Runtime and Tests remain DO_NOT_TOUCH (this prompt)
**Date:** 2026-06-18
**Decision:** Despite scope override in D-003, Runtime and Tests files remain DO_NOT_TOUCH for the current registry/workflow prompt series.
**Status:** ACTIVE
**Applies to:** `Assets/ToolLab/Runtime/**`, `Assets/ToolLab/Tests/**`
**Lifted when:** Igor assigns a specific code task targeting those files.

---

## D-005 — Commit protocol staged-only list
**Date:** 2026-06-18
**Decision:** Only the following paths may be staged for commit in registry/workflow tasks:
- `Assets/ToolLab/Registry/**`
- `Assets/ToolLab/Docs/**`
- `AI_WORKFLOW/**`
- `CLAUDE.md` (if modified)
- `AGENTS.md` (if modified)
**Do not stage:** Runtime, Tests, ProjectSettings, Packages, UserSettings, .mcp.json, Library, Temp, Logs.

---

<!-- Add new decisions as D-NNN. Never delete or modify existing locked entries. -->
