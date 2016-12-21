Public Class Voto
    Private _id As Int16
    Public Property Id() As Int16
        Get
            Return _id
        End Get
        Set(ByVal value As Int16)
            _id = value
        End Set
    End Property

    Private _candidato As Candidato
    Public Property Candidato() As Candidato
        Get
            Return _candidato
        End Get
        Set(ByVal value As Candidato)
            _candidato = value
        End Set
    End Property

End Class
