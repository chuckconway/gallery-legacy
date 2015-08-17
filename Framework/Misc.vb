Imports System.Web.HttpRequest
Imports System.Drawing.Imaging
Imports System.IO


Namespace Misc

    Public Class File
        Public Function Filename(ByVal strValue As String)
            Dim arrArray() As String = strValue.Split("\")                                         ' splits the values by the slash character
            Dim strItem As String = arrArray.Length ' gets the length of th array
            Dim strString As String = "\" ' this adds the trailing slash to the file so it will go into the correct directory
            strString += Trim(arrArray(strItem - 1)) 'gets the last item in the array
            Return strString
        End Function

        Public Function Extension(ByVal strString As String)
            Dim arrExtent() As String = strString.Split(".")
            Dim strExtLen As String = arrExtent.Length
            Dim strExtenstion As String = Trim(arrExtent(strExtLen - 1))
            Return strExtenstion
        End Function

    End Class


End Namespace
