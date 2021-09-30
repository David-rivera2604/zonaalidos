using System;
using System.Collections.Generic;

namespace Architect.API.Core.Contracts.General
{
    /// <summary>
    /// Controla el flujo de procesamiento para Visualizaciones de datos en forma de widget, reportes, dashboard.
    /// </summary>
    public partial class VisualizationsResult
    {
        /// <summary>
        /// Visualizaciones de datos en forma de widget, reportes, dashboard.
        /// </summary>
        public Visualizations Visualizations { get; set; }
        /// <summary>
        /// Lista de notificaciónes resultado de las validaciones.
        /// </summary>
        public List<Core.Contracts.General.Error> Errors { get; set; }
    }
}

