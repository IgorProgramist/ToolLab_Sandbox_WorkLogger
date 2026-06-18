# ToolLab Action Plan — V4.3
<!-- Generated: 2026-06-18 | Registry: V4.3 | 100 utilities across 10 batches -->

## Current Phase
**WorkLogger Code Gate** — T1–T7 tests passing, JSONL output verified.
Runtime and test files: **DO_NOT_TOUCH**.

---

## Gate Decisions

| Item | Decision | Rationale |
|------|----------|-----------|
| TMP_001 (UTL-011/012) | CLOSED_BY_OPERATOR | Alpha handling complete. Non-blocking. |
| UTL-001 ToolLabWorkLogger | DONE | Schema v1.2, 19 fields, gate tests green. |
| UTL-002 WorkLoggerTests | DONE | T1–T7 passing. |

---

## Batch Execution Plan

### B01 — Core Logging (UTL-001 to UTL-010)
**Status:** UTL-001/002 DONE. UTL-003–010 PLANNED.

| Priority | Tool | Why |
|----------|------|-----|
| 1 | UTL-005 SessionIdProvider | Prerequisite for stable session_id across domain reloads |
| 2 | UTL-003 LogRotationPolicy | Prevents unbounded JSONL growth |
| 3 | UTL-007 LogSchemaValidator | Catches schema drift at runtime |
| 4 | UTL-008 LogLevelFilter | Enables selective log queries |
| 5 | UTL-004 LogQueryReader | Enables JSONL introspection |
| 6 | UTL-009 LogExporterJson | Human-readable output |
| 7 | UTL-010 LogExporterCsv | Spreadsheet export |
| 8 | UTL-006 RedactionGuardTests | Extra coverage for throw path |

**Verify criteria:** Each tool has edit-mode tests passing before next tool starts.

---

### B02 — TMP / Text (UTL-011 to UTL-020)
**Status:** UTL-011/012 CLOSED_BY_OPERATOR. UTL-013–020 PLANNED.

| Priority | Tool | Why |
|----------|------|-----|
| 1 | UTL-013 TmpTypewriter | Core text reveal — highest reuse |
| 2 | UTL-015 TmpRichTagStripper | Needed before logging TMP content |
| 3 | UTL-017 TmpFontSizer | Common UI pain point |
| 4 | UTL-016 TmpWordWrapper | Fallback for overflow edge cases |
| 5 | UTL-018 TmpLinkHandler | Interactive text use cases |
| 6 | UTL-014 TmpColorCycler | Visual feedback utility |
| 7 | UTL-019 TmpSpriteAnimator | Polish |
| 8 | UTL-020 TmpLocalizationBridge | Depends on final i18n strategy |

---

### B03 — Editor Utilities (UTL-021 to UTL-030)
**Status:** All PLANNED.

Suggested order: UTL-021 (EditorWindowBase) first — all other editor windows will inherit it.
Then UTL-026 (MissingScriptFinder) and UTL-028 (FolderStructureValidator) as high-value early tools.

---

### B04 — Scene Tools (UTL-031 to UTL-040)
**Status:** All PLANNED.

Start with UTL-031 (SceneSwitcher) — daily friction reducer.
UTL-036 (LightingPresetManager) is HDRP-specific, defer until B03 base is stable.

---

### B05 — Asset Pipeline (UTL-041 to UTL-050)
**Status:** All PLANNED.

UTL-041/042 (Texture/Audio import presets) should be implemented as AssetPostprocessors.
UTL-045 (DuplicateAssetFinder) has highest ROI for project hygiene.

---

## Risk Register

| Risk | Severity | Mitigation |
|------|----------|------------|
| B01 tools touch Runtime files | HIGH | Each tool gets its own file; DO_NOT_TOUCH applies only to existing files |
| TMP_001 reopened accidentally | HIGH | Status locked to CLOSED_BY_OPERATOR in registry |
| Schema drift in UTL-001 | MEDIUM | UTL-007 (LogSchemaValidator) is B01 priority 3 |
| B10 Integrations require external credentials | LOW | Defer until integration targets confirmed |

---

## Definition of Done (per utility)

1. C# file created at declared path.
2. EditMode test written — covers primary happy path + one failure case.
3. Tests pass (no compile errors, no test failures).
4. Row updated in TOOLLAB_WORK_LOG.md + TOOLLAB_WORK_LOG.csv (status → DONE, commit_sha filled).
5. JSONL sample logged if tool touches ToolLabWorkLogger.

---

## What Is NOT In Scope

- Editing `Assets/ToolLab/Runtime/Logging/ToolLabWorkLogger.cs` (DO_NOT_TOUCH).
- Editing `Assets/ToolLab/Tests/Editor/WorkLoggerTests.cs` (DO_NOT_TOUCH).
- Editing any APP / MCP / Sandbox / ProjectSettings files.
- Git staging, commits, or pushes.
- Claiming BUG_FIXED_ACTIVE or final readiness.

---

*Action plan generated 2026-06-18. Review before each batch start.*
