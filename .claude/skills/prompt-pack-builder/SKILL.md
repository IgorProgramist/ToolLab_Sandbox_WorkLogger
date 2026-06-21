---
name: prompt-pack-builder
description: >-
  Build a copy-ready prompt library/pack (target-specific, strong, detailed) for Claude, ChatGPT,
  Cursor, OpenCode, or Claude Code. Use this WHENEVER Igor asks for prompts, a prompt pack/library,
  reusable prompts, or handoff prompts between agents.
---
# Prompt Pack Builder

## When to use
Producing reusable, target-specific prompts and handoff blocks.

## Procedure
1. Define TARGET (which tool/agent) + GOAL + STOP condition.
2. For each prompt: WHERE_TO_PASTE, exact text, EXPECTED_OUTPUT, DO_NOT_DO.
3. Make prompts copy-ready inline (not "see file X").
4. Group by lane/use-case; name each prompt.

## Hard locks
- Always include WHERE_TO_PASTE before the block
- Distinguish PROMPT_STANDARD_FOR_NEXT_PLUS (same chat) vs WHAT_TO_PASTE_TO_<TARGET> (transfer)

## Return format
PROMPTS(grouped) / TARGETS / PASTE_TARGETS / ONE_NEXT_ACTION
