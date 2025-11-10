' Clase genérica que abstrae la creación y ejecución del Builder
Public Class Report(Of T As Class)
    Implements IReport

    Public ReadOnly Property Nombre As String Implements IReport.Nombre
    Private ReadOnly _parametros As Object()

    Public Sub New(nombre As String, ParamArray parametros As Object())
        Me.Nombre = nombre
        _parametros = parametros
    End Sub

    Public Function Procesar(excelPath As String, xmlPath As String) As DataTable Implements IReport.Procesar
        ' Crear instancia del builder dinámicamente
        Dim builder As Object = Activator.CreateInstance(GetType(T), _parametros)

        ' Cargar y procesar el Excel
        CallByName(builder, "LoadExcelInformation", CallType.Method, excelPath)

        ' Serializar el resultado a XML
        CallByName(builder, "FileSerialize", CallType.Method, xmlPath, False)

        ' Devolver la tabla de respuesta
        Return CallByName(builder, "Response", CallType.Get)
    End Function
End Class
