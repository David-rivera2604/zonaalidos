Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Policy

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class RuleLoans

        ''' <summary>
        ''' Crea un registro en la tabla RuleLoans.
        ''' </summary>
        ''' <param name="ruleloansItem">Instancia de RuleLoans</param>
        ''' <returns>Instancia de RuleLoans</returns>
        Public Shared Function Create(ruleloansItem As Architect.API.Insurance.Contracts.Policy.RuleLoans) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO RuleLoans " &
                                              "(LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance) " &
                                        "VALUES(@:LoanNumber, @:CompanyId, @:DocumentNumber, @:FullName, @:BirthDate, @:Gender, @:StartTerm, @:EndTerm, @:Duration, @:Amount, @:Balance)", "RuleLoans", "Research")
                .AddParameter("LoanNumber", DbType.Decimal, 9, ruleloansItem.LoanNumber.IsEmpty(), ruleloansItem.LoanNumber)
                .AddParameter("CompanyId", DbType.Decimal, 5, ruleloansItem.CompanyId.IsEmpty(), ruleloansItem.CompanyId)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, ruleloansItem.DocumentNumber.IsEmpty(), ruleloansItem.DocumentNumber)
                .AddParameter("FullName", DbType.AnsiString, 160, ruleloansItem.FullName.IsEmpty(), ruleloansItem.FullName)
                .AddParameter("BirthDate", DbType.DateTime, 9, ruleloansItem.BirthDate.IsEmpty(), ruleloansItem.BirthDate)
                .AddParameter("Gender", DbType.Decimal, 5, ruleloansItem.Gender.IsEmpty(), ruleloansItem.Gender)
                .AddParameter("StartTerm", DbType.DateTime, 9, ruleloansItem.StartTerm.IsEmpty(), ruleloansItem.StartTerm)
                .AddParameter("EndTerm", DbType.DateTime, 9, ruleloansItem.EndTerm.IsEmpty(), ruleloansItem.EndTerm)
                .AddParameter("Duration", DbType.Decimal, 3, ruleloansItem.Duration.IsEmpty(), ruleloansItem.Duration)
                .AddParameter("Amount", DbType.Decimal, 18, ruleloansItem.Amount.IsEmpty(), ruleloansItem.Amount)
                .AddParameter("Balance", DbType.Decimal, 18, ruleloansItem.Balance.IsEmpty(), ruleloansItem.Balance)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla RuleLoans por medio de su clave primaria.
        ''' </summary>
        ''' <param name="loannumber"></param>
        ''' <returns>Instancia de RuleLoans</returns>
        Public Shared Function Retrieve(loannumber As Integer) As Architect.API.Insurance.Contracts.Policy.RuleLoans
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Insurance.Contracts.Policy.RuleLoans = Nothing
            With New DataManagerFactory("SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance " &
                                          "FROM RuleLoans " &
                                         "WHERE LoanNumber=@:LoanNumber", "RuleLoans", "Research")
                .AddParameter("LoanNumber", DbType.Decimal, 9, False, loannumber)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla RuleLoans.
        ''' </summary>
        ''' <returns>Lista de instancias de RuleLoans</returns>
        Public Shared Function RetrieveAll() As List(Of Architect.API.Insurance.Contracts.Policy.RuleLoans)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Insurance.Contracts.Policy.RuleLoans)
            With New DataManagerFactory("SELECT LoanNumber, CompanyId, DocumentNumber, FullName, BirthDate, Gender, StartTerm, EndTerm, Duration, Amount, Balance " &
                                          "FROM RuleLoans", "RuleLoans", "Research")
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
        ''' Verifica si existe un registro en la tabla RuleLoans por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(LoanNumber),0) " &
                                          "FROM RuleLoans", "RuleLoans", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla RuleLoans por medio de su clave primaria.
        ''' </summary>
        ''' <param name="ruleloansItem">Instancia de RuleLoans</param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(ruleloansItem As Architect.API.Insurance.Contracts.Policy.RuleLoans) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE RuleLoans " &
                                           "SET CompanyId=@:CompanyId, DocumentNumber=@:DocumentNumber, FullName=@:FullName, BirthDate=@:BirthDate, Gender=@:Gender, StartTerm=@:StartTerm, EndTerm=@:EndTerm, Duration=@:Duration, Amount=@:Amount, Balance=@:Balance " &
                                         "WHERE LoanNumber=@:LoanNumber", "RuleLoans", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, ruleloansItem.CompanyId.IsEmpty(), ruleloansItem.CompanyId)
                .AddParameter("DocumentNumber", DbType.AnsiString, 20, ruleloansItem.DocumentNumber.IsEmpty(), ruleloansItem.DocumentNumber)
                .AddParameter("FullName", DbType.AnsiString, 160, ruleloansItem.FullName.IsEmpty(), ruleloansItem.FullName)
                .AddParameter("BirthDate", DbType.DateTime, 9, ruleloansItem.BirthDate.IsEmpty(), ruleloansItem.BirthDate)
                .AddParameter("Gender", DbType.Decimal, 5, ruleloansItem.Gender.IsEmpty(), ruleloansItem.Gender)
                .AddParameter("StartTerm", DbType.DateTime, 9, ruleloansItem.StartTerm.IsEmpty(), ruleloansItem.StartTerm)
                .AddParameter("EndTerm", DbType.DateTime, 9, ruleloansItem.EndTerm.IsEmpty(), ruleloansItem.EndTerm)
                .AddParameter("Duration", DbType.Decimal, 3, ruleloansItem.Duration.IsEmpty(), ruleloansItem.Duration)
                .AddParameter("Amount", DbType.Decimal, 18, ruleloansItem.Amount.IsEmpty(), ruleloansItem.Amount)
                .AddParameter("Balance", DbType.Decimal, 18, ruleloansItem.Balance.IsEmpty(), ruleloansItem.Balance)
                .AddParameter("LoanNumber", DbType.Decimal, 9, False, ruleloansItem.LoanNumber)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla RuleLoans por medio de su clave primaria.
        ''' </summary>
        ''' <param name="loannumber"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(loannumber As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM RuleLoans " &
                                         "WHERE LoanNumber=@:LoanNumber", "RuleLoans", "Research")
                .AddParameter("LoanNumber", DbType.Decimal, 9, False, loannumber)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla RuleLoans por medio de su clave primaria.
        ''' </summary>
        ''' <param name="loannumber"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(loannumber As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(LoanNumber) " &
                                          "FROM RuleLoans " &
                                         "WHERE LoanNumber=@:LoanNumber", "RuleLoans", "Research")
                .AddParameter("LoanNumber", DbType.Decimal, 9, False, loannumber)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de RuleLoans.
        ''' </summary>
        ''' <returns>Instancia de RuleLoans</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Insurance.Contracts.Policy.RuleLoans
            Return New Architect.API.Insurance.Contracts.Policy.RuleLoans With {.LoanNumber = itemRow.NumericValue("LoanNumber"), .CompanyId = itemRow.NumericValue("CompanyId"), .DocumentNumber = itemRow.StringValue("DocumentNumber"), .FullName = itemRow.StringValue("FullName"), .BirthDate = itemRow.DateTimeValue("BirthDate"), .Gender = itemRow.NumericValue("Gender"), .StartTerm = itemRow.DateTimeValue("StartTerm"), .EndTerm = itemRow.DateTimeValue("EndTerm"), .Duration = itemRow.NumericValue("Duration"), .Amount = itemRow.NumericValue("Amount"), .Balance = itemRow.NumericValue("Balance")}
        End Function

#End Region

    End Class

End Namespace

