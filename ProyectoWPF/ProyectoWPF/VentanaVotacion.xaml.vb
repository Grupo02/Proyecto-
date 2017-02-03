Public Class VentanaVotacion
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Owner.Show()
    End Sub

    Private Sub btnVotarConsejal_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarConsejal.Click

    End Sub
End Class
