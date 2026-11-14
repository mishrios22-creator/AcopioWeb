Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.Owin
Imports Microsoft.Owin.Host.SystemWeb
Imports Microsoft.Owin.Security

Partial Public Class Ingresar
    Inherits System.Web.UI.Page

    Protected Sub btnIngresar_Click(
        sender As Object,
        e As EventArgs
    )

        lblError.Text = String.Empty

        Page.Validate("Login")
        If Not Page.IsValid Then Return

        Dim manager =
            Context.GetOwinContext().
                GetUserManager(Of ApplicationUserManager)()

        Dim usuario = manager.FindByEmail(txtCorreo.Text.Trim())

        If usuario Is Nothing Then
            lblError.Text = "Correo o contraseña incorrectos."
            Return
        End If

        If Not manager.CheckPassword(usuario, txtClave.Text) Then
            lblError.Text = "Correo o contraseña incorrectos."
            Return
        End If

        Dim identidad = manager.CreateIdentity(
            usuario,
            DefaultAuthenticationTypes.ApplicationCookie)

        Context.GetOwinContext().Authentication.SignIn(
            New AuthenticationProperties With {
                .IsPersistent = False
            },
            identidad)

        Response.Redirect("~/ConsultarEntregas.aspx")
    End Sub

End Class