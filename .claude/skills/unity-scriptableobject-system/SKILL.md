---
name: unity-scriptableobject-system
description: >-
  Design a ScriptableObject-based data system (config, inventory, item DB, settings) for Unity.
  Use this WHENEVER Igor asks for data architecture, ScriptableObjects, item/inventory/config
  system, or data-driven design instead of hardcoded values.
---
# Unity ScriptableObject System

## When to use
Data-driven systems: item DB, inventory, config, tunable settings, registries.

## Hard locks
- SO assets under Assets/ToolLab/Data/ (or stated folder); namespace UnityToolLab.Data
- CreateAssetMenu attributes for authoring
- No singletons-by-default; prefer explicit references / a single registry SO
- Keep it minimal — no inheritance trees for single-use data

## Procedure
1. List entities + fields before coding.
2. One SO type per entity; [CreateAssetMenu(menuName="ToolLab/Data/<X>")].
3. Optional registry SO holding a List<T> for lookup.
4. Editor authoring only; runtime reads, no runtime writes unless asked.

## Return format
ENTITIES / FILES_CREATED / SAFETY_CHECK / ONE_NEXT_ACTION
