using System.Collections.Generic;
using Architect.API.Core.Contracts.General;
using Architect.API.Tron.Contracts.Comun;

namespace Architect.API.Tron.Business.Emision
{
    /// <summary>
    /// Combina requisitos de emisión con adjuntos persistidos sin reclasificar archivos históricos.
    /// </summary>
    internal static class DocumentosAdjuntos
    {
        /// <summary>
        /// Completa el primer requisito pendiente del mismo tipo estable y conserva los restantes como generales.
        /// </summary>
        /// <param name="requeridos">Requisitos generados por las reglas del producto.</param>
        /// <param name="adjuntos">Adjuntos recuperados por presupuesto y compañía.</param>
        /// <returns>Requisitos y adjuntos generales con sus identificadores reales.</returns>
        internal static List<DocumentoRequerido> Completar(List<DocumentoRequerido> requeridos, List<AttachmentView> adjuntos)
        {
            var resultado = requeridos ?? new List<DocumentoRequerido>();
            if (adjuntos == null) return resultado;

            foreach (var adjunto in adjuntos)
            {
                var requerido = resultado.Find(documento => documento.tipo != "Genérico"
                    && documento.documentType == adjunto.DocumentType
                    && string.IsNullOrEmpty(documento.DStored));

                if (requerido == null)
                {
                    requerido = new DocumentoRequerido
                    {
                        tipo = "Genérico",
                        documentType = adjunto.DocumentType,
                        documentTypeDesc = adjunto.DocumentTypeDesc,
                        DArchivoEsperado = adjunto.FileName,
                        Grupo = "F"
                    };
                    resultado.Add(requerido);
                }

                requerido.documentosrequeridosId = adjunto.Id;
                requerido.DStored = adjunto.FileName;
                requerido.DNombre = adjunto.FileName;
                requerido.DDescripcion = adjunto.Description;
                requerido.DFecha = adjunto.UpdateDate;
                requerido.DTamano = adjunto.FileSize;
                requerido.UpdateUserName = adjunto.UpdateUserName;
            }
            return resultado;
        }
    }
}
