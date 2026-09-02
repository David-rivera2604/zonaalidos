# CV Talamanca Technical Language Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Replace the Talamanca experience block with the exact approved technical wording while preserving the five-page CV layout and all other content.

**Architecture:** Update only the Talamanca bullet list in the existing deterministic PDF builder. Regenerate the derived PDF from the preserved source, then validate text, pagination, dimensions, and rendered appearance with pypdf and Poppler.

**Tech Stack:** Python 3.12, reportlab, pypdf, PyMuPDF, Poppler (`pdfinfo`, `pdftoppm`)

---

### Task 1: Preserve a baseline for comparison

**Files:**
- Read: `output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf`
- Create: `tmp/pdfs/cv_heiner_2026/baseline-before-technical-update.pdf`
- Create: `tmp/pdfs/verify_cv_talamanca.py`

- [ ] **Step 1: Copy the current derived PDF as a temporary baseline**

Run:

```powershell
Copy-Item -LiteralPath 'output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf' -Destination 'tmp/pdfs/cv_heiner_2026/baseline-before-technical-update.pdf' -Force
```

Expected: the baseline file exists and has five A4 pages.

- [ ] **Step 2: Create a deterministic verification script**

Create `tmp/pdfs/verify_cv_talamanca.py` with this block rule and normalization:

```python
import re
import sys
import unicodedata
from pypdf import PdfReader

baseline_path, final_path = sys.argv[1:3]

def normalized(value: str) -> str:
    return " ".join(unicodedata.normalize("NFC", value).split())

def pages(path: str) -> list[str]:
    return [page.extract_text() or "" for page in PdfReader(path).pages]

block_pattern = re.compile(
    r"Área de Salud - Talamanca\s+Navarro y Avilés\s+"
    r"Talamanca, Limón - 2026\s+.*?\s+"
    r"(?=Área de Salud - Aguas Zarcas)",
    re.DOTALL,
)

expected = normalized("""
Área de Salud - Talamanca
Navarro y Avilés
Talamanca, Limón - 2026
Maestro de obras general certificado, responsable de la planificación,
coordinación y supervisión integral de la construcción del edificio y sus
obras de infraestructura, con un área aproximada de 6.500 m² distribuida en
dos niveles.
Dirección y coordinación de aproximadamente 150 trabajadores, entre personal
propio y contratistas, organizando frentes de trabajo y verificando el
cumplimiento de planos, especificaciones técnicas, calidad y avance de obra.
""")

baseline = pages(baseline_path)
final = pages(final_path)
assert len(baseline) == len(final) == 5
match = block_pattern.search(final[0])
assert match, "Talamanca block not found"
assert normalized(match.group(0)) == expected, "Approved wording mismatch"
assert final[0].count("Área de Salud - Talamanca") == 1
assert "Proyecto KALMA" in final[2]

baseline_outside = block_pattern.sub("<TALAMANCA>", baseline[0])
final_outside = block_pattern.sub("<TALAMANCA>", final[0])
assert normalized(baseline_outside) == normalized(final_outside)
for old_page, new_page in zip(baseline[1:], final[1:]):
    assert normalized(old_page) == normalized(new_page)

reader = PdfReader(final_path)
for page in reader.pages:
    width = float(page.mediabox.width)
    height = float(page.mediabox.height)
    assert abs(width - 595.5) < 0.1 and abs(height - 842.25) < 0.1
print("PASS: exact wording, untouched content, five A4 pages")
```

Expected: the script defines an exact normalized-text comparison and a page-by-page non-target comparison.

### Task 2: Apply the exact approved wording

**Files:**
- Modify: `tmp/pdfs/build_cv_heiner_2026.py`

- [ ] **Step 1: Replace only the Talamanca bullet list**

Use exactly:

```python
bullets=[
    "<b>Maestro de obras general certificado</b>, responsable de la planificación, coordinación y supervisión integral de la construcción del edificio y sus obras de infraestructura, con un área aproximada de <b>6.500 m² distribuida en dos niveles</b>.",
    "Dirección y coordinación de aproximadamente <b>150 trabajadores</b>, entre personal propio y contratistas, organizando frentes de trabajo y verificando el cumplimiento de planos, especificaciones técnicas, calidad y avance de obra.",
]
```

Expected: no title, company, location, date, or non-Talamanca block changes.

- [ ] **Step 2: Regenerate the PDF**

Run:

```powershell
& 'C:\Users\jeffr\.cache\codex-runtimes\codex-primary-runtime\dependencies\python\python.exe' 'tmp/pdfs/build_cv_heiner_2026.py'
```

Expected: `output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf` is recreated successfully.

### Task 3: Verify content and layout

**Files:**
- Read: `tmp/pdfs/cv_heiner_2026/baseline-before-technical-update.pdf`
- Read: `output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf`
- Create: `tmp/pdfs/cv_heiner_2026/technical-final/page-*.png`

- [ ] **Step 1: Verify exact wording, structural invariants, and untouched content**

Run:

```powershell
& 'C:\Users\jeffr\.cache\codex-runtimes\codex-primary-runtime\dependencies\python\python.exe' 'tmp/pdfs/verify_cv_talamanca.py' 'tmp/pdfs/cv_heiner_2026/baseline-before-technical-update.pdf' 'output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf'
```

Expected: `PASS: exact wording, untouched content, five A4 pages`.

- [ ] **Step 3: Render and inspect all pages**

Run:

```powershell
pdftoppm -png -r 140 'output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf' 'tmp/pdfs/cv_heiner_2026/technical-final/page'
```

Expected: no clipping, overlaps, damaged glyphs, or unexpected page breaks; the Talamanca entry remains first.

- [ ] **Step 4: Deliver the verified PDF**

Provide the final artifact from `output/pdf/CV - Heiner Madrigal - Encargado de obras - actualizado 2026.pdf`.
