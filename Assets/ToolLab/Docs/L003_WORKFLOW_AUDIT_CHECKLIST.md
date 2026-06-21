# L003 ToolLab Workflow Audit Checklist

DRAFT_ONLY: YES
NOT_FOR_RUNTIME_USE: YES
PENDING_GATE_APPROVAL: YES

PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
ARTIFACT: L003_WORKFLOW_AUDIT_CHECKLIST.md
MODE: DOCS_ONLY_DESIGN
STATUS: DOCS_ONLY_READY

---

## 1. Purpose

L003 defines a concise audit checklist for reviewing the ToolLab workflow system state.

Use this checklist to confirm that AI_WORKFLOW files, registry entries, prompt history, docs artifacts, and WORKER_BATCH_LOG entries are internally consistent and safe before proceeding to any implementation gate.

This document is a planning and validation artifact only. No runtime, tests, staging, commit, or push is approved by this document.

---

## 2. Scope

* AI_WORKFLOW file consistency;
* registry and worklog consistency;
* prompt history consistency;
* docs-only vs runtime/test boundary checks;
* RedactionGuard reminders;
* gate status taxonomy;
* WORKER_BATCH_LOG.md review checklist.

---

## 3. Out of Scope

* no Runtime implementation;
* no Tests implementation;
* no `.cs` files;
* no TMP_001 reopening;
* no ProjectSettings or UserSettings edits;
* no APP / MCP / Sandbox files;
* no package installation;
* no external APIs;
* no git staging, commit, or push.

---

## 4. AI_WORKFLOW File Consistency

### 4.1 Required Files Present

| File | Required | Check |
|------|----------|-------|
| `AI_WORKFLOW/00_START_HERE.md` | YES | [ ] |
| `AI_WORKFLOW/PROJECT_PROFILE.md` | YES | [ ] |
| `AI_WORKFLOW/CURRENT_STATE.md` | YES | [ ] |
| `AI_WORKFLOW/ACTION_PLAN.md` | YES | [ ] |
| `AI_WORKFLOW/WORK_LOG.md` | YES | [ ] |
| `AI_WORKFLOW/DECISIONS.md` | YES | [ ] |
| `AI_WORKFLOW/BLOCKERS.md` | YES | [ ] |
| `AI_WORKFLOW/REGISTRY_INDEX.md` | YES | [ ] |
| `AI_WORKFLOW/PROJECT_FILE_INDEX.md` | YES | [ ] |
| `AI_WORKFLOW/COMMIT_PROTOCOL.md` | YES | [ ] |
| `AI_WORKFLOW/PROMPT_HISTORY.md` | YES | [ ] |
| `AI_WORKFLOW/HANDOFF.md` | YES | [ ] |
| `AI_WORKFLOW/CHANGELOG.md` | YES | [ ] |

### 4.2 CURRENT_STATE.md Checks

| Check | Expected | Result |
|-------|----------|--------|
| Phase header present | YES | [ ] |
| Done table accurate | Matches committed SHAs | [ ] |
| In Progress section current | No stale entries | [ ] |
| Blocked section accurate | No phantom blockers | [ ] |
| Uncommitted files list accurate | Matches `git status` | [ ] |
| TMP_001 status shown | CLOSED_BY_OPERATOR | [ ] |

### 4.3 WORK_LOG.md Checks

| Check | Expected | Result |
|-------|----------|--------|
| Append-only (newest at top) | YES | [ ] |
| Each entry has date, agent, action, outcome | YES | [ ] |
| No entry claims commit without SHA | YES | [ ] |
| TMP_001 not reopened in any entry | YES | [ ] |

### 4.4 DECISIONS.md Checks

| Check | Expected | Result |
|-------|----------|--------|
| D-001 present (WorkLogger gate complete) | YES | [ ] |
| D-002 present (TMP_001 closed) | YES | [ ] |
| D-003 present (Registry route override) | YES | [ ] |
| D-004 present (Runtime/Tests DO_NOT_TOUCH) | YES | [ ] |
| D-005 present (Commit protocol) | YES | [ ] |
| No decision contradicts CLAUDE.md | YES | [ ] |

### 4.5 BLOCKERS.md Checks

| Check | Expected | Result |
|-------|----------|--------|
| Active blockers listed | Accurate | [ ] |
| Resolved blockers marked resolved | YES | [ ] |
| B-001 (stale scope) marked resolved | YES | [ ] |

---

## 5. Registry / Worklog Consistency

### 5.1 TOOLLAB_WORK_LOG.md

| Check | Expected | Result |
|-------|----------|--------|
| 100 utilities listed (UTL-001 to UTL-100) | YES | [ ] |
| UTL-001 status = DONE | YES | [ ] |
| UTL-002 status = DONE | YES | [ ] |
| UTL-011, UTL-012 = CLOSED_BY_OPERATOR | YES | [ ] |
| All remaining = PLANNED or later approved status | YES | [ ] |
| No utility references Runtime path without approved gate | YES | [ ] |
| No duplicate utility IDs | YES | [ ] |

### 5.2 TOOLLAB_WORK_LOG.csv

| Check | Expected | Result |
|-------|----------|--------|
| Row count matches .md entry count (100 utilities) | YES | [ ] |
| Header row present with correct columns | YES | [ ] |
| UTL-001 row matches .md row | YES | [ ] |
| UTL-002 row matches .md row | YES | [ ] |
| No missing required fields in any CSV row | YES | [ ] |
| No unescaped commas in field values | YES | [ ] |
| No duplicate utility IDs in CSV | YES | [ ] |

### 5.3 REGISTRY_INDEX.md

| Check | Expected | Result |
|-------|----------|--------|
| Points to correct registry file paths | YES | [ ] |
| Batch summary matches .md batch sections | YES | [ ] |
| No broken internal references | YES | [ ] |

---

## 6. Prompt History Consistency

### 6.1 PROMPT_HISTORY.md

| Check | Expected | Result |
|-------|----------|--------|
| Append-only (newest at top) | YES | [ ] |
| P-001 present (Registry creation) | YES | [ ] |
| P-002 present (AI_WORKFLOW bootstrap) | YES | [ ] |
| P-003 present (CONVEYOR MODE QA route) | YES | [ ] |
| Each entry has Prompt ID, Agent, Outcome, Files | YES | [ ] |
| No entry claims DONE without confirming files created | YES | [ ] |
| TMP_001 marked not reopened in all entries | YES | [ ] |
| Prompt IDs sequential with no gaps | YES | [ ] |

---

## 7. Docs-Only vs Runtime/Test Boundary Checks

For every docs artifact in `Assets/ToolLab/Docs/`, confirm:

| Check | Expected | Result |
|-------|----------|--------|
| File marked `DRAFT_ONLY: YES` | YES | [ ] |
| File marked `NOT_FOR_RUNTIME_USE: YES` | YES | [ ] |
| File marked `PENDING_GATE_APPROVAL: YES` | YES | [ ] |
| No `.cs` file created alongside docs artifact | YES | [ ] |
| No Runtime path referenced without `DO_NOT_TOUCH` disclaimer | YES | [ ] |
| No Tests path referenced without `DO_NOT_TOUCH` disclaimer | YES | [ ] |
| TMP_001 not referenced as open | YES | [ ] |

Runtime/Tests lock reminder:

```text
Assets/ToolLab/Runtime/**  — DO_NOT_TOUCH (this prompt series)
Assets/ToolLab/Tests/**   — DO_NOT_TOUCH (this prompt series)
TMP_001                   — CLOSED_BY_OPERATOR, never reopen
```

---

## 8. RedactionGuard Reminders

Before approving any registry entry, docs file, or WORKER_BATCH_LOG entry, confirm:

| Pattern | Action if found |
|---------|----------------|
| `bearer` (case-insensitive) | BLOCKER — remove immediately, mark `validation_state: FAIL` |
| `sk-` prefix | BLOCKER — remove immediately, mark `validation_state: FAIL` |
| `ghp_` prefix | BLOCKER — remove immediately, mark `validation_state: FAIL` |
| `cloudtoken` | BLOCKER — remove immediately, mark `validation_state: FAIL` |
| Absolute system paths (e.g. `C:\Users\...`) | BLOCKER — replace with relative project path |
| API keys or passwords in any field | BLOCKER — remove immediately |

Do NOT expose violation details in result cards. Report only that a RedactionGuard violation was found.

---

## 9. Gate Status Taxonomy

### Worker Status (used by Claude Code / Cursor / OpenCode)

```text
IMPLEMENTED      — docs or artifact created as instructed, no violations
BLOCKED          — cannot proceed; blocker present
FAILED           — task attempted but produced incorrect output
WAIT_MODE        — waiting for external input or gate approval
DOCS_ONLY_READY  — docs-only artifact created, not staged
REPORT_ONLY_READY — report produced, not staged
```

### Control Room Verdict (used by Control Room only)

```text
PASS             — approved as-is
PASS_WITH_FIXES  — approved with required corrections (Control Room only)
BLOCKED          — gate cannot advance
FAIL             — rejected
```

**Rule: `PASS_WITH_FIXES` is a Control Room verdict only. Workers must never use it.**

### Gate States

```text
OPEN_TOOLLAB_LNNN        — gate open for task LNNN
OPEN_TOOLLAB_LNNN_VERIFY — verify-only gate for task LNNN
CLOSED                   — gate closed; no further work on this task
PENDING                  — gate not yet opened
```

---

## 10. WORKER_BATCH_LOG.md Review Checklist

Use this checklist when reviewing any `WORKER_BATCH_LOG.md` entry.

| Check | Expected | Result |
|-------|----------|--------|
| `WORKER_MODE` field present | YES | [ ] |
| `LANE` field is `ToolLab` | YES | [ ] |
| `PROJECT` field is `ToolLab_Sandbox_WorkLogger` | YES | [ ] |
| `ACTIVE_GATE` references a valid gate ID | YES | [ ] |
| `TASK_ID` present and matches gate | YES | [ ] |
| `STATUS` uses approved worker status taxonomy | `IMPLEMENTED` / `BLOCKED` / `FAILED` | [ ] |
| `STATUS` does NOT use `PASS_WITH_FIXES` | YES | [ ] |
| `RUNTIME_TOUCHED: NO` | YES | [ ] |
| `TESTS_TOUCHED: NO` | YES | [ ] |
| `TMP_001_REOPENED: NO` | YES | [ ] |
| `CS_FILES_CREATED_OR_CHANGED: NO` | YES | [ ] |
| `STAGED: NO` unless staging route explicitly opened | YES | [ ] |
| `COMMITTED: NO` unless commit route explicitly opened | YES | [ ] |
| `PUSHED: NO` | ALWAYS NO | [ ] |
| `BLOCKERS` field present | YES | [ ] |
| `NON_BLOCKERS` field present | YES | [ ] |
| `NEXT_RECOMMENDED_TOOL` field present | YES | [ ] |
| `ONE_NEXT_ACTION` field present | YES | [ ] |
| `FILE_CREATED` path is within allowed scope | YES | [ ] |
| `FILES_CHANGED` list matches `git status --short` | YES | [ ] |
| No sensitive data in any field | YES | [ ] |

---

## 11. Blockers / Non-Blockers

### Blockers

* any required AI_WORKFLOW file missing;
* CURRENT_STATE.md out of sync with actual `git status`;
* WORK_LOG.md has entry claiming commit without SHA;
* PROMPT_HISTORY.md has gap in sequential P-NNN IDs;
* registry entry has missing required field;
* CSV row inconsistent with markdown row;
* docs artifact missing `DRAFT_ONLY` / `NOT_FOR_RUNTIME_USE` / `PENDING_GATE_APPROVAL` markers;
* RedactionGuard violation in any file;
* WORKER_BATCH_LOG entry uses forbidden status taxonomy;
* `PASS_WITH_FIXES` used as worker status;
* Runtime or Tests files touched without open gate;
* TMP_001 reopened;
* any file staged/committed/pushed without explicit route.

### Non-Blockers

* optional fields absent from registry entries;
* `commit_sha` blank for uncommitted utilities;
* docs artifact not yet staged (expected until commit route opens);
* future extension points listed as pending;
* WORK_LOG entries referencing draft artifacts not yet committed.

---

## 12. Do-Not-Do

During any workflow audit, do not:

* modify Runtime files;
* modify Test files;
* reopen TMP_001;
* create `.cs` files;
* touch APP / MCP / Sandbox files;
* edit ProjectSettings or UserSettings;
* install packages;
* call external APIs;
* stage files;
* commit;
* push;
* use Stage All;
* use `git add .`;
* claim final readiness;
* claim BUG_FIXED_ACTIVE;
* use `PASS_WITH_FIXES` as a worker status;
* expose RedactionGuard violation details in result cards.

---

## 13. Return Card

```text
TOOLLAB_L003_AUDIT_RETURN:
PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
MODE: WORKFLOW_AUDIT
AUDIT_DATE:
AUDITOR:
AI_WORKFLOW_CONSISTENT: YES / NO / PARTIAL
REGISTRY_CONSISTENT: YES / NO / PARTIAL
PROMPT_HISTORY_CONSISTENT: YES / NO / PARTIAL
DOCS_BOUNDARY_CLEAN: YES / NO
REDACTION_GUARD_PASS: YES / NO
GATE_TAXONOMY_CORRECT: YES / NO
WORKER_BATCH_LOG_CLEAN: YES / NO
BLOCKERS:
NON_BLOCKERS:
NEXT_RECOMMENDED_TOOL:
ONE_NEXT_ACTION:
```

---

## 14. Next Gate

After this docs-only file is created locally, the next safe gate is verify-only inspection.

Recommended next gate:

```text
OPEN_TOOLLAB_L003_DOCS_VERIFY
```

Recommended next tool:

```text
OpenCode verify-only
```

If verify STATUS = IMPLEMENTED, exact staged commit:

```text
git add Assets/ToolLab/Docs/L003_WORKFLOW_AUDIT_CHECKLIST.md
git commit -m "docs(toollab): add L003 workflow audit checklist"
```

No Runtime or Tests gate is opened by this document.

---

## DO_NOT_TOUCH

```text
- Assets/ToolLab/Runtime/**
- Assets/ToolLab/Tests/**
- TMP_001
- *.cs files
- APP/**
- MCP/**
- Sandbox/**
- ProjectSettings/**
- UserSettings/**
- .mcp.json
- secrets/tokens
- Packages/**
- Assets/Plugins/**
- Library/**
- Temp/**
- Logs/**
- *.zip
```
