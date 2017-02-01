Imports System.Data.OleDb
Imports System.Data
Public Class LoginCandidato
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "../../Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath

        Using dbConexion As New OleDbConnection(strConexion)

        End Using
    End Sub
    Private Sub btnIngresarCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btnIngresarCandidato.Click
        Dim dbPath = "../../Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        Dim dbConexion As New OleDbConnection(strConexion)

        dbConexion.Open()
        Console.WriteLine("Conexion exitosa")
        Dim strQuery1 As String = "SELECT usuario, clave FROM Candidato WHERE usuario ='" & txtUserCandidato.Text & "'AND clave ='" & passCandidato.Password & "'"
        Dim comandos = New OleDbCommand(strQuery1, dbConexion)
        Dim adapter As New OleDbDataAdapter
        adapter.SelectCommand = comandos
        Dim lector As OleDbDataReader
        lector = comandos.ExecuteReader
        If lector.HasRows = True Then
            MsgBox("Login exitoso", MsgBoxStyle.Information, "Login")
        Else
            MsgBox("No esta dentro de la base de datos", MsgBoxStyle.Critical, "Error")
        End If
        dbConexion.Close()

        Dim ventanaCandidato As New VentanaCandidato
        ventanaCandidato.Owner = Me
        Me.Hide()
        Me.Owner.Hide()
        ventanaCandidato.Show()
    End Sub


End Class
