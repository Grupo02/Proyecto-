Public Class RecintoElectoral
    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property

    Private _votos As ArrayList
    Public Property Votos() As ArrayList
        Get
            Return _votos
        End Get
        Set(ByVal value As ArrayList)
            _votos = value
        End Set
    End Property

    Private _direccion As String
    Public Property Direccion() As String
        Get
            Return _direccion
        End Get
        Set(ByVal value As String)
            _direccion = value
        End Set
    End Property

    Private _provincia As String
    Public Property Provincia() As String
        Get
            Return _provincia
        End Get
        Set(ByVal value As String)
            _provincia = value
        End Set
    End Property

    Private _mesa As Mesa
    Public Property Mesa() As Mesa
        Get
            Return _mesa
        End Get
        Set(ByVal value As Mesa)
            _mesa = value
        End Set
    End Property
End Class
