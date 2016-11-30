Public Class Administrador

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

End Class
