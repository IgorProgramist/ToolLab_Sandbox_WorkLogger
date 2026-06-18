# Changelog
<!-- ToolLab_Sandbox_WorkLogger | Append only — newest at top -->

---

## [V4.3] — 2026-06-18

### Added
- `AI_WORKFLOW/` folder with 20 workflow coordination files
- `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md` — 100-utility registry
- `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv` — machine-readable registry
- `Assets/ToolLab/Docs/TOOLLAB_ACTION_PLAN.md` — B01–B10 execution plan
- `AGENTS.md` — agent routing rules

### Changed
- `CLAUDE.md` — added Current Route Override section (D-003); old narrow FILES_ALLOWED superseded for registry route

### Fixed
- Stale-scope mismatch that caused OpenCode FAIL (B-001 resolved)

### Not changed
- `Assets/ToolLab/Runtime/**` — untouched
- `Assets/ToolLab/Tests/**` — untouched
- TMP_001 — remains CLOSED_BY_OPERATOR

---

## [V4.2] — pre-2026-06-18 (reconstructed)

### Done
- UTL-001 ToolLabWorkLogger.cs — LOG_SCHEMA v1.2 (commit a540a21)
- UTL-002 WorkLoggerTests.cs — T1–T7 gate passing (commit a540a21)
- UTL-011 TmpAlphaFadeIn.cs — TMP_001 (commit e9272d8)
- UTL-012 TmpAlphaFadeInTests.cs — TMP_001 tests (commit a540a21)
- TextMesh Pro essentials added (commit e9272d8)

---

<!-- Format: ## [VERSION] — YYYY-MM-DD -->
