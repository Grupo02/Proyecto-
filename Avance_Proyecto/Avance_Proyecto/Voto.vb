Public Class Voto
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
