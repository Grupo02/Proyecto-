Imports System.Data.OleDb
Imports System.Data
Public Class LoginVotante

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "E:\VISUAL BASIC\Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        'Dim dbConexion As New OleDbConnection(strConexion)

        'dbConexion.Open()
        'Console.WriteLine("Conexion exitosa")
        'dbConexion.Close()

        Using dbConexion As New OleDbConnection(strConexion)
            'Console.WriteLine("Conexion exitosa")

        End Using
    End Sub

    Private Sub btnIngresarVotante_Click(sender As Object, e As RoutedEventArgs) Handles btnIngresarVotante.Click
        Dim dbPath = "E:\base\Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        Dim dbConexion As New OleDbConnection(strConexion)

        dbConexion.Open()

        Dim strQuery1 As String = "SELECT Id FROM Votante WHERE Id ='" & txtCedula.Text & "'"
        Dim comandos = New OleDbCommand(strQuery1, dbConexion)
        Dim adapter As New OleDbDataAdapter
        adapter.SelectCommand = comandos
        Dim lector As OleDbDataReader
        lector = comandos.ExecuteReader
        If lector.HasRows = True Then
            MsgBox("Al fin")
        Else
            MsgBox("NO :c")
        End If
        dbConexion.Close()

    End Sub



End Class
