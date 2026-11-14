# AcopioWeb

Laboratorio 1 de IN3114 Programación de Computadoras VI.

Estudiante: COMPLETAR

## Tecnologías

- Visual Basic .NET
- ASP.NET Web Forms
- .NET Framework 4.8.1
- ASP.NET Identity 2
- Bootstrap 5

## Ejecución

1. Abrir la solución en Visual Studio.
2. Restaurar los paquetes NuGet.
3. Tener instalado .NET Framework 4.8.1 Developer Pack y SQL Server LocalDB.
4. Verificar la cadena DefaultConnection.
5. Ejecutar con IIS Express.
6. En el primer inicio se crean los roles y usuarios de prueba.

Identity almacena las cuentas en LocalDB.

Las entregas se almacenan en una lista compartida en memoria.
Se eliminan al reiniciar la aplicación.

## Usuarios de prueba

| Usuario | Contraseña | Rol |
|---|---|---|
| admin@apas.local | Acopio2026 | Administrador |
| recepcion1@apas.local | Acopio2026 | Recepcion |
| recepcion2@apas.local | Acopio2026 | Recepcion |

## Organización

- Modelos: productores, entregas, pagos y almacenamiento.
- Seguridad: inicialización de Identity y control de acceso.
- RegistrarEntrega.aspx: registro exclusivo para Recepcion.
- ConsultarEntregas.aspx: consulta filtrada por rol.
- Site.Master: menú y cierre de sesión.

## Evidencia de pruebas

### Caso 1
![Caso 1](evidencias/caso01.png)

### Caso 2
![Caso 2](evidencias/caso02.png)

### Caso 3
![Caso 3](evidencias/caso03.png)

### Caso 4
![Caso 4](evidencias/caso04.png)

### Caso 5
![Caso 5](evidencias/caso05.png)

### Caso 6
![Caso 6](evidencias/caso06.png)

### Caso 7
![Caso 7](evidencias/caso07.png)

## Uso de inteligencia artificial

Se utilizó ChatGPT como apoyo para interpretar el enunciado,
organizar la solución.

COMPLETAR con las revisiones, modificaciones y pruebas realizadas
personalmente.
