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
    Public Sub New(persona As Persona, estado As Boolean)
        Me.Id = persona.Id
        Me.Nombre = persona.Nombre
        Me.Apellido = persona.Apellido
        Me.Edad = persona.Edad
        Me.Estado = estado
    End Sub
    Public Overrides Function ToString() As String
        Return "Persona nro: " & Me.Id & ": " & Me.Nombre & " " & Me.Apellido & " tiene " & Me.Edad & " años" & vbTab & " Estado " & Me.Estado
    End Function
End Class