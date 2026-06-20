# L002 WorkLogger Registry QA Checklist

DRAFT_ONLY: YES
NOT_FOR_RUNTIME_USE: YES
PENDING_GATE_APPROVAL: YES

PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
ARTIFACT: L002_WORKLOGGER_REGISTRY_QA.md
MODE: DOCS_ONLY_DESIGN
STATUS: DOCS_ONLY_READY

---

## 1. Purpose

L002 defines a docs-only QA checklist for reviewing ToolLab registry and worklog entries.

This document is a planning and validation artifact only. It does not approve implementation, Runtime work, Tests work, EditorWindow creation, automation, staging, commits, or push.

The checklist helps Igor and Control Room confirm that registry entries are internally consistent, complete, and safe before any utility proceeds to implementation or commit.

---

## 2. Scope

In scope for this document:

* registry row schema definition;
* required and optional field definitions;
* RedactionGuard rules for registry content;
* output format for review result cards;
* T1–T7 gate reference as historical context;
* CSV consistency checklist;
* reusable future utility review template;
* blocker / non-blocker definitions;
* safety locks.

This document only defines the QA checklist. It does not create any runtime behavior.

---

## 3. Out of Scope

The following are explicitly out of scope:

* no Runtime implementation;
* no Tests implementation;
* no `.cs` files;
* no EditorWindow code;
* no TMP_001 reopening;
* no ProjectSettings or UserSettings edits;
* no APP / MCP / Sandbox files;
* no package installation;
* no external APIs;
* no git staging, commit, or push;
* no automation approval;
* no final readiness claim;
* no BUG_FIXED_ACTIVE claim.

---

## 4. Registry Row Schema

Each ToolLab registry entry (in both `TOOLLAB_WORK_LOG.md` and `TOOLLAB_WORK_LOG.csv`) must conform to the following row schema.

| Column | Type | Notes |
|--------|------|-------|
| utility_id | string | Format: UTL-NNN (zero-padded to 3 digits) |
| name | string | PascalCase utility name |
| lane | string | Always `UTL` for ToolLab utilities |
| status | enum | `PLANNED` / `IN_PROGRESS` / `DONE` / `CLOSED_BY_OPERATOR` / `BLOCKED` |
| owner_tool | string | Agent or tool that created/owns the entry |
| source_file_or_doc | string | Relative path to source file or docs artifact |
| created_or_updated | date | ISO-8601 date (YYYY-MM-DD) |
| gate | string | Gate ID that approved this entry (e.g. `OPEN_TOOLLAB_L001`) |
| validation_state | enum | `PENDING` / `PASS` / `PASS_WITH_WARNINGS` / `FAIL` / `BLOCKED` |
| blockers | string | Pipe-separated blocker list or `NONE` |
| non_blockers | string | Pipe-separated non-blocker list or `NONE` |
| next_action | string | One-sentence next safe action |

---

## 5. Required Fields

The following fields are required for every registry entry. A missing required field is a **blocker**.

| Field | Rule |
|-------|------|
| `utility_id` | Must match `UTL-NNN` pattern; must be unique across all entries |
| `name` | Must be non-empty; must match PascalCase |
| `lane` | Must be `UTL` for all ToolLab utilities |
| `status` | Must be one of the approved enum values |
| `owner_tool` | Must identify the agent or tool responsible |
| `source_file_or_doc` | Must be a valid relative path or docs artifact reference |
| `created_or_updated` | Must be a valid ISO-8601 date |
| `gate` | Must reference an approved gate ID |
| `validation_state` | Must be one of the approved enum values |
| `blockers` | Must be present; use `NONE` if no blockers |
| `non_blockers` | Must be present; use `NONE` if no non-blockers |
| `next_action` | Must be a non-empty, actionable statement |

---

## 6. Optional Fields

The following fields are optional. A missing optional field is a **non-blocker** unless the gate explicitly requires it.

| Field | Notes |
|-------|-------|
| `commit_sha` | Git commit SHA when the utility was committed; leave blank if uncommitted |
| `reviewer` | Name of agent or person who reviewed this entry |
| `related_prompt` | Prompt ID (e.g. `P-001`) from `PROMPT_HISTORY.md` |
| `related_report` | Path to related report in `AI_WORKFLOW/REPORTS/` |
| `risk_level` | `LOW` / `MEDIUM` / `HIGH`; default assumed `LOW` for docs-only entries |
| `notes` | Free-text notes relevant to the entry |
| `tags` | Comma-separated tags for grouping or filtering |

---

## 7. RedactionGuard Rules

Registry entries must not expose sensitive data. The following rules apply:

| Rule | Description |
|------|-------------|
| No bearer tokens | `source_file_or_doc`, `notes`, or any field must not contain bearer token strings |
| No `sk-` prefixes | API key patterns starting with `sk-` are forbidden in all fields |
| No `ghp_` prefixes | GitHub personal access token patterns are forbidden in all fields |
| No `cloudtoken` strings | Cloud credential token patterns are forbidden in all fields |
| No private paths beyond allowed scope | Absolute system paths outside the project root are forbidden |
| No credentials or passwords | Any credential-like string in any field is a blocker |

If any of these patterns are detected in a registry entry:

* mark `validation_state` as `FAIL`;
* add a `blockers` entry describing the violation;
* do NOT log or expose the sensitive value in the result card.

---

## 8. Output Format

A registry QA review must produce the following result card:

```text
TOOLLAB_REGISTRY_QA_RETURN:
PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
MODE: REGISTRY_QA
UTILITY_ID:
UTILITY_NAME:
VALIDATION_STATE: PENDING / PASS / PASS_WITH_WARNINGS / FAIL / BLOCKED
REQUIRED_FIELDS_PRESENT: YES / NO / PARTIAL
OPTIONAL_FIELDS_PRESENT: YES / NO / PARTIAL
REDACTION_GUARD_PASS: YES / NO
CSV_CONSISTENT: YES / NO / NOT_CHECKED
BLOCKERS:
NON_BLOCKERS:
REVIEWER:
REVIEWED_DATE:
NEXT_RECOMMENDED_TOOL:
ONE_NEXT_ACTION:
```

---

## 9. T1–T7 Gate Reference

The T1–T7 test gate was the original WorkLogger code-gate test suite (commit `a540a21`).

This section is historical context only. The gate covers:

| Test | Description |
|------|-------------|
| T1 | Required fields present in output |
| T2 | JSONL output format confirmed |
| T3 | RedactionGuard fires on forbidden patterns |
| T4 | `session_id` stable per domain reload |
| T5 | Append-only output (no overwrite) |
| T6 | Hardcoded constants: `actor`, `lane`, `risk_lane` |
| T7 | Optional fields serialised when set |

**This reference does not reopen Runtime or Tests.** These tests are recorded as passing in `a540a21`. No re-execution is required for registry QA.

Registry QA reviewers should note which T1–T7 behaviors are relevant to the utility under review and mark them as covered / not applicable.

---

## 10. CSV Consistency Checklist

The `TOOLLAB_WORK_LOG.csv` must remain consistent with `TOOLLAB_WORK_LOG.md`.

For each utility row, confirm:

| Check | Expected | Result |
|-------|----------|--------|
| `utility_id` matches in both files | Identical string | [ ] |
| `name` matches in both files | Identical string | [ ] |
| `status` matches in both files | Identical enum value | [ ] |
| `gate` matches in both files | Identical gate ID | [ ] |
| `validation_state` matches in both files | Identical enum value | [ ] |
| `next_action` matches in both files | Identical string | [ ] |
| No required fields missing in CSV row | All 12 required fields present | [ ] |
| No duplicate `utility_id` in CSV | Unique across all rows | [ ] |
| CSV row is parse-safe | No unescaped commas in fields; quoted where needed | [ ] |
| CSV column count matches header | Same number of columns in every row | [ ] |

Mark `[x]` for confirmed, `[!]` for mismatch found.

Any `[!]` item is a **blocker** for that utility's registry entry.

---

## 11. Future Utility Review Template

Use this template for reviewing any future `UTL-NNN` registry entry.

```text
UTILITY_REVIEW:
UTILITY_ID: UTL-NNN
UTILITY_NAME:
LANE: UTL
STATUS:
OWNER_TOOL:
SOURCE_FILE_OR_DOC:
CREATED_OR_UPDATED:
GATE:
VALIDATION_STATE:

REQUIRED_FIELDS:
  utility_id: PRESENT / MISSING
  name: PRESENT / MISSING
  lane: PRESENT / MISSING
  status: PRESENT / MISSING
  owner_tool: PRESENT / MISSING
  source_file_or_doc: PRESENT / MISSING
  created_or_updated: PRESENT / MISSING
  gate: PRESENT / MISSING
  validation_state: PRESENT / MISSING
  blockers: PRESENT / MISSING
  non_blockers: PRESENT / MISSING
  next_action: PRESENT / MISSING

OPTIONAL_FIELDS:
  commit_sha: PRESENT / ABSENT
  reviewer: PRESENT / ABSENT
  related_prompt: PRESENT / ABSENT
  related_report: PRESENT / ABSENT
  risk_level: PRESENT / ABSENT
  notes: PRESENT / ABSENT
  tags: PRESENT / ABSENT

REDACTION_GUARD:
  bearer: CLEAN / VIOLATION
  sk-: CLEAN / VIOLATION
  ghp_: CLEAN / VIOLATION
  cloudtoken: CLEAN / VIOLATION
  private_paths: CLEAN / VIOLATION

CSV_CONSISTENCY:
  utility_id match: YES / NO
  status match: YES / NO
  gate match: YES / NO
  next_action match: YES / NO
  required fields in CSV: YES / NO / PARTIAL
  no duplicate IDs: YES / NO
  parse-safe: YES / NO

T1-T7_RELEVANCE:
  T1 (required fields): APPLICABLE / NOT_APPLICABLE
  T2 (JSONL format): APPLICABLE / NOT_APPLICABLE
  T3 (redaction guard): APPLICABLE / NOT_APPLICABLE
  T4 (session_id stable): APPLICABLE / NOT_APPLICABLE
  T5 (append-only): APPLICABLE / NOT_APPLICABLE
  T6 (hardcoded constants): APPLICABLE / NOT_APPLICABLE
  T7 (optional fields): APPLICABLE / NOT_APPLICABLE

BLOCKERS:
NON_BLOCKERS:
REVIEWER:
REVIEWED_DATE:
NEXT_ACTION:
```

---

## 12. Blockers / Non-Blockers

### Blockers

A registry QA review must report the following as **blockers**:

* any required field missing from the registry row;
* `utility_id` not matching `UTL-NNN` pattern;
* duplicate `utility_id` across entries;
* `status` or `validation_state` set to an unknown enum value;
* RedactionGuard violation in any field;
* CSV row missing a required column;
* CSV row column count mismatch;
* CSV and markdown rows inconsistent on required fields;
* `source_file_or_doc` path pointing to a restricted location (Runtime, Tests, ProjectSettings, etc.);
* any `PASS_WITH_FIXES` used as a worker status (allowed only as Control Room verdict).

### Non-Blockers

The following are **non-blockers**:

* optional fields absent;
* `commit_sha` blank because the utility is uncommitted;
* `related_prompt` or `related_report` absent for early-stage utilities;
* `notes` field absent;
* `risk_level` defaulting to `LOW`;
* draft status or pending gate approval on a docs-only artifact.

---

## 13. Do-Not-Do

During registry QA review, do not:

* modify Runtime files;
* modify Test files;
* reopen TMP_001;
* create `.cs` files;
* touch APP / MCP / Sandbox files;
* edit ProjectSettings or UserSettings;
* install packages;
* call external APIs;
* stage any files;
* commit;
* push;
* use Stage All;
* use `git add .`;
* claim final readiness;
* claim BUG_FIXED_ACTIVE;
* use `PASS_WITH_FIXES` as a worker status;
* expose RedactionGuard violation details in the result card.

---

## 14. Return Card

Worker/tool status taxonomy:

```text
WORKER_STATUS:
PASS
PASS_WITH_WARNINGS
FAIL
BLOCKED
WAIT_MODE
DOCS_ONLY_READY
REPORT_ONLY_READY
```

Control Room verdict taxonomy:

```text
CONTROL_ROOM_VERDICT:
PASS
PASS_WITH_FIXES
BLOCKED
FAIL
```

Rule:

```text
PASS_WITH_FIXES is Control Room verdict only, never worker status.
```

Registry QA result card:

```text
TOOLLAB_REGISTRY_QA_RETURN:
PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
MODE: REGISTRY_QA
UTILITY_ID:
UTILITY_NAME:
VALIDATION_STATE: PENDING / PASS / PASS_WITH_WARNINGS / FAIL / BLOCKED
REQUIRED_FIELDS_PRESENT: YES / NO / PARTIAL
OPTIONAL_FIELDS_PRESENT: YES / NO / PARTIAL
REDACTION_GUARD_PASS: YES / NO
CSV_CONSISTENT: YES / NO / NOT_CHECKED
BLOCKERS:
NON_BLOCKERS:
REVIEWER:
REVIEWED_DATE:
NEXT_RECOMMENDED_TOOL:
ONE_NEXT_ACTION:
```

---

## 15. Next Gate

After this docs-only file is created locally, the next safe gate is verify-only inspection.

Recommended next gate:

```text
OPEN_TOOLLAB_L002_DOCS_VERIFY
```

Recommended next tool:

```text
OpenCode verify-only
```

Verify must confirm:

* `git status --short` shows only the new docs file as untracked;
* `Assets/ToolLab/Runtime/**` untouched;
* `Assets/ToolLab/Tests/**` untouched;
* TMP_001 not reopened;
* no `.cs` files created;
* no staged files;
* no commit;
* no push.

If verify PASS, next action is exact local commit of only the approved file:

```text
git add Assets/ToolLab/Docs/L002_WORKLOGGER_REGISTRY_QA.md
git commit -m "docs(toollab): add L002 worklogger registry QA checklist"
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
