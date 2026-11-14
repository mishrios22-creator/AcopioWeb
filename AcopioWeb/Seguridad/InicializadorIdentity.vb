Imports Microsoft.AspNet.Identity
Imports Microsoft.AspNet.Identity.EntityFramework
Imports System.Linq

Public NotInheritable Class InicializadorIdentity

    Private Sub New()
    End Sub

    Public Shared Sub Ejecutar()

        Using contexto As New ApplicationDbContext()

            Using roles As New RoleManager(Of IdentityRole)(
                New RoleStore(Of IdentityRole)(contexto))

                Using usuarios As New ApplicationUserManager(
                    New UserStore(Of ApplicationUser)(contexto))

                    ' La contraseña exigida por el laboratorio
                    ' no contiene símbolos.
                    usuarios.PasswordValidator = New PasswordValidator With {
                        .RequiredLength = 8,
                        .RequireDigit = True,
                        .RequireLowercase = True,
                        .RequireUppercase = True,
                        .RequireNonLetterOrDigit = False
                    }

                    If Not roles.RoleExists("Administrador") Then
                        Comprobar(roles.Create(
                            New IdentityRole("Administrador")))
                    End If

                    If Not roles.RoleExists("Recepcion") Then
                        Comprobar(roles.Create(
                            New IdentityRole("Recepcion")))
                    End If

                    CrearUsuario(
                        usuarios,
                        "admin@apas.local",
                        "Administrador")

                    CrearUsuario(
                        usuarios,
                        "recepcion1@apas.local",
                        "Recepcion")

                    CrearUsuario(
                        usuarios,
                        "recepcion2@apas.local",
                        "Recepcion")
                End Using
            End Using
        End Using
    End Sub

    Private Shared Sub CrearUsuario(
        manager As ApplicationUserManager,
        correo As String,
        rol As String
    )

        Dim usuario = manager.FindByEmail(correo)

        If usuario Is Nothing Then

            usuario = New ApplicationUser With {
                .UserName = correo,
                .Email = correo,
                .EmailConfirmed = True
            }

            Comprobar(manager.Create(usuario, "Acopio2026"))
        End If

        If Not manager.IsInRole(usuario.Id, rol) Then
            Comprobar(manager.AddToRole(usuario.Id, rol))
        End If
    End Sub

    Private Shared Sub Comprobar(resultado As IdentityResult)
        If Not resultado.Succeeded Then
            Throw New InvalidOperationException(
                String.Join("; ", resultado.Errors.ToArray()))
        End If
    End Sub

End Class
