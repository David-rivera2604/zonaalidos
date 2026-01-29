window.onload = () => {
    let _id = app.core.URLStringValue('id');
    let _mode = app.core.URLStringValue('mode');
    
    if (_mode === 'custom') {
        // Custom Mode
        app.core.Get(app.setting.apipath + `v1/CustomData/${_id}/dashboard/Data`)
            .done(function (data) {
                try {
                    const script = document.createElement('script');
                    script.textContent = data;
                    document.head.appendChild(script);
                } catch (error) {
                    console.error("Error al ejecutar el script:", error);
                }
            });
    } else {
        // Default Mode
        import(`./dashboard/${_id}.js`)
            .then(module => {

            })
            .catch(error => {
                console.error("Error al cargar el módulo:", error);
            });
    }
};
