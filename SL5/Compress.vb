Imports System.IO
Imports System.Text

Imports ICSharpCode
Imports ICSharpCode.SharpZipLib
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Zip.Compression
Imports ICSharpCode.SharpZipLib.Core

Public Module Compress

    Public Sub FastCreateZip(ByVal folderPath As String, ByVal zipPath As String, Optional ByVal fileFilter As String = "", Optional ByVal password As String = Nothing)
        Dim fz As New FastZip
        If password <> Nothing Then fz.Password = password
        fz.CreateZip(zipPath, folderPath, True, fileFilter)
    End Sub

    Public Function FastExtractZip(ByVal zipPath As String, ByVal folderPath As String, Optional ByVal fileFilter As String = "", Optional ByVal password As String = Nothing) As Boolean
        Dim res As Boolean = True
        Dim fz As New FastZip
        If password <> Nothing Then fz.Password = password
        Try
            fz.ExtractZip(zipPath, folderPath, fileFilter)
        Catch ex As Exception
            res = (ex.Message = "")
        End Try
        Return res And Directory.Exists(folderPath)
    End Function

End Module
