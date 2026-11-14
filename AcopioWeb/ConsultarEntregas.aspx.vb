Imports Microsoft.AspNet.Identity
Imports System.Web.UI.WebControls

Partial Public Class ConsultarEntregas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        sender As Object,
        e As EventArgs
    ) Handles Me.Load

        If Not ControlAcceso.Exigir(
            Me,
            "Recepcion",
            "Administrador"
        ) Then Return

        If Not IsPostBack Then
            CargarEntregas()
        End If
    End Sub

    Private Sub CargarEntregas()

        Dim esAdministrador = User.IsInRole("Administrador")

        lblAlcance.Text = If(
            esAdministrador,
            "Mostrando las entregas de todos los usuarios.",
            "Mostrando únicamente sus entregas.")

        gvEntregas.DataSource = AlmacenEntregas.Consultar(
            User.Identity.GetUserId(),
            esAdministrador)

        gvEntregas.DataBind()
    End Sub

    Protected Sub gvEntregas_PageIndexChanging(
        sender As Object,
        e As GridViewPageEventArgs
    )

        If Not ControlAcceso.Exigir(
            Me,
            "Recepcion",
            "Administrador"
        ) Then Return

        gvEntregas.PageIndex = e.NewPageIndex
        CargarEntregas()
    End Sub

End Class