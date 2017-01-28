Public Class VentanaAdministrador
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Owner.Owner.Close()
    End Sub
End Class
