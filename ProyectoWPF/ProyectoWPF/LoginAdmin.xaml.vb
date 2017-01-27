Imports System.Data.OleDb
Imports System.Data
Public Class LoginAdmin

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "C:\Users\PaolaO\Documents\ESPOL\5S\Programación Visual\Ejercicios\BD\sample.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        'Dim dbConexion As New OleDbConnection(strConexion)

        'dbConexion.Open()
        'Console.WriteLine("Conexion exitosa")
        'dbConexion.Close()

        Using dbConexion As New OleDbConnection(strConexion)
            'Console.WriteLine("Conexion exitosa")
            Dim strQuery As String = "SELECT * FROM tbl_master"
            Dim dbAdapter As New OleDbDataAdapter(strQuery, dbConexion)


        End Using

    End Sub
    Private Sub bntIngresarAdmin_Click(sender As Object, e As RoutedEventArgs) Handles bntIngresarAdmin.Click

        Dim dbPath = "C:\Users\PaolaO\Documents\ESPOL\5S\Programación Visual\Ejercicios\BD\sample.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        Dim dbConexion As New OleDbConnection(strConexion)

        dbConexion.Open()
        Console.WriteLine("Conexion exitosa")
        Dim strQuery1 As String = "SELECT firstName, LastName FROM tbl_master WHERE firstName ='" & txtUserAdmin.Text & "'AND LastName ='" & txtClaveAdmin.Text & "'"
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
