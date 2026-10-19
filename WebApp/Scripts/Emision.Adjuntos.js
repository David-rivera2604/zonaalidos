var app = app || {};

// Adaptación del contrato de emisión al uploader. La persistencia pertenece a Common/Upload.
app.EmisionAdjuntos = (function () {
    function load(uploader, documentos, presupuesto, descripcion) {
        var esperados = [];
        var generales = [];
        (documentos || []).forEach(function (doc, index) {
            var cargado = doc.DStored != null && doc.DStored !== '';
            if (doc.tipo !== 'Genérico') {
                esperados.push({
                    id: 'requerido-' + doc.documentType + '-' + index,
                    name: doc.tipo,
                    description: doc.DArchivoEsperado || '',
                    documentType: doc.documentType,
                    documentTypeDesc: doc.documentTypeDesc || doc.tipo,
                    status: cargado ? 'completed' : 'pending',
                    uploadedFile: cargado ? {
                        id: doc.documentosrequeridosId,
                        name: doc.DNombre,
                        storedFileName: doc.DStored,
                        size: doc.DTamano,
                        user: doc.UpdateUserName,
                        date: doc.DFecha,
                        type: 'application/octet-stream'
                    } : null
                });
            } else if (cargado) {
                generales.push({
                    Id: doc.documentosrequeridosId,
                    FileName: doc.DNombre,
                    StoredFileName: doc.DStored,
                    DocumentType: doc.documentType,
                    DocumentTypeDesc: doc.documentTypeDesc || 'General',
                    Description: doc.DDescripcion,
                    Size: doc.DTamano,
                    UpdateUserName: doc.UpdateUserName,
                    UpdateDate: doc.DFecha
                });
            }
        });
        uploader.fileUploader('load', generales, {
            EntityType: 3000, EntityId: presupuesto, DocumentType: 99, Description: descripcion
        });
        uploader.fileUploader('setExpectedDocuments', esperados);
    }

    function read(uploader) {
        return uploader.fileUploader('files').map(function (file) {
            return {
                documentosrequeridosId: file.Id,
                documentType: file.DocumentType,
                documentTypeDesc: file.DocumentTypeDesc,
                tipo: file.DocumentTypeDesc || 'Genérico',
                DStored: file.StoredFileName || file.Stored || file.FileName,
                DNombre: file.FileName,
                DArchivoEsperado: file.FileName,
                DDescripcion: file.Description || file.FileName,
                DFecha: file.UpdateDate || new Date().toISOString(),
                DTamano: file.Size || file.FileSize || 0,
                UpdateUserName: file.UpdateUserName,
                Grupo: 'F'
            };
        });
    }

    function canSubmit(uploader) {
        if (uploader.fileUploader('pending') > 0) {
            toastr.warning('Espere a que terminen las operaciones con adjuntos antes de continuar.');
            return false;
        }
        return true;
    }

    return { load: load, read: read, canSubmit: canSubmit };
})();
