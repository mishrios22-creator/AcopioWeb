Imports Microsoft.AspNet.Identity
Imports Microsoft.Owin.Host.SystemWeb

Partial Public Class SiteMaster
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(
        sender As Object,
        e As EventArgs
    ) Handles Me.Load

        Dim autenticado = Context.User.Identity.IsAuthenticated

        lnkRegistrar.Visible =
            autenticado AndAlso Context.User.IsInRole("Recepcion")

        lnkConsultar.Visible =
            autenticado AndAlso
            (Context.User.IsInRole("Recepcion") OrElse
             Context.User.IsInRole("Administrador"))

        lnkIngresar.Visible = Not autenticado
        btnSalir.Visible = autenticado
    End Sub

    Protected Sub btnSalir_Click(
        sender As Object,
        e As EventArgs
    )

        Context.GetOwinContext().Authentication.SignOut(
            DefaultAuthenticationTypes.ApplicationCookie)

        Response.Redirect("~/Ingresar.aspx")
    End Sub

End Class