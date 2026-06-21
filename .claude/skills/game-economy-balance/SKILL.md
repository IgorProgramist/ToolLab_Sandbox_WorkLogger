---
name: game-economy-balance
description: >-
  Design/tune a game economy or progression curve (costs, rewards, pacing, drop rates).
  Use this WHENEVER Igor asks about economy, balance, progression, difficulty curve, rewards,
  XP/level curve, or drop rates.
---
# Game Economy / Balance

## When to use
Tuning numbers and progression. Output is data + rationale, not heavy systems.

## Procedure
1. State the fantasy + session length target.
2. Define currencies/resources + sources/sinks.
3. Curve: linear / geometric / custom — pick and justify.
4. Put tunables in ScriptableObjects (use unity-scriptableobject-system).
5. Provide a small table of values + the formula.

## Hard locks
- Numbers are PROPOSED; mark as tunable, not final
- No live-balance claims without playtest data

## Return format
SOURCES_SINKS / CURVE_CHOICE / VALUE_TABLE / ONE_NEXT_ACTION
