Imports System.IO
Imports System.Runtime.Serialization

Namespace Services.Contracts

    <DataContract()>
    Public Class info

        <DataMember()>
        Public Property Name As String

        <DataMember()>
        Public Property LastWrite As Date

        <DataMember()>
        Public Property Length As Long

        <DataMember()>
        Public Property IsFolder As Boolean

        <DataMember()>
        Public Property PathFullName As String

        <DataMember()>
        Public Property Childs As List(Of info)

        Friend Shared Function Process(path As String, Optional parent As info = Nothing) As info
            Dim folderBase As DirectoryInfo = Nothing
            Dim root As info = Nothing
            Dim current As info = Nothing

            Try
                If Not IsNothing(parent) Then
                    root = parent
                Else
                    root = New info With {.Name = System.IO.Path.GetFileName(path),
                                          .PathFullName = path,
                                          .IsFolder = True}
                End If
                If IsNothing(root.Childs) Then
                    root.Childs = New List(Of info)
                End If

                folderBase = New DirectoryInfo(path)
                For Each file As FileInfo In folderBase.GetFiles()
                    root.Childs.Add(New info With {.Name = file.Name,
                                                   .PathFullName = file.FullName,
                                                   .IsFolder = False,
                                                   .LastWrite = file.LastWriteTime.ToLocalTime,
                                                   .Length = file.Length})
                Next

                For Each directory As DirectoryInfo In folderBase.GetDirectories
                    current = New info With {.Name = System.IO.Path.GetFileName(directory.Name),
                                             .PathFullName = directory.FullName,
                                             .IsFolder = True,
                                             .LastWrite = directory.LastWriteTime.ToLocalTime}
                    root.Childs.Add(current)
                    Process(directory.FullName, current)
                Next
            Catch ex As Exception
                root.Name = "Falla: " & ex.Message
            End Try
            Return root
        End Function

    End Class

End Namespace