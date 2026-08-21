# CV Professional Experience Rewrite Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Generate a new five-page CV PDF in which all 22 projects remain independent and use source-grounded professional construction terminology.

**Architecture:** Extend the existing deterministic ReportLab/PyMuPDF builder to redact and redraw only the experience regions on pages 1-4 while preserving the source header, profile, formation, references, yellow timeline, and page structure. Store experience content as immutable page-grouped data, render it with compact reusable styles, and verify the output by text inventory plus PNG inspection.

**Tech Stack:** Python 3.12, reportlab, pypdf, PyMuPDF, Poppler (`pdfinfo`, `pdftoppm`)

---

### Task 1: Protect the source and define the experience inventory

**Files:**
- Read: `C:/Users/jeffr/Downloads/CV - Heiner Madrigal - Encargado de obras.pdf`
- Modify: `tmp/pdfs/build_cv_heiner_2026.py`
- Create: `tmp/pdfs/verify_cv_professional.py`

- [ ] Record the source PDF SHA-256 before editing.
- [ ] Add an immutable list of 22 experience dictionaries containing project, professional title, company, location, scope bullets, metraje, and crew size from the approved spec.
- [ ] Group entries into page distributions `4 / 7 / 7 / 4` for pages 1-4.
- [ ] Add a failing verifier that requires all 22 project labels, four independent Los Robles metrajes, five A4 pages, and a new output filename.
- [ ] Run the verifier before generation and confirm it fails because the new output does not yet exist.

### Task 2: Redraw all experience regions

**Files:**
- Modify: `tmp/pdfs/build_cv_heiner_2026.py`

- [ ] Change the output to `output/pdf/CV - Heiner Madrigal - experiencias profesionales 2026.pdf`.
- [ ] Redact only the experience text regions on pages 1-4; preserve left-side section labels, yellow timeline, header/profile, formation, and references.
- [ ] Extend `draw_block` with compact configurable title, company, location, and body styles suitable for dense pages.
- [ ] Render the 22 approved entries independently in chronological/source order.
- [ ] Generate the new PDF without overwriting the source or the prior derived PDF.

### Task 3: Verify content, preservation, and layout

**Files:**
- Read: `output/pdf/CV - Heiner Madrigal - experiencias profesionales 2026.pdf`
- Create: `tmp/pdfs/cv_heiner_2026/professional-final/page-*.png`
- Test: `tmp/pdfs/verify_cv_professional.py`

- [ ] Run the verifier and require exact project/company/location/metraje/crew inventory checks.
- [ ] Confirm the source SHA-256 is unchanged.
- [ ] Confirm the final PDF has five A4 pages and the 22 experiences appear once each.
- [ ] Render all five pages at 140 DPI with `pdftoppm`.
- [ ] Inspect every PNG for clipping, overlap, broken glyphs, timeline damage, and formation/reference preservation.
- [ ] Deliver only the verified professional PDF.
