# Registry Index
<!-- ToolLab_Sandbox_WorkLogger | V4.3 | Updated: 2026-06-18 -->

## Canonical registry files

| File | Purpose | Row count |
|------|---------|-----------|
| [Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md](../Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md) | Human-readable registry | 100 utilities |
| [Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv](../Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv) | Machine-readable registry | 100 rows |
| [Assets/ToolLab/Docs/TOOLLAB_ACTION_PLAN.md](../Assets/ToolLab/Docs/TOOLLAB_ACTION_PLAN.md) | Batch execution plan | B01–B10 |

---

## Batch summary

| Batch | Range | Category | Done | In Progress | Planned |
|-------|-------|----------|------|-------------|---------|
| B01 | UTL-001–010 | Core Logging | 2 | 0 | 8 |
| B02 | UTL-011–020 | TMP / Text | 2* | 0 | 8 |
| B03 | UTL-021–030 | Editor Utilities | 0 | 0 | 10 |
| B04 | UTL-031–040 | Scene Tools | 0 | 0 | 10 |
| B05 | UTL-041–050 | Asset Pipeline | 0 | 0 | 10 |
| B06 | UTL-051–060 | Shader / VFX | 0 | 0 | 10 |
| B07 | UTL-061–070 | UI Components | 0 | 0 | 10 |
| B08 | UTL-071–080 | Diagnostics | 0 | 0 | 10 |
| B09 | UTL-081–090 | Automation | 0 | 0 | 10 |
| B10 | UTL-091–100 | Integrations | 0 | 0 | 10 |

*B02: UTL-011/012 are CLOSED_BY_OPERATOR (TMP_001), not DONE.

---

## Status counts (2026-06-18)

| Status | Count |
|--------|-------|
| DONE | 2 |
| CLOSED_BY_OPERATOR | 2 |
| IN_PROGRESS | 0 |
| PLANNED | 96 |
| BLOCKED | 0 |
| CANCELLED | 0 |
| **Total** | **100** |

---

## How to update

1. Edit `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.md` — update the row status, commit_sha, proof_ref.
2. Edit `Assets/ToolLab/Registry/TOOLLAB_WORK_LOG.csv` — same row, same fields.
3. Update status counts in this file.
4. Add a WORK_LOG.md entry.
5. Do NOT edit both files in different states — keep MD and CSV in sync.
