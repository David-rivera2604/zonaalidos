Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class Lookup

        ''' <summary>
        ''' Crea un registro en la tabla Lookup.
        ''' </summary>
        ''' <param name="lookupItem">Instancia de Lookup</param>
        ''' <returns>Instancia de Lookup</returns>
        Public Shared Function Create(lookupItem As Architect.API.Core.Contracts.General.Lookup) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Lookup " &
                                              "(LookupId, CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, RecordStatus, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:LookupId, @:CompanyId, @:Language, @:ParentLookupId, @:SubParentLookupId, @:Code, @:Description, @:QueryOrder, @:HomologousCode, @:ExtendNumberValue1, @:ExtendNumberValue2, @:ExtendStringValue1, @:ExtendStringValue2, @:RecordStatus, @:UpdateUserCode, @:UpdateDate)", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, lookupItem.LookupId.IsEmpty(), lookupItem.LookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, lookupItem.CompanyId.IsEmpty(), lookupItem.CompanyId)
                .AddParameter("Language", DbType.Decimal, 5, lookupItem.Language.IsEmpty(), lookupItem.Language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, lookupItem.ParentLookupId.IsEmpty(), lookupItem.ParentLookupId)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, lookupItem.SubParentLookupId.IsEmpty(), lookupItem.SubParentLookupId)
                .AddParameter("Code", DbType.Decimal, 9, lookupItem.Code.IsEmpty(), lookupItem.Code)
                .AddParameter("Description", DbType.AnsiString, 255, lookupItem.Description.IsEmpty(), lookupItem.Description)
                .AddParameter("QueryOrder", DbType.Decimal, 5, lookupItem.QueryOrder.IsEmpty(), lookupItem.QueryOrder)
                .AddParameter("HomologousCode", DbType.AnsiString, 12, lookupItem.HomologousCode.IsEmpty(), lookupItem.HomologousCode)
                .AddParameter("ExtendNumberValue1", DbType.Decimal, 11, lookupItem.ExtendNumberValue1.IsEmpty(), lookupItem.ExtendNumberValue1)
                .AddParameter("ExtendNumberValue2", DbType.Decimal, 11, lookupItem.ExtendNumberValue2.IsEmpty(), lookupItem.ExtendNumberValue2)
                .AddParameter("ExtendStringValue1", DbType.AnsiString, 30, lookupItem.ExtendStringValue1.IsEmpty(), lookupItem.ExtendStringValue1)
                .AddParameter("ExtendStringValue2", DbType.AnsiString, 30, lookupItem.ExtendStringValue2.IsEmpty(), lookupItem.ExtendStringValue2)
                .AddParameter("RecordStatus", DbType.Decimal, 5, lookupItem.RecordStatus.IsEmpty(), lookupItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, lookupItem.UpdateUserCode.IsEmpty(), lookupItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, lookupItem.UpdateDate.IsEmpty(), lookupItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <param name="lookupid"></param>
        ''' <param name="companyid"></param>
        ''' <param name="language"></param>
        ''' <param name="parentlookupid"></param>
        ''' <param name="subparentlookupid"></param>
        ''' <param name="code"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Instancia de Lookup</returns>
        Public Shared Function Retrieve(lookupid As Integer, companyid As Integer, language As Integer, parentlookupid As Integer, subparentlookupid As Integer, code As Integer) As Architect.API.Core.Contracts.General.Lookup
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.Lookup = Nothing
            With New DataManagerFactory("SELECT LookupId, Lookup.CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, Lookup.RecordStatus, Lookup.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Lookup.UpdateDate " &
                                          "FROM Lookup LEFT JOIN UserMember um ON um.UserId = Lookup.UpdateUserCode " &
                                         "WHERE Lookup.LookupId=@:LookupId AND Lookup.CompanyId=@:CompanyId AND Lookup.Language=@:Language AND Lookup.ParentLookupId=@:ParentLookupId AND Lookup.SubParentLookupId=@:SubParentLookupId AND Lookup.Code=@:Code AND Lookup.CompanyId=@:CompanyId", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentlookupid)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, False, subparentlookupid)
                .AddParameter("Code", DbType.Decimal, 9, False, code)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Lookup.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="filter"></param>
        ''' <returns>Lista de instancias de Lookup</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.General.Lookup)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Lookup)
            With New DataManagerFactory("SELECT LookupId, Lookup.CompanyId, Language, ParentLookupId, SubParentLookupId, Code, Description, QueryOrder, HomologousCode, ExtendNumberValue1, ExtendNumberValue2, ExtendStringValue1, ExtendStringValue2, Lookup.RecordStatus, Lookup.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Lookup.UpdateDate " &
                                          "FROM Lookup LEFT JOIN UserMember um ON um.UserId = Lookup.UpdateUserCode " &
                                         "WHERE Lookup.CompanyId=@:CompanyId", "Lookup", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(DataRowMapper(itemRow))
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Verifica si existe un registro en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <param name="lookupid"></param>
        ''' <param name="companyid"></param>
        ''' <param name="language"></param>
        ''' <param name="parentlookupid"></param>
        ''' <param name="subparentlookupid"></param>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey(lookupid As Integer, companyid As Integer, language As Integer, parentlookupid As Integer, subparentlookupid As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Code),0) " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND SubParentLookupId=@:SubParentLookupId", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentlookupid)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, False, subparentlookupid)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <param name="lookupItem">Instancia de Lookup</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(lookupItem As Architect.API.Core.Contracts.General.Lookup) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Lookup " &
                                           "SET Description=@:Description, QueryOrder=@:QueryOrder, HomologousCode=@:HomologousCode, ExtendNumberValue1=@:ExtendNumberValue1, ExtendNumberValue2=@:ExtendNumberValue2, ExtendStringValue1=@:ExtendStringValue1, ExtendStringValue2=@:ExtendStringValue2, RecordStatus=@:RecordStatus, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND SubParentLookupId=@:SubParentLookupId AND Code=@:Code", "Lookup", "Research")
                .AddParameter("Description", DbType.AnsiString, 255, lookupItem.Description.IsEmpty(), lookupItem.Description)
                .AddParameter("QueryOrder", DbType.Decimal, 5, lookupItem.QueryOrder.IsEmpty(), lookupItem.QueryOrder)
                .AddParameter("HomologousCode", DbType.AnsiString, 12, lookupItem.HomologousCode.IsEmpty(), lookupItem.HomologousCode)
                .AddParameter("ExtendNumberValue1", DbType.Decimal, 11, lookupItem.ExtendNumberValue1.IsEmpty(), lookupItem.ExtendNumberValue1)
                .AddParameter("ExtendNumberValue2", DbType.Decimal, 11, lookupItem.ExtendNumberValue2.IsEmpty(), lookupItem.ExtendNumberValue2)
                .AddParameter("ExtendStringValue1", DbType.AnsiString, 30, lookupItem.ExtendStringValue1.IsEmpty(), lookupItem.ExtendStringValue1)
                .AddParameter("ExtendStringValue2", DbType.AnsiString, 30, lookupItem.ExtendStringValue2.IsEmpty(), lookupItem.ExtendStringValue2)
                .AddParameter("RecordStatus", DbType.Decimal, 5, lookupItem.RecordStatus.IsEmpty(), lookupItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, lookupItem.UpdateUserCode.IsEmpty(), lookupItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, lookupItem.UpdateDate.IsEmpty(), lookupItem.UpdateDate)
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupItem.LookupId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, lookupItem.CompanyId)
                .AddParameter("Language", DbType.Decimal, 5, False, lookupItem.Language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, lookupItem.ParentLookupId)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, False, lookupItem.SubParentLookupId)
                .AddParameter("Code", DbType.Decimal, 9, False, lookupItem.Code)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <param name="lookupid"></param>
        ''' <param name="companyid"></param>
        ''' <param name="language"></param>
        ''' <param name="parentlookupid"></param>
        ''' <param name="subparentlookupid"></param>
        ''' <param name="code"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(lookupid As Integer, companyid As Integer, language As Integer, parentlookupid As Integer, subparentlookupid As Integer, code As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND SubParentLookupId=@:SubParentLookupId AND Code=@:Code AND CompanyId=@:CompanyId", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentlookupid)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, False, subparentlookupid)
                .AddParameter("Code", DbType.Decimal, 9, False, code)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Lookup por medio de su clave primaria.
        ''' </summary>
        ''' <param name="lookupid"></param>
        ''' <param name="companyid"></param>
        ''' <param name="language"></param>
        ''' <param name="parentlookupid"></param>
        ''' <param name="subparentlookupid"></param>
        ''' <param name="code"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(lookupid As Integer, companyid As Integer, language As Integer, parentlookupid As Integer, subparentlookupid As Integer, code As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(LookupId) " &
                                          "FROM Lookup " &
                                         "WHERE LookupId=@:LookupId AND CompanyId=@:CompanyId AND Language=@:Language AND ParentLookupId=@:ParentLookupId AND SubParentLookupId=@:SubParentLookupId AND Code=@:Code AND CompanyId=@:CompanyId", "Lookup", "Research")
                .AddParameter("LookupId", DbType.Decimal, 9, False, lookupid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("Language", DbType.Decimal, 5, False, language)
                .AddParameter("ParentLookupId", DbType.Decimal, 9, False, parentlookupid)
                .AddParameter("SubParentLookupId", DbType.Decimal, 9, False, subparentlookupid)
                .AddParameter("Code", DbType.Decimal, 9, False, code)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista para selección de la tabla Lookup.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <returns>Lista de instancias de LookUpValue</returns>
        Public Shared Function LookUp(companyId As Integer) As List(Of Architect.Common.DataType.LookUpValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.Common.DataType.LookUpValue)
            With New DataManagerFactory("SELECT LookupId, Description " &
                                          "FROM Lookup WHERE CompanyId=@:CompanyId ORDER BY Description", "Lookup", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.Common.DataType.LookUpValue With {.Code = itemRow.StringValue("LookupId"), .Description = itemRow.StringValue("Description")})
                    Next
                End If
            End With
            Return result
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Lookup.
        ''' </summary>
        ''' <returns>Instancia de Lookup</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.Lookup
            Return New Architect.API.Core.Contracts.General.Lookup With {.LookupId = itemRow.NumericValue("LookupId"), .CompanyId = itemRow.NumericValue("CompanyId"), .Language = itemRow.NumericValue("Language"), .ParentLookupId = itemRow.NumericValue("ParentLookupId"), .SubParentLookupId = itemRow.NumericValue("SubParentLookupId"), .Code = itemRow.NumericValue("Code"), .Description = itemRow.StringValue("Description"), .QueryOrder = itemRow.NumericValue("QueryOrder"), .HomologousCode = itemRow.StringValue("HomologousCode"), .ExtendNumberValue1 = itemRow.NumericValue("ExtendNumberValue1"), .ExtendNumberValue2 = itemRow.NumericValue("ExtendNumberValue2"), .ExtendStringValue1 = itemRow.StringValue("ExtendStringValue1"), .ExtendStringValue2 = itemRow.StringValue("ExtendStringValue2"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

