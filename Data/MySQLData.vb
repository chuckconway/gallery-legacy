Imports System
Imports System.Data
Imports ByteFX.Data.MySQLClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Configuration
Imports Gallery
Imports System.Reflection


Namespace Data
    Public Class Gallery
        'Global MySql Connection 
        Dim conGallery As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
        Public Function Insert(ByVal strGalleryName As String)

            Dim strInsert As String = "INSERT INTO GALLERY (NAME) VALUES (@NAME)"
            Dim cmdInsert As MySQLCommand = New MySQLCommand(strInsert, conGallery)

            cmdInsert.Parameters.Add("@NAME", strGalleryName)

            conGallery.Open()
            cmdInsert.ExecuteNonQuery()
            conGallery.Close()
        End Function

    End Class



End Namespace
