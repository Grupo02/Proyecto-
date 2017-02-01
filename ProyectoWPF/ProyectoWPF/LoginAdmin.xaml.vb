Imports System.Data.OleDb
Imports System.Data
Public Class LoginAdmin

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "../../Proyecto_Visual.mdb"
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
    Private Sub bntIngresarAdmin_Click(sender As Object, e As RoutedEventArgs) Handles bntIngresarAdmin.Click

        Dim dbPath = "../../Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        Dim dbConexion As New OleDbConnection(strConexion)

        dbConexion.Open()
        Console.WriteLine("Conexion exitosa")
        Dim strQuery1 As String = "SELECT usuario, clave FROM Administrador WHERE usuario ='" & txtUserAdmin.Text & "'AND clave ='" & passAdmin.Password & "'"
        Dim comandos = New OleDbCommand(strQuery1, dbConexion)
        Dim adapter As New OleDbDataAdapter
        adapter.SelectCommand = comandos
        Dim lector As OleDbDataReader
        lector = comandos.ExecuteReader
        If lector.HasRows = True Then
            MsgBox("Login exitoso", MsgBoxStyle.Information, "Login")
            Dim ventanaAdmin As New VentanaAdministrador
            ventanaAdmin.Owner = Me
            Me.Hide()
            Me.Owner.Hide()
            ventanaAdmin.Show()
        Else
            MsgBox("No esta dentro de la base de datos", MsgBoxStyle.Critical, "Error")
        End If
        dbConexion.Close()

    End Sub


End Class
