---
name: unity-hdrp-shader-helper
description: >-
  Help build/debug HDRP Shader Graph effects and custom passes (dissolve, fade, outline, etc).
  Use this WHENEVER Igor mentions Shader Graph, HDRP, shader, custom pass, dissolve, material
  effect. HDRP API changes fast — every claim is VALIDATE_FIRST.
---
# Unity HDRP Shader Helper

## When to use
Shader Graph nodes/effects and HDRP custom passes. VALIDATE_FIRST-heavy.

## Hard locks (CRITICAL)
- Every HDRP/Shader Graph API claim = VALIDATE_FIRST vs current HDRP package docs (do NOT trust memory)
- State HDRP package version assumption explicitly; if unknown → ask
- No render pipeline asset edits without APPROVE
- Sandbox materials/shaders under Assets/ToolLab/Shaders/

## Procedure
1. State effect goal + HDRP version assumption.
2. Mark each non-trivial node/API as [VALIDATE_FIRST] until confirmed.
3. Provide graph node plan first; only then concrete steps.
4. Flag anything that needs the actual Editor to verify.

## Return format
EFFECT_PLAN / VALIDATE_FIRST_LIST / FILES_CREATED / LIMITATIONS / ONE_NEXT_ACTION
