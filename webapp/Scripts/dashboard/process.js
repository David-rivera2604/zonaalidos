class DashboardManager {
    /**
     * @param {string} containerId - ID del contenedor raíz.
     * @param {function} dataProvider - Función asíncrona que retorna el JSON de datos.
     */
    constructor(containerId, dataProvider) {
        this.container = document.getElementById(containerId);
        this.dataProvider = dataProvider; // Guardamos la referencia a la función
        this.data = null;
        this.isMaximized = false;
        
        // Propiedades de refresco
        this.refreshTimer = null;
        this.refreshInterval = 60000; 
        this.nextRefreshIn = 60;
        this.countdownTimer = null;

        this.init();
    }

    injectStyles() {
        const style = document.createElement('style');
        style.innerHTML = `
            #dashboard-app {
                background-color: #f0f2f5;
                min-height: 100vh;
                padding: 24px;
                font-family: 'Segoe UI', Roboto, -apple-system, sans-serif;
                font-size: 16px;
                color: #1a1a1a;
                position: relative;
            }

            /* Definición explícita de colores y tamaños para títulos */
            #dashboard-app h2 { 
                font-size: 1.5rem; 
                font-weight: 800; 
                margin: 0; 
                color: #1e293b; /* Azul Pizarra Profundo */
            }
            #dashboard-app h4 { 
                font-size: 1.25rem; 
                font-weight: 700; 
                margin: 0; 
                color: #1e293b; 
            }
            #dashboard-app h6 { 
                font-size: 1rem; 
                font-weight: 700; 
                margin: 0; 
                color: #334155; 
            }

            #dashboard-app .card {
                border: none;
                border-radius: 16px;
                box-shadow: 0 4px 20px rgba(0,0,0,0.04);
                transition: all 0.3s cubic-bezier(0.4, 0, 0.2, 1);
                margin-bottom: 24px;
                background: #fff;
                overflow: hidden;
            }

            #dashboard-app .header-dashboard {
                display: flex;
                justify-content: space-between;
                align-items: center;
                margin-bottom: 30px;
                background: #fff;
                padding: 15px 25px;
                border-radius: 16px;
                box-shadow: 0 2px 10px rgba(0,0,0,0.02);
            }

            #dashboard-app .refresh-circle-container {
                position: relative; width: 42px; height: 42px; display: flex; justify-content: center; align-items: center;
            }

            #dashboard-app .refresh-circle-svg { transform: rotate(-90deg); width: 42px; height: 42px; }

            #dashboard-app .refresh-circle-prog {
                fill: none; stroke: #d81e05; stroke-width: 3; stroke-dasharray: 100; stroke-dashoffset: 0;
                transition: stroke-dashoffset 1s linear; stroke-linecap: round;
            }

            #dashboard-app .kpi-card { padding: 24px; position: relative; }
            #dashboard-app .kpi-card::before { content: ''; position: absolute; top: 0; left: 0; width: 4px; height: 100%; background: #d81e05; }
            #dashboard-app .kpi-label { color: #64748b; font-size: 0.85rem; font-weight: 600; text-transform: uppercase; margin-bottom: 8px; }
            #dashboard-app .kpi-value { font-size: 2.25rem; font-weight: 800; color: #1e293b; line-height: 1.1; }

            #dashboard-app .card-header-custom { display: flex; justify-content: space-between; align-items: center; padding: 15px 24px; border-bottom: 1px solid #f1f5f9; }
            #dashboard-app .card-title-custom { 
                font-size: 1rem; 
                font-weight: 700; 
                color: #334155; /* Gris Carbón */
                margin: 0; 
            }

            #dashboard-app .btn-maximize {
                background: #f8fafc; border: 1px solid #e2e8f0; border-radius: 8px; padding: 6px;
                color: #64748b; transition: all 0.2s; cursor: pointer; display: flex; align-items: center; justify-content: center;
            }

            #dashboard-app .btn-maximize:hover { background: #f1f5f9; color: #d81e05; }

            #dashboard-app .table-saas thead th { background: #f8fafc; font-size: 0.75rem; text-transform: uppercase; color: #64748b; padding: 16px; border: none; font-weight: 700; }
            #dashboard-app .table-saas td { padding: 16px; vertical-align: middle; border-top: 1px solid #f1f5f9; color: #475569; }

            #dashboard-app .maximized-element {
                position: absolute !important; top: 0 !important; left: 0 !important; width: 100% !important; height: 100% !important;
                z-index: 9999; background: #fff !important; display: flex; flex-direction: column;
            }

            #dashboard-app .max-header { padding: 20px 40px; border-bottom: 1px solid #f1f5f9; display: flex; justify-content: space-between; align-items: center; background: #fff; }
            #dashboard-app .max-header h2 { 
                margin: 0; 
                font-weight: 800; 
                color: #1e293b; 
                font-size: 1.75rem; 
            }
            #dashboard-app .max-content { flex: 1; padding: 40px; overflow-y: auto; background: #f8fafc; }
            #dashboard-app .close-max-btn { background: #d81e05; color: white; border: none; border-radius: 8px; padding: 8px 20px; font-weight: 700; cursor: pointer; }
            #dashboard-app .countdown-number { position: absolute; font-size: 0.75rem; font-weight: 700; color: #555; }
            
            #dashboard-app .refresh-label { font-size: 0.7rem; font-weight: 800; text-transform: uppercase; color: #64748b; }
            #dashboard-app .interval-select-custom { font-size: 0.875rem; }

            #dashboard-app .trend-up { color: #10b981; font-weight: bold; }
            #dashboard-app .trend-down { color: #ef4444; font-weight: bold; }
        `;
        document.head.appendChild(style);
    }

    attachEventListeners() {
        this.container.addEventListener('click', (e) => {
            const btn = e.target.closest('.btn-maximize');
            if (btn) {
                const targetId = btn.getAttribute('data-target-id');
                const targetTitle = btn.getAttribute('data-target-title');
                this.openMaximize(targetId, targetTitle);
            }
        });
    }

    async loadData(isSilent = false) {
        if (!isSilent) this.showLoader();
        try {
            // Llamamos a la función callback inyectada
            this.data = await this.dataProvider();
        } catch (e) {
            console.error("DashboardManager: Error en dataProvider", e);
        } finally {
            if (!isSilent) this.hideLoader();
        }
    }

    showLoader() {
        const loader = document.createElement('div');
        loader.id = 'main-loader';
        loader.style = "position:fixed; top:0; left:0; width:100%; height:100%; background:rgba(255,255,255,0.8); z-index:10000; display:flex; justify-content:center; align-items:center;";
        loader.innerHTML = '<div class="spinner-border text-danger"></div>';
        document.body.appendChild(loader);
    }

    hideLoader() {
        const loader = document.getElementById('main-loader');
        if (loader) loader.remove();
    }

    renderSkeleton() {
        this.container.innerHTML = `
            <div class="container-fluid">
                <div class="header-dashboard">
                    <div class="d-flex align-items-center">
                        <h4 class="mb-0">Dashboard de Aliados</h4>
                    </div>
                    <div class="d-flex align-items-center gap-3">
                        <div class="mr-3 text-right">
                            <div class="refresh-label">Refresco</div>
                            <select id="interval-select" class="form-control form-control-sm border-0 bg-light font-weight-bold interval-select-custom">
                                <option value="30">30 seg</option>
                                <option value="60" selected>1 min</option>
                                <option value="300">5 min</option>
                                <option value="0">Off</option>
                            </select>
                        </div>
                        <div class="refresh-circle-container">
                            <svg class="refresh-circle-svg"><circle cx="21" cy="21" r="18" fill="none" stroke="#eee" stroke-width="3"></circle>
                            <circle id="refresh-circle-prog" cx="21" cy="21" r="18" class="refresh-circle-prog"></circle></svg>
                            <div class="countdown-number" id="countdown-text">60</div>
                        </div>
                    </div>
                </div>
                <div class="row" id="kpi-area"></div>
                <div class="row">
                    <div class="col-lg-8" id="visual-evolution"></div>
                    <div class="col-lg-4" id="visual-priority"></div>
                </div>
                <div class="row">
                    <div class="col-lg-7" id="visual-proc"></div>
                    <div class="col-lg-5" id="visual-src"></div>
                </div>
                <div class="row" id="table-area"></div>
            </div>
        `;
        document.getElementById('interval-select').addEventListener('change', (e) => this.startRefreshCycle(parseInt(e.target.value)));
    }

    startRefreshCycle(seconds) {
        if (this.refreshTimer) clearInterval(this.refreshTimer);
        if (this.countdownTimer) clearInterval(this.countdownTimer);
        const circle = document.getElementById('refresh-circle-prog');
        const text = document.getElementById('countdown-text');
        if (seconds === 0) { text.innerText = '--'; circle.style.strokeDashoffset = 100; return; }
        this.refreshInterval = seconds;
        this.nextRefreshIn = seconds;
        this.countdownTimer = setInterval(() => {
            this.nextRefreshIn--;
            text.innerText = this.nextRefreshIn;
            circle.style.strokeDashoffset = 100 - (this.nextRefreshIn / this.refreshInterval * 100);
            if (this.nextRefreshIn <= 0) { 
                this.refreshData(); 
                this.nextRefreshIn = this.refreshInterval; 
            }
        }, 1000);
    }

    async refreshData() {
        await this.loadData(true); // Carga silenciosa
        if(this.data) { 
            this.renderKPIs(); 
            this.renderVisuals(); 
            this.renderTable(); 
        }
    }

    renderKPIs() {
        const area = document.getElementById('kpi-area');
        const created = this.data.Casoscreados || {};
        const closed = this.data.Casoscerrados || {};
        const pending = this.data.Casospendientes?.TOTAL_CASOS_PENDIENTES || 0;
        
        const trendClass = (t) => String(t).includes('-') ? 'trend-down' : 'trend-up';
        const trendIcon = (t) => String(t).includes('-') ? '▼' : '▲';

        area.innerHTML = `
            <div class="col-md-3"><div class="card kpi-card"><div class="kpi-label">CREADOS</div><div class="kpi-value">${created['Casos Mes Actual'] || 0}</div><div class="mt-2 small ${trendClass(created['Variación %'])}">${trendIcon(created['Variación %'])} ${created['Variación %'] || '0%'} <span class="text-muted font-weight-normal">vs mes ant.</span></div></div></div>
            <div class="col-md-3"><div class="card kpi-card"><div class="kpi-label">CERRADOS</div><div class="kpi-value">${closed['Casos Cerrados Mes Actual'] || 0}</div><div class="mt-2 small ${trendClass(closed['Variación %'])}">${trendIcon(closed['Variación %'])} ${closed['Variación %'] || '0%'} <span class="text-muted font-weight-normal">vs mes ant.</span></div></div></div>
            <div class="col-md-3"><div class="card kpi-card"><div class="kpi-label">PENDIENTES</div><div class="kpi-value">${pending}</div><div class="mt-2 small text-success font-weight-bold">Total Acumulado</div></div></div>
            <div class="col-md-3"><div class="card kpi-card"><div class="kpi-label">CASOS VIP</div><div class="kpi-value">${this.data.Casosvippendientes?.TOTAL_CASOS || 0}</div><div class="mt-2 small text-muted font-weight-bold">Prioridad Crítica</div></div></div>
        `;
    }

    renderVisuals() {
        this.renderChartCard('visual-evolution', 'Evolución Mensual', 'chart-evo');
        this.renderChartCard('visual-priority', 'Distribución por Prioridad', 'chart-prio');
        this.renderChartCard('visual-proc', 'Eficiencia por Proceso', 'chart-proc');
        this.renderChartCard('visual-src', 'Fuentes de Entrada', 'chart-src');

        const m = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];
        
        new ApexCharts(document.getElementById('chart-evo'), {
            series: [{ name: 'Creados', data: this.data.Casospormes.map(d => d.TOTAL_CREADOS) }, { name: 'Cerrados', data: this.data.Casospormes.map(d => d.TOTAL_CERRADOS) }],
            chart: { type: 'area', height: 320, toolbar: {show:false}, fontFamily: 'inherit' },
            colors: ['#d81e05', '#1e293b'], stroke: { curve: 'smooth', width: 4 },
            xaxis: { categories: this.data.Casospormes.map(d => m[d.MES_NUMERO-1] || d.MES_NUMERO) },
            dataLabels: { enabled: false }
        }).render();

        new ApexCharts(document.getElementById('chart-prio'), {
            series: (this.data.Casosporprioridad || []).map(d => d.CANTIDAD),
            labels: (this.data.Casosporprioridad || []).map(d => d.PRIORIDAD),
            chart: { type: 'donut', height: 320, fontFamily: 'inherit' },
            colors: ['#d81e05', '#1e293b', '#475569', '#94a3b8', '#cbd5e1'], legend: { position: 'bottom' }
        }).render();

        new ApexCharts(document.getElementById('chart-proc'), {
            series: [{ name: 'Creados', data: (this.data.Casosporproceso || []).map(d => d.TOTAL_CREADOS) }, { name: 'Cerrados', data: (this.data.Casosporproceso || []).map(d => d.TOTAL_CERRADOS) }],
            chart: { type: 'bar', height: 320, toolbar: {show:false}, fontFamily: 'inherit' },
            colors: ['#d81e05', '#1e293b'], xaxis: { categories: (this.data.Casosporproceso || []).map(d => d.NOMBRE_PROCESO) }
        }).render();

        new ApexCharts(document.getElementById('chart-src'), {
            series: (this.data.Casosporfuente || []).map(d => d.TOTAL_CASOS),
            labels: (this.data.Casosporfuente || []).map(d => d.COMPANIA_USUARIO),
            chart: { type: 'pie', height: 320, fontFamily: 'inherit' }, colors: ['#d81e05', '#1e293b', '#94a3b8'], legend: { position: 'bottom' }
        }).render();
    }

    renderChartCard(containerId, title, chartId) {
        document.getElementById(containerId).innerHTML = `
            <div class="card">
                <div class="card-header-custom">
                    <h6 class="card-title-custom">${title}</h6>
                    <button class="btn-maximize" data-target-id="${chartId}" data-target-title="${title}">
                        <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M15 3h6v6M9 21H3v-6M21 3l-7 7M3 21l7-7"/></svg>
                    </button>
                </div>
                <div id="${chartId}" style="min-height:320px; padding:15px;"></div>
            </div>
        `;
    }

    renderTable() {
        const rows = (this.data.Casosporprocesoduracion2 || []).map(r => `
            <tr><td class="font-weight-bold">${r.NOMBRE_PROCESO}</td><td class="text-center"><span class="badge badge-light px-3 py-1">${r.CANTIDAD_CASOS}</span></td><td class="text-right">${r.DURACION_MINIMA_DIAS.toFixed(1)}d</td><td class="text-right text-danger font-weight-bold">${r.DURACION_PROMEDIO_DIAS.toFixed(1)}d</td><td class="text-right">${r.DURACION_MAXIMA_DIAS.toFixed(1)}d</td></tr>
        `).join('');
        document.getElementById('table-area').innerHTML = `
            <div class="col-12"><div class="card"><div class="card-header-custom"><h6 class="card-title-custom">Eficiencia Detallada por Proceso</h6><button class="btn-maximize" data-target-id="main-table" data-target-title="Eficiencia Detallada"><svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M15 3h6v6M9 21H3v-6M21 3l-7 7M3 21l7-7"/></svg></button></div><div class="table-responsive" id="main-table"><table class="table table-saas mb-0"><thead><tr><th>Proceso</th><th class="text-center">Volumen</th><th class="text-right">Mínimo</th><th class="text-right">Promedio</th><th class="text-right">Máximo</th></tr></thead><tbody>${rows}</tbody></table></div></div></div>
        `;
    }

    openMaximize(id, title) {
        this.isMaximized = true;
        const overlay = document.createElement('div');
        overlay.className = 'maximized-element';
        overlay.id = 'max-overlay';
        
        overlay.innerHTML = `
            <div class="max-header">
                <h2>${title}</h2>
                <button class="close-max-btn" id="close-max-trigger">Cerrar Vista [Esc]</button>
            </div>
            <div class="max-content">
                <div id="max-target-container" style="height: 100%; width: 100%;"></div>
            </div>
        `;

        this.container.appendChild(overlay);

        const targetContainer = document.getElementById('max-target-container');
        const closeBtn = document.getElementById('close-max-trigger');
        
        const closeFn = () => {
            overlay.remove();
            this.isMaximized = false;
            window.removeEventListener('keydown', escHandler);
        };

        const escHandler = (e) => { if(e.key === 'Escape') closeFn(); };
        window.addEventListener('keydown', escHandler);
        closeBtn.onclick = closeFn;

        if (id === 'main-table') {
            const tableHtml = document.getElementById('main-table').innerHTML;
            targetContainer.innerHTML = `<div class="card p-4 h-100 overflow-auto shadow-sm">${tableHtml}</div>`;
        } else {
            const chartOptions = this.getChartOptions(id, true);
            const chart = new ApexCharts(targetContainer, chartOptions);
            chart.render();
        }
    }

    getChartOptions(id, isFullHeight) {
        const m = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];
        const h = isFullHeight ? '100%' : 320;
        
        if (id === 'chart-evo') {
            return {
                series: [{ name: 'Creados', data: this.data.Casospormes.map(d => d.TOTAL_CREADOS) }, { name: 'Cerrados', data: this.data.Casospormes.map(d => d.TOTAL_CERRADOS) }],
                chart: { type: 'area', height: h, toolbar: {show:true}, fontFamily: 'inherit' },
                colors: ['#d81e05', '#1e293b'], stroke: { curve: 'smooth', width: 4 },
                xaxis: { categories: this.data.Casospormes.map(d => m[d.MES_NUMERO-1] || d.MES_NUMERO) },
                dataLabels: { enabled: isFullHeight }
            };
        } else if (id === 'chart-prio') {
            return {
                series: (this.data.Casosporprioridad || []).map(d => d.CANTIDAD),
                labels: (this.data.Casosporprioridad || []).map(d => d.PRIORIDAD),
                chart: { type: 'donut', height: h, fontFamily: 'inherit' },
                colors: ['#d81e05', '#1e293b', '#475569', '#94a3b8', '#cbd5e1'],
                legend: { position: isFullHeight ? 'right' : 'bottom', fontSize: '14px' }
            };
        } else if (id === 'chart-proc') {
            return {
                series: [{ name: 'Creados', data: (this.data.Casosporproceso || []).map(d => d.TOTAL_CREADOS) }, { name: 'Cerrados', data: (this.data.Casosporproceso || []).map(d => d.TOTAL_CERRADOS) }],
                chart: { type: 'bar', height: h, toolbar: {show:true}, fontFamily: 'inherit' },
                colors: ['#d81e05', '#1e293b'],
                plotOptions: { bar: { borderRadius: 8, dataLabels: { position: 'top' } } },
                dataLabels: { enabled: isFullHeight, offsetY: -20, style: { colors: ['#333'] } },
                xaxis: { categories: (this.data.Casosporproceso || []).map(d => d.NOMBRE_PROCESO) }
            };
        } else if (id === 'chart-src') {
            return {
                series: (this.data.Casosporfuente || []).map(d => d.TOTAL_CASOS),
                labels: (this.data.Casosporfuente || []).map(d => d.COMPANIA_USUARIO),
                chart: { type: 'pie', height: h, fontFamily: 'inherit' },
                colors: ['#d81e05', '#1e293b', '#94a3b8'],
                legend: { position: isFullHeight ? 'right' : 'bottom' }
            };
        }
    }

    async init() {
        this.injectStyles();
        this.renderSkeleton();
        this.attachEventListeners(); 
        
        // Carga inicial usando el proveedor inyectado
        await this.loadData();
        
        if(this.data) {
            this.renderKPIs();
            this.renderVisuals();
            this.renderTable();
            this.startRefreshCycle(60);
        }
    }
}

async function myCustomDataProvider() {
    const API_URL = 'https://appqa.mapfrecr.com/datapiprd/api/entity/process/insight';

    const FALLBACK_DATA = {
        "Casosporprocesoduracion2": [
            { "NOMBRE_PROCESO": "EMISIÓN RESPONSABILIDAD CIVIL", "CANTIDAD_CASOS": 1.0, "DURACION_MINIMA_DIAS": 4.94, "DURACION_PROMEDIO_DIAS": 4.94, "DURACION_MAXIMA_DIAS": 4.94 },
            { "NOMBRE_PROCESO": "DEVOLUCIÓN DE DINERO - COBROS", "CANTIDAD_CASOS": 2.0, "DURACION_MINIMA_DIAS": 3.76, "DURACION_PROMEDIO_DIAS": 4.77, "DURACION_MAXIMA_DIAS": 5.78 }
        ],
        "Casoscreados": { "Casos Mes Actual": 431.0, "Casos Mes Anterior (MTD)": 500.0, "Variación %": "-13.8%" },
        "Casosporproceso": [
            { "NOMBRE_PROCESO": "CONSULTAS GENERALES - SAC", "TOTAL_CREADOS": 89.0, "TOTAL_CERRADOS": 87.0 },
            { "NOMBRE_PROCESO": "APLICACIÓN DE PAGOS - TRANSFERENCIAS - VOUCHERS RA", "TOTAL_CREADOS": 57.0, "TOTAL_CERRADOS": 44.0 }
        ],
        "Casoscerrados": { "Casos Cerrados Mes Actual": 342.0, "Casos Cerrados Mes Ant. (MTD)": 414.0, "Variación %": "-17.39%" },
        "Casospormes": [{ "MES_NUMERO": 1.0, "TOTAL_CREADOS": 431.0, "TOTAL_CERRADOS": 226.0 }],
        "Casospendientes": { "TOTAL_CASOS_PENDIENTES": 708.0 },
        "Casosporfuente": [{ "COMPANIA_USUARIO": "Mapfre", "TOTAL_CASOS": 338.0 }, { "COMPANIA_USUARIO": "Aliados", "TOTAL_CASOS": 84.0 }],
        "Casosporprioridad": [{ "PRIORIDAD": "Rapida", "CANTIDAD": 308.0 }, { "PRIORIDAD": "Intermedia", "CANTIDAD": 82.0 }],
        "Casosvippendientes": { "PRIORIDAD": "VIP", "TOTAL_CASOS": 7.0 }
    };

    try {
        // Intento de obtener datos reales
        //const response = await app.core.datapi('GET', `API_URL`);
        const response = await fetch(API_URL);
        if (!response.ok) throw new Error('Network error');
        const result = await response.json();

        // Validación mínima de estructura
        if (result && result.Casoscreados) return result;
        return FALLBACK_DATA;
    } catch (error) {
        console.warn("DataProvider: Error al obtener datos, usando fallback.", error);
        return FALLBACK_DATA;
    }
}

new DashboardManager('dashboard-app', myCustomDataProvider);