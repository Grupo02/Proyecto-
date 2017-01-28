Public Class VentanaAdministrador
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Owner.Owner.Close()
    End Sub

    Private Sub btn_agregandoCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btn_agregandoCandidato.Click
        Dim AgregarCandidato As New VentanaAgregarCandidato
        AgregarCandidato.Owner = Me
        AgregarCandidato.Show()
    End Sub

    Private Sub btn_eliminarCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btn_eliminarCandidato.Click
        Dim EliminarCandidato As New VentanaEliminarCandidato
        EliminarCandidato.Owner = Me
        EliminarCandidato.Show()
    End Sub

    Private Sub btn_agregarVotante_Click(sender As Object, e As RoutedEventArgs) Handles btn_agregarVotante.Click
        Dim AgregarVotante As New VentanaAgregarVotante
        AgregarVotante.Owner = Me
        AgregarVotante.Show()
    End Sub

    Private Sub btn_EliminarVotante_Click(sender As Object, e As RoutedEventArgs) Handles btn_EliminarVotante.Click
        Dim EliminarVotante As New VentanaEliminarVotante
        EliminarVotante.Owner = Me
        EliminarVotante.Show()
    End Sub
End Class
