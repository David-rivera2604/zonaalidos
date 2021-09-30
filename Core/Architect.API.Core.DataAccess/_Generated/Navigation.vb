Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General

    ''' <summary>
    ''' 
    ''' </summary>
    Partial Public NotInheritable Class Navigation

        ''' <summary>
        ''' Crea un registro en la tabla Navigation.
        ''' </summary>
        ''' <param name="navigationItem">Instancia de Navigation</param>
        ''' <returns>Instancia de Navigation</returns>
        Public Shared Function Create(navigationItem As Architect.API.Core.Contracts.General.Navigation) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Navigation " &
                                              "(NavigationId, Code, ParentCode, Type, Title, MenuTitle, Description, URLPath, URLHelp, SmallImage, BigImage, Sequence, RecordStatus, CompanyId, UpdateUserCode, UpdateDate) " &
                                        "VALUES(@:NavigationId, @:Code, @:ParentCode, @:Type, @:Title, @:MenuTitle, @:Description, @:URLPath, @:URLHelp, @:SmallImage, @:BigImage, @:Sequence, @:RecordStatus, @:CompanyId, @:UpdateUserCode, @:UpdateDate)", "Navigation", "Research")
                .AddParameter("NavigationId", DbType.Decimal, 9, navigationItem.NavigationId.IsEmpty(), navigationItem.NavigationId)
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, navigationItem.Code.IsEmpty(), navigationItem.Code)
                .AddParameter("ParentCode", DbType.AnsiStringFixedLength, 8, navigationItem.ParentCode.IsEmpty(), navigationItem.ParentCode)
                .AddParameter("Type", DbType.Decimal, 5, navigationItem.Type.IsEmpty(), navigationItem.Type)
                .AddParameter("Title", DbType.AnsiString, 120, navigationItem.Title.IsEmpty(), navigationItem.Title)
                .AddParameter("MenuTitle", DbType.AnsiString, 40, navigationItem.MenuTitle.IsEmpty(), navigationItem.MenuTitle)
                .AddParameter("Description", DbType.AnsiString, 255, navigationItem.Description.IsEmpty(), navigationItem.Description)
                .AddParameter("URLPath", DbType.AnsiString, 255, navigationItem.URLPath.IsEmpty(), navigationItem.URLPath)
                .AddParameter("URLHelp", DbType.AnsiString, 255, navigationItem.URLHelp.IsEmpty(), navigationItem.URLHelp)
                .AddParameter("SmallImage", DbType.AnsiString, 80, navigationItem.SmallImage.IsEmpty(), navigationItem.SmallImage)
                .AddParameter("BigImage", DbType.AnsiString, 80, navigationItem.BigImage.IsEmpty(), navigationItem.BigImage)
                .AddParameter("Sequence", DbType.Decimal, 5, navigationItem.Sequence.IsEmpty(), navigationItem.Sequence)
                .AddParameter("RecordStatus", DbType.Decimal, 5, navigationItem.RecordStatus.IsEmpty(), navigationItem.RecordStatus)
                .AddParameter("CompanyId", DbType.Decimal, 5, navigationItem.CompanyId.IsEmpty(), navigationItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, navigationItem.UpdateUserCode.IsEmpty(), navigationItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, navigationItem.UpdateDate.IsEmpty(), navigationItem.UpdateDate)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera un registro en la tabla Navigation por medio de su clave primaria.
        ''' </summary>
        ''' <param name="navigationid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Instancia de Navigation</returns>
        Public Shared Function Retrieve(navigationid As Integer, companyId As Integer) As Architect.API.Core.Contracts.General.Navigation
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.Navigation = Nothing
            With New DataManagerFactory("SELECT NavigationId, Code, ParentCode, Type, Title, MenuTitle, Description, URLPath, URLHelp, SmallImage, BigImage, Sequence, Navigation.RecordStatus, Navigation.CompanyId, Navigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Navigation.UpdateDate " &
                                          "FROM Navigation LEFT JOIN UserMember um ON um.UserId = Navigation.UpdateUserCode " &
                                         "WHERE NavigationId=@:NavigationId AND Navigation.CompanyId=@:CompanyId", "Navigation", "Research")
                .AddParameter("NavigationId", DbType.Decimal, 9, False, navigationid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = DataRowMapper(rows.Rows(0))
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Recupera una lista de registros en la tabla Navigation.
        ''' </summary>
        ''' <param name="companyId"></param>
        ''' <param name="filter"></param>
        ''' <returns>Lista de instancias de Navigation</returns>
        Public Shared Function RetrieveAll(companyId As Integer, filter As String) As List(Of Architect.API.Core.Contracts.General.Navigation)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.API.Core.Contracts.General.Navigation)
            With New DataManagerFactory("SELECT NavigationId, Code, ParentCode, Type, Title, MenuTitle, Description, URLPath, URLHelp, SmallImage, BigImage, Sequence, Navigation.RecordStatus, Navigation.CompanyId, Navigation.UpdateUserCode, um.FirstName || ' ' || um.LastName AS UpdateUserName, Navigation.UpdateDate " &
                                          "FROM Navigation LEFT JOIN UserMember um ON um.UserId = Navigation.UpdateUserCode " &
                                         "WHERE Navigation.CompanyId=@:CompanyId", "Navigation", "Research")
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
        ''' Verifica si existe un registro en la tabla Navigation por medio de su clave primaria.
        ''' </summary>
        ''' <returns>Verdadero si existe el registro, en caso contrario falso.</returns>
        Public Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(NavigationId),0) " &
                                          "FROM Navigation", "Navigation", "Research")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Actualiza un registro en la tabla Navigation por medio de su clave primaria.
        ''' </summary>
        ''' <param name="navigationItem">Instancia de Navigation</param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros actualizados.</returns>
        Public Shared Function Update(navigationItem As Architect.API.Core.Contracts.General.Navigation, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("UPDATE Navigation " &
                                           "SET Code=@:Code, ParentCode=@:ParentCode, Type=@:Type, Title=@:Title, MenuTitle=@:MenuTitle, Description=@:Description, URLPath=@:URLPath, URLHelp=@:URLHelp, SmallImage=@:SmallImage, BigImage=@:BigImage, Sequence=@:Sequence, RecordStatus=@:RecordStatus, CompanyId=@:CompanyId, UpdateUserCode=@:UpdateUserCode, UpdateDate=@:UpdateDate " &
                                         "WHERE NavigationId=@:NavigationId AND Navigation.CompanyId=@:CompanyId", "Navigation", "Research")
                .AddParameter("Code", DbType.AnsiStringFixedLength, 8, navigationItem.Code.IsEmpty(), navigationItem.Code)
                .AddParameter("ParentCode", DbType.AnsiStringFixedLength, 8, navigationItem.ParentCode.IsEmpty(), navigationItem.ParentCode)
                .AddParameter("Type", DbType.Decimal, 5, navigationItem.Type.IsEmpty(), navigationItem.Type)
                .AddParameter("Title", DbType.AnsiString, 120, navigationItem.Title.IsEmpty(), navigationItem.Title)
                .AddParameter("MenuTitle", DbType.AnsiString, 40, navigationItem.MenuTitle.IsEmpty(), navigationItem.MenuTitle)
                .AddParameter("Description", DbType.AnsiString, 255, navigationItem.Description.IsEmpty(), navigationItem.Description)
                .AddParameter("URLPath", DbType.AnsiString, 255, navigationItem.URLPath.IsEmpty(), navigationItem.URLPath)
                .AddParameter("URLHelp", DbType.AnsiString, 255, navigationItem.URLHelp.IsEmpty(), navigationItem.URLHelp)
                .AddParameter("SmallImage", DbType.AnsiString, 80, navigationItem.SmallImage.IsEmpty(), navigationItem.SmallImage)
                .AddParameter("BigImage", DbType.AnsiString, 80, navigationItem.BigImage.IsEmpty(), navigationItem.BigImage)
                .AddParameter("Sequence", DbType.Decimal, 5, navigationItem.Sequence.IsEmpty(), navigationItem.Sequence)
                .AddParameter("RecordStatus", DbType.Decimal, 5, navigationItem.RecordStatus.IsEmpty(), navigationItem.RecordStatus)
                .AddParameter("CompanyId", DbType.Decimal, 5, navigationItem.CompanyId.IsEmpty(), navigationItem.CompanyId)
                .AddParameter("UpdateUserCode", DbType.Decimal, 9, navigationItem.UpdateUserCode.IsEmpty(), navigationItem.UpdateUserCode)
                .AddParameter("UpdateDate", DbType.DateTime, 0, navigationItem.UpdateDate.IsEmpty(), navigationItem.UpdateDate)
                .AddParameter("NavigationId", DbType.Decimal, 9, False, navigationItem.NavigationId)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Elimina un registro en la tabla Navigation por medio de su clave primaria.
        ''' </summary>
        ''' <param name="navigationid"></param>
        ''' <param name="companyId"></param>
        ''' <returns>Cantidad de registros eliminados.</returns>
        Public Shared Function Delete(navigationid As Integer, companyId As Integer) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("DELETE FROM Navigation " &
                                         "WHERE NavigationId=@:NavigationId AND CompanyId=@:CompanyId", "Navigation", "Research")
                .AddParameter("NavigationId", DbType.Decimal, 9, False, navigationid)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera la cantidad de registros existentes en la tabla Navigation por medio de su clave primaria.
        ''' </summary>
        ''' <param name="navigationid"></param>
        ''' <returns>Cantidad de registros encontrados.</returns>
        Public Shared Function Count(navigationid As Integer) As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT COUNT(NavigationId) " &
                                          "FROM Navigation " &
                                         "WHERE NavigationId=@:NavigationId", "Navigation", "Research")
                .AddParameter("NavigationId", DbType.Decimal, 9, False, navigationid)
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Recupera una lista para selección de la tabla Navigation.
        ''' </summary>
        ''' <returns>Lista de instancias de LookUpValue</returns>
        Public Shared Function LookUp() As List(Of Architect.Common.DataType.LookUpValue)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Architect.Common.DataType.LookUpValue)
            With New DataManagerFactory("SELECT NavigationId, Title " &
                                          "FROM Navigation ORDER BY Title", "Navigation", "Research")
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Architect.Common.DataType.LookUpValue With {.Code = itemRow.StringValue("NavigationId"), .Description = itemRow.StringValue("Title")})
                    Next
                End If
            End With
            Return result
        End Function

#Region "Helper"

        ''' <summary>
        ''' Permite hacer el mapeo entre una fila de un datatable hacia una instancia de Navigation.
        ''' </summary>
        ''' <returns>Instancia de Navigation</returns>
        Private Shared Function DataRowMapper(itemRow As DataRow) As Architect.API.Core.Contracts.General.Navigation
            Return New Architect.API.Core.Contracts.General.Navigation With {.NavigationId = itemRow.NumericValue("NavigationId"), .Code = itemRow.StringValue("Code"), .ParentCode = itemRow.StringValue("ParentCode"), .Type = itemRow.NumericValue("Type"), .Title = itemRow.StringValue("Title"), .MenuTitle = itemRow.StringValue("MenuTitle"), .Description = itemRow.StringValue("Description"), .URLPath = itemRow.StringValue("URLPath"), .URLHelp = itemRow.StringValue("URLHelp"), .SmallImage = itemRow.StringValue("SmallImage"), .BigImage = itemRow.StringValue("BigImage"), .Sequence = itemRow.NumericValue("Sequence"), .RecordStatus = itemRow.NumericValue("RecordStatus"), .CompanyId = itemRow.NumericValue("CompanyId"), .UpdateUserCode = itemRow.NumericValue("UpdateUserCode"), .UpdateUserName = itemRow.StringValue("UpdateUserName"), .UpdateDate = itemRow.DateTimeValue("UpdateDate")}
        End Function

#End Region

    End Class

End Namespace

