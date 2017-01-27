Imports System.Data.OleDb
Imports System.Data
Class MainWindow

    Private Sub btnAdmin_Click(sender As Object, e As RoutedEventArgs) Handles btnAdmin.Click
        Dim loginAdmin As New LoginAdmin
        loginAdmin.Owner = Me
        loginAdmin.Show()
    End Sub

    Private Sub btnVotante_Click(sender As Object, e As RoutedEventArgs) Handles btnVotante.Click
        Dim loginVotante As New LoginVotante
        loginVotante.Owner = Me
        loginVotante.Show()
    End Sub

    Private Sub btnCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btnCandidato.Click
        Dim loginCandidato As New LoginCandidato
        loginCandidato.Owner = Me
        loginCandidato.Show()
    End Sub



End Class
