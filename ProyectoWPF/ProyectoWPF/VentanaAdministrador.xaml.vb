﻿Public Class VentanaAdministrador
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Owner.Owner.Close()
    End Sub

    Private Sub btn_agregandoCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btn_agregandoCandidato.Click
        Dim AgregarCandidato As New VentanaAgregarCandidato
        AgregarCandidato.Owner = Me
        AgregarCandidato.Show()
    End Sub

    Private Sub btn_agregarDignidad_Click(sender As Object, e As RoutedEventArgs) Handles btn_agregarDignidad.Click
        Dim AgregarVotante As New VentanaAgregarVotante
        AgregarVotante.Owner = Me
        AgregarVotante.Show()
    End Sub




End Class
