---
name: unity-editorwindow-scaffold
description: >-
  Scaffold a Unity EditorWindow / IMGUI tool under HDRP with UnityToolLab.* namespace,
  Undo-safe mutations, MenuItem entry, and LOG_SCHEMA v1.2 logging. Use this WHENEVER Igor
  asks to create an Editor tool, EditorWindow, custom inspector, drawer, batch utility, or
  asset auditor in Assets/ToolLab/ — even if he doesn't say the word "skill".
---
# Unity EditorWindow Scaffold

## When to use
Editor-side tools: EditorWindow, IMGUI panels, batch utilities, asset auditors. Sandbox only.

## Hard locks (always)
- FILES_ALLOWED: Assets/ToolLab/Editor/ only
- No git, no package install, no manifest.json edit, no scene save, no batchmode build
- Wrap every mutation in Undo.RegisterCompleteObjectUndo (or Undo.RecordObject) BEFORE change
- Unity API: VALIDATE_FIRST vs Unity 6 (6000.3.9f1) Manual — do not trust 2022 API from memory
- namespace UnityToolLab.Editor

## Procedure
1. Confirm tool name <Name> + target subfolder.
2. Create <Name>Window.cs : EditorWindow in Assets/ToolLab/Editor/.
3. Add [MenuItem("ToolLab/<Name>")] static Open().
4. OnGUI: minimal controls only (no premature flexibility — Karpathy SIMPLICITY).
5. Mutations: Undo first, then AssetDatabase.SaveAssets/Refresh only if required.
6. Log action via ToolLabWorkLogger (LOG_SCHEMA v1.2) if available.

## Return format
FILES_CREATED / FILES_MODIFIED / SAFETY_CHECK / TEST_STATUS / LIMITATIONS / ONE_NEXT_ACTION
