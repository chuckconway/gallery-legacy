Imports Gallery.Data.Gallery
Imports ByteFX.Data.MySQLClient
Imports System
Imports System.Data
Imports System.Web.UI.WebControls

Public Class GalleryAdmin
    Inherits System.Web.UI.UserControl

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents txtGalleryName As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblResults As System.Web.UI.WebControls.Label
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents drgGalleryInsert As System.Web.UI.WebControls.DataGrid

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
        If Not Page.IsPostBack Then
            BindDataGrid()
        End If
    End Sub
    Sub BindDataGrid()

        Dim conBindData As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
        Dim cmdGallery As MySQLCommand = New MySQLCommand("SELECT * FROM GALLERY ORDER BY NAME", conBindData)

        conBindData.Open()
        drgGalleryInsert.DataSource = cmdGallery.ExecuteReader()
        drgGalleryInsert.DataBind()
        conBindData.Close()



    End Sub
    Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim galGalInsert As Gallery.Data.Gallery = New Gallery.Data.Gallery
        galGalInsert.Insert(txtGalleryName.Text)
        txtGalleryName.Text = ""
        lblResults.Text = "Insert Successful!"
        Response.Redirect("Admin.aspx?admin=Gal")
    End Sub

    Sub drgGalleryInsert_EditCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)
        drgGalleryInsert.EditItemIndex = e.Item.ItemIndex
        BindDataGrid()
    End Sub

    Sub drgGalleryInsert_UpdateCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        Dim IntGalleryID As Integer
        Dim txtGalleryName As TextBox
        Dim strName, strGallerySQL As String

        Dim conMySQL As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
        Dim cmdGalleryInsert As MySQLCommand

        If (Page.IsValid) Then
            IntGalleryID = drgGalleryInsert.DataKeys(e.Item.ItemIndex)
            txtGalleryName = e.Item.Cells(0).Controls(0)
            strName = txtGalleryName.Text
            strGallerySQL = "UPDATE GALLERY SET NAME=@NAME WHERE GALLERY_ID=@GALLERY_ID"
            cmdGalleryInsert = New MySQLCommand(strGallerySQL, conMySQL)
            cmdGalleryInsert.Parameters.Add("@NAME", strName)
            cmdGalleryInsert.Parameters.Add("@GALLERY_ID", IntGalleryID)
            conMySQL.Open()
            cmdGalleryInsert.ExecuteNonQuery()
            conMySQL.Close()
            drgGalleryInsert.EditItemIndex = -1
            BindDataGrid()
        End If
    End Sub

    Sub drgGalleryInsert_CancelCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        drgGalleryInsert.EditItemIndex = -1
        BindDataGrid()

    End Sub

    Sub drgGalleryInsert_DeleteCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        Dim IntGalleryID As Integer
        Dim txtGalleryName As TextBox
        Dim strName, strGallerySQL As String

        Dim conMySQL As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
        Dim cmdGalleryInsert As MySQLCommand

        If (Page.IsValid) Then
            IntGalleryID = drgGalleryInsert.DataKeys(e.Item.ItemIndex)
            strGallerySQL = "DELETE FROM GALLERY WHERE GALLERY_ID=@GALLERY_ID"
            cmdGalleryInsert = New MySQLCommand(strGallerySQL, conMySQL)
            cmdGalleryInsert.Parameters.Add("@GALLERY_ID", IntGalleryID)
            conMySQL.Open()
            cmdGalleryInsert.ExecuteNonQuery()
            conMySQL.Close()
            BindDataGrid()
        End If

    End Sub

End Class
