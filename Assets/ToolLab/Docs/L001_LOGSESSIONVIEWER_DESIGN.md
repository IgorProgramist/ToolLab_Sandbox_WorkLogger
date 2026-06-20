# L001 LogSessionViewer Design

DRAFT_ONLY: YES
NOT_FOR_RUNTIME_USE: YES
PENDING_GATE_APPROVAL: YES

PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
ARTIFACT: L001_LOGSESSIONVIEWER_DESIGN.md
MODE: DOCS_ONLY_DESIGN
STATUS: DOCS_ONLY_READY

---

## 1. Purpose

The purpose of L001 LogSessionViewer is to define a future ToolLab utility for inspecting ToolLab workflow/session logs in a safe, read-only, production-support-friendly way.

This document is a planning artifact only. It does not approve implementation, Runtime work, Tests work, EditorWindow creation, automation, staging, commits, or push.

The future LogSessionViewer concept should help Igor and Control Room review session history, result cards, blockers, non-blockers, changed files, and next actions without guessing project state.

---

## 2. User Problem

Igor's Unity conveyor uses multiple lanes, tools, chats, and result cards. As the system grows, it becomes easy to lose track of:

* which lane produced which result;
* whether a task was PASS, BLOCKED, or parked;
* what files were changed;
* whether Runtime/Tests were touched;
* what the next safe action is;
* which result cards are missing;
* whether a worker incorrectly claimed readiness.

The future LogSessionViewer should make session review easier by displaying structured log data clearly and safely.

---

## 3. Scope

The scope of L001 is a future read-only ToolLab log/session viewer design.

In scope for the design:

* session list concept;
* selected session detail concept;
* result card display;
* blocker/non-blocker display;
* next action display;
* file-change summary;
* worker/control-room status taxonomy;
* validation checklist;
* OpenCode verification checklist;
* safety and boundary rules.

This document only describes the design. It does not create any runtime behavior.

---

## 4. Non-Goals

The following are explicitly out of scope:

* no Runtime implementation;
* no Tests implementation;
* no `.cs` files;
* no EditorWindow code;
* no TMP_001 reopening;
* no automation approval;
* no upload/adoption approval;
* no final readiness claim;
* no git staging, commit, or push;
* no APP/MCP/Sandbox work;
* no ProjectSettings or UserSettings edits;
* no package installation;
* no external APIs.

---

## 5. Inputs

Future possible read-only inputs may include existing ToolLab documentation and workflow logs such as:

* `AI_WORKFLOW/WORK_LOG.md`;
* `AI_WORKFLOW/CURRENT_STATE.md`;
* `AI_WORKFLOW/PROMPT_HISTORY.md`;
* `AI_WORKFLOW/REPORTS/**`;
* `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md`;
* `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv`;
* future JSONL session logs if explicitly approved later.

Input handling must be read-only unless a later gate explicitly approves writing.

---

## 6. Outputs

Future possible outputs may include:

* an on-screen read-only session summary;
* a filtered list of session records;
* selected session details;
* blocker/non-blocker overview;
* next action summary;
* missing proof/card warnings;
* copy-ready report card text.

No output may mutate Runtime, Tests, ProjectSettings, UserSettings, packages, scenes, or cross-lane files unless separately approved by Control Room.

---

## 7. UI Layout

A future LogSessionViewer UI could be structured into the following read-only panels:

1. Session List
   Shows sessions or result cards in chronological order.

2. Session Detail
   Shows selected session metadata, status, lane, task, files changed, and next action.

3. Blockers / Non-Blockers
   Shows active blockers separately from known non-blockers.

4. File Scope Panel
   Shows files changed, files inspected, and restricted paths.

5. Return Card Panel
   Shows the exact result card returned by a worker/tool.

6. Safety Panel
   Shows locks such as no Runtime, no Tests, no push, no Stage All, and no git add dot.

The UI must clearly label draft, parked, blocked, and pending states.

---

## 8. Filters

Potential filters:

* lane: ToolLab / APP / MCP / Sandbox;
* task ID;
* status;
* worker/tool;
* blocker present;
* runtime touched;
* tests touched;
* staged/committed/pushed state;
* date/time if timestamps exist;
* file path category.

Filters must not modify log data.

---

## 9. Search

Search may support:

* task ID search;
* file path search;
* blocker keyword search;
* status search;
* next action search;
* worker/tool search.

Search should be case-insensitive where reasonable and must not require external APIs.

---

## 10. Grouping

Potential grouping modes:

* by lane;
* by task ID;
* by status;
* by worker/tool;
* by date/session batch;
* by blocker/non-blocker;
* by changed file category;
* by Control Room gate.

Grouping must not hide blockers by default. Blocked items should remain visible or easy to reveal.

---

## 11. Error Handling

The future viewer should handle:

* missing log files;
* empty logs;
* malformed rows;
* unknown status values;
* missing next action;
* missing file list;
* missing commit SHA;
* missing proof card;
* duplicate task IDs;
* unavailable registry files.

Error states should be reported as read-only warnings, not crashes.

---

## 12. JSONL Assumptions

If a future JSONL format is introduced, each line should represent one session or result event.

Potential fields:

* `timestamp`;
* `lane`;
* `project`;
* `task_id`;
* `tool`;
* `worker_status`;
* `control_room_verdict`;
* `files_changed`;
* `runtime_touched`;
* `tests_touched`;
* `staged`;
* `committed`;
* `pushed`;
* `blockers`;
* `non_blockers`;
* `one_next_action`.

JSONL use is not approved by this document. This section only defines a possible future direction.

---

## 13. Performance

The future viewer should remain lightweight.

Design expectations:

* handle long logs without freezing;
* allow simple pagination or scroll behavior;
* avoid expensive full-project scans unless explicitly requested;
* avoid background automation unless approved;
* avoid external services;
* prefer local files only.

Performance concerns should be treated as non-blockers during design and blockers only during implementation validation if actual issues appear.

---

## 14. Safety Locks

Required safety locks:

* no push;
* no Stage All;
* no `git add .`;
* no upload/adoption approval;
* no final readiness claim;
* no BUG_FIXED_ACTIVE claim;
* no ProjectSettings/UserSettings edits;
* no secrets/tokens access;
* no package installs;
* no external APIs;
* no cross-lane modifications.

The future viewer must display safety-sensitive fields clearly.

---

## 15. Runtime / Tests Lock

ToolLab Runtime and Tests remain locked unless Control Room explicitly opens a runtime/test gate.

This document does not approve:

* `Assets/ToolLab/Runtime/**`;
* `Assets/ToolLab/Tests/**`;
* TMP_001 reopening;
* `.cs` files;
* test files;
* runtime prefabs;
* scenes.

The future LogSessionViewer must respect this lock.

---

## 16. File Boundaries

Allowed future docs-only planning paths may include:

* `Assets/ToolLab/Docs/**`;
* `Assets/ToolLab/Registry/**`;
* `AI_WORKFLOW/**`.

Restricted paths:

* `Assets/ToolLab/Runtime/**`;
* `Assets/ToolLab/Tests/**`;
* `ProjectSettings/**`;
* `UserSettings/**`;
* `.mcp.json`;
* secrets/tokens;
* APP files;
* MCP files;
* Sandbox files;
* Packages;
* Library;
* Temp;
* Logs.

Any future implementation route must define exact allowed files before work starts.

---

## 17. Extension Points

Possible future extension points, pending approval:

* Markdown report viewer;
* CSV/JSONL session parser;
* EditorWindow read-only UI;
* result-card validator;
* status taxonomy checker;
* missing-proof detector;
* lane summary generator;
* Control Room export card.

Each extension point requires a separate gate and must not be treated as approved by this draft.

---

## 18. Validation Checklist

Future validation checklist:

* target docs file exists;
* file is marked DRAFT_ONLY;
* file is marked NOT_FOR_RUNTIME_USE;
* file is marked PENDING_GATE_APPROVAL;
* Runtime untouched;
* Tests untouched;
* TMP_001 not reopened;
* no `.cs` files created;
* no ProjectSettings/UserSettings touched;
* no APP/MCP/Sandbox files touched;
* no stage/commit/push;
* status taxonomy separates worker status from Control Room verdict;
* PASS_WITH_FIXES appears only under Control Room verdict.

---

## 19. OpenCode Checklist

A verify-only OpenCode check should confirm:

* `git status --short`;
* target file exists;
* changed files list;
* Runtime untouched;
* Tests untouched;
* TMP_001 not reopened;
* no `.cs` files created;
* no APP files touched;
* no MCP files touched;
* no Sandbox files touched;
* no staged files;
* no commit;
* no push.

Expected return card:

```text
TOOLLAB_L001_VERIFY_RETURN:
PROJECT: ToolLab_Sandbox_WorkLogger
STATUS: PASS / PASS_WITH_WARNINGS / BLOCKED / FAIL
FILE_EXISTS: YES/NO
TARGET_PATH: Assets/ToolLab/Docs/L001_LOGSESSIONVIEWER_DESIGN.md
GIT_STATUS_SHORT:
FILES_CHANGED:
RUNTIME_TOUCHED: YES/NO
TESTS_TOUCHED: YES/NO
TMP_001_REOPENED: YES/NO
CS_FILES_CREATED: YES/NO
APP_FILES_TOUCHED: YES/NO
MCP_FILES_TOUCHED: YES/NO
SANDBOX_FILES_TOUCHED: YES/NO
STAGED: YES/NO
COMMITTED: YES/NO
PUSHED: YES/NO
BLOCKERS:
NON_BLOCKERS:
READY_FOR_CONTROL_ROOM_REVIEW: YES/NO
ONE_NEXT_ACTION:
```

---

## 20. Blockers / Non-Blockers

Examples of blockers:

* Runtime touched;
* Tests touched;
* TMP_001 reopened;
* `.cs` file created without approval;
* ProjectSettings/UserSettings touched;
* cross-lane files touched;
* staged/committed/pushed without route;
* missing target file after creation route;
* PASS_WITH_FIXES used as worker status.

Examples of non-blockers:

* file is draft-only;
* no commit yet because commit route was not opened;
* future implementation questions remain open;
* SHA uncertainty remains if not needed for this docs-only artifact;
* target file created but not staged.

---

## 21. Do-Not-Do

Do not:

* create Runtime code;
* edit Runtime;
* edit Tests;
* reopen TMP_001;
* create `.cs` files;
* touch APP/MCP/Sandbox;
* edit ProjectSettings/UserSettings;
* install packages;
* call external APIs;
* stage;
* commit;
* push;
* use Stage All;
* use `git add .`;
* claim final readiness;
* claim BUG_FIXED_ACTIVE;
* treat this draft as runtime approval.

---

## 22. Return Card

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

ToolLab creation return card:

```text
TOOLLAB_L001_DOCS_CREATE_RETURN:
PROJECT: ToolLab_Sandbox_WorkLogger
LANE: ToolLab
STATUS: PASS / PASS_WITH_WARNINGS / BLOCKED / FAIL
MODE: DOCS_ONLY_CREATE
FILE_CREATED:
FILES_CHANGED:
RUNTIME_TOUCHED: YES/NO
TESTS_TOUCHED: YES/NO
TMP_001_REOPENED: YES/NO
CS_FILES_CREATED: YES/NO
PROJECTSETTINGS_TOUCHED: YES/NO
USERSETTINGS_TOUCHED: YES/NO
STAGED: YES/NO
COMMITTED: YES/NO
PUSHED: YES/NO
BLOCKERS:
NON_BLOCKERS:
NEXT_RECOMMENDED_TOOL:
ONE_NEXT_ACTION:
```

---

## 23. Next Gate

After this docs-only file is created locally, the next safe gate is verify-only inspection.

Recommended next gate:

```text
OPEN_TOOLLAB_L001_DOCS_VERIFY
```

Recommended next tool:

```text
OpenCode verify-only
```

No Runtime or Tests gate is opened by this document.

Final next action:

```text
Run verify-only OpenCode check and return TOOLLAB_L001_VERIFY_RETURN.
```

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
