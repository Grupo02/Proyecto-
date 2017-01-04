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
    Private _lista As Integer
    Public Property Lista() As Integer
        Get
            Return _lista
        End Get
        Set(ByVal value As Integer)
            _lista = value
        End Set
    End Property
    Private _votos As Integer
    Public Property Votos() As Integer
        Get
            Return _votos
        End Get
        Set(ByVal value As Integer)
            _votos = value
        End Set
    End Property
    Public Sub New(persona As Persona, user As String, clave As String, dignidad As String, lista As Integer)
        Me.Id = persona.Id
        Me.Nombre = persona.Nombre
        Me.Apellido = persona.Apellido
        Me.Edad = persona.Edad
        Me.UsuarioCandidato = user
        Me.ClaveCandidato = clave
        Me.Dignidad = dignidad
        Me.Lista = lista
        Me.Votos = 0
    End Sub
    Public Overrides Function ToString() As String
        Return "Persona nro: " & Me.Id & ": " & Me.Nombre & " " & Me.Apellido & " tiene " & Me.Edad & " años" & vbTab & " User " & Me.UsuarioCandidato & "-Clave" & Me.ClaveCandidato & "-Dignidad" & Me.Dignidad & "Lista" & Me.Lista & " tiene " & Me.Votos & " votos"
    End Function
End Class
