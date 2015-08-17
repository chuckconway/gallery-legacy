Imports ByteFX.Data.MySQLClient

Public Class GalleryPhotos
    Inherits System.Web.UI.UserControl
    Dim conMysql As MySQLConnection = New MySQLConnection(ConfigurationSettings.AppSettings("mySQLConnection"))

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rptShowPhotos As System.Web.UI.WebControls.Repeater

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

        Dim strGalleryID As String = Request.QueryString("Gal")
        Dim intGalleryID As Integer = CType(strGalleryID, Integer)
        Dim strPhotoSQL As String = "SELECT TITLE, FILENAME, DESCRIPTION, DATETAKEN FROM PHOTOS, GALLERY_PHOTOS WHERE PHOTOS.PHOTOS_ID=GALLERY_PHOTOS.PHOTOS_ID AND GALLERY_PHOTOS.GALLERY_ID=@GALLERY_PHOTOS.GALLERY_ID"
        Dim cmdPhoto As New MySQLCommand(strPhotoSQL, conMysql)
        cmdPhoto.Parameters.Add("@GALLERY_PHOTOS.GALLERY_ID", intGalleryID)
        Dim dtrPhoto As MySQLDataReader

        conMysql.Open()
        dtrPhoto = cmdPhoto.ExecuteReader()
        rptShowPhotos.DataSource = dtrPhoto
        rptShowPhotos.DataBind()
        dtrPhoto.Close()
        conMysql.Close()

    End Sub

End Class
