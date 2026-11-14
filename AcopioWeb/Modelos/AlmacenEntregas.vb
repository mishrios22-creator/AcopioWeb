Imports System.Collections.Generic
Imports System.Linq
Imports System.Text.RegularExpressions

Public NotInheritable Class AlmacenEntregas

    Private Shared ReadOnly Candado As New Object()
    Private Shared ReadOnly Datos As New List(Of Entrega)()

    Private Sub New()
    End Sub

    Public Shared Function ExisteBoleta(boleta As String) As Boolean
        SyncLock Candado
            Return Datos.Any(Function(e) e.Boleta = boleta)
        End SyncLock
    End Function

    Public Shared Function ObtenerBoletas() As List(Of String)
        SyncLock Candado
            Return Datos.Select(Function(e) e.Boleta).ToList()
        End SyncLock
    End Function

    Public Shared Function IntentarRegistrar(
        codigoProductor As String,
        boleta As String,
        peso As Integer,
        calidad As String,
        usuarioId As String,
        usuarioCorreo As String,
        ByRef registrada As Entrega,
        ByRef errorRegistro As String
    ) As Boolean

        registrada = Nothing
        errorRegistro = String.Empty

        Dim productor = CatalogoProductores.Buscar(codigoProductor)

        If productor Is Nothing Then
            errorRegistro = "Seleccione un productor válido."
            Return False
        End If

        If Not Regex.IsMatch(
            If(boleta, String.Empty),
            "\AB-[0-9]{6}\z"
        ) Then
            errorRegistro = "La boleta debe tener el formato B-000123."
            Return False
        End If

        If peso < 100 OrElse peso > 30000 Then
            errorRegistro = "El peso debe estar entre 100 y 30000 kg."
            Return False
        End If

        If calidad <> "A" AndAlso
           calidad <> "B" AndAlso
           calidad <> "C" Then

            errorRegistro = "Seleccione una calidad válida."
            Return False
        End If

        If String.IsNullOrWhiteSpace(usuarioId) OrElse
           String.IsNullOrWhiteSpace(usuarioCorreo) Then

            errorRegistro = "No se pudo identificar al usuario."
            Return False
        End If

        SyncLock Candado

            If Datos.Any(Function(e) e.Boleta = boleta) Then
                errorRegistro = "La boleta ya está registrada."
                Return False
            End If

            registrada = New Entrega With {
                .Boleta = boleta,
                .Productor = productor.Descripcion,
                .PesoKg = peso,
                .Calidad = calidad,
                .Pago = CalculadoraPago.Calcular(peso, calidad),
                .UsuarioId = usuarioId,
                .UsuarioCorreo = usuarioCorreo
            }

            Datos.Add(registrada)
            Return True
        End SyncLock
    End Function

    Public Shared Function Consultar(
        usuarioId As String,
        esAdministrador As Boolean
    ) As List(Of Entrega)

        SyncLock Candado

            Dim consulta As IEnumerable(Of Entrega) = Datos

            If Not esAdministrador Then
                consulta = consulta.Where(
                    Function(e) e.UsuarioId = usuarioId)
            End If

            ' Se devuelven copias para proteger la lista compartida.
            Return consulta.Select(
                Function(e) New Entrega With {
                    .Boleta = e.Boleta,
                    .Productor = e.Productor,
                    .PesoKg = e.PesoKg,
                    .Calidad = e.Calidad,
                    .Pago = e.Pago,
                    .UsuarioId = e.UsuarioId,
                    .UsuarioCorreo = e.UsuarioCorreo
                }).ToList()

        End SyncLock
    End Function

End Class
