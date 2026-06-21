---
name: game-juice-pass
description: >-
  Add "juice"/game-feel feedback (screen shake, tweens, particles, hit-stop, audio cues) to an
  existing mechanic. Use this WHENEVER Igor asks to make something feel better, add polish,
  feedback, juice, game-feel, or "it feels dead".
---
# Game Juice Pass

## When to use
A working-but-flat mechanic that needs feel. Additive only.

## Checklist (pick few, not all)
- Visual: tween scale/pos on action, particles on impact, flash on hit.
- Motion: hit-stop / time-scale dip, screen shake (clamped).
- Audio: on-action + on-result cues.
- UI: TMP punch-scale, color pulse via color.a.

## Hard locks
- Additive: do not refactor the mechanic
- Clamp shake/time-scale; no nausea-grade values
- No new heavy deps without APPROVE

## Return format
ADDED_EFFECTS / FILES_TOUCHED / SAFETY_CHECK / ONE_NEXT_ACTION
