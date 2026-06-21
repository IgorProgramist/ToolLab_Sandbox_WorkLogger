---
name: unity-tool-safety-audit
description: >-
  Audit a Unity Editor/runtime tool for sandbox safety, Undo correctness, and hard-lock
  compliance before merge. Use this WHENEVER Igor asks to review a tool for safety, check
  Undo, verify it stays in sandbox, or asks "is this tool safe / ready to merge".
---
# Unity Tool Safety Audit

## When to use
Pre-merge safety pass on any ToolLab tool. Read-only review (does not modify code).

## Checklist
1. PATHS: writes only inside declared FILES_ALLOWED? Any stray Assets/ writes?
2. UNDO: every mutation preceded by Undo.RecordObject / RegisterCompleteObjectUndo?
3. DESTRUCTIVE: DeleteAsset / DestroyImmediate / SaveScene present? → must be gated.
4. GIT/PACKAGES: any process call to git, UPM install, manifest edit? → BLOCKER.
5. API: HDRP/Unity6 calls flagged VALIDATE_FIRST where uncertain?
6. LOGGING: writes LOG_SCHEMA v1.2 session_id correctly?
7. CLAIMS: no "BUG_FIXED_ACTIVE" / final-readiness claims.

## Return format
VERDICT: PASS / PASS_WITH_FIXES / FAIL
WHAT_WORKS / BLOCKERS / NON_BLOCKERS / REQUIRED_FIXES / NEXT_ACTION
(Review PASS != merge approval.)
