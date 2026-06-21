---
name: unity-worklog-writer
description: >-
  Write canonical work-log entries in LOG_SCHEMA v1.2 for ToolLab sessions. Use this WHENEVER
  Igor asks to log an action, append to WorkLogger, record a session, or produce a work-log row.
---
# Unity WorkLog Writer (LOG_SCHEMA v1.2)

## When to use
Recording tool actions into the canonical work log / WorkLogger sink.

## Schema (LOG_SCHEMA v1.2 — confirm fields against project canon)
session_id ; timestamp ; lane(APP/MCP/TOOLLAB/SANDBOX) ; action ; files_touched ; result ; next_action
- session_id rules per project; never invent a session_id — read current or ask.

## Hard locks
- Append-only; never rewrite past rows
- No final-readiness / BUG_FIXED_ACTIVE claims in result field
- English field values; Ukrainian only in free-text notes if needed

## Return format
ROW_WRITTEN / SCHEMA_CHECK / ONE_NEXT_ACTION
