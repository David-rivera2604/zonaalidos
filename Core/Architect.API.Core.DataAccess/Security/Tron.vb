Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.Security

    Partial Public NotInheritable Class Tron

        Public Shared Function RetrieveAgentInformationByEmail(companyId As Integer, email As String) As Contracts.Security.AgentInformation
            Dim l_fec_validez As String = String.Format("{0}{1}{2}", Today.Year, Today.Month.ToString.PadLeft(2, "0"), Today.Day.ToString.PadLeft(2, "0"))
            Dim rows As Data.DataTable = Nothing
            Dim result As Contracts.Security.AgentInformation = Nothing
            With New DataManagerFactory(True, "em_k_Tables_Contract_mcr.em_p_retrieve_by_email_com", "Tron")
                .AddParameter("P_COD_CIA", DbType.Decimal, 5, False, companyId)
                .AddParameter("P_FEC_VALIDEZ", DbType.String, 15, False, l_fec_validez)
                .AddParameter("P_EMAIL_COM", DbType.String, 60, False, email)
                rows = .ProcedureExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Contracts.Security.AgentInformation With {
                        .cod_agt = rows.FirstRow.NumericValue("cod_agt"),
                        .cod_sub_agt = rows.FirstRow.StringValue("sub_agt"),
                        .info_agt = rows.FirstRow.StringValue("info_agt"),
                        .tip_docum = rows.FirstRow.StringValue("tip_docum"),
                        .cod_docum = rows.FirstRow.StringValue("cod_docum")
                    }
                End If
            End With
            Return result
        End Function

        Public Shared Function RetrieveClientInformationByDocument(tip_docum As String, cod_docum As String) As Contracts.Security.ClientInformation
            Dim rows As Data.DataTable = Nothing
            Dim result As Contracts.Security.ClientInformation = Nothing

            cod_docum = Convert.ToInt64(cod_docum.OnlyNumbers()).ToString()


            With New DataManagerFactory("SELECT EMAIL" &
                                        "  FROM A1001331 " &
                                        " WHERE TIP_DOCUM=@:TIP_DOCUM AND COD_DOCUM=@:COD_DOCUM", "Tron")
                .AddParameter("TIP_DOCUM", DbType.String, 3, False, tip_docum)
                .AddParameter("COD_DOCUM", DbType.String, 20, False, cod_docum)
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Contracts.Security.ClientInformation With {
                        .tip_docum = tip_docum,
                        .cod_docum = cod_docum,
                        .email = rows.FirstRow.StringValue("EMAIL")
                    }
                End If
            End With
            Return result
        End Function

    End Class

End Namespace

