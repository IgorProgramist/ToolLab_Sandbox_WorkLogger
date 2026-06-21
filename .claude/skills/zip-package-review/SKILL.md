---
name: zip-package-review
description: >-
  Review a ZIP/package/build: open it, check structure, MANIFEST.json, missing/extra files,
  hashes, hidden approvals, dangerous claims. Use this WHENEVER Igor uploads a ZIP/package or
  asks to review, smoke-test, or verify a build/package.
---
# ZIP / Package Review (Smoke)

## When to use
Any ZIP/package/build/review task.

## Procedure
1. Does the ZIP open? Print file tree.
2. Structure sane? Expected folders present?
3. MANIFEST.json present → compare listed vs actual; recompute sha256.
4. Missing / extra files; secrets accidentally bundled (auth/tokens) → BLOCKER.
5. Hidden approvals / "BUG_FIXED_ACTIVE" / final-readiness claims → flag.
6. Separate blockers vs non-blockers.

## Hard locks
- Review PASS != upload/adoption approval
- Self-review = evidence, not final authority

## Return format
VERDICT: PASS / PASS_WITH_FIXES / FAIL
WHAT_WORKS / BLOCKERS / NON_BLOCKERS / REQUIRED_FIXES / NEXT_ACTION
