Public Class Administrador
    Inherits Persona
    Private _usuarioAdministrado As String
    Public Property UsuarioAdministrador() As String
        Get
            Return _usuarioAdministrado
        End Get
        Set(ByVal value As String)
            _usuarioAdministrado = value
        End Set
    End Property

    Private _claveAdministrador As String
    Public Property ClaveAdministrador() As String
        Get
            Return _claveAdministrador
        End Get
        Set(ByVal value As String)
            _claveAdministrador = value
        End Set
    End Property

    Public Sub New(persona As Persona, usuario As String, clave As String)
        Me.Id = persona.Id
        Me.Nombre = persona.Nombre
        Me.Apellido = persona.Apellido
        Me.Edad = persona.Edad
        Me.UsuarioAdministrador = usuario
        Me.ClaveAdministrador = clave
    End Sub
    Public Overrides Function ToString() As String
        Return "Persona nro: " & Me.Id & ": " & Me.Nombre & " " & Me.Apellido & " tiene " & Me.Edad & " años" & vbTab & " User " & Me.UsuarioAdministrador & "-Clave " & Me.ClaveAdministrador
    End Function
End Class
