---
name: unity-test-harness
description: >-
  Create EditMode/PlayMode tests with the Unity Test Runner (NUnit) including SetUp/TearDown
  and cleanup discipline. Use this WHENEVER Igor mentions tests, Test Runner, EditMode,
  PlayMode, cleanup, TearDown, or asks to verify a tool/behaviour before merge (e.g. TMP_001).
---
# Unity Test Harness

## When to use
Authoring tests for ToolLab tools/behaviours. Ties directly to TMP_001 cleanup workflow.

## Hard locks
- Tests under Assets/ToolLab/Tests/ (asmdef with UnityEngine.TestRunner refs)
- TearDown MUST DestroyImmediate created objects (no leaked GameObjects between tests)
- No scene save; no git; PlayMode only if behaviour needs runtime
- Running the Test Runner is a MANUAL Igor action — skill scaffolds, does not claim PASS

## Procedure
1. Identify behaviour + edge cases (e.g. Mathf.Clamp01 on alpha).
2. EditMode test class with [SetUp]/[TearDown]; create+destroy per test.
3. Arrange-Act-Assert; one assert-intent per test.
4. Output TEST_STATUS = SCAFFOLDED (await manual Test Runner run).

## Return format
TESTS_CREATED / COVERAGE_NOTES / TEST_STATUS(SCAFFOLDED) / ONE_NEXT_ACTION(run Test Runner)
