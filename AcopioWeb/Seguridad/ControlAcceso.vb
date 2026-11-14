Imports System.Web
Imports System.Web.UI

Public NotInheritable Class ControlAcceso

    Private Sub New()
    End Sub

    Public Shared Function Exigir(
        pagina As Page,
        ParamArray roles() As String
    ) As Boolean

        If Not pagina.User.Identity.IsAuthenticated Then

            pagina.Response.Redirect(
        pagina.ResolveUrl("~/Ingresar.aspx"),
        False)

            HttpContext.Current.ApplicationInstance.CompleteRequest()
            Return False
        End If

        For Each rol In roles
            If pagina.User.IsInRole(rol) Then
                Return True
            End If
        Next

        Throw New HttpException(403, "Acceso denegado.")
    End Function

End Class
