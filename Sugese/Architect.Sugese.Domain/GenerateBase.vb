Imports System.Globalization
Imports System.Threading

Public Class GenerateBase
    Public Sub New()
        Dim culture = New CultureInfo("en-US")

        Thread.CurrentThread.CurrentCulture = culture
        Thread.CurrentThread.CurrentUICulture = culture
    End Sub
End Class
