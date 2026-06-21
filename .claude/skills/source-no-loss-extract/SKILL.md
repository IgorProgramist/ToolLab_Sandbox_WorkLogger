---
name: source-no-loss-extract
description: >-
  No-loss (GRAIL) extraction from books, cookbooks, old chats, NotebookLM/Gemini/Claude dumps,
  YouTube notes, archive ZIPs. Use this WHENEVER Igor provides source material to mine into a
  cookbook, prompt library, SOP library, idea catalog, or action backlog.
---
# Source No-Loss (GRAIL) Extract

## When to use
Turning raw sources into structured, lossless knowledge artifacts.

## Procedure
1. SOURCE_INVENTORY (every source listed).
2. SOURCE_STREAM_LEDGER (what came from where).
3. Extract per source: prompts, SOPs, checklists, warnings, examples, bugs, fixes, decisions,
   ideas (strong/medium/weak/partial/niche/deferred/uncertain), implementation routes.
4. Remove ONLY exact dups, broken wrappers, boilerplate, empty noise, stale conflicting rules.
5. Log exclusions + gaps (MISSING / NOT_VISIBLE / SOURCE_RECOVERY_REQUIRED).

## Hard locks
- Do NOT compress into a tiny summary unless Igor asks for short output
- Do not invent missing content

## Return format
SOURCE_INVENTORY / LEDGER / EXTRACTS / EXCLUSIONS / GAPS / NEXT_ACTION
