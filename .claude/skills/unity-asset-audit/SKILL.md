---
name: unity-asset-audit
description: >-
  Audit Unity assets — prefabs, materials, textures, missing references, import settings.
  Use this WHENEVER Igor asks to check prefabs, find missing references, audit materials/
  textures, review import settings, or clean up an asset folder.
---
# Unity Asset Audit

## When to use
Read-only inventory + issue report over an asset folder. Across ~400 mini-projects too.

## Checklist
1. Missing references (None/Missing script, missing material/texture).
2. Prefab overrides / broken nested prefabs.
3. Texture import: oversized, no compression, wrong max size.
4. Material/shader: HDRP-incompatible shaders, pink materials.
5. Naming/folder convention drift.

## Hard locks
- Read-only by default; any fix is a separate APPROVE step
- No mass reimport without stating cost

## Return format
SCANNED_COUNT / ISSUES(by category) / SEVERITY / SUGGESTED_FIXES / ONE_NEXT_ACTION
