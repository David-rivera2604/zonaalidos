Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class CustomFields

        ''' <summary>
        ''' Crea un registro en la tabla CustomFields.
        ''' </summary>
        ''' <param name="customfieldsItem">Instancia de CustomFields</param>
        ''' <returns>Instancia de CustomFields</returns>
        Public Shared Function Create(customfieldsItem As Architect.API.Core.Contracts.General.CustomFields) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO CustomFields " &
                                              "(Id, CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, RecordStatus, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:CompanyId, @:EntityType, @:Name, @:Caption, @:DataType, @:Precision, @:Scale, @:IsRequired, @:DisplayOrder, @:Specification, @:RecordStatus, @:UpdateUserCode, @:UpdateDate)", "CustomFields", "Research")
                .AddParameter("Id", DbType.Decimal, 9, customfieldsItem.Id.IsEmpty(), customfieldsItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, customfieldsItem.CompanyId.IsEmpty(), customfieldsItem.CompanyId)
                .AddParameter("EntityType", DbType.Decimal, 5, customfieldsItem.EntityType.IsEmpty(), customfieldsItem.EntityType)
                .AddParameter("Name", DbType.AnsiString, 40, customfieldsItem.Name.IsEmpty(), customfieldsItem.Name)
                .AddParameter("Caption", DbType.AnsiString, 80, customfieldsItem.Caption.IsEmpty(), customfieldsItem.Caption)
                .AddParameter("DataType", DbType.Decimal, 5, customfieldsItem.DataType.IsEmpty(), customfieldsItem.DataType)
                .AddParameter("Precision", DbType.Decimal, 3, customfieldsItem.Precision.IsEmpty(), customfieldsItem.Precision)
                .AddParameter("Scale", DbType.Decimal, 2, customfieldsItem.Scale.IsEmpty(), customfieldsItem.Scale)
                .AddParameter("IsRequired", DbType.Decimal, 1, False, IIf(customfieldsItem.IsRequired, 1, 0))
                .AddParameter("DisplayOrder", DbType.Decimal, 9, customfieldsItem.DisplayOrder.IsEmpty(), customfieldsItem.DisplayOrder)
                .AddParameter("Specification", DbType.AnsiString, 2048, customfieldsItem.Specification.IsEmpty(), customfieldsItem.Specification)
                .AddParameter("RecordStatus", DbType.Decimal, 5, customfieldsItem.RecordStatus.IsEmpty(), customfieldsItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, customfieldsItem.UpdateUserCode.IsEmpty(), customfieldsItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, customfieldsItem.UpdateDate.IsEmpty(), customfieldsItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla CustomFields por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Instancia de CustomFields</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Core.Contracts.General.CustomFields
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.CustomFields = Nothing
            With New DataManagerFactory("SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " &
                                          "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " &
                                         "WHERE CustomFields.Id=@:Id AND CustomFields.CompanyId=@:CompanyId", "CustomFields", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla CustomFields.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="filter"></param>
        ''' <returns>Lista de instancias de CustomFields</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.General.CustomFields)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.CustomFields)
            With New DataManagerFactory("SELECT Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " &
                                          "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " &
                                         "WHERE CustomFields.CompanyId=@:CompanyId", "CustomFields", "Research")
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
        ''' Verifica si existe un registro en la tabla CustomFields por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM CustomFields", "CustomFields", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla CustomFields por medio de su clave primaria.
        ''' </summary>
        ''' <param name="customfieldsItem">Instancia de CustomFields</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(customfieldsItem As Architect.API.Core.Contracts.General.CustomFields) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE CustomFields " &
                                           "SET CompanyId=@:CompanyId, EntityType=@:EntityType, Name=@:Name, Caption=@:Caption, DataType=@:DataType, Precision=@:Precision, Scale=@:Scale, IsRequired=@:IsRequired, DisplayOrder=@:DisplayOrder, Specification=@:Specification, RecordStatus=@:RecordStatus, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "CustomFields", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, customfieldsItem.CompanyId.IsEmpty(), customfieldsItem.CompanyId)
                .AddParameter("EntityType", DbType.Decimal, 5, customfieldsItem.EntityType.IsEmpty(), customfieldsItem.EntityType)
                .AddParameter("Name", DbType.AnsiString, 40, customfieldsItem.Name.IsEmpty(), customfieldsItem.Name)
                .AddParameter("Caption", DbType.AnsiString, 80, customfieldsItem.Caption.IsEmpty(), customfieldsItem.Caption)
                .AddParameter("DataType", DbType.Decimal, 5, customfieldsItem.DataType.IsEmpty(), customfieldsItem.DataType)
                .AddParameter("Precision", DbType.Decimal, 3, customfieldsItem.Precision.IsEmpty(), customfieldsItem.Precision)
                .AddParameter("Scale", DbType.Decimal, 2, customfieldsItem.Scale.IsEmpty(), customfieldsItem.Scale)
                .AddParameter("IsRequired", DbType.Decimal, 1, False, IIf(customfieldsItem.IsRequired, 1, 0))
                .AddParameter("DisplayOrder", DbType.Decimal, 9, customfieldsItem.DisplayOrder.IsEmpty(), customfieldsItem.DisplayOrder)
                .AddParameter("Specification", DbType.AnsiString, 2048, customfieldsItem.Specification.IsEmpty(), customfieldsItem.Specification)
                .AddParameter("RecordStatus", DbType.Decimal, 5, customfieldsItem.RecordStatus.IsEmpty(), customfieldsItem.RecordStatus)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, customfieldsItem.UpdateUserCode.IsEmpty(), customfieldsItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, customfieldsItem.UpdateDate.IsEmpty(), customfieldsItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, customfieldsItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla CustomFields por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM CustomFields " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "CustomFields", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla CustomFields por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(Id) " &
                                          "FROM CustomFields " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "CustomFields", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla CustomFields.
        ''' </summary>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de CustomFields</returns>
        Public Shared Function RetrieveByEntityTypeCompanyId(entitytype As Integer, companyid As Integer) As List(Of Architect.API.Core.Contracts.General.CustomFields)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.CustomFields)
            With New DataManagerFactory("Select Id, CustomFields.CompanyId, EntityType, Name, Caption, DataType, Precision, Scale, IsRequired, DisplayOrder, Specification, CustomFields.RecordStatus, CustomFields.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, CustomFields.UpdateDate " &
                                          "FROM CustomFields LEFT JOIN UserMember um ON um.UserId = CustomFields.UpdateUserCode " &
                                         "WHERE EntityType=@:EntityType AND CompanyId=@:CompanyId", "CustomFields", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
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
        ''' Elimina un registro en la tabla CustomFields por medio de su clave primaria.
        ''' </summary>
        ''' <param name="entitytype"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByEntityTypeCompanyId(entitytype As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM CustomFields " &
                                         "WHERE EntityType=@:EntityType AND CompanyId=@:CompanyId", "CustomFields", "Research")
                .AddParameter("EntityType", DbType.Decimal, 5, False, entitytype)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de CustomFields.
        ''' </summary>
        ''' <returns>Instancia de CustomFields</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.CustomFields
            Return New Architect.API.Core.Contracts.General.CustomFields With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .EntityType = itemRow.NumericValue("EntityType"), .Name = itemRow.StringValue("Name"), .Caption = itemRow.StringValue("Caption"), .DataType = itemRow.NumericValue("DataType"), .Precision = itemRow.NumericValue("Precision"), .Scale = itemRow.NumericValue("Scale"), .IsRequired = (itemRow.NumericValue("IsRequired") = 1), .DisplayOrder = itemRow.NumericValue("DisplayOrder"), .Specification = itemRow.StringValue("Specification"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

