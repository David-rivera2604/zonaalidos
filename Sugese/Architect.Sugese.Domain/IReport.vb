' Interfaz base para cualquier tipo de reporte
Public Interface IReport
    ReadOnly Property Nombre As String
    Function Procesar(excelPath As String, xmlPath As String) As DataTable
End Interface
