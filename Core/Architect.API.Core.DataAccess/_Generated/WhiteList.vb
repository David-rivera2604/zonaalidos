Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    ''' <summary>
    ''' Administrador de IPs autorizadas a consumo de sistema
    ''' </summary>
    Partial Public NotInheritable Class WhiteList

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla WhiteList por medio de su host.
        ''' </summary>
        ''' <param name="host">Host.</param> 
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Find(host As String) As Boolean
            Dim result As Boolean = True
            Dim key = "WhiteList"
            Dim items = New List(Of String)
            If Architect.Utilities.Cache.Exist(key) Then
                items = Architect.Utilities.Cache.GetItem(key)
            End If
            If Not items.Any(Function(c) c.EqualIgnoringCase(host)) Then
                Dim rows As Integer = 0
                With New DataManagerFactory("SELECT COUNT(ID) " &
                                              "FROM WHITELIST " &
                                             "WHERE WHITELIST.IPADDRESS = @:IPADDRESS", "WHITELIST", "Research")
                    .AddParameter("IPADDRESS", DbType.String, 20, False, host)
                    rows = .QueryExecuteScalarToInteger
                    If rows > 0 Then
                        result = True
                    End If
                End With
                If result Then
                    items.Add(host)
                    Architect.Utilities.Cache.SetItem(key, items)
                End If
            Else
                result = True
            End If
            Return result
        End Function

    End Class

End Namespace