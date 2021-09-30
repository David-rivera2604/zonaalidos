Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    Partial Public NotInheritable Class LookupCustom

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveLpkExtendStringValue1(lookupId As Integer, language As Integer, extendStringValue1 As String, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.Lookup)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Lookup)
            With New DataManagerFactory("SELECT Code, Description, ParentLookupId, ExtendStringValue1 " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ExtendStringValue1=@:ExtendStringValue1 AND RecordStatus=1" &
                                         "ORDER BY QueryOrder, Description", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ExtendStringValue1", DbType.AnsiString, 30, False, extendStringValue1)
                .Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.API.Core.Contracts.General.Lookup With {.Code = rows.FirstRow.NumericValue("Code"),
                                                                                         .Description = rows.FirstRow.StringValue("Description"),
                                                                                         .ParentLookupId = rows.FirstRow.NumericValue("ParentLookupId"),
                                                                                         .ExtendStringValue1 = rows.FirstRow.StringValue("ExtendStringValue1")})
                    Next
                End If
            End With
            Return result
        End Function
        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveLpkByCodeFull(lookupId As Integer, language As Integer, parentLookupId As Integer, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.Lookup)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Lookup)
            With New DataManagerFactory("SELECT Code, Description, ExtendStringValue1 " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND RecordStatus=1" &
                                         "ORDER BY QueryOrder, Description", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentLookupId)
                .Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.API.Core.Contracts.General.Lookup With {.Code = itemRow.NumericValue("Code"),
                                                                                   .Description = itemRow.StringValue("Description"),
                                                                                   .ExtendStringValue1 = itemRow.StringValue("ExtendStringValue1")})
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveLpkByDescription(lookupId As Integer, language As Integer, description As String, companyId As Integer) As Architect.API.Core.Contracts.General.LookupValue
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.LookupValue = Nothing
            With New DataManagerFactory("SELECT Code, Description " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND RecordStatus=1 AND LOWER(Description)=@:Description " &
                                         "ORDER BY QueryOrder, Description", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("Description", DbType.AnsiString, 255, description.IsEmpty(), description.ToLower())
                .Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Architect.API.Core.Contracts.General.LookupValue With {.Code = rows.FirstRow.NumericValue("Code"),
                                                                                        .Description = rows.FirstRow.StringValue("Description")}
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveLpkByHomologousCode(lookupId As Integer, language As Integer, homologousCode As String, companyId As Integer) As Architect.API.Core.Contracts.General.LookupValue
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.LookupValue = Nothing
            With New DataManagerFactory("SELECT Code, Description " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND RecordStatus=1 AND HomologousCode=@:HomologousCode " &
                                         "ORDER BY QueryOrder, Description", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("HomologousCode", DbType.AnsiString, 12, homologousCode.IsEmpty(), homologousCode)
                .Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Architect.API.Core.Contracts.General.LookupValue With {.Code = rows.FirstRow.NumericValue("Code"),
                                                                                        .Description = rows.FirstRow.StringValue("Description")}
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveByLookupMasterKey(lookupId As Integer, language As Integer, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.LookupValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.LookupValue)
            Dim key As String = String.Format("Lookup.{0}.{1}.{2}", lookupId, language, companyId)
            If Architect.Common.Helpers.Caching.NotExist(key) Then
                With New DataManagerFactory("SELECT Code, Description " &
                                              "FROM Lookup " &
                                             "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND RecordStatus=1" &
                                             "ORDER BY QueryOrder, Description", "Lookup", "Research")
                    .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                    .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                    .AddParameter("Language", DbType.Decimal, 5, False, language)
                    '.Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                    rows = .QueryExecuteToTable(True)
                    If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                        For Each itemRow As DataRow In rows.Rows
                            result.Add(New Architect.API.Core.Contracts.General.LookupValue With {.Code = itemRow.StringValue("Code").Trim,
                                                                                                  .Description = itemRow.StringValue("Description")})
                        Next
                    End If
                End With
                Architect.Common.Helpers.Caching.SetItem(key, result)
            Else
                result = Architect.Common.Helpers.Caching.GetItem(key)
            End If
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveByLookupMasterKey(lookupId As Integer, language As Integer, parentLookupId As Integer, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.LookupValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.LookupValue)
            With New DataManagerFactory("SELECT Code, Description " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND RecordStatus=1" &
                                         "ORDER BY QueryOrder, Description", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentLookupId)
                .Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.API.Core.Contracts.General.LookupValue With {.Code = itemRow.NumericValue("Code"),
                                                                           .Description = itemRow.StringValue("Description")})
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveByLookupMasterKey(lookupId As Integer, language As Integer, parentLookupId As Integer, extendNumberValue1 As Integer, companyId As Integer) As List(Of Architect.API.Core.Contracts.General.LookupValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.LookupValue)
            With New DataManagerFactory("SELECT Code, Description " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND SubParentLookupId=@:SubParentLookupId AND RecordStatus=1" &
                                         "ORDER BY QueryOrder, Description", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentLookupId)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, False, extendNumberValue1)
                .Cache = Architect.Common.Enumerations.EnumCache.CacheWithFullParameters
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.API.Core.Contracts.General.LookupValue With {.Code = itemRow.NumericValue("Code"),
                                                                           .Description = itemRow.StringValue("Description")})
                    Next
                End If
            End With
            Return result
        End Function
    End Class

End Namespace
