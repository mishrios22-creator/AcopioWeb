Imports System.Collections.Generic
Imports System.Linq

Public Class Productor
    Public Property Codigo As String
    Public Property Nombre As String

    Public ReadOnly Property Descripcion As String
        Get
            Return Codigo & " - " & Nombre
        End Get
    End Property
End Class

Public NotInheritable Class CatalogoProductores

    Private Sub New()
    End Sub

    Public Shared Function ObtenerTodos() As List(Of Productor)
        Return New List(Of Productor) From {
            New Productor With {
                .Codigo = "P-101",
                .Nombre = "Finca Los Almendros"
            },
            New Productor With {
                .Codigo = "P-102",
                .Nombre = "Finca El Progreso"
            },
            New Productor With {
                .Codigo = "P-103",
                .Nombre = "Finca San Jorge"
            },
            New Productor With {
                .Codigo = "P-104",
                .Nombre = "Finca La Esperanza"
            },
            New Productor With {
                .Codigo = "P-105",
                .Nombre = "Finca Río Claro"
            }
        }
    End Function

    Public Shared Function Buscar(codigo As String) As Productor
        Return ObtenerTodos().FirstOrDefault(
            Function(p) p.Codigo = codigo)
    End Function

End Class
