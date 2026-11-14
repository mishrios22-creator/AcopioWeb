Imports Microsoft.AspNet.Identity
Imports System.Globalization
Imports System.Web.Script.Serialization
Imports System.Web.UI.WebControls

Partial Public Class RegistrarEntrega
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(
        sender As Object,
        e As EventArgs
    ) Handles Me.Load

        If Not ControlAcceso.Exigir(Me, "Recepcion") Then Return

        If Not IsPostBack Then

            ddlProductor.DataSource =
                CatalogoProductores.ObtenerTodos()

            ddlProductor.DataTextField = "Descripcion"
            ddlProductor.DataValueField = "Codigo"
            ddlProductor.DataBind()

            ddlProductor.Items.Insert(
                0,
                New ListItem("Seleccione...", ""))
        End If
    End Sub

    Protected Sub cvBoleta_ServerValidate(
        source As Object,
        args As ServerValidateEventArgs
    )
        args.IsValid =
            Not AlmacenEntregas.ExisteBoleta(args.Value)
    End Sub

    Protected Sub btnGuardar_Click(
        sender As Object,
        e As EventArgs
    )

        If Not ControlAcceso.Exigir(Me, "Recepcion") Then Return

        Page.Validate("Entrega")
        If Not Page.IsValid Then Return

        Dim peso As Integer

        If Not Integer.TryParse(
            txtPeso.Text,
            NumberStyles.None,
            CultureInfo.InvariantCulture,
            peso
        ) Then

            MostrarError("El peso debe ser un número entero.")
            Return
        End If

        Dim entregaRegistrada As Entrega = Nothing
        Dim errorRegistro As String = Nothing

        Dim guardada = AlmacenEntregas.IntentarRegistrar(
            ddlProductor.SelectedValue,
            txtBoleta.Text,
            peso,
            ddlCalidad.SelectedValue,
            User.Identity.GetUserId(),
            User.Identity.Name,
            entregaRegistrada,
            errorRegistro)

        If Not guardada Then
            MostrarError(errorRegistro)
            Return
        End If

        Dim monto = entregaRegistrada.Pago.ToString(
            "N0",
            CultureInfo.GetCultureInfo("es-CR"))

        lblMensaje.CssClass = "alert alert-success d-block mt-3"

        lblMensaje.Text = Server.HtmlEncode(
            "Boleta " & entregaRegistrada.Boleta &
            " registrada. Pago: ₡" & monto & ".")

        txtBoleta.Text = String.Empty
        txtPeso.Text = String.Empty

        ddlProductor.SelectedIndex = 0
        ddlCalidad.SelectedIndex = 0
    End Sub

    Private Sub MostrarError(mensaje As String)
        lblMensaje.CssClass = "alert alert-danger d-block mt-3"
        lblMensaje.Text = Server.HtmlEncode(mensaje)
    End Sub

    Protected Sub Page_PreRender(
        sender As Object,
        e As EventArgs
    ) Handles Me.PreRender

        If Not User.Identity.IsAuthenticated OrElse
           Not User.IsInRole("Recepcion") Then Return

        Dim serializador As New JavaScriptSerializer()

        Dim json = serializador.Serialize(
            AlmacenEntregas.ObtenerBoletas())

        ClientScript.RegisterStartupScript(
            Me.GetType(),
            "BoletasRegistradas",
            "window.boletasRegistradas = " & json & ";",
            True)
    End Sub

End Class