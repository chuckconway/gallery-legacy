Imports ByteFX.Data.MySQLClient
Public Class ShowGalleries
    Inherits System.Web.UI.UserControl
    Dim conMysql As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
    Protected WithEvents childRepeater As System.Web.UI.WebControls.Repeater
    Protected WithEvents parentRepeater As System.Web.UI.WebControls.Repeater

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim cmd1 As MySQLDataAdapter = New MySQLDataAdapter("SELECT * FROM GALLERY", conMysql)
        Dim ds As DataSet = New DataSet
        cmd1.Fill(ds, "authors")

        Dim cmd2 As MySQLDataAdapter = New MySQLDataAdapter("SELECT DISTINCT( GALLERY_ID), FILENAME FROM PHOTOS, GALLERY_PHOTOS WHERE PHOTOS.PHOTOS_ID=GALLERY_PHOTOS.PHOTOS_ID GROUP BY GALLERY_ID", conMysql)
        cmd2.Fill(ds, "titles")
        ds.Relations.Add("myrelation", ds.Tables("authors").Columns("GALLERY_ID"), ds.Tables("titles").Columns("GALLERY_ID"))
        parentRepeater.DataSource = ds.Tables("authors")
        parentRepeater.DataSource = ds.Tables("authors")
        Page.DataBind()
        conMysql.Close()
    End Sub

End Class
