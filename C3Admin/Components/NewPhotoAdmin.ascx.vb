Imports Gallery.Misc
Imports ByteFX.Data.MySQLClient



Public Class PhotoAdmin
    Inherits System.Web.UI.UserControl
    Dim strParseDate As String = CType(Date.Now.ToShortDateString, String)  'todays date :)
    Dim conMysql As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))
    Protected WithEvents btnUpload As System.Web.UI.WebControls.Button
    Dim strBlah As String
    Dim strGlobalVAlue As String
#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents dropGallery As System.Web.UI.WebControls.DropDownList
    Protected WithEvents txttitle As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdescript As System.Web.UI.WebControls.TextBox
    Protected WithEvents txtdate As System.Web.UI.WebControls.TextBox
    Protected WithEvents lblerror As System.Web.UI.WebControls.Label
    Protected WithEvents inpfileup As System.Web.UI.HtmlControls.HtmlInputFile
    Protected WithEvents btnSubmit As System.Web.UI.WebControls.Button
    Protected WithEvents txtGalleryName As System.Web.UI.WebControls.TextBox

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
            BindDropdownList()
            txtdate.Text = strParseDate
        End If


    End Sub

    Sub Button_Click(ByVal s As Object, ByVal e As EventArgs)

        Dim strValue As String = inpfileup.PostedFile.FileName 'value of the input textbox

        If strValue = "" Then ' this varifies that they entered a file name in the box.
            lblerror.Text = "You forgot to select a file!"

        Else

            Dim gmfFilename As Gallery.Misc.File = New Gallery.Misc.File
            Dim gmfExtension As Gallery.Misc.File = New Gallery.Misc.File
            Dim datfilename As New Date 'time for the timestamp filename in the database.
            Dim strFilename As String = datfilename.Date.Now.ToString("yyyymmddhhmmss")
            Dim strImageExtension As String = gmfExtension.Extension(gmfFilename.Filename(strValue))

            strfilename += "."
            strfilename += strImageExtension

            If strImageExtension.ToLower = "gif" Or strImageExtension.ToLower = "jpg" Or strImageExtension.ToLower = "jpeg" Then
                inpfileup.PostedFile.SaveAs(Server.MapPath("..\Photos") & "\" & strFilename)  ' this puts the correct filename in the directory

                Dim strInsert As String = "INSERT INTO PHOTOS(TITLE, DESCRIPTION, FILENAME, DATETAKEN) VALUES (@TITLE, @DESCRIPTION, @FILENAME, @DATETAKEN)" ' MySql ODBC is position relavant not variable relvant
                Dim cmdInsert As MySQLCommand = New MySQLCommand(strInsert, conMysql)

                cmdInsert.Parameters.Add("@TITLE", txttitle.Text)
                cmdInsert.Parameters.Add("@DESCRIPTION", txtdescript.Text)
                cmdInsert.Parameters.Add("@FILENAME", strFilename)
                cmdInsert.Parameters.Add("@DATETAKEN", txtdate.Text)
                conMysql.Open()
                cmdInsert.ExecuteNonQuery()



                Dim strGalleryPhoto As String = "SELECT PHOTOS_ID FROM PHOTOS WHERE FILENAME= '" & strfilename & "'  "
                Dim cmdGalleryPhoto As MySQLCommand = New MysqlCommand(strGalleryPhoto, conMysql)
                Dim intSelectPhotoID As Integer

                intSelectPhotoID = cmdGalleryPhoto.ExecuteScalar()


                Dim strInsertGalleryPhotos As String = "INSERT INTO GALLERY_PHOTOS(PHOTOS_ID, GALLERY_ID) VALUES (@PHOTOS_ID, @GALLERY_ID)"
                Dim cmdInsertGalleryPhotos As MySQLCommand = New MySQLCommand(strInsertGalleryPhotos, conMysql)

                cmdInsertGalleryPhotos.Parameters.Add("@PHOTOS_ID", intSelectPhotoID)
                cmdInsertGalleryPhotos.Parameters.Add("@GALLERY_ID", dropGallery.SelectedItem.Value)

                cmdInsertGalleryPhotos.ExecuteNonQuery()
                conMySql.Close()

                txttitle.Text = ""
                txtdescript.Text = ""
                lblerror.Text = "File Successfully Uploaded!"
            Else
                lblerror.Text = "Wrong File Format you can only upload these types of images: .gif .jpeg .jpg"
            End If

        End If
    End Sub
    Sub BindDropdownList()
        Dim cmdGallery As MySQLCommand
        Dim strStatement As String = "SELECT GALLERY_ID,NAME FROM GALLERY"
        Dim dtrdropGAllery As MySQLDataReader


        cmdGallery = New MySQLCommand(strStatement, conMysql)
        conMysql.Open()
        dtrdropGAllery = cmdGallery.ExecuteReader()
        dropGallery.DataSource = dtrdropGAllery
        dropGallery.DataValueField = "GALLERY_ID"
        dropGallery.DataTextField = "NAME"
        dropGallery.DataBind()
        conMysql.Close()
        dropGallery.SelectedIndex = 0


    End Sub


End Class
