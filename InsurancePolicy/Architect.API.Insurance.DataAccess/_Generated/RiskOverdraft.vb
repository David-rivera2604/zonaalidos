Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' Información de los prestamos vinculados a una póliza.
    ''' </summary>
    Partial Public NotInheritable Class RiskOverdraft

        ''' <summary>
        ''' Crea un registro en la tabla RiskOverdraft.
        ''' </summary>
        ''' <param name="riskoverdraftItem">Instancia de RiskOverdraft</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Public Shared Function Create(riskoverdraftItem As Architect.API.Insurance.Contracts.Policy.RiskOverdraft) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO RiskOverdraft " &
                                              "(Id, CompanyId, StartTerm, EndTerm, Amount1, EndTermOnAmount1, Recast1, Amount2, EndTermOnAmount2, Recast2, Amount3, EndTermOnAmount3, Recast3, Amount4, EndTermOnAmount4, Recast4, Amount5, EndTermOnAmount5, Recast5, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:Id, @:CompanyId, @:StartTerm, @:EndTerm, @:Amount1, @:EndTermOnAmount1, @:Recast1, @:Amount2, @:EndTermOnAmount2, @:Recast2, @:Amount3, @:EndTermOnAmount3, @:Recast3, @:Amount4, @:EndTermOnAmount4, @:Recast4, @:Amount5, @:EndTermOnAmount5, @:Recast5, @:UpdateUserCode, @:UpdateDate)", "RiskOverdraft", "Research")
                .AddParameter("Id", DbType.Decimal, 9, riskoverdraftItem.Id.IsEmpty(), riskoverdraftItem.Id)
                .AddParameter("CompanyId", DbType.Decimal, 5, riskoverdraftItem.CompanyId.IsEmpty(), riskoverdraftItem.CompanyId)
                .AddParameter("StartTerm", DbType.DateTime, 9, riskoverdraftItem.StartTerm.IsEmpty(), riskoverdraftItem.StartTerm)
                .AddParameter("EndTerm", DbType.DateTime, 9, riskoverdraftItem.EndTerm.IsEmpty(), riskoverdraftItem.EndTerm)
                .AddParameter("Amount1", DbType.Decimal, 18, riskoverdraftItem.Amount1.IsEmpty(), riskoverdraftItem.Amount1)
                .AddParameter("EndTermOnAmount1", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount1.IsEmpty(), riskoverdraftItem.EndTermOnAmount1)
                .AddParameter("Recast1", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast1, 1, 0))
                .AddParameter("Amount2", DbType.Decimal, 18, riskoverdraftItem.Amount2.IsEmpty(), riskoverdraftItem.Amount2)
                .AddParameter("EndTermOnAmount2", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount2.IsEmpty(), riskoverdraftItem.EndTermOnAmount2)
                .AddParameter("Recast2", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast2, 1, 0))
                .AddParameter("Amount3", DbType.Decimal, 18, riskoverdraftItem.Amount3.IsEmpty(), riskoverdraftItem.Amount3)
                .AddParameter("EndTermOnAmount3", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount3.IsEmpty(), riskoverdraftItem.EndTermOnAmount3)
                .AddParameter("Recast3", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast3, 1, 0))
                .AddParameter("Amount4", DbType.Decimal, 18, riskoverdraftItem.Amount4.IsEmpty(), riskoverdraftItem.Amount4)
                .AddParameter("EndTermOnAmount4", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount4.IsEmpty(), riskoverdraftItem.EndTermOnAmount4)
                .AddParameter("Recast4", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast4, 1, 0))
                .AddParameter("Amount5", DbType.Decimal, 18, riskoverdraftItem.Amount5.IsEmpty(), riskoverdraftItem.Amount5)
                .AddParameter("EndTermOnAmount5", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount5.IsEmpty(), riskoverdraftItem.EndTermOnAmount5)
                .AddParameter("Recast5", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast5, 1, 0))
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskoverdraftItem.UpdateUserCode.IsEmpty(), riskoverdraftItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskoverdraftItem.UpdateDate.IsEmpty(), riskoverdraftItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla RiskOverdraft por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única de la póliza.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Instancia de RiskOverdraft</returns>
        Public Shared Function Retrieve(id As Integer, companyId As Integer) As Architect.API.Insurance.Contracts.Policy.RiskOverdraft
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Insurance.Contracts.Policy.RiskOverdraft = Nothing
            With New DataManagerFactory("SELECT Id, RiskOverdraft.CompanyId, StartTerm, EndTerm, Amount1, EndTermOnAmount1, Recast1, Amount2, EndTermOnAmount2, Recast2, Amount3, EndTermOnAmount3, Recast3, Amount4, EndTermOnAmount4, Recast4, Amount5, EndTermOnAmount5, Recast5, RiskOverdraft.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskOverdraft.UpdateDate " &
                                          "FROM RiskOverdraft LEFT JOIN UserMember um ON um.UserId = RiskOverdraft.UpdateUserCode " &
                                         "WHERE RiskOverdraft.Id=@:Id AND RiskOverdraft.CompanyId=@:CompanyId", "RiskOverdraft", "Research")
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
        ''' Actualiza un registro en la tabla RiskOverdraft por medio de su clave primaria.
        ''' </summary>
        ''' <param name="riskoverdraftItem">Instancia de RiskOverdraft</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(riskoverdraftItem As Architect.API.Insurance.Contracts.Policy.RiskOverdraft) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE RiskOverdraft " &
                                           "SET CompanyId=@:CompanyId, StartTerm=@:StartTerm, EndTerm=@:EndTerm, Amount1=@:Amount1, EndTermOnAmount1=@:EndTermOnAmount1, Recast1=@:Recast1, Amount2=@:Amount2, EndTermOnAmount2=@:EndTermOnAmount2, Recast2=@:Recast2, Amount3=@:Amount3, EndTermOnAmount3=@:EndTermOnAmount3, Recast3=@:Recast3, Amount4=@:Amount4, EndTermOnAmount4=@:EndTermOnAmount4, Recast4=@:Recast4, Amount5=@:Amount5, EndTermOnAmount5=@:EndTermOnAmount5, Recast5=@:Recast5, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE Id=@:Id", "RiskOverdraft", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, riskoverdraftItem.CompanyId.IsEmpty(), riskoverdraftItem.CompanyId)
                .AddParameter("StartTerm", DbType.DateTime, 9, riskoverdraftItem.StartTerm.IsEmpty(), riskoverdraftItem.StartTerm)
                .AddParameter("EndTerm", DbType.DateTime, 9, riskoverdraftItem.EndTerm.IsEmpty(), riskoverdraftItem.EndTerm)
                .AddParameter("Amount1", DbType.Decimal, 18, riskoverdraftItem.Amount1.IsEmpty(), riskoverdraftItem.Amount1)
                .AddParameter("EndTermOnAmount1", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount1.IsEmpty(), riskoverdraftItem.EndTermOnAmount1)
                .AddParameter("Recast1", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast1, 1, 0))
                .AddParameter("Amount2", DbType.Decimal, 18, riskoverdraftItem.Amount2.IsEmpty(), riskoverdraftItem.Amount2)
                .AddParameter("EndTermOnAmount2", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount2.IsEmpty(), riskoverdraftItem.EndTermOnAmount2)
                .AddParameter("Recast2", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast2, 1, 0))
                .AddParameter("Amount3", DbType.Decimal, 18, riskoverdraftItem.Amount3.IsEmpty(), riskoverdraftItem.Amount3)
                .AddParameter("EndTermOnAmount3", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount3.IsEmpty(), riskoverdraftItem.EndTermOnAmount3)
                .AddParameter("Recast3", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast3, 1, 0))
                .AddParameter("Amount4", DbType.Decimal, 18, riskoverdraftItem.Amount4.IsEmpty(), riskoverdraftItem.Amount4)
                .AddParameter("EndTermOnAmount4", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount4.IsEmpty(), riskoverdraftItem.EndTermOnAmount4)
                .AddParameter("Recast4", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast4, 1, 0))
                .AddParameter("Amount5", DbType.Decimal, 18, riskoverdraftItem.Amount5.IsEmpty(), riskoverdraftItem.Amount5)
                .AddParameter("EndTermOnAmount5", DbType.DateTime, 9, riskoverdraftItem.EndTermOnAmount5.IsEmpty(), riskoverdraftItem.EndTermOnAmount5)
                .AddParameter("Recast5", DbType.Decimal, 1, False, IIf(riskoverdraftItem.Recast5, 1, 0))
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, riskoverdraftItem.UpdateUserCode.IsEmpty(), riskoverdraftItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, riskoverdraftItem.UpdateDate.IsEmpty(), riskoverdraftItem.UpdateDate)
                .AddParameter("Id", DbType.Decimal, 9, False, riskoverdraftItem.Id)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla RiskOverdraft por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id">Identificación única de la póliza.</param>
        ''' <param name="companyId">Identificación de la compañia propietaria.</param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(id As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskOverdraft " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "RiskOverdraft", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RiskOverdraft.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Lista de instancias de RiskOverdraft</returns>
        Public Shared Function RetrieveByIdCompanyId(id As Integer, companyid As Integer) As List(Of Architect.API.Insurance.Contracts.Policy.RiskOverdraft)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RiskOverdraft)
            With New DataManagerFactory("Select Id, RiskOverdraft.CompanyId, StartTerm, EndTerm, Amount1, EndTermOnAmount1, Recast1, Amount2, EndTermOnAmount2, Recast2, Amount3, EndTermOnAmount3, Recast3, Amount4, EndTermOnAmount4, Recast4, Amount5, EndTermOnAmount5, Recast5, RiskOverdraft.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, RiskOverdraft.UpdateDate " &
                                          "FROM RiskOverdraft LEFT JOIN UserMember um ON um.UserId = RiskOverdraft.UpdateUserCode " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "RiskOverdraft", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
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
        ''' Elimina un registro en la tabla RiskOverdraft por medio de su clave primaria.
        ''' </summary>
        ''' <param name="id"></param>
        ''' <param name="companyid"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function DeleteByIdCompanyId(id As Integer, companyid As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RiskOverdraft " &
                                         "WHERE Id=@:Id AND CompanyId=@:CompanyId", "RiskOverdraft", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de RiskOverdraft.
        ''' </summary>
        ''' <returns>Instancia de RiskOverdraft</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.RiskOverdraft
            Return New Architect.API.Insurance.Contracts.Policy.RiskOverdraft With {.Id = itemRow.NumericValue("Id"), .CompanyId = itemRow.NumericValue("CompanyId"), .StartTerm = itemRow.DateTimeValue("StartTerm"), .EndTerm = itemRow.DateTimeValue("EndTerm"), .Amount1 = itemRow.NumericValue("Amount1"), .EndTermOnAmount1 = itemRow.DateTimeValue("EndTermOnAmount1"), .Recast1 = (itemRow.NumericValue("Recast1") = 1), .Amount2 = itemRow.NumericValue("Amount2"), .EndTermOnAmount2 = itemRow.DateTimeValue("EndTermOnAmount2"), .Recast2 = (itemRow.NumericValue("Recast2") = 1), .Amount3 = itemRow.NumericValue("Amount3"), .EndTermOnAmount3 = itemRow.DateTimeValue("EndTermOnAmount3"), .Recast3 = (itemRow.NumericValue("Recast3") = 1), .Amount4 = itemRow.NumericValue("Amount4"), .EndTermOnAmount4 = itemRow.DateTimeValue("EndTermOnAmount4"), .Recast4 = (itemRow.NumericValue("Recast4") = 1), .Amount5 = itemRow.NumericValue("Amount5"), .EndTermOnAmount5 = itemRow.DateTimeValue("EndTermOnAmount5"), .Recast5 = (itemRow.NumericValue("Recast5") = 1), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

