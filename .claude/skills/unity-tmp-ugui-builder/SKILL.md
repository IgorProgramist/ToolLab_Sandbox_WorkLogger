---
name: unity-tmp-ugui-builder
description: >-
  Build in-game/editor UI with uGUI/Canvas/RectTransform and TextMeshProUGUI following Igor's
  conventions. Use this WHENEVER Igor mentions HUD, Canvas, panel, button, inventory screen,
  TMP text, label, or any UI layout — NOT UI Toolkit unless explicitly asked.
---
# Unity uGUI/TMP Builder

## When to use
Any uGUI UI: HUD, panels, menus, inventory, labels. Default to uGUI, never UI Toolkit unless asked.

## Hard locks
- Text: TextMeshProUGUI for ALL UI text (never legacy Text)
- Alpha/fade: animate TMP color alpha (color.a) or CanvasGroup.alpha — not GameObject active toggles
- Anchors/pivots explicit; no hardcoded pixel positions without RectTransform anchoring
- FILES_ALLOWED stated per task; namespace UnityToolLab.UI for scripts

## Procedure
1. Define hierarchy: Canvas > Panel > children (list it before creating).
2. Set RectTransform anchors/pivot intentionally (state choice).
3. TMP for text; CanvasGroup for show/hide + fade.
4. Wire references via SerializeField; no GameObject.Find in runtime hot paths.

## Return format
HIERARCHY_PLANNED / FILES_CREATED / SAFETY_CHECK / ONE_NEXT_ACTION
