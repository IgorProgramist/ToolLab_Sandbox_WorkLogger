# AGENTS.md — Igor's Unity Projects (multi-harness)
# Works with: Codex CLI, Windsurf, Gemini CLI, and other tools reading AGENTS.md
# Location: project root of any Unity project

## SAME RULES AS CLAUDE.md
All rules in CLAUDE.md apply here identically.
This file exists so tools that read AGENTS.md (instead of CLAUDE.md) get the same guardrails.

---

## THE 4 RULES (Karpathy)

1. **THINK** — State assumptions explicitly. If unclear → ask, do not guess.
2. **SIMPLIFY** — Minimum code. 200 lines that could be 50 → rewrite.
3. **SURGICAL** — Touch only what the task requires. No adjacent improvements.
4. **GOAL-DRIVEN** — Tests are success criteria. Loop until verified or report blockers.

---

## GLOBAL HARD LOCKS
- No git commit / push / stage
- No package installs or manifest.json edits
- No scene save or batchmode build
- No files outside explicitly stated scope
- No final-readiness or BUG_FIXED_ACTIVE claims
- No automation without stop condition

---

## STACK (common to all projects)
- Unity 6 · C# · HDRP or Standard RP
- UI: uGUI/Canvas (NOT UI Toolkit)
- Text: TextMeshProUGUI (NOT legacy Text)
- VALIDATE_FIRST for all Unity API claims

---

## PROJECT-SPECIFIC OVERRIDES
If this file is in a specific project root, that project's CLAUDE.md
contains the detailed stack, files allowed, and phase restrictions.
Read CLAUDE.md alongside this file.
