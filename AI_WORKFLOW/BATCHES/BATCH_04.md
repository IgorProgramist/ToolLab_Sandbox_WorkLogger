# Batch L04 — Editor QA
<!-- ToolLab_Sandbox_WorkLogger | AI_WORKFLOW/BATCHES/ | Updated: 2026-06-18 -->

## Overview

**Goal:** Validate project structure and catch common editor issues early via menu-driven tools.
**Status:** PLANNED
**Depends on:** UTL-021 EditorWindowBase (PLANNED — implement first in this batch)

---

## Tasks

| ID | Task | File | Status | Test file |
|----|------|------|--------|-----------|
| L04-T0 | EditorWindowBase base class | Assets/ToolLab/Editor/EditorWindowBase.cs | PLANNED | — |
| L04-T1 | MissingScriptFinder | Assets/ToolLab/Editor/MissingScriptFinder.cs | PLANNED | L04-T4 |
| L04-T2 | FolderStructureValidator | Assets/ToolLab/Editor/FolderStructureValidator.cs | PLANNED | L04-T5 |
| L04-T3 | AssetSizeAuditor | Assets/ToolLab/Editor/AssetSizeAuditor.cs | PLANNED | — |
| L04-T4 | MissingScriptFinder tests | Assets/ToolLab/Tests/Editor/MissingScriptFinderTests.cs | PLANNED | — |
| L04-T5 | FolderStructureValidator tests | Assets/ToolLab/Tests/Editor/FolderStructureValidatorTests.cs | PLANNED | — |

---

## Implementation notes

- Namespace: `UnityToolLab.Editor`
- EditorWindowBase: abstract base, provides `[MenuItem]` pattern + log sink hook
- MissingScriptFinder: iterates all GameObjects in all open scenes, reports missing scripts
- FolderStructureValidator: checks against a hardcoded expected folder list
- AssetSizeAuditor: scans `AssetDatabase`, reports assets over configurable byte threshold
- All results logged to JSONL via ToolLabWorkLogger (`type="action"`)

---

## Verify criteria

1. MissingScriptFinder finds a known missing script in a test prefab.
2. FolderStructureValidator flags a missing required folder.
3. AssetSizeAuditor reports correctly sized assets.
4. L04-T4/T5 tests pass.

---

## Definition of done

- [ ] EditorWindowBase.cs compiles
- [ ] MissingScriptFinder.cs compiles
- [ ] FolderStructureValidator.cs compiles
- [ ] AssetSizeAuditor.cs compiles
- [ ] MissingScriptFinderTests.cs — all pass
- [ ] FolderStructureValidatorTests.cs — all pass
- [ ] Registry rows UTL-021, UTL-026, UTL-028, UTL-044 updated
- [ ] WORK_LOG.md entry added
