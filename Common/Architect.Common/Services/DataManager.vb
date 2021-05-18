#Region "using"

Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration
Imports System.ServiceModel
Imports Architect.Common.Attributes
Imports Architect.Common.Helpers
Imports Architect.Common.Services.Contracts
Imports Architect.Common.Services.Interfaces

#End Region

Namespace Services

    '<AspNetCompatibilityRequirements(RequirementsMode:=AspNetCompatibilityRequirementsMode.Allowed)>
    <EntityExclude()>
    Public Class DataManager
        Implements IDataManager

        ''' <summary>
        ''' Método que permite devolver valores en modo Lookup / Method to return values mode Lookup
        ''' </summary>
        ''' <param name="command"></param>
        ''' <returns></returns>
        Public Function QueryExecuteToLookup(command As DataCommand) As List(Of DataType.LookUpValue) Implements IDataManager.QueryExecuteToLookup
            Dim result As New List(Of DataType.LookUpValue)
            Dim resultTable As DataTable
            Using db As DbConnection = ConnectionOpenLocal(command)
                If Not String.IsNullOrEmpty(command.QueryCount) Then
                    Using commandItem As DbCommand = db.CreateCommand()
                        With commandItem
                            .CommandType = CommandType.Text
                            .CommandText = DataAccessLayer.PreprocessStatement(command.QueryCount, db.ToString)
                        End With
                        BuildParameters(command, commandItem)
                        command.QueryCountResult = DataAccessLayer.QueryExecuteScalar(Of Integer)(commandItem, db, command.TableName)
                        commandItem.Connection = Nothing
                        commandItem.Dispose()
                    End Using
                End If

                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    resultTable = DataAccessLayer.QueryExecuteToTable(commandItem, db, CommandBehavior.Default, command.TableName)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()

                    If resultTable.Columns.Count >= 2 Then

                        If resultTable.IsNotEmpty AndAlso resultTable.Rows.Count <> 1 Then
                            For Each Item As DataRow In resultTable.Rows
                                result.Add(New DataType.LookUpValue() With {.Code = Item.StringValue(resultTable.Columns(0).ColumnName).Trim, .Description = Item.StringValue(resultTable.Columns(1).ColumnName).Trim})
                            Next
                        End If

                    Else
                        Throw New Exceptions.CustomException("The query must have at least two columns for the lookupvalue")
                    End If
                End Using
                db.Close()
                db.Dispose()
            End Using

            Return result
        End Function

        Public Function QueryExecuteToTableJSON(command As DataCommand, resultEmpty As Boolean) As String Implements IDataManager.QueryExecuteToTableJSON
            Dim result As DataTable = Nothing

            Using db As DbConnection = DataAccessLayer.OpenDbConnection(command.ConnectionStringName, command.CompanyId)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.QueryExecuteToTableJSON(commandItem, db, CommandBehavior.Default, command.TableName, resultEmpty)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            Return result.ToJSON().CompressString
        End Function

        Public Function QueryExecuteToTable(command As DataCommand, resultEmpty As Boolean) As QueryResult Implements IDataManager.QueryExecuteToTable
            Dim result As New QueryResult
            Using db As DbConnection = ConnectionOpenLocal(command)
                If Not String.IsNullOrEmpty(command.QueryCount) Then
                    Using commandItem As DbCommand = db.CreateCommand()
                        With commandItem
                            .CommandType = CommandType.Text
                            .CommandText = DataAccessLayer.PreprocessStatement(command.QueryCount, db.ToString)
                        End With
                        BuildParameters(command, commandItem)
                        command.QueryCountResult = DataAccessLayer.QueryExecuteScalar(Of Integer)(commandItem, db, command.TableName)
                        commandItem.Connection = Nothing
                        commandItem.Dispose()
                    End Using
                End If

                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result.Table = DataAccessLayer.QueryExecuteToTable(commandItem, db, CommandBehavior.Default, command.TableName, resultEmpty)
                    If result.Table.IsNotEmpty AndAlso result.Table.Rows.Count > 0 Then
                        result.QueryCountResult = result.Table.Rows.Count
                    End If
                    With command
                        If Not .IgnoreMaxNumberOfRecords Then
                            If .MaxNumberOfRecord <> 0 Then
                                If result.Table.IsNotEmpty AndAlso result.Table.Rows.Count > .MaxNumberOfRecord Then
                                    Dim newDataTable As New DataTable
                                    newDataTable = result.Table.Clone
                                    newDataTable.Rows.Clear()
                                    For i = 0 To .MaxNumberOfRecord - 1
                                        newDataTable.ImportRow(result.Table.Rows(i))
                                    Next
                                    result.Table = newDataTable
                                End If
                            End If
                        End If
                    End With
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Over method for connectionstringsraw
        ''' </summary>
        ''' <param name="command"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConnectionOpenLocal(command As DataCommand) As DbConnection
            Dim result As DbConnection = Nothing
            If IsNothing(command.ConnectionStringsRaw) Then
                result = DataAccessLayer.OpenDbConnection(command.ConnectionStringName, command.CompanyId)
            Else
                If Not IsNothing(command.ConnectionStringsRaw) Then
                    result = DataAccessLayer.OpenDbConnectionRaw(command.ConnectionStringsRaw.ConnectionString, command.ConnectionStringsRaw.ProviderName)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        ''' Over method for connectionstringsraw
        ''' </summary>
        ''' <param name="connectionName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConnectionOpenLocal(connectionName As String) As DbConnection
            Dim result As DbConnection = Nothing
            result = DataAccessLayer.OpenDbConnection(connectionName)
            Return result
        End Function

        Public Function QueryExecuteScalar(command As DataCommand) As Object Implements IDataManager.QueryExecuteScalar
            Dim result As Object = Nothing

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.QueryExecuteScalar(Of Object)(commandItem, db, command.TableName)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using

            Return result
        End Function

        Public Function QueryExecuteScalarToInteger(command As DataCommand) As Integer Implements IDataManager.QueryExecuteScalarToInteger
            Dim result As Integer = 0

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.QueryExecuteScalar(Of Integer)(commandItem, db, command.TableName)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            If result.IsEmpty Then
                result = 0
            End If
            Return result
        End Function

        ''' <summary>
        ''' Método que permite devolver el valor en decimal/ Method to return the value in decimal
        ''' </summary>
        ''' <param name="command"></param>
        ''' <returns></returns>
        Public Function QueryExecuteScalarToDecimal(command As DataCommand) As Decimal Implements IDataManager.QueryExecuteScalarToDecimal
            Dim result As Decimal = 0

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.QueryExecuteScalar(Of Decimal)(commandItem, db, command.TableName)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            If result.IsEmpty Then
                result = 0.0
            End If
            Return result
        End Function

        Public Function QueryExecuteScalarToString(command As DataCommand) As String Implements IDataManager.QueryExecuteScalarToString
            Dim result As String = String.Empty

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.QueryExecuteScalar(Of String)(commandItem, db, command.TableName)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            If result.IsEmpty Then
                result = String.Empty
            End If
            Return result
        End Function

        Public Function QueryExecuteScalarToDate(command As DataCommand) As Date Implements IDataManager.QueryExecuteScalarToDate
            Dim result As Date = Date.MinValue

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.QueryExecuteScalar(Of Date)(commandItem, db, command.TableName)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            If result.IsEmpty Then
                result = Date.MinValue
            End If
            Return result
        End Function

        Public Sub CommandExecuteAsynchronous(command As DataCommand) Implements IDataManager.CommandExecuteAsynchronous
            Dim result As Integer = 0

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.CommandExecute(commandItem, db, command.TableName, command.Operation)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
        End Sub

        Public Function CommandExecute(command As DataCommand) As Integer Implements IDataManager.CommandExecute
            Dim result As Integer = 0

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    result = DataAccessLayer.CommandExecute(commandItem, db, command.TableName, command.Operation)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            Return result
        End Function

        Public Function DataStructure(command As DataCommand) As String Implements IDataManager.DataStructure
            Dim result As String = "Ok"

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.Text
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    DataAccessLayer.CommandExecute(commandItem, db, command.TableName, "Data Structure")
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            Return result
        End Function

        ''' <summary>
        '''  Build the command for making to script - Construye el comando para convertirlo en un script
        ''' </summary>
        ''' <param name="command"> Command executed - Comando ejecutado</param>
        ''' <returns>Real statement - Comando real</returns>
        Public Function ResolveStatement(command As DataCommand) As String Implements IDataManager.ResolveStatement
            Dim result As String = String.Empty

            Using db As DbConnection = ConnectionOpenLocal(command)
                Dim statement As String = command.Statement
                Dim value As String = "'Null'"

                For Each item As DataParameter In command.Parameters
                    If Not item.IsNull Then

                        Select Case item.Type
                            Case DbType.AnsiString, DbType.AnsiStringFixedLength
                                value = String.Format(CultureInfo.InvariantCulture, "'{0}'", item.Value.ToString.Replace("'", "''"))

                            Case Else
                                value = String.Format(CultureInfo.InvariantCulture, "{0}", item.Value.ToString.Replace("'", String.Empty))
                        End Select
                    End If

                    statement = statement.Replace(String.Format(CultureInfo.InvariantCulture, "@:{0}", item.Name), value)
                Next

                result = DataAccessLayer.PreprocessStatement(statement, db.ToString)
            End Using

            Return result
        End Function

        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="command"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ObjectExist(command As DataCommand) As Boolean Implements IDataManager.ObjectExist
            Dim result As Boolean

            Using db As DbConnection = ConnectionOpenLocal(command)
                Dim providerName As String = db.ToString

                Using commandItem As DbCommand = db.CreateCommand()
                    If DataAccessLayer.IsOracle(providerName) Then
                        With commandItem
                            .CommandType = CommandType.Text
                            .CommandText = DataAccessLayer.PreprocessStatement("SELECT COUNT(ALL_OBJECTS.OBJECT_NAME)" &
                                                                                " FROM ALL_OBJECTS" &
                                                                               " WHERE ALL_OBJECTS.OWNER       =@:OWNER" &
                                                                                 " AND ALL_OBJECTS.OBJECT_TYPE =@:TYPE" &
                                                                                 " AND ALL_OBJECTS.OBJECT_NAME =@:NAME", providerName)
                        End With
                    Else
                        Throw New NotImplementedException
                    End If
                    DataAccessLayer.CommandParameter(commandItem, "OWNER", DbType.AnsiString, 30, True, command.Owner.ToUpper)
                    DataAccessLayer.CommandParameter(commandItem, "TYPE", DbType.AnsiString, 30, True, command.ObjectType.ToUpper)
                    DataAccessLayer.CommandParameter(commandItem, "NAME", DbType.AnsiString, 30, True, command.TableName.ToUpper)

                    result = (DataAccessLayer.QueryExecuteScalar(Of Integer)(commandItem, db, "Object Exist") > 0)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using

            Return result
        End Function

#Region "Helpers"

        ''' <summary>
        '''
        ''' </summary>
        ''' <param name="command"></param>
        ''' <param name="commandItem"></param>
        ''' <remarks></remarks>
        Private Shared Sub BuildParameters(command As DataCommand, commandItem As DbCommand)
            If command.Parameters.IsNotEmpty AndAlso command.Parameters.Count > 0 Then
                For Each item As DataParameter In command.Parameters
                    DataAccessLayer.CommandParameter(commandItem, item.Name, item.Type, item.Size, Not item.IsNull, item.Value, item.Direction)
                Next
            End If
        End Sub

        ''' <summary>
        ''' Create a new parameter of RefCursor type
        ''' </summary>
        ''' <param name="parameterInstance"></param>
        ''' <returns>DbParameter with DbType RefCursor</returns>
        ''' <remarks>
        ''' Usage: command.Parameters.Add(CreateRefCursorParameter(dbProviderFactory.CreateParameter()))
        ''' </remarks>
        Private Shared Function CreateRefCursorParameter(parameterInstance As DbParameter) As DbParameter
            Dim parameterType As Type = parameterInstance.GetType
            Dim oracleDbType As Type = parameterType.Assembly.GetType("Oracle.DataAccess.Client.OracleDbType")
            Dim refCursorParameter As Object = Activator.CreateInstance(parameterType, New Object() {"RC1", [Enum].Parse(oracleDbType, "RefCursor")})
            refCursorParameter.Direction = ParameterDirection.Output

            Return refCursorParameter
        End Function

#End Region

        Public Function ProcedureExecute(command As DataCommand) As StoredProcedureResult Implements IDataManager.ProcedureExecute
            Dim resultRowAffected As Integer = 0
            Dim result As New StoredProcedureResult
            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)
                    resultRowAffected = DataAccessLayer.CommandExecute(commandItem, db, command.TableName, command.Operation)
                    result.RowAffected = resultRowAffected
                    Dim tempParamtterOut As List(Of DbParameter) = StoredParemeterOut(commandItem.Parameters)
                    If Not IsNothing(tempParamtterOut) AndAlso tempParamtterOut.Count <> 0 Then
                        result.OutParameter = New Dictionary(Of String, Object)
                        For Each item In tempParamtterOut
                            With result.OutParameter
                                If Not .ContainsKey(item.ParameterName) Then
                                    .Add(item.ParameterName, item.Value)
                                End If
                            End With
                        Next
                    End If
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using
            Return result
        End Function

        Private Function StoredParemeterOut(dbParameterCollection As DbParameterCollection) As List(Of DbParameter)
            Dim result As New List(Of DbParameter)
            For Each item As DbParameter In dbParameterCollection
                If item.Direction = ParameterDirection.Output Or item.Direction = ParameterDirection.InputOutput Then
                    result.Add(item)
                    If IsDBNull(item.Value) Then
                        item.Value = Nothing
                    End If
                End If
            Next
            Return result
        End Function

        ''' <summary>
        ''' Permite la ejecucion de un procedure tipado con retorno de un table
        ''' </summary>
        ''' <param name="command"></param>
        ''' <param name="resultEmpty"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ProcedureExecuteToTable(command As DataCommand, resultEmpty As Boolean) As QueryResult Implements IDataManager.ProcedureExecuteToTable
            Dim result As New QueryResult
            Using db As DbConnection = ConnectionOpenLocal(command)
                If Not String.IsNullOrEmpty(command.QueryCount) Then
                    Using commandItem As DbCommand = db.CreateCommand()
                        With commandItem
                            .CommandType = CommandType.Text
                            .CommandText = DataAccessLayer.PreprocessStatement(command.QueryCount, db.ToString)
                        End With
                        BuildParameters(command, commandItem)
                        command.QueryCountResult = DataAccessLayer.QueryExecuteScalar(Of Integer)(commandItem, db, command.TableName)
                        commandItem.Connection = Nothing
                        commandItem.Dispose()
                    End Using
                End If

                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)

                    If DataAccessLayer.IsOracle(db.ToString) Then
                        commandItem.Parameters.Add(CreateRefCursorParameter(commandItem.CreateParameter()))
                    End If
                    result.QueryCountResult = command.QueryCountResult
                    result.Table = DataAccessLayer.QueryExecuteToTable(commandItem, db, CommandBehavior.Default, command.TableName, resultEmpty)
                    If result.Table.IsNotEmpty AndAlso result.Table.Rows.Count > 0 Then
                        result.QueryCountResult = result.Table.Rows.Count
                    End If
                    With command
                        If Not .IgnoreMaxNumberOfRecords Then
                            If .MaxNumberOfRecord <> 0 Then
                                If result.Table.IsNotEmpty AndAlso result.Table.Rows.Count > .MaxNumberOfRecord Then
                                    Dim newDataTable As New DataTable
                                    newDataTable = result.Table.Clone
                                    newDataTable.Rows.Clear()
                                    For i = 0 To .MaxNumberOfRecord - 1
                                        newDataTable.ImportRow(result.Table.Rows(i))
                                    Next
                                    result.Table = newDataTable
                                End If
                            End If
                        End If
                    End With
                End Using
            End Using

            Return result
        End Function

        ''' <summary>
        ''' Sobre carga para poder envir un conjunto de commandos y ejecutar como instruccion atomica
        ''' </summary>
        ''' <param name="commands"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PackageExecuteScalar(commands As List(Of DataCommand)) As String Implements IDataManager.PackageExecuteScalar
            Return PackageExecuteScalar(commands, "")
        End Function

        ''' <summary>
        ''' Metodo poder envir un conjunto de commandos y ejecutar como instruccion atomica
        ''' </summary>
        ''' <param name="commands"></param>
        ''' <param name="connectionName"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function PackageExecuteScalar(commands As List(Of DataCommand), connectionName As String) As String
            Dim result As String = String.Empty

            Using db As DbConnection = DataAccessLayer.OpenDbConnection(commands.First.ConnectionStringName, commands.Item(0).CompanyId)
                For Each command As DataCommand In commands
                    Using commandItem As DbCommand = db.CreateCommand()
                        With commandItem
                            .CommandType = CommandType.Text
                            .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                        End With
                        BuildParameters(command, commandItem)
                        result &= DataAccessLayer.QueryExecuteScalar(commandItem, db, command.TableName) & ";"
                        commandItem.Connection = Nothing
                        commandItem.Dispose()
                    End Using
                Next
                db.Close()
                db.Dispose()
            End Using
            If result.EndsWith(";") Then
                result = result.Substring(0, result.Length - 1)
            End If
            Return result
        End Function

        ''' <summary>
        ''' Retorna el la structura de un sp
        ''' </summary>
        ''' <param name="command"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ProcedureExecuteResultSchema(command As DataCommand) As DataTable Implements IDataManager.ProcedureExecuteResultSchema
            Dim result As DataTable = Nothing

            Using db As DbConnection = ConnectionOpenLocal(command)
                Using commandItem As DbCommand = db.CreateCommand()
                    With commandItem
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = DataAccessLayer.PreprocessStatement(command.Statement, db.ToString)
                    End With
                    BuildParameters(command, commandItem)

                    If DataAccessLayer.IsOracle(db.ToString) Then
                        commandItem.Parameters.Add(CreateRefCursorParameter(commandItem.CreateParameter()))
                    End If
                    result = DataAccessLayer.QueryExecuteToTable(commandItem, db, CommandBehavior.SchemaOnly, command.TableName, True)
                    commandItem.Connection = Nothing
                    commandItem.Dispose()
                End Using
                db.Close()
                db.Dispose()
            End Using

            Return result
        End Function

#Region "Tools"

        Function ConnectionStringGet(ConnectionStrinName As String, companyId As Integer) As ConnectionString Implements IDataManager.ConnectionStringGet
            Return ConnectionStrings.ConnectionStringGet(ConnectionStrinName, companyId)
        End Function

        Function ConnectionStringGetAll(ConnectionStrinName As String, companyId As Integer) As List(Of ConnectionString) Implements IDataManager.ConnectionStringGetAll
            Return ConnectionStrings.ConnectionStringGetAll(ConnectionStrinName, companyId)
        End Function

        Function ConnectionStringUserAndPassword(ConectionStringName As String, companyId As Integer) As Credential Implements IDataManager.ConnectionStringUserAndPassword
            Return ConnectionStrings.ConnectionStringUserAndPassword(ConectionStringName, companyId)
        End Function

#End Region

        ''' <summary>
        '''  Obtiene el provider de ConnectionString que se solicita.
        ''' </summary>
        ''' <param name="repositoryName">Nombre del ConnectionString</param>
        ''' <returns></returns>
        Public Function GetDataBaseProvider(repositoryName As String) As String Implements IDataManager.GetDataBaseProvider
            Dim result As String = String.Empty
            Try
                Dim companyDefault As Integer = Integer.MinValue
                If ConfigurationManager.AppSettings("BackOffice.CompanyDefault").IsNotEmpty Then
                    companyDefault = ConfigurationManager.AppSettings("BackOffice.CompanyDefault")
                Else
                    companyDefault = 1
                End If

                Dim resultConnectionString = ConnectionStrings.ConnectionStringGet(repositoryName, companyDefault)
                If resultConnectionString.IsNotEmpty Then
                    If resultConnectionString.ProviderName.ToLower.Contains("ora") Then
                        result = "ORACLE"
                    Else
                        result = resultConnectionString.ProviderName
                    End If
                Else
                    Throw Exceptions.ServiceFaultException.Factory(String.Format("ConnectionString '{0}', It's not found", repositoryName))
                End If
            Catch exServices As FaultException
                Throw exServices
            Catch ex As Exception
                Throw Exceptions.ServiceFaultException.Factory(String.Format("An error occurred while looking up the '{0}' connectionstring", repositoryName), ex)
            End Try
            Return result
        End Function

        ''' <summary>
        ''' Devuelve el valor del appSetting según el nombre del setting
        ''' </summary>
        ''' <param name="repositoryName">nombre del repositorio</param>
        ''' <param name="settingName">nombre del setting</param>
        Public Function GetSettingValue(repositoryName As String, settingName As String) As String Implements IDataManager.GetSettingValue
            Dim result As String = String.Empty

            Select Case settingName
                Case "DateFormat"
                    result = ConfigurationManager.AppSettings(String.Format(CultureInfo.InvariantCulture, "Linked.{0}.DateFormat", repositoryName))

                Case "NotesFormat"
                    result = ConfigurationManager.AppSettings(String.Format(CultureInfo.InvariantCulture, "Linked.{0}.NotesFormat", repositoryName))

                    If Not String.IsNullOrEmpty(result) Then
                        result = result.ToUpper(CultureInfo.CurrentCulture)
                    End If
            End Select

            Return result
        End Function

        Public Function CurrentTime() As String Implements IDataManager.CurrentTime
            Return DateTime.Now.ToLocalTime.ToString("yyyy-MM-ddTHH:mm:ss")
        End Function

        Public Function AppInfo(path As String) As Services.Contracts.info Implements IDataManager.AppInfo
            If String.IsNullOrEmpty(path) Then
                Return New info With {.Name = "Ruta: " & ConfigurationManager.AppSettings("WebApplicationPath")}
            Else
                Return Services.Contracts.info.Process(path)
            End If

        End Function

    End Class

End Namespace