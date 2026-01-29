/**
         * VISTA: Generador HTML
         */
class CrudHtmlGenerator {

    static renderBase(scope, config) {
        const kpiSection = config.showKPIs ? '<div data-element="kpi-container" class="row mb-4"></div>' : '';
        const tableView = this._renderTableView(scope, config);

        let editContainer = '';
        if (config.editMode === 'modal') {
            editContainer = this._renderModal(scope, config);
        } else if (config.editMode === 'page') {
            editContainer = this._renderPageView(scope, config);
        } else {
            editContainer = this._renderSidebar(scope, config);
        }

        return `
                    <div class="crud-container position-relative" id="${scope}-root">
                        <!-- Sección KPI (Opcional) -->
                        ${kpiSection}

                        <!-- Contenedor Tabla -->
                        <div data-element="view-table" class="table-view">
                            ${tableView}
                        </div>

                        <!-- Contenedor Edición -->
                        ${editContainer}

                        <div class="panel-overlay" data-element="overlay" data-action="close-edit"></div>
                    </div>
                `;
    }

    static renderKPIs(kpis) {
        if (!kpis || kpis.length === 0) return '';
        const colSize = Math.max(3, Math.floor(12 / kpis.length));

        return kpis.map(kpi => `
                    <div class="col-md-${colSize} mb-3 mb-md-0">
                        <div class="kpi-card kpi-border-${kpi.color || 'primary'}">
                            <div class="kpi-title">${kpi.title}</div>
                            <div class="kpi-value kpi-text-${kpi.color || 'primary'}">${kpi.value}</div>
                            <div class="kpi-icon text-${kpi.color || 'primary'}">
                                <i class="fa ${kpi.icon || 'fa-bar-chart'}"></i>
                            </div>
                        </div>
                    </div>
                `).join('');
    }

    static _renderTableView(scope, config) {
        const tableCols = config.columns.filter(c => !c.hiddenInTable);
        const searchPlaceholder = config.searchPlaceholder || "Buscar registros...";

        return `
                    <div class="d-flex flex-column flex-md-row align-items-md-center justify-content-between mb-4">
                        <div>
                            <h4 class="font-weight-bold mb-1 text-dark" style="margin:0;">${config.title}</h4>
                            <p class="small text-muted mb-0">Gestión de datos</p>
                        </div>
                        <div class="mt-3 mt-md-0">
                             <button class="btn btn-white mr-2" data-action="export">
                                <i class="fa fa-download mr-2 text-muted"></i>Exportar
                            </button>
                            <button class="btn btn-outline-danger mr-2 d-none" data-element="btn-bulk-delete" data-action="bulk-delete">
                                <i class="fa fa-trash mr-2"></i> Eliminar (<span data-element="count-selected">0</span>)
                            </button>
                            <button class="btn btn-primary shadow-sm" data-action="create">
                                <i class="fa fa-plus mr-2"></i>Nuevo
                            </button>
                        </div>
                    </div>
                    
                    <div class="main-card position-relative">
                        <div class="loader-overlay" data-element="loader">
                            <div class="spinner-border text-primary" role="status"></div>
                        </div>

                        <div class="p-3 border-bottom d-flex align-items-center justify-content-between bg-white">
                            <div class="position-relative" style="width: 100%; max-width: 320px;">
                                <i class="fa fa-search position-absolute text-muted" style="left: 15px; top: 12px; z-index:2;"></i>
                                <input type="text" class="form-control" style="padding-left: 40px;" placeholder="${searchPlaceholder}" data-role="search-input">
                            </div>
                            <small class="text-muted font-weight-bold ml-3" data-element="table-info"></small>
                        </div>

                        <div class="table-responsive">
                            <table class="table table-hover mb-0">
                                <thead>
                                    <tr>
                                        <th class="pl-4" style="width: 50px;">
                                            <div class="custom-control custom-checkbox">
                                                <input type="checkbox" class="custom-control-input" id="${scope}-master-check" data-action="toggle-all">
                                                <label class="custom-control-label" for="${scope}-master-check"></label>
                                            </div>
                                        </th>
                                        ${tableCols.map(c => {
            const respClass = c.responsive ? `d-none d-${c.responsive}-table-cell` : '';
            return `<th class="${respClass}">${c.label}</th>`;
        }).join('')}
                                        <th class="text-right pr-4">Acciones</th>
                                    </tr>
                                </thead>
                                <tbody data-element="table-body"></tbody>
                            </table>
                        </div>

                        <div class="p-3 d-flex justify-content-end bg-white border-top">
                            <nav><ul class="pagination mb-0" data-element="pagination-list"></ul></nav>
                        </div>
                    </div>
                `;
    }

    static _renderSidebar(scope, config) {
        const width = config.size || '500px';
        // Añadimos max-width: 100vw para móviles
        return `
                    <div class="side-panel" data-element="view-edit" style="width: ${width}; max-width: 100vw;">
                        <div class="px-4 py-4 border-bottom d-flex justify-content-between align-items-center flex-shrink-0">
                            <div>
                                <h5 class="mb-0 font-weight-bold text-dark" data-element="form-title">Registro</h5>
                            </div>
                            <button class="btn btn-icon-only btn-light text-muted" data-action="close-edit"><i class="fa fa-times"></i></button>
                        </div>
                        
                        <!-- Cuerpo con scroll -->
                        <div class="flex-grow-1 overflow-auto bg-light">
                            <div class="bg-white p-4 m-4 rounded shadow-sm border">
                                ${this._renderForm(scope, config)}
                            </div>
                        </div>
                        
                        <!-- Footer fijo al fondo del panel gracias a flexbox -->
                        <div class="side-panel-footer">
                            <button class="btn btn-white mr-2" data-action="close-edit">Cancelar</button>
                            <button type="submit" form="${scope}-form" class="btn btn-primary px-4 shadow-sm">Guardar</button>
                        </div>
                    </div>
                `;
    }

    static _renderModal(scope, config) {
        const sizeClass = config.size || '';
        return `
                    <div class="modal fade" id="${scope}-modal" tabindex="-1" role="dialog" aria-hidden="true" data-element="view-edit-modal">
                        <div class="modal-dialog ${sizeClass} modal-dialog-centered" role="document">
                            <div class="modal-content border-0 shadow-lg overflow-hidden">
                                <div class="modal-header border-bottom-0 pb-0">
                                    <h5 class="modal-title font-weight-bold" data-element="form-title">Registro</h5>
                                    <button type="button" class="close" data-action="close-edit" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                </div>
                                <div class="modal-body p-4">
                                    ${this._renderForm(scope, config)}
                                </div>
                                <div class="modal-footer border-top-0 pt-0 bg-light pb-3 pr-4">
                                    <button type="button" class="btn btn-white" data-action="close-edit">Cancelar</button>
                                    <button type="submit" form="${scope}-form" class="btn btn-primary">Guardar</button>
                                </div>
                            </div>
                        </div>
                    </div>
                `;
    }

    static _renderPageView(scope, config) {
        return `
                    <div class="page-view" data-element="view-edit-page">
                        <div class="card main-card shadow-lg">
                             <div class="card-header bg-white py-4 d-flex justify-content-between align-items-center border-bottom">
                                <div>
                                    <h4 class="mb-0 font-weight-bold text-dark" data-element="form-title">Registro</h4>
                                    <p class="text-muted mb-0 small">Edición en pantalla completa</p>
                                </div>
                                <button class="btn btn-icon-only btn-light" data-action="close-edit"><i class="fa fa-times"></i></button>
                            </div>
                            <div class="card-body p-5 bg-light">
                                <div class="bg-white p-5 rounded shadow-sm border" style="max-width: 900px; margin: 0 auto;">
                                    ${this._renderForm(scope, config)}
                                </div>
                            </div>
                            <div class="card-footer bg-white py-3 text-right">
                                <button class="btn btn-white mr-2" data-action="close-edit">Volver</button>
                                <button type="submit" form="${scope}-form" class="btn btn-primary px-5">Guardar Registro</button>
                            </div>
                        </div>
                    </div>
                `;
    }

    static _renderForm(scope, config) {
        const formCols = config.columns.filter(c => !c.hiddenInForm);
        return `
                    <form id="${scope}-form" data-role="crud-form">
                        <div class="form-row">
                            ${formCols.map(col => this._renderField(col)).join('')}
                        </div>
                    </form>
                `;
    }

    static _renderField(col) {
        const colSize = col.formCol ? `col-md-${col.formCol}` : 'col-12';
        let inputHtml = '';

        if (col.type === 'select' && col.options) {
            inputHtml = `<select name="${col.name}" class="form-control custom-select"><option value="">Seleccione...</option>${col.options.map(o => `<option value="${o}">${o}</option>`).join('')}</select>`;
        } else if (col.type === 'textarea') {
            inputHtml = `<textarea name="${col.name}" class="form-control" rows="3"></textarea>`;
        } else {
            inputHtml = `<input type="${col.type || 'text'}" name="${col.name}" class="form-control" ${col.readonly ? 'readonly' : ''}>`;
        }

        return `
                    <div class="form-group ${colSize} mb-4">
                        <label class="small font-weight-bold text-uppercase text-muted mb-2" style="font-size: 0.7rem;">${col.label}</label>
                        ${inputHtml}
                    </div>
                `;
    }

    static generateRows(items, columns, selectedSet, scope) {
        if (!items || items.length === 0) return `<tr><td colspan="100%" class="text-center py-5 text-muted">No se encontraron datos</td></tr>`;

        const tableCols = columns.filter(c => !c.hiddenInTable);

        return items.map(i => {
            const isSelected = selectedSet.has(i.id);
            return `
                    <tr class="${isSelected ? 'table-active' : ''}">
                        <td class="pl-4">
                            <div class="custom-control custom-checkbox">
                                <input type="checkbox" class="custom-control-input" id="${scope}-chk-${i.id}" 
                                    ${isSelected ? 'checked' : ''} 
                                    data-action="toggle-one" data-id="${i.id}">
                                <label class="custom-control-label" for="${scope}-chk-${i.id}"></label>
                            </div>
                        </td>
                        ${tableCols.map(c => {
                const respClass = c.responsive ? `d-none d-${c.responsive}-table-cell` : '';
                return `<td class="${respClass}"><span class="font-weight-medium">${i[c.name] || '-'}</span></td>`;
            }).join('')}
                        <td class="text-right pr-4">
                            <div class="d-inline-block">
                                <i class="fa fa-pencil action-icon mr-2" data-action="edit" data-id="${i.id}" title="Editar"></i>
                                <i class="fa fa-trash action-icon text-danger" data-action="delete" data-id="${i.id}" title="Eliminar"></i>
                            </div>
                        </td>
                    </tr>`;
        }).join('');
    }

    static generatePagination(meta) {
        const { page, totalPages } = meta;
        if (!totalPages || totalPages <= 1) return '';
        let html = '';
        const renderLi = (p, text, disabled, active) => `<li class="page-item ${disabled ? 'disabled' : ''} ${active ? 'active' : ''}"><button class="page-link shadow-none" data-action="paginate" data-page="${p}">${text}</button></li>`;
        html += renderLi(page - 1, '<i class="fa fa-chevron-left"></i>', page === 1, false);
        for (let i = 1; i <= totalPages; i++) html += renderLi(i, i, false, i === page);
        html += renderLi(page + 1, '<i class="fa fa-chevron-right"></i>', page === totalPages, false);
        return html;
    }
}

/**
 * MODELO: DataService
 */
class DataService {
    constructor(res, data) {
        this.key = `db_kpi_${res}`;
        if (!localStorage.getItem(this.key)) localStorage.setItem(this.key, JSON.stringify(data || []));
    }

    async query({ search = '', page = 1, limit = 5 } = {}) {
        await new Promise(r => setTimeout(r, 400));
        let allData = JSON.parse(localStorage.getItem(this.key) || '[]');
        if (search) {
            const q = search.toLowerCase();
            allData = allData.filter(d => Object.values(d).some(v => String(v).toLowerCase().includes(q)));
        }
        const total = allData.length;
        const totalPages = Math.ceil(total / limit);
        const startIndex = (page - 1) * limit;
        const endIndex = startIndex + limit;
        return { items: allData.slice(startIndex, endIndex), meta: { total, totalPages, page, limit } };
    }

    async getKPIs(search = '') {
        let data = JSON.parse(localStorage.getItem(this.key) || '[]');

        if (search) {
            const q = search.toLowerCase();
            data = data.filter(d => Object.values(d).some(v => String(v).toLowerCase().includes(q)));
        }

        const total = data.length;
        let totalValue = 0;
        let maxValue = 0;

        data.forEach(item => {
            if (item.precio) totalValue += parseFloat(item.precio);
            if (item.stock) totalValue += parseFloat(item.stock);
            if (item.precio && item.precio > maxValue) maxValue = item.precio;
        });

        return [
            { title: "Total Registros", value: total, color: "primary", icon: "fa-database" },
            { title: "Valor Acumulado", value: totalValue > 0 ? `$${totalValue.toLocaleString()}` : 'N/A', color: "success", icon: "fa-usd" },
            { title: "Valor Máximo", value: maxValue > 0 ? `$${maxValue.toLocaleString()}` : 'N/A', color: "warning", icon: "fa-line-chart" },
            { title: "Alertas", value: "0", color: "danger", icon: "fa-exclamation-triangle" }
        ];
    }

    async save(item) {
        let allData = JSON.parse(localStorage.getItem(this.key) || '[]');
        if (item.id) allData = allData.map(d => d.id === item.id ? { ...d, ...item } : d);
        else { item.id = Date.now().toString(); allData.push(item); }
        localStorage.setItem(this.key, JSON.stringify(allData));
    }

    async delete(ids) {
        let allData = JSON.parse(localStorage.getItem(this.key) || '[]');
        const idsToDelete = (Array.isArray(ids) ? ids : [ids]).map(String);
        allData = allData.filter(d => !idsToDelete.includes(String(d.id)));
        localStorage.setItem(this.key, JSON.stringify(allData));
    }

    async getAll() { return JSON.parse(localStorage.getItem(this.key) || '[]'); }
}

/**
 * CONTROLADOR: BootstrapCrud
 */
class BootstrapCrud {
    constructor(containerId, config) {
        this.root = document.getElementById(containerId);
        this.config = config;
        this.scope = `scope-${Math.floor(Math.random() * 100000)}`;
        this.model = new DataService(config.resource, config.demoData);
        this.state = { items: [], selected: new Set(), editingId: null, search: '', page: 1, limit: config.limit || 5, meta: {} };
        this.init();
    }

    init() {
        this.root.innerHTML = CrudHtmlGenerator.renderBase(this.scope, this.config);
        this.cacheDom();
        this.bindEvents();
        this.refresh();
    }

    cacheDom() {
        const $ = s => this.root.querySelector(s);
        this.dom = {
            tbody: $('[data-element="table-body"]'), form: $('[data-role="crud-form"]'),
            loader: $('[data-element="loader"]'), pagination: $('[data-element="pagination-list"]'),
            tableInfo: $('[data-element="table-info"]'), searchInput: $('[data-role="search-input"]'),
            modal: $(`#${this.scope}-modal`), sidebar: $('[data-element="view-edit"]'),
            pageView: $('[data-element="view-edit-page"]'), tableView: $('[data-element="view-table"]'),
            overlay: $('[data-element="overlay"]'), title: $('[data-element="form-title"]'),
            bulkBtn: $('[data-element="btn-bulk-delete"]'), countSelected: $('[data-element="count-selected"]'),
            masterCheck: $(`#${this.scope}-master-check`),
            kpiContainer: $('[data-element="kpi-container"]')
        };
    }

    bindEvents() {
        this.root.addEventListener('click', e => {
            if (e.target.tagName === 'INPUT') return;
            const t = e.target.closest('[data-action]');
            if (!t) return;
            const act = t.dataset.action;
            if (act === 'create') this.openForm();
            if (act === 'edit') this.edit(t.dataset.id);
            if (act === 'delete') this.remove([t.dataset.id]);
            if (act === 'close-edit') this.closeForm();
            if (act === 'bulk-delete') this.removeBulk();
            if (act === 'export') this.exportData();
            if (act === 'paginate') { e.preventDefault(); this.state.page = parseInt(t.dataset.page); this.refresh(); }
        });

        this.root.addEventListener('change', e => {
            const t = e.target.closest('input[type="checkbox"][data-action]');
            if (!t) return;
            if (t.dataset.action === 'toggle-one') this.toggleOne(t.dataset.id);
            if (t.dataset.action === 'toggle-all') this.toggleAll(t.checked);
        });

        let timeout;
        this.dom.searchInput.addEventListener('input', (e) => {
            clearTimeout(timeout);
            timeout = setTimeout(() => { this.state.search = e.target.value; this.state.page = 1; this.refresh(); }, 500);
        });

        this.dom.form.addEventListener('submit', e => { e.preventDefault(); this.save(); });
    }

    async refresh() {
        this.dom.loader.style.display = 'flex';

        const promises = [this.model.query({ search: this.state.search, page: this.state.page, limit: this.state.limit })];
        if (this.config.showKPIs) promises.push(this.model.getKPIs(this.state.search));

        const [res, kpis] = await Promise.all(promises);

        this.state.items = res.items;
        this.state.meta = res.meta;

        this.renderTable();
        this.renderPagination();
        this.updateBulkUI();

        if (this.config.showKPIs && kpis && this.dom.kpiContainer) {
            this.dom.kpiContainer.innerHTML = CrudHtmlGenerator.renderKPIs(kpis);
        }

        this.dom.loader.style.display = 'none';
    }

    renderTable() {
        this.dom.tbody.innerHTML = CrudHtmlGenerator.generateRows(this.state.items, this.config.columns, this.state.selected, this.scope);
        const { total, page } = this.state.meta;
        this.dom.tableInfo.innerText = total > 0 ? `${(page - 1) * this.state.limit + 1}-${Math.min(page * this.state.limit, total)} de ${total}` : '';
    }

    renderPagination() { this.dom.pagination.innerHTML = CrudHtmlGenerator.generatePagination(this.state.meta); }

    toggleOne(id) {
        if (this.state.selected.has(id)) this.state.selected.delete(id); else this.state.selected.add(id);
        this.renderTable(); this.updateBulkUI();
    }

    toggleAll(checked) {
        this.state.items.forEach(i => checked ? this.state.selected.add(i.id) : this.state.selected.delete(i.id));
        this.renderTable(); this.updateBulkUI();
    }

    updateBulkUI() {
        const count = this.state.selected.size;
        this.dom.countSelected.innerText = count;
        count > 0 ? this.dom.bulkBtn.classList.remove('d-none') : this.dom.bulkBtn.classList.add('d-none');
        if (this.dom.masterCheck) {
            const allSelected = this.state.items.length > 0 && this.state.items.every(i => this.state.selected.has(i.id));
            this.dom.masterCheck.checked = allSelected;
            this.dom.masterCheck.indeterminate = (count > 0 && !allSelected);
        }
    }

    openForm(item = null) {
        this.state.editingId = item ? item.id : null;
        this.dom.form.reset();
        if (item) this.config.columns.forEach(c => { if (this.dom.form.elements[c.name]) this.dom.form.elements[c.name].value = item[c.name]; });

        const titleText = item ? 'Editar Registro' : 'Nuevo Registro';
        if (this.dom.title) this.dom.title.innerText = titleText;

        const mode = this.config.editMode || 'sidebar';
        if (mode === 'modal') $(`#${this.scope}-modal`).modal('show');
        else if (mode === 'page') { this.dom.tableView.classList.add('hidden'); this.dom.pageView.classList.add('active'); }
        else { this.dom.sidebar.classList.add('is-open'); this.dom.overlay.classList.add('is-open'); }
    }

    closeForm() {
        const mode = this.config.editMode || 'sidebar';
        if (mode === 'modal') $(`#${this.scope}-modal`).modal('hide');
        else if (mode === 'page') { this.dom.pageView.classList.remove('active'); this.dom.tableView.classList.remove('hidden'); }
        else { this.dom.sidebar.classList.remove('is-open'); this.dom.overlay.classList.remove('is-open'); }
    }

    edit(id) { this.openForm(this.state.items.find(i => i.id === id)); }

    async save() {
        const data = Object.fromEntries(new FormData(this.dom.form).entries());
        if (this.state.editingId) data.id = this.state.editingId;
        await this.model.save(data); this.closeForm(); this.refresh();
    }

    async remove(ids) {
        if (!ids || ids.length === 0) return;

        const msg = ids.length === 1
            ? '¿Está seguro de que desea eliminar este registro?'
            : `¿Está seguro de eliminar los ${ids.length} registros seleccionados?`;

        if (confirm(msg)) {
            await this.model.delete(ids);
            ids.forEach(id => this.state.selected.delete(id));
            this.refresh();
        }
    }

    removeBulk() { this.remove(Array.from(this.state.selected)); }

    async exportData() {
        const data = await this.model.getAll();
        const blob = new Blob([JSON.stringify(data, null, 2)], { type: 'application/json' });
        const a = document.createElement('a'); a.href = URL.createObjectURL(blob); a.download = `${this.config.resource}_export.json`; a.click();
    }
}

// --- INSTANCIAS ---

// 1. Productos (CON KPIs)
new BootstrapCrud('crud-productos', {
    title: "Inventario General",
    resource: "productos_kpi",
    editMode: "sidebar",
    size: "600px",
    showKPIs: true,
    demoData: [
        { id: '1', prod: 'Monitor 4K', sku: 'MON-001', stock: 12, precio: 350 },
        { id: '2', prod: 'Teclado Mecánico', sku: 'KB-002', stock: 50, precio: 80 },
        { id: '3', prod: 'Laptop Pro', sku: 'LP-003', stock: 5, precio: 1200 }
    ],
    columns: [
        { name: "prod", label: "Producto", formCol: 8 },
        { name: "sku", label: "SKU", formCol: 4, responsive: 'sm' },
        { name: "stock", label: "Stock", type: "number", formCol: 6 },
        { name: "precio", label: "Precio ($)", type: "number", formCol: 6 },
        { name: "desc", label: "Detalles", type: "textarea", formCol: 12, hiddenInTable: true }
    ]
});