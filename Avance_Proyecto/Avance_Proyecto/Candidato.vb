Public Class Candidato
    Inherits Persona
    Private _usuarioCandidato As String
    Public Property UsuarioCandidato() As String
        Get
            Return _usuarioCandidato
        End Get
        Set(ByVal value As String)
            _usuarioCandidato = value
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

    Private _dignidad As String
    Public Property Dignidad() As String
        Get
            Return _dignidad
        End Get
        Set(ByVal value As String)
            _dignidad = value
        End Set
    End Property

    Private _votoRecibido As Integer
    Public Property VotoRecibido() As Integer
        Get
            Return _votoRecibido
        End Get
        Set(ByVal value As Integer)
            _votoRecibido = value
        End Set
    End Property
End Class
