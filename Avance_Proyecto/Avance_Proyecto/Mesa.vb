Public Class Mesa
    Private _id As String
    Public Property Id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property
    Private _estado As Boolean
    Public Property Estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

    Private _votantes As ArrayList
    Public Property Votantes() As ArrayList
        Get
            Return _votantes
        End Get
        Set(ByVal value As ArrayList)
            _votantes = value
        End Set
    End Property
End Class
