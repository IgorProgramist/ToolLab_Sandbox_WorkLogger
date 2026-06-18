# Commit Protocol
<!-- ToolLab_Sandbox_WorkLogger | Updated: 2026-06-18 -->

## Rule: No commit without explicit Igor approval

AI agents MUST NOT run `git add`, `git commit`, `git push`, or `git stage` commands
unless Igor has explicitly approved the specific commit in the current session.

---

## What MAY be staged (registry/workflow tasks)

```
git add Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md
git add Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv
git add Assets/ToolLab/Docs/TOOLLAB_ACTION_PLAN.md
git add AI_WORKFLOW/
git add CLAUDE.md          # only if modified this session
git add AGENTS.md          # only if modified this session
```

## What MUST NOT be staged

```
Assets/ToolLab/Runtime/**       — DO_NOT_TOUCH
Assets/ToolLab/Tests/**         — DO_NOT_TOUCH
ProjectSettings/**
Packages/**
UserSettings/**
.mcp.json
Library/**
Temp/**
Logs/**
Assets/Scenes/**
Assets/Settings/**
```

---

## Suggested commit message format (for Igor to run)

```
git commit -m "chore: add ToolLab AI_WORKFLOW and V4.3 registry

- AI_WORKFLOW/ bootstrapped (20 files)
- Registry: TOOLLAB_WORK_LOG.md + TOOLLAB_WORK_LOG.csv (100 utilities)
- Docs: TOOLLAB_ACTION_PLAN.md (B01-B10)
- CLAUDE.md: registry route override added
- AGENTS.md: created

TMP_001: CLOSED_BY_OPERATOR. Runtime/Tests: untouched."
```

---

## Pre-commit checklist (for Igor)

- [ ] `git status` — confirm only allowed paths are staged
- [ ] `git diff --cached` — review what will actually be committed
- [ ] No Runtime files in staging area
- [ ] No Tests files in staging area
- [ ] No ProjectSettings in staging area
- [ ] Commit message describes the registry/workflow change, not code changes
