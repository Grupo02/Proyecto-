Public Class VentanaAdministrador
    Private Sub Window_Closing(sender As Object, e As RoutedEventArgs)
        Me.Owner.Owner.Close()
    End Sub
End Class
