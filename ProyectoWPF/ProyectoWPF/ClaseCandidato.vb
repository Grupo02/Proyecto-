Public Class Candidato
    Private _usuarioCandidato As String
    Public Property UsuarioCandidato() As String
        Get
            Return _usuarioCandidato
        End Get
        Set(ByVal value As String)
            _usuarioCandidato = value
        End Set
    End Property
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _claveCandidato As String
    Public Property ClaveCandidato() As String
        Get
            Return _claveCandidato
        End Get
        Set(ByVal value As String)
            _claveCandidato = value
        End Set
    End Property

    Public _dignidad As String
    Public Property Dignidad() As String
        Get
            Return _dignidad
        End Get
        Set(ByVal value As String)
            _dignidad = value
        End Set
    End Property
    Public Sub New(user As String, clave As String, dignidad As String, nombre As String, apellido As String)
        Me.UsuarioCandidato = user
        Me.ClaveCandidato = clave
        Me.Dignidad = dignidad
        Me.Nombre = nombre
        Me.Apellido = apellido
    End Sub

End Class
