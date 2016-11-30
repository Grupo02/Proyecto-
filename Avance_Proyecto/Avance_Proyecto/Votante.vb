Public Class Votante
    Inherits Persona

    Private _estado As Boolean
    Public Property Estado() As Boolean
        Get
            Return _estado
        End Get
        Set(ByVal value As Boolean)
            _estado = value
        End Set
    End Property

End Class
