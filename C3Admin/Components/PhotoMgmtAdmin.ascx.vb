Imports ByteFX.Data.MySQLClient

Public Class PhotoMgmtAdmin
    Inherits System.Web.UI.UserControl
    Dim conMysql As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
    Dim intGalleryID As Integer
    Dim strCurrentState As String

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dgrdPhotoGallery As System.Web.UI.WebControls.DataGrid
    Protected WithEvents dropEditGalleryList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents dropGalleryList As System.Web.UI.WebControls.DropDownList
    Protected WithEvents lblTest As System.Web.UI.WebControls.Label

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
            BindGalleryList()
            BindPhotoDataGrid(dropGalleryList.SelectedItem.Value)
        End If

    End Sub

    Sub BindGalleryList()
        Dim cmdGallery As MySQLCommand
        Dim strStatement As String = "SELECT GALLERY_ID,NAME FROM GALLERY"
        Dim dtrdropGAlleryList As MySQLDataReader


        cmdGallery = New MySQLCommand(strStatement, conMysql)
        conMysql.Open()
        dtrdropGAlleryList = cmdGallery.ExecuteReader()
        dropGalleryList.DataSource = dtrdropGAlleryList
        dropGalleryList.DataValueField = "GALLERY_ID"
        dropGalleryList.DataTextField = "NAME"
        dropGalleryList.DataBind()
        conMysql.Close()
        dropGalleryList.SelectedIndex = 0

       
    End Sub

    Sub dropGalleryList_Select(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim intGalleryID As Integer
        intGalleryID = dropGalleryList.SelectedItem.Value
        BindPhotoDataGrid(intGalleryID)

    End Sub


    Sub BindPhotoDataGrid(ByVal intGalleryID As Integer)

        Dim cmdGallery As MySQLCommand
        Dim strStatement As String = "SELECT GALLERY_PHOTOS.GALLERY_PHOTOS_ID, GALLERY_PHOTOS.GALLERY_ID, PHOTOS.PHOTOS_ID, PHOTOS.TITLE, PHOTOS.DESCRIPTION, PHOTOS.DATETAKEN, GALLERY.NAME, PHOTOS.FILENAME FROM PHOTOS, GALLERY, GALLERY_PHOTOS WHERE PHOTOS.PHOTOS_ID = GALLERY_PHOTOS.PHOTOS_ID AND GALLERY_PHOTOS.GALLERY_ID = GALLERY.GALLERY_ID AND GALLERY.GALLERY_ID = @GALLERY.GALLERY_ID"
        cmdGallery = New MySQLCommand(strStatement, conMysql)
        cmdGallery.Parameters.Add("@GALLERY.GALLERY_ID", intGalleryID)
        conMysql.Open()
        dgrdPhotoGallery.DataSource = cmdGallery.ExecuteReader()
        dgrdPhotoGallery.DataBind()
        conMysql.Close()


    End Sub
    Sub dgrdPhotoGallery_EditCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        dgrdPhotoGallery.EditItemIndex = e.Item.ItemIndex
        BindPhotoDataGrid(dropGalleryList.SelectedItem.Value)
        lblTest.Text = Convert.ToInt32(e.Item.Cells(1).Text)
    End Sub

    Sub BinddropGalleryListInsert()
        Dim strStatement As String = "SELECT GALLERY_ID,NAME FROM GALLERY"
        Dim cmdGalleryList As MySQLCommand = New MySQLCommand(strStatement, conMysql)
        Dim dtrdropGalleryListInsert As MySQLDataReader
        conMysql.Open()
        dtrdropGalleryListInsert = cmdGalleryList.ExecuteReader()
        dropEditGalleryList.DataSource = dtrdropGalleryListInsert
        dropEditGalleryList.DataValueField = "GALLERY_ID"
        dropEditGalleryList.DataTextField = "NAME"
        dropEditGalleryList.DataBind()
        conMysql.Close()
        dropEditGalleryList.SelectedIndex = 0

    End Sub

    Sub dgrdPhotoGallery_UpdateCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        Dim intGalleryPhotosID As String
        Dim txtTitle As TextBox
        Dim txtDescription As TextBox
        Dim txtDateTaken As TextBox
        Dim intPhotoID As Integer


        If (Page.IsValid) Then
            intGalleryPhotosID = dgrdPhotoGallery.DataKeys(e.Item.ItemIndex)
            intPhotoID = Convert.ToInt32(lblTest.Text)
            txtTitle = e.Item.Cells(2).Controls(0)
            txtDescription = e.Item.Cells(3).Controls(0)
            txtDateTaken = e.Item.Cells(4).Controls(0)
            Dim strSQL As String = "UPDATE PHOTOS SET TITLE=@TITLE,DESCRIPTION=@DESCRIPTION,DATETAKEN=@DATETAKEN WHERE PHOTOS_ID=@PHOTOS_ID"
            Dim cmdInsert As MySQLCommand = New MySQLCommand(strSQL, conMysql)
            cmdInsert.Parameters.Add("@PHOTOS_ID", intPhotoID)
            cmdInsert.Parameters.Add("@TITLE", txtTitle.Text)
            cmdInsert.Parameters.Add("@DESCRIPTION", txtDescription.Text)
            cmdInsert.Parameters.Add("@DATETAKEN", txtDateTaken.Text)

            Dim strGallery As String = "UPDATE GALLERY_PHOTOS SET GALLERY_ID=@GALLERY_ID WHERE PHOTOS_ID=@GALLERY_ID"
            Dim cmdInsertGalleryPhotos As MySQLCommand = New MySQLCommand(strGallery, conMysql)
            'cmdInsertGalleryPhotos.Parameters.Add("@GALLERY_ID, 41)
            'cmdInsertGalleryPhotos.Parameters.Add("@PHOTOS_ID, "4") 
            conMysql.Open()
            cmdInsert.ExecuteNonQuery()
            conMysql.Close()

            dgrdPhotoGallery.EditItemIndex = -1
            BindPhotoDataGrid(dropGalleryList.SelectedItem.Value)

        End If

    End Sub
    Sub DeteleItem_OnItemBound(ByVal s As Object, ByVal e As DataGridItemEventArgs)
        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem, ListItemType.EditItem
                Dim myDeleteButton As LinkButton
                myDeleteButton = e.Item.FindControl("btnDelete")
                myDeleteButton.Attributes.Add("onclick", "return confirm('Are you sure?');")
        End Select

    End Sub

    Sub dgrdPhotoGallery_CancelCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        dgrdPhotoGallery.EditItemIndex = -1
        BindPhotoDataGrid(dropGalleryList.SelectedItem.Value)

    End Sub

    Sub dgrdPhotoGallery_DeleteCommand(ByVal s As Object, ByVal e As DataGridCommandEventArgs)

        Dim intPhotoID As String
        lblTest.Text = Convert.ToInt32(e.Item.Cells(1).Text)


        If (Page.IsValid) Then
            intPhotoID = Convert.ToInt32(lblTest.Text)
            Dim strSQL As String = "DELETE FROM PHOTOS WHERE PHOTOS_ID=@PHOTOS_ID"
            Dim strGallerySQL As String = "DELETE FROM GALLERY_PHOTOS WHERE PHOTOS_ID=@PHOTOS_ID"
            Dim cmdGalleryDelete As New MySQLCommand(strGallerySQL, conMysql)
            Dim cmdInsert As MySQLCommand = New MySQLCommand(strSQL, conMysql)
            cmdInsert.Parameters.Add("@PHOTOS_ID", intPhotoID)
            cmdGalleryDelete.Parameters.Add("@PHOTOS_ID", intPhotoID)
            conMysql.Open()
            cmdInsert.ExecuteNonQuery()
            cmdGalleryDelete.ExecuteNonQuery()
            conMysql.Close()
            conMysql.Dispose()

            dgrdPhotoGallery.EditItemIndex = -1
            BindPhotoDataGrid(dropGalleryList.SelectedItem.Value)

        End If

    End Sub

    Function BindState()
        ' Create Instance of Connection and Command Object
        Dim myCommand As MySQLCommand = New MySQLCommand("SELECT NAME, GALLERY_ID FROM GALLERY ORDER BY GALLERY_ID", conMysql)
        Try
            conMysql.Open()
            Return myCommand.ExecuteReader(CommandBehavior.CloseConnection)
        Catch SQLexc As MySQLException
            'lblStatus.Text = "Error while Generating Data. Error is " & SQLexc.ToString()
        End Try
    End Function

    Sub ItemDataBound(ByVal s As Object, ByVal e As DataGridItemEventArgs)
        If e.Item.ItemType = ListItemType.EditItem Then
            Dim myDropDown As DropDownList
            myDropDown = CType(e.Item.FindControl("dropEditGalleryList"), DropDownList)
            myDropDown.SelectedIndex = myDropDown.Items.IndexOf(myDropDown.Items.FindByText("General"))
        End If
    End Sub
    ' Sub dgrdPhotoGallery_ItemDataBound(ByVal s As Object, ByVal e As DataGridItemEventArgs)
    '  If e.Item.ItemType = ListItemType.EditItem Then
    '     'Grab a reference to the DropDownList for the current row that is being edited
    '    Dim Temp As DropDownList = CType(e.Item.FindControl("dropEditGalleryList"), DropDownList)
    '    'Load the Categories table into the DropDownList
    '    LoadDropDownList(Temp, "SELECT NAME, GALLERY_ID FROM GALLERY ORDER BY GALLERY_ID", "GALLERY_ID", "NAME")
    '    'Set the selected item in the Categories DropDownList to the value from the Products DataTable
    '    Temp.SelectedIndex = Temp.Items.IndexOf(Temp.Items.FindByValue(e.Item.DataItem("GALLERY_ID")))
    ' End If
    ' End Sub

    'Private Sub LoadDropDownList(ByRef CurrentDDL As DropDownList, ByVal CommandText As String, ByVal DataValueField As String, ByVal DataTextField As String)
    'Fill the DropDownList based off of the incoming parameters
    ' Dim cmdDropEditGallery As New MySQLCommand(CommandText, conMysql)
    ' With cmdDropEditGallery
    '    .Connection.Open()
    '     CurrentDDL.DataValueField = DataValueField
    '     CurrentDDL.DataTextField = DataTextField
    '     CurrentDDL.DataSource = .ExecuteReader
    '    CurrentDDL.DataBind()
    '    .Connection.Close()
    '    .Dispose()
    '  End With

    ' End Sub

End Class
