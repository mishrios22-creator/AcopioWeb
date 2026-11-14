Imports Microsoft.Owin
Imports Owin

<Assembly: OwinStartupAttribute(GetType(Startup))>

Partial Public Class Startup
    Public Sub Configuration(app As Owin.IAppBuilder)
        ConfigureAuth(app)
        InicializadorIdentity.Ejecutar()
    End Sub
End Class
