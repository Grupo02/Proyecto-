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

    Private _nroMesa As Int16
    Public Property NroMesa() As Int16
        Get
            Return _nroMesa
        End Get
        Set(ByVal value As Int16)
            _nroMesa = value
        End Set
    End Property

End Class
