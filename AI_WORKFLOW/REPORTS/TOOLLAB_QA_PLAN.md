# TOOLLAB_QA_PLAN.md
<!-- ToolLab_Sandbox_WorkLogger | Created: 2026-06-18 -->
<!-- Route: Registry Route (D-003 active) -->

## Purpose

Defines the first safe QA candidate and a structured checklist for validating
the WorkLogger registry (UTL-001) against LOG_SCHEMA v1.2.

---

## Selected Candidate: Option A — WorkLogger Registry QA Checklist

**Rationale:**
- UTL-001 (ToolLabWorkLogger.cs) is the only DONE runtime utility.
- The T1–T7 gate already passed (commit a540a21), but no registry-level QA
  checklist exists yet to formally sign off the utility entry.
- Pure docs work — zero runtime or test file changes required.
- Validates that the registry row for UTL-001 is accurate and complete before
  the next batch (B01 remainder) begins.
- Provides a reusable QA template for all future UTL-NNN entries.

---

## Scope

| In scope | Out of scope |
|----------|-------------|
| TOOLLAB_WORK_LOG.md — UTL-001 row | Runtime code (ToolLabWorkLogger.cs) |
| TOOLLAB_WORK_LOG.csv — UTL-001 row | Test code (WorkLoggerTests.cs) |
| This QA plan doc | TMP_001 (CLOSED_BY_OPERATOR) |
| AI_WORKFLOW updates | Any UTL-002+ implementation |

---

## QA Checklist — UTL-001 (ToolLabWorkLogger)

### 1. Registry Row Completeness

| Field | Expected | Check |
|-------|----------|-------|
| ID | UTL-001 | [ ] |
| Name | ToolLabWorkLogger | [ ] |
| Batch | B01 | [ ] |
| Category | Core Logging | [ ] |
| Status | DONE | [ ] |
| Path | Assets/ToolLab/Runtime/Logging/ToolLabWorkLogger.cs | [ ] |
| Commit SHA | a540a21 | [ ] |
| Proof Ref | WorkLoggerTests.cs T1–T7 | [ ] |
| Notes | LOG_SCHEMA v1.2, 19 fields | [ ] |

### 2. LOG_SCHEMA v1.2 Field Coverage

Verify that ToolLabWorkLogger.cs serialises all 12 required fields:

| Field | Present in schema | Check |
|-------|-------------------|-------|
| schema_version = "1.2" | Required | [ ] |
| id | Required | [ ] |
| ts | Required | [ ] |
| session_id | Required | [ ] |
| type | Required | [ ] |
| level | Required | [ ] |
| actor = "tool" | Required | [ ] |
| tool_id | Required | [ ] |
| lane = "UTL" | Required | [ ] |
| risk_lane = "SANDBOX_FIRST" | Required | [ ] |
| action | Required | [ ] |
| summary | Required | [ ] |

And 7 optional fields are present in the struct (not necessarily serialised on every call):

| Field | Optional | Check |
|-------|----------|-------|
| target | Optional | [ ] |
| status | Optional | [ ] |
| verdict | Optional | [ ] |
| payload | Optional | [ ] |
| duration_ms | Optional | [ ] |
| tags | Optional | [ ] |
| artifact | Optional | [ ] |

### 3. RedactionGuard

| Rule | Expected behaviour | Check |
|------|--------------------|-------|
| "bearer" in summary | Throws InvalidOperationException | [ ] |
| "sk-" in summary | Throws InvalidOperationException | [ ] |
| "ghp_" in summary | Throws InvalidOperationException | [ ] |
| "cloudtoken" in summary | Throws InvalidOperationException | [ ] |
| redacted field NOT added | Guard = throw, not flag | [ ] |

### 4. Output Format

| Rule | Expected | Check |
|------|----------|-------|
| File path pattern | Assets/Logs/toollab_YYYYMMDD.jsonl | [ ] |
| Write mode | AppendAllText only | [ ] |
| Never overwrite | Confirmed | [ ] |
| One JSON object per line | Newline-delimited JSONL | [ ] |

### 5. Test Gate Coverage

| Test | Gate | Check |
|------|------|-------|
| T1 | Required fields present | [ ] |
| T2 | JSONL output format | [ ] |
| T3 | RedactionGuard fires | [ ] |
| T4 | session_id stable per domain reload | [ ] |
| T5 | Append-only (no overwrite) | [ ] |
| T6 | Hardcoded constants (actor, lane, risk_lane) | [ ] |
| T7 | Optional fields serialised when set | [ ] |

---

## Registry CSV Consistency Check

Verify TOOLLAB_WORK_LOG.csv UTL-001 row matches TOOLLAB_WORK_LOG.md UTL-001 row:

- [ ] All 9 columns present
- [ ] Status = DONE in both files
- [ ] Commit SHA = a540a21 in both files
- [ ] Path identical in both files

---

## How to Use This Plan

1. An AI agent (Claude Code, Cursor, OpenCode) reads this file.
2. For each `[ ]` item, the agent inspects the source file (read-only).
3. Fills `[x]` if confirmed, `[!]` if mismatch found.
4. Reports mismatches in REPORTS/TOOLLAB_QA_PLAN.md (this file) or a new REPORTS/UTL001_QA_RESULT.md.
5. Does NOT modify Runtime or Test files — read-only inspection only.

---

## Template for Future UTL-NNN QA

Copy the checklist above for each new utility. Replace:
- `UTL-001` → `UTL-NNN`
- `ToolLabWorkLogger` → utility name
- Test gate rows (T1–T7) → relevant tests for the utility
- Commit SHA → new SHA after merge

---

## Status

**PLAN: DRAFT** — Not yet executed. Awaiting agent assignment.

---

<!-- Next: assign to Claude Code / Cursor for read-only inspection pass -->
