# CLAUDE.md — ToolLab_Sandbox_WorkLogger
# Location: project root (ToolLab_Sandbox_WorkLogger/CLAUDE.md)

## THIS PROJECT
**Purpose:** Disposable HDRP sandbox for WorkLogger development and testing.
**Unity:** 6000.3.9f1 · HDRP · disposable sandbox (not production)
**Phase:** WorkLogger Code Gate (T1–T7 tests + JSONL output)

---

## THE 4 RULES (Karpathy — always active)

### 1. THINK BEFORE CODING
State assumptions before implementing. If unclear → ask, do not guess.
Multiple interpretations → present them, do not pick silently.

### 2. SIMPLICITY FIRST
Minimum code that solves the task. No speculative features.
200 lines that could be 50 → rewrite. No abstractions for single use.

### 3. SURGICAL CHANGES
Touch ONLY files in FILES_ALLOWED. No adjacent improvements.
No "while I'm here." Every changed line must trace to the request.

### 4. GOAL-DRIVEN EXECUTION
Tests are the definition of done. State a plan before coding.
Loop until tests pass or report why blocked. Never claim "done" without test run.

---

## PROJECT STACK
- Unity 6000.3.9f1 · HDRP · C#
- Logging contract: **LOG_SCHEMA v1.2** (19 fields)
- Canonical logger: `Assets/ToolLab/Runtime/Logging/ToolLabWorkLogger.cs`
- Namespace: `UnityToolLab.Logging` · Class: `ToolLabWorkLogger`
- Tests: `Assets/ToolLab/Tests/Editor/WorkLoggerTests.cs`
- Output format: JSONL (one JSON object per line, newline-delimited)

## FILES_ALLOWED (for WorkLogger gate tasks)
```
Assets/ToolLab/Runtime/Logging/ToolLabWorkLogger.cs
Assets/ToolLab/Tests/Editor/WorkLoggerTests.cs
```
Do NOT touch any other files without explicit approval.

---

## CURRENT ROUTE OVERRIDE — Registry Route (active 2026-06-18)

**Supersedes the narrow FILES_ALLOWED above for registry/workflow tasks.**
Igor approved this override after OpenCode returned FAIL due to stale-scope mismatch.
See AI_WORKFLOW/DECISIONS.md D-003.

### Approved scope for registry/workflow tasks
```
Assets/ToolLab/Registry/**     — ToolLab utility registry (MD + CSV)
Assets/ToolLab/Docs/**         — ToolLab action plans and docs
AI_WORKFLOW/**                 — Workflow coordination files
CLAUDE.md                      — This file (scope updates)
AGENTS.md                      — Agent routing rules
.cursor/rules/**               — Cursor rule files
```

### Still DO_NOT_TOUCH (this prompt series)
```
Assets/ToolLab/Runtime/**      — Runtime code, including ToolLabWorkLogger.cs
Assets/ToolLab/Tests/**        — Test files, including WorkLoggerTests.cs
ProjectSettings/**
Packages/**
UserSettings/**
.mcp.json
Library/** / Temp/** / Logs/**
```

### TMP_001 lock
TmpAlphaFadeIn.cs and TmpAlphaFadeInTests.cs are CLOSED_BY_OPERATOR.
Do NOT reopen. Do NOT modify.

---

## HARD LOCKS (never without Igor's explicit approval)
- No git commit / push / stage
- No package installs, no Packages/manifest.json edits
- No scene save, no batchmode build
- No MCP calls unless explicitly enabled for the task
- No files outside FILES_ALLOWED
- No final-readiness or BUG_FIXED_ACTIVE claims
- No deletion of any file

---

## WORKLOGGER SCHEMA v1.2 (19 fields — CANONICAL)

### Required fields (12)
```
schema_version  = "1.2"   (hardcoded constant, always "1.2")
id              — unique entry ID (Guid or sequential)
ts              — ISO-8601 UTC timestamp (e.g. "2026-06-15T18:00:00Z")
session_id      — ONE static GUID per domain reload (NOT per Log() call)
type            = "action"|"session"|"file_op"|"test_result"|"gate"|"decision"|"error"|"security"|"source"
level           = "INFO"|"WARN"|"ERROR"|"GATE"|"SECURITY"
actor           = "tool"  (WorkLogger always sets this, hardcoded)
tool_id         — identifies which tool/system wrote the entry
lane            = "UTL"
risk_lane       = "SANDBOX_FIRST"
action          — what happened (verb phrase)
summary         — human-readable description
```

### Optional fields (7)
```
target          — affected file, asset, or object
status          = "ok"|"warn"|"fail"   (execution result)
verdict         = "PASS"|"PASS_WITH_FIXES"|"FAIL"|"REWORK_REQUIRED"|"BLOCKED"
payload         — structured data (JSON string or object)
duration_ms     — operation duration in milliseconds
tags            — array of string labels
artifact        — path or reference to related artifact
```

### RedactionGuard
THROW `InvalidOperationException` if `summary` contains (case-insensitive):
`"bearer"`, `"sk-"`, `"ghp_"`, `"cloudtoken"`
DO NOT add a `redacted` boolean field. Guard = throw, not flag.

### Output
- File: `Assets/Logs/toollab_YYYYMMDD.jsonl`
- Format: one JSON object per line (newline-delimited)
- Write: `File.AppendAllText` only — never overwrite, never truncate

---

## RETURN FORMAT (mandatory for code tasks)
```
IMPLEMENTATION_STATUS:
FILES_CREATED:
FILES_MODIFIED:
SAFETY_CHECK:
TEST_STATUS:
JSONL_SAMPLE:
LIMITATIONS:
ONE_NEXT_ACTION:
```

---

## UNITY CONVENTIONS
- uGUI/Canvas (NOT UI Toolkit)
- TextMeshProUGUI for all UI text
- VALIDATE_FIRST for all Unity API claims
