# Blockers
<!-- ToolLab_Sandbox_WorkLogger | Updated: 2026-06-18 -->

## Active blockers

None.

---

## Resolved blockers

### B-001 — Stale CLAUDE.md scope (RESOLVED 2026-06-18)
**Symptom:** OpenCode returned FAIL because CLAUDE.md FILES_ALLOWED only listed Runtime/Logging and Tests files.
**Root cause:** Old scope predates registry route approval.
**Resolution:** CLAUDE.md updated with Current Route Override section (D-003). Registry/Docs/AI_WORKFLOW scope now explicit.

---

## Dependency map

| Batch | Depends on |
|-------|-----------|
| L01 | UTL-001 (WorkLogger stable) ✓ |
| L02 | UTL-011 closed ✓, TmpAlphaFadeIn as reference |
| L03 | L01 (WorkLogger window exists) |
| L04 | UTL-021 (EditorWindowBase) |
| L05 | UTL-001 (log sink available) ✓ |

---

## Watch list

| Item | Risk | Action if triggered |
|------|------|---------------------|
| Unity 6000.3.9f1 API changes | LOW | VALIDATE_FIRST before any Unity API claim |
| JSONL file growth | LOW | UTL-003 LogRotationPolicy in B01 |
| Schema drift | MEDIUM | UTL-007 LogSchemaValidator planned |
| Cursor/OpenCode scope mismatch | WAS HIGH → RESOLVED | CLAUDE.md now has explicit override |
