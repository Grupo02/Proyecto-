Imports System.Data.OleDb
Imports System.Data
Class MainWindow

    Private Sub btnAdmin_Click(sender As Object, e As RoutedEventArgs) Handles btnAdmin.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim loginAdmin As New LoginAdmin
        loginAdmin.Owner = Me
        loginAdmin.Show()
    End Sub

    Private Sub btnVotante_Click(sender As Object, e As RoutedEventArgs) Handles btnVotante.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim loginVotante As New LoginVotante
        loginVotante.Owner = Me
        loginVotante.Show()
    End Sub

    Private Sub btnCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btnCandidato.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim loginCandidato As New LoginCandidato
        loginCandidato.Owner = Me
        loginCandidato.Show()
    End Sub

    Private Sub btnAnuncio_Click(sender As Object, e As RoutedEventArgs) Handles btnAnuncio.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim ventanaAnuncio As New VentanaAnuncio
        ventanaAnuncio.Owner = Me
        ventanaAnuncio.Show()

    End Sub
End Class
