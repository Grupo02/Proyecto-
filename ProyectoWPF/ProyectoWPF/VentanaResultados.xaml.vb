Public Class VentanaCandidato
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Owner.Show()
    End Sub
End Class
