---
name: game-core-loop-scaffold
description: >-
  Scaffold a game's core loop (input -> state -> action -> feedback -> reward) as minimal,
  testable Unity scripts. Use this WHENEVER Igor asks for a core loop, gameplay loop, MVP
  prototype, mechanic skeleton, or "make it playable".
---
# Game Core Loop Scaffold

## When to use
First playable skeleton of a mechanic / mini-project (fits the ~400 sandbox projects).

## Hard locks
- Minimal: one loop, no menus/economy unless asked (Karpathy SIMPLICITY)
- Sandbox folder per mini-project; namespace per project
- uGUI/TMP for any UI; no premature systems

## Procedure
1. Name the loop in one sentence: "Player does X to get Y, repeat."
2. Identify: Input, State, Action, Feedback, Reward.
3. One controller script + minimal state; placeholder feedback.
4. Make it run in <1 session; list what's stubbed.

## Return format
LOOP_STATEMENT / FILES_CREATED / STUBBED / ONE_NEXT_ACTION
