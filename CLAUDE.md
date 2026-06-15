# CLAUDE.md — Unity AI Starter Kit (root guardrails)

Read this before any task. These rules apply to every Claude Code session in this project.

## 4 RULES (Karpathy-derived)
1. THINK: State assumptions explicitly. If unclear — ask, do not guess.
2. SIMPLIFY: Minimum code that solves the task. 200 lines that could be 50 → rewrite.
3. SURGICAL: Touch ONLY files in FILES_ALLOWED. No adjacent improvements. No "while I'm here".
4. GOAL-DRIVEN: The tests are the success criteria. Loop until they pass or report why blocked.

## PROJECT STACK
- Unity 6000.3.9f1 · HDRP · disposable sandbox
- Logging contract: LOG_SCHEMA v1.2 (19 fields)
- Canonical logger: Assets/ToolLab/Runtime/Logging/ToolLabWorkLogger.cs (namespace UnityToolLab.Logging)

## HARD LOCKS (never without explicit human approval)
- No git commit/push/stage
- No package installs, no manifest.json edits
- No scene save, no batchmode build
- No MCP calls unless explicitly enabled for the task
- No files outside FILES_ALLOWED
- No final-readiness or BUG_FIXED_ACTIVE claims

## DEFAULT RETURN FORMAT
IMPLEMENTATION_STATUS / FILES_CREATED / SAFETY_CHECK / TEST_STATUS / JSONL_SAMPLE / LIMITATIONS / ONE_NEXT_ACTION
