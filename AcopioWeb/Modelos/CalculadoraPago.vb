Public NotInheritable Class CalculadoraPago

    Private Sub New()
    End Sub

    Public Shared Function Calcular(
        peso As Integer,
        calidad As String
    ) As Decimal

        If peso < 100 OrElse peso > 30000 Then
            Throw New ArgumentOutOfRangeException(NameOf(peso))
        End If

        Dim precio As Decimal

        Select Case calidad
            Case "A"
                precio = 95D
            Case "B"
                precio = 80D
            Case "C"
                precio = 60D
            Case Else
                Throw New ArgumentException("Calidad no válida.")
        End Select

        Return peso * precio
    End Function

End Class
