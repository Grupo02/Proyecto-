Imports System.Data.OleDb
Imports System.Data
Public Class LoginAdmin
    Dim personaCmdBuilder = New OleDbCommand
    Dim adapter As New OleDbDataAdapter
    Dim lector As OleDbDataReader
    Dim consulta As String
    Dim comandos As OleDbCommand
    Dim dbPath = "C:\Users\PaolaO\Source\Repos\Proyecto-\Proyecto_Visual.accdb"
    Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath

    Private Sub bntIngresarAdmin_Click(sender As Object, e As RoutedEventArgs) Handles bntIngresarAdmin.Click


        Using dbConexion As New OleDbConnection(strConexion)

        End Using

        consulta = "SELECT usuario, clave FROM Administrador= '" & txtUserAdmin.Text & "' AND contraseña= '" & txtClaveAdmin.Text & " '"
        comandos = New OleDbCommand(consulta, strConexion)
        adapter.SelectCommand = comandos
        lector = comandos.ExecuteReader
        If lector.HasRows = True Then
            MsgBox("Correcto")
        Else
            MsgBox("Usuario Incorrecto")
        End If

    End Sub
End Class
