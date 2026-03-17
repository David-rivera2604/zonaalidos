class syscorpla_embebido {
    /**
     * Renderiza un iframe dentro del contenedor indicado.
     * @param {string} containerId ID del elemento contenedor.
     * @param {string} iframeUrl URL que se cargará en el iframe.
     */
    constructor(containerId, iframeUrl) {
        this.container = document.getElementById(containerId);
        this.iframeUrl = iframeUrl;
        this.resizeHandler = null;

        if (!this.container) return;

        this.injectStyles();
        this.render();
        this.registerEvents();
    }

    /**
     * Inyecta estilos mínimos para que el iframe ocupe el ancho completo
     * y se adapte al alto disponible del viewport.
     */
    injectStyles() {
        const style = document.createElement('style');
        style.innerHTML = `
            #dashboard-app {
                width: 100%;
                padding: 0;
                margin: 0;
            }

            #dashboard-app .syscorpla-iframe-wrapper {
                width: 100%;
                min-height: 600px;
                height: calc(100vh - 24px);
                overflow: hidden;
            }

            #dashboard-app .syscorpla-iframe {
                width: 100%;
                height: 100%;
                border: 0;
                display: block;
            }
        `;

        document.head.appendChild(style);
    }

    /**
     * Crea la estructura HTML del iframe dentro del contenedor principal.
     */
    render() {
        this.container.innerHTML = `
            <div class="syscorpla-iframe-wrapper" id="syscorpla-iframe-wrapper">
                <iframe
                    id="syscorpla-iframe"
                    class="syscorpla-iframe"
                    src="${this.iframeUrl}"
                    loading="lazy"
                    referrerpolicy="no-referrer-when-downgrade"
                    title="Syscorpla embebido">
                </iframe>
            </div>
        `;

        this.adjustIframeSize();
    }

    /**
     * Registra eventos para recalcular el tamaño cuando carga el iframe
     * y cuando cambia el tamaño de la ventana.
     */
    registerEvents() {
        const iframe = document.getElementById('syscorpla-iframe');
        if (iframe) {
            iframe.addEventListener('load', () => this.adjustIframeSize());
        }

        this.resizeHandler = () => this.adjustIframeSize();
        window.addEventListener('resize', this.resizeHandler);
    }

    /**
     * Ajusta la altura del iframe según el espacio visible disponible.
     * Si el contenido del iframe es cross-origin, se mantiene el cálculo por viewport.
     */
    adjustIframeSize() {
        const wrapper = document.getElementById('syscorpla-iframe-wrapper');
        const iframe = document.getElementById('syscorpla-iframe');
        if (!wrapper || !iframe) return;

        const rect = wrapper.getBoundingClientRect();
        const availableHeight = Math.max(window.innerHeight - rect.top - 16, 600);

        wrapper.style.height = `${availableHeight}px`;
        iframe.style.height = `${availableHeight}px`;

        try {
            const iframeDoc = iframe.contentWindow?.document;
            if (iframeDoc?.body?.scrollHeight) {
                const contentHeight = Math.max(iframeDoc.body.scrollHeight, availableHeight);
                wrapper.style.height = `${contentHeight}px`;
                iframe.style.height = `${contentHeight}px`;
            }
        } catch (_) {
            // Cross-origin: no se puede leer el contenido interno del iframe.
        }
    }
}

new syscorpla_embebido('dashboard-app', 'https://syscorpla.net/#/sinister?company=mapfre');