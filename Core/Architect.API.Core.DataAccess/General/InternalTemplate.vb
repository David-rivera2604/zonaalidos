Imports System.Configuration
Imports Architect.Common.Proxy

Namespace Architect.API.Core.DataAccess.General
    Public NotInheritable Class InternalTemplate

        Public Shared Function Retrieve(companyId As Integer, key As String) As Architect.API.Core.Contracts.General.InternalTemplate
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.InternalTemplate = New Contracts.General.InternalTemplate With {.Subject = "Plantilla no encontrada",
                                                                                                               .Body = "Plantilla no encontrada"}
            With New DataManagerFactory("SELECT Subject, Body, EmailTo, MasterTemplateId " &
                                          "FROM Template " &
                                         "WHERE Key=@:Key AND (CompanyId=@:CompanyId OR CompanyId=0) Order by CompanyId DESC", "Template", "Research")
                .AddParameter("Key", DbType.AnsiString, 40, False, key)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                If ConfigurationManager.AppSettings("Working.Mode") <> "Development" Then
                    .Cache = Common.Enumerations.EnumCache.CacheWithFullParameters
                End If
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Architect.API.Core.Contracts.General.InternalTemplate With {.Subject = rows.FirstRow.StringValue("Subject"),
                                                                                     .Body = rows.FirstRow.StringValue("Body"),
                                                                                     .EmailTo = rows.FirstRow.StringValue("EmailTo"),
                                                                                     .MasterTemplateId = rows.FirstRow.IntegerValue("MasterTemplateId")}
                End If
            End With
            Return result
        End Function

        Public Shared Function RetrieveById(companyId As Integer, id As Integer) As Architect.API.Core.Contracts.General.InternalTemplate
            Dim rows As Data.DataTable = Nothing
            Dim result As Architect.API.Core.Contracts.General.InternalTemplate = New Contracts.General.InternalTemplate With {.Subject = "Plantilla no encontrada",
                                                                                                               .Body = "Plantilla no encontrada"}
            With New DataManagerFactory("SELECT Subject, Body, EmailTo, MasterTemplateId " &
                                          "FROM Template " &
                                         "WHERE Id=@:Id AND (CompanyId=@:CompanyId OR CompanyId=0) Order by CompanyId DESC", "Template", "Research")
                .AddParameter("Id", DbType.Decimal, 9, False, id)
                .AddParameter("CompanyId", DbType.Decimal, 5, False, companyId)
                If ConfigurationManager.AppSettings("Working.Mode") <> "Development" Then
                    .Cache = Common.Enumerations.EnumCache.CacheWithFullParameters
                End If
                rows = .QueryExecuteToTable(True)
                If rows.IsNotEmpty AndAlso rows.Rows.Count <> 0 Then
                    result = New Architect.API.Core.Contracts.General.InternalTemplate With {.Subject = rows.FirstRow.StringValue("Subject"),
                                                                                     .Body = rows.FirstRow.StringValue("Body"),
                                                                                     .EmailTo = rows.FirstRow.StringValue("EmailTo"),
                                                                                     .MasterTemplateId = rows.FirstRow.IntegerValue("MasterTemplateId")}
                End If
            End With
            Return result
        End Function

    End Class

End Namespace

