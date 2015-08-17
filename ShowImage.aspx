<%@ Page Language="VB" %>
<%@ import Namespace="System.Drawing.Imaging" %>
<script runat="server">

    Function ThumbnailCallback() as Boolean
      Return False
    End Function


    Sub Page_Load(sender as Object, e as EventArgs)

      'Read in the image filename to create a thumbnail of
      Dim imageUrl as String = Request.QueryString("img")

      'Read in the width and height
      Dim imageHeight as Integer ' = Request.QueryString("h")
      Dim imageWidth as Integer ' = Request.QueryString("w")


      'Make sure that the image URL doesn't contain any /'s or \'s
      If imageUrl.IndexOf("/") >= 0 Or imageUrl.IndexOf("\") >= 0 then
        'We found a / or \
        Response.End()
      End If

      'Add on the appropriate directory
      imageUrl = "photos/" & imageUrl

      Dim fullSizeImg as System.Drawing.Image
      fullSizeImg = System.Drawing.Image.FromFile(Server.MapPath(imageUrl))


       If fullSizeImg.height > fullSizeImg.width then

        imageWidth = 58  ' it's a portrat not landscape
        imageHeight = 77

        Else

        imageHeight = 58
        ImageWidth = 77

      End If



      'Do we need to create a thumbnail?
      Response.ContentType = "image/jpeg"
      If imageHeight > 0 and imageWidth > 0 then
        Dim dummyCallBack as System.Drawing.Image.GetThumbNailImageAbort
        dummyCallBack = New _
           System.Drawing.Image.GetThumbnailImageAbort(AddressOf ThumbnailCallback)

        Dim thumbNailImg as System.Drawing.Image
        thumbNailImg = fullSizeImg.GetThumbnailImage(imageWidth, imageHeight, _
                                                     dummyCallBack, IntPtr.Zero)

        thumbNailImg.Save(Response.OutputStream, ImageFormat.jpeg)
        thumbNail.Dispose()
      Else
        fullSizeImg.Save(Response.OutputStream, ImageFormat.jpeg)
        fullSizeImg.Dispose()
      End If

    End Sub

</script>

