Imports Architect.Common.Proxy

Namespace Architect.API.Insurance.DataAccess.Others

    ''' <summary>
    ''' .
    ''' </summary>
    Partial Public NotInheritable Class Inclusiones

        ''' <summary>
        ''' Devuelve una lista inclusiones para un rango de identificaciones.
        ''' </summary>
        Public Shared Function RetrieveInclusionViewById(companyid As Integer, idFrom As Integer, idTo As Integer) As List(Of Contracts.Bayer.InclusionView)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Contracts.Bayer.InclusionView)
            Dim filter As String = String.Format(" AND P.Id >= @:idFrom ")

            If idTo > 0 Then
                filter += String.Format(" AND P.Id <= @:idTo ")
            End If

            With New DataManagerFactory(My.Resources.Inclusiones_View.Replace("@FILTER@", filter), "RiskRoles", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("idFrom", DbType.Decimal, 9, False, idFrom)
                If idTo > 0 Then
                    .AddParameter("idTo", DbType.Decimal, 9, False, idTo)
                End If
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Contracts.Bayer.InclusionView With {
                                       .Id = itemRow.NumericValue("Id"),
                                       .IssueDate = itemRow.DateTimeValue("IssueDate"),
                                       .DocumentNumber = itemRow.StringValue("DocumentNumber"),
                                       .InsuredFullName = itemRow.StringValue("InsuredFullName"),
                                       .BirthDate = itemRow.DateTimeValue("BirthDate"),
                                       .PhoneNumber = itemRow.StringValue("PhoneNumber"),
                                       .PrimaryEmailAddress = itemRow.StringValue("PrimaryEmailAddress"),
                                       .Status = itemRow.NumericValue("Status"),
                                       .StatusDesc = itemRow.StringValue("StatusDesc"),
                                       .UpdateDate = itemRow.DateTimeValue("UpdateDate")})
                    Next
                End If
            End With
            Return result
        End Function

        ''' <summary>
        ''' Devuelve una lista inclusiones para un rango de fecha de ingreso.
        ''' </summary>
        Public Shared Function RetrieveInclusionViewByIssueDate(companyid As Integer, issueDateFrom As Date, issueDateTo As Date) As List(Of Contracts.Bayer.InclusionView)
            Dim rows As Data.DataTable = Nothing
            Dim result As New List(Of Contracts.Bayer.InclusionView)
            Dim filter As String = String.Format(" AND P.IssueDate >= @:issueDateFrom ")

            If issueDateTo <> Date.MinValue Then
                filter += String.Format(" AND P.IssueDate <= @:issueDateTo ")
            End If

            With New DataManagerFactory(My.Resources.Inclusiones_View.Replace("@FILTER@", filter), "RiskRoles", "Research")
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyid)
                .AddParameter("issueDateFrom", DbType.DateTime, 9, False, issueDateFrom)
                If issueDateTo <> Date.MinValue Then
                    .AddParameter("issueDateFrom", DbType.DateTime, 9, False, issueDateTo)
                End If
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    For Each itemRow As DataRow In rows.Rows
                        result.Add(New Contracts.Bayer.InclusionView With {
                                       .Id = itemRow.NumericValue("Id"),
                                       .IssueDate = itemRow.DateTimeValue("IssueDate"),
                                       .DocumentNumber = itemRow.StringValue("DocumentNumber"),
                                       .InsuredFullName = itemRow.StringValue("InsuredFullName"),
                                       .BirthDate = itemRow.DateTimeValue("BirthDate"),
                                       .PhoneNumber = itemRow.StringValue("PhoneNumber"),
                                       .PrimaryEmailAddress = itemRow.StringValue("PrimaryEmailAddress"),
                                       .Status = itemRow.NumericValue("Status"),
                                       .StatusDesc = itemRow.StringValue("StatusDesc"),
                                       .UpdateDate = itemRow.DateTimeValue("UpdateDate")})
                    Next
                End If
            End With
            Return result
        End Function

        Public Shared Function Create(inclusionesItem As Contracts.Others.Inclusiones, userId As Integer) As Integer
            Dim result As New Common.DataType.Result With {.Success = False,
                                                                    .Code = 0,
                                                                    .Reason = String.Empty}
            With inclusionesItem
                If .Id.IsEmpty Then
                    .Id = RetrieveLastKey() + 1
                End If
            End With
            result.Success = (Create(inclusionesItem) > 0)
            If result.Success Then
                If inclusionesItem.Extras.IsNotEmpty AndAlso
                       inclusionesItem.Extras.Count > 0 Then

                    Dim index As Integer = 1
                    For Each item As Contracts.Others.InclusionesExtra In inclusionesItem.Extras
                        With item
                            .Id = inclusionesItem.Id
                            .Consecutivo = index
                        End With

                        Create(item)
                        index += 1
                    Next
                End If
                result.Code = inclusionesItem.Id
            End If

            Return inclusionesItem.Id
        End Function

        ''' <summary>
        ''' Crea un registro en la tabla Inclusiones.
        ''' </summary>
        ''' <param name="inclusionesItem">Instancia de Inclusiones</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Private Shared Function Create(inclusionesItem As Contracts.Others.Inclusiones) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO Inclusiones " &
                                              "(Id, Empresa, TieneDependientes, CantidadDeDependientes, Finalizado, CodigoDeImpresion, CantidadDeCanets, CantidadDeCertificados, FechaDeRecibido, FechaDeEnvioAPanama, FechaDeEnvioACorredor, Tramite, FechaEfectiva, Clase, Nombre, Apellido, Cedula, Observacines, FechaDeEnvioDeLaObservacion, FechaNacimiento, Sexo, Estatus, TipoDeIdentificacion, CorreoElectronico, NroCuenta, Plan, Certificado, DeducibleConsumido, DeducibleMaximoVitalicio, StopLost, EmployeeNumber) " &
                                        "VALUES(@:Id, @:Empresa, @:TieneDependientes, @:CantidadDeDependientes, @:Finalizado, @:CodigoDeImpresion, @:CantidadDeCanets, @:CantidadDeCertificados, @:FechaDeRecibido, @:FechaDeEnvioAPanama, @:FechaDeEnvioACorredor, @:Tramite, @:FechaEfectiva, @:Clase, @:Nombre, @:Apellido, @:Cedula, @:Observacines, @:FechaDeEnvioDeLaObservacion, @:FechaNacimiento, @:Sexo, @:Estatus, @:TipoDeIdentificacion, @:CorreoElectronico, @:NroCuenta, @:Plan, @:Certificado, @:DeducibleConsumido, @:DeducibleMaximoVitalicio, @:StopLost, @:EmployeeNumber)", "Inclusiones", "Tron")
                .AddParameter("Id", DbType.Decimal, 9, inclusionesItem.Id.IsEmpty(), inclusionesItem.Id)
                .AddParameter("Empresa", DbType.Decimal, 9, inclusionesItem.Empresa.IsEmpty(), inclusionesItem.Empresa)
                .AddParameter("TieneDependientes", DbType.Decimal, 1, False, IIf(inclusionesItem.TieneDependientes, 1, 0))
                .AddParameter("CantidadDeDependientes", DbType.Decimal, 3, inclusionesItem.CantidadDeDependientes.IsEmpty(), inclusionesItem.CantidadDeDependientes)
                .AddParameter("Finalizado", DbType.Decimal, 1, False, IIf(inclusionesItem.Finalizado, 1, 0))
                .AddParameter("CodigoDeImpresion", DbType.AnsiString, 255, inclusionesItem.CodigoDeImpresion.IsEmpty(), inclusionesItem.CodigoDeImpresion)
                .AddParameter("CantidadDeCanets", DbType.AnsiString, 255, inclusionesItem.CantidadDeCanets.IsEmpty(), inclusionesItem.CantidadDeCanets)
                .AddParameter("CantidadDeCertificados", DbType.AnsiString, 255, inclusionesItem.CantidadDeCertificados.IsEmpty(), inclusionesItem.CantidadDeCertificados)
                .AddParameter("FechaDeRecibido", DbType.DateTime, 9, inclusionesItem.FechaDeRecibido.IsEmpty(), inclusionesItem.FechaDeRecibido)
                .AddParameter("FechaDeEnvioAPanama", DbType.DateTime, 9, inclusionesItem.FechaDeEnvioAPanama.IsEmpty(), inclusionesItem.FechaDeEnvioAPanama)
                .AddParameter("FechaDeEnvioACorredor", DbType.DateTime, 9, inclusionesItem.FechaDeEnvioACorredor.IsEmpty(), inclusionesItem.FechaDeEnvioACorredor)
                .AddParameter("Tramite", DbType.AnsiString, 255, inclusionesItem.Tramite.IsEmpty(), inclusionesItem.Tramite)
                .AddParameter("FechaEfectiva", DbType.DateTime, 9, inclusionesItem.FechaEfectiva.IsEmpty(), inclusionesItem.FechaEfectiva)
                .AddParameter("Clase", DbType.AnsiString, 255, inclusionesItem.Clase.IsEmpty(), inclusionesItem.Clase)
                .AddParameter("Nombre", DbType.AnsiString, 255, inclusionesItem.Nombre.IsEmpty(), inclusionesItem.Nombre)
                .AddParameter("Apellido", DbType.AnsiString, 255, inclusionesItem.Apellido.IsEmpty(), inclusionesItem.Apellido)
                .AddParameter("Cedula", DbType.AnsiString, 255, inclusionesItem.Cedula.IsEmpty(), inclusionesItem.Cedula)
                .AddParameter("Observacines", DbType.AnsiString, 255, inclusionesItem.Observacines.IsEmpty(), inclusionesItem.Observacines)
                .AddParameter("FechaDeEnvioDeLaObservacion", DbType.DateTime, 9, inclusionesItem.FechaDeEnvioDeLaObservacion.IsEmpty(), inclusionesItem.FechaDeEnvioDeLaObservacion)
                .AddParameter("FechaNacimiento", DbType.DateTime, 9, inclusionesItem.FechaNacimiento.IsEmpty(), inclusionesItem.FechaNacimiento)
                .AddParameter("Sexo", DbType.AnsiString, 10, inclusionesItem.Sexo.IsEmpty(), inclusionesItem.Sexo)
                .AddParameter("Estatus", DbType.AnsiString, 30, inclusionesItem.Estatus.IsEmpty(), inclusionesItem.Estatus)
                .AddParameter("TipoDeIdentificacion", DbType.AnsiString, 40, inclusionesItem.TipoDeIdentificacion.IsEmpty(), inclusionesItem.TipoDeIdentificacion)
                .AddParameter("CorreoElectronico", DbType.AnsiString, 80, inclusionesItem.CorreoElectronico.IsEmpty(), inclusionesItem.CorreoElectronico)
                .AddParameter("NroCuenta", DbType.AnsiString, 22, inclusionesItem.NroCuenta.IsEmpty(), inclusionesItem.NroCuenta)
                .AddParameter("Plan", DbType.Decimal, 5, inclusionesItem.Plan.IsEmpty(), inclusionesItem.Plan)
                .AddParameter("Certificado", DbType.Decimal, 9, inclusionesItem.Certificado.IsEmpty(), inclusionesItem.Certificado)
                .AddParameter("DeducibleConsumido", DbType.Decimal, 18, inclusionesItem.DeducibleConsumido.IsEmpty(), inclusionesItem.DeducibleConsumido)
                .AddParameter("DeducibleMaximoVitalicio", DbType.Decimal, 18, inclusionesItem.DeducibleMaximoVitalicio.IsEmpty(), inclusionesItem.DeducibleMaximoVitalicio)
                .AddParameter("StopLost", DbType.Decimal, 18, inclusionesItem.StopLost.IsEmpty(), inclusionesItem.StopLost)
                .AddParameter("EmployeeNumber", DbType.AnsiString, 30, inclusionesItem.EmployeeNumber.IsEmpty(), inclusionesItem.EmployeeNumber)

                rows = .CommandExecute()
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Último valor asignado a clave unica de la tabla Inclusiones.
        ''' </summary>
        ''' <returns>Último valor asignado.</returns>
        Private Shared Function RetrieveLastKey() As Integer
            Dim rows As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM Inclusiones", "Inclusiones", "Tron")
                rows = .QueryExecuteScalarToInteger
            End With
            Return rows
        End Function

        ''' <summary>
        ''' Crea un registro en la tabla InclusionesExtra.
        ''' </summary>
        ''' <param name="inclusionesextraItem">Instancia de InclusionesExtra</param>
        ''' <returns>Cantidad de registros creados.</returns>
        Private Shared Function Create(inclusionesextraItem As Contracts.Others.InclusionesExtra) As Integer
            Dim rows As Integer = 0
            With New DataManagerFactory("INSERT INTO InclusionesExtra " &
                                              "(Id, Consecutivo, TipoExtra, IdentificacionExtra, NombreExtra, ApellidoExtra, EdadExtra, ParentescoExtra, FechaInclusionExtra, FechaExclusionExtra, ParticipacionExtra, TipoDeIdentificacionExtra, PlanEx, DeducibleConsumidoEx, DeducibleMaximoVitalicioEx, StopLossEx, FechaNacimientoEx) " &
                                        "VALUES(@:Id, @:Consecutivo, @:TipoExtra, @:IdentificacionExtra, @:NombreExtra, @:ApellidoExtra, @:EdadExtra, @:ParentescoExtra, @:FechaInclusionExtra, @:FechaExclusionExtra, @:ParticipacionExtra, @:TipoDeIdentificacionExtra, @:PlanEx, @:DeducibleConsumidoEx, @:DeducibleMaximoVitalicioEx, @:StopLossEx, @:FechaNacimientoEx)", "InclusionesExtra", "Tron")
                .AddParameter("Id", DbType.Decimal, 9, inclusionesextraItem.Id.IsEmpty(), inclusionesextraItem.Id)
                .AddParameter("Consecutivo", DbType.Decimal, 9, inclusionesextraItem.Consecutivo.IsEmpty(), inclusionesextraItem.Consecutivo)
                .AddParameter("TipoExtra", DbType.AnsiString, 20, inclusionesextraItem.TipoExtra.IsEmpty(), inclusionesextraItem.TipoExtra)
                .AddParameter("IdentificacionExtra", DbType.AnsiString, 60, inclusionesextraItem.IdentificacionExtra.IsEmpty(), inclusionesextraItem.IdentificacionExtra)
                .AddParameter("NombreExtra", DbType.AnsiString, 80, inclusionesextraItem.NombreExtra.IsEmpty(), inclusionesextraItem.NombreExtra)
                .AddParameter("ApellidoExtra", DbType.AnsiString, 35, inclusionesextraItem.ApellidoExtra.IsEmpty(), inclusionesextraItem.ApellidoExtra)
                .AddParameter("EdadExtra", DbType.Decimal, 3, inclusionesextraItem.EdadExtra.IsEmpty(), inclusionesextraItem.EdadExtra)
                .AddParameter("ParentescoExtra", DbType.AnsiString, 35, inclusionesextraItem.ParentescoExtra.IsEmpty(), inclusionesextraItem.ParentescoExtra)
                .AddParameter("FechaInclusionExtra", DbType.DateTime, 9, inclusionesextraItem.FechaInclusionExtra.IsEmpty(), inclusionesextraItem.FechaInclusionExtra)
                .AddParameter("FechaExclusionExtra", DbType.DateTime, 9, inclusionesextraItem.FechaExclusionExtra.IsEmpty(), inclusionesextraItem.FechaExclusionExtra)
                .AddParameter("ParticipacionExtra", DbType.Decimal, 3, inclusionesextraItem.ParticipacionExtra.IsEmpty(), inclusionesextraItem.ParticipacionExtra)
                .AddParameter("TipoDeIdentificacionExtra", DbType.AnsiString, 40, inclusionesextraItem.TipoDeIdentificacionExtra.IsEmpty(), inclusionesextraItem.TipoDeIdentificacionExtra)
                .AddParameter("PlanEx", DbType.Decimal, 5, inclusionesextraItem.PlanEx.IsEmpty(), inclusionesextraItem.PlanEx)
                .AddParameter("DeducibleConsumidoEx", DbType.Decimal, 18, inclusionesextraItem.DeducibleConsumidoEx.IsEmpty(), inclusionesextraItem.DeducibleConsumidoEx)
                .AddParameter("DeducibleMaximoVitalicioEx", DbType.Decimal, 18, inclusionesextraItem.DeducibleMaximoVitalicioEx.IsEmpty(), inclusionesextraItem.DeducibleMaximoVitalicioEx)
                .AddParameter("StopLossEx", DbType.Decimal, 18, inclusionesextraItem.StopLossEx.IsEmpty(), inclusionesextraItem.StopLossEx)
                .AddParameter("FechaNacimientoEx", DbType.DateTime, 9, inclusionesextraItem.FechaNacimientoEx.IsEmpty(), inclusionesextraItem.FechaNacimientoEx)
                rows = .CommandExecute()
            End With
            Return rows
        End Function


        Public Shared Function RetrieveContratante(poliza As String) As Integer
            Dim id As Integer = 0

            With New DataManagerFactory("SELECT NVL(MAX(Id),0) " &
                                          "FROM CONTRATANTES WHERE POLIZATRON=@:POLIZATRON", "CONTRATANTES", "Tron")
                .AddParameter("POLIZATRON", DbType.AnsiString, 14, False, poliza)
                id = .QueryExecuteScalarToInteger
            End With
            Return id
        End Function


    End Class

End Namespace

