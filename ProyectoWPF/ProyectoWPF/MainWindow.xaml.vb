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

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "C:\Users\PaolaO\Source\Repos\Proyecto-\Proyecto_Visual.accdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath

        Using dbConexion As New OleDbConnection(strConexion)
            Dim personaCmdBuilder = New OleDbCommand
            Dim adapter As New OleDbDataAdapter
            Dim lector As OleDbDataReader
        End Using
    End Sub
End Class
