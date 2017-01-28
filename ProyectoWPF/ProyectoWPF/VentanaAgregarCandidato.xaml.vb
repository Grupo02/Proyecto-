Public Class VentanaAgregarCandidato
    Private Sub cBoxDignidad_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cBoxDignidad.SelectionChanged
        cBoxDignidad.Items.Add("Presidente")
        cBoxDignidad.Items.Add("Asambleísta")
        cBoxDignidad.Items.Add("Alcalde")
    End Sub
End Class
