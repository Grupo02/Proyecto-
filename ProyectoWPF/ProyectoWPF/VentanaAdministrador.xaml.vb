﻿Public Class VentanaAdministrador
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Owner.Owner.Close()
    End Sub

    Private Sub btn_agregandoCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btn_agregandoCandidato.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim AgregarCandidato As New VentanaAgregarCandidato
        AgregarCandidato.Owner = Me
        AgregarCandidato.Show()
    End Sub

    Private Sub btn_agregarDignidad_Click(sender As Object, e As RoutedEventArgs) Handles btn_agregarDignidad.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim AgregarDignidad As New VentanaAgregarDignidad
        AgregarDignidad.Owner = Me
        AgregarDignidad.Show()
    End Sub

    Private Sub btnMostrarResultado_Click(sender As Object, e As RoutedEventArgs) Handles btnMostrarResultado.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim MostrarResultados As New VentanaResultados
        MostrarResultados.Owner = Me
        MostrarResultados.Show()
    End Sub

    Private Sub btn_cerrar_Click(sender As Object, e As RoutedEventArgs) Handles btn_cerrar.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim VentanaPrincipal As New MainWindow
        VentanaPrincipal.Show()
        Me.Close()
    End Sub
End Class
