Imports System.Data.OleDb
Imports System.Data
Public Class LoginVotante

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

    Private Sub btnIngresarVotante_Click(sender As Object, e As RoutedEventArgs) Handles btnIngresarVotante.Click
        Dim dbPath = "../../Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        Dim dbConexion As New OleDbConnection(strConexion)

        dbConexion.Open()

        Dim strQuery1 As String = "SELECT Id FROM Votante WHERE Id ='" & txtCedula.Text & "'"
        Dim strQuery2 As String = "SELECT estado FROM Votante WHERE Id ='" & txtCedula.Text & "' and estado=0"


        Dim comandos = New OleDbCommand(strQuery1, dbConexion)
        Dim comandos2 = New OleDbCommand(strQuery2, dbConexion)

        Dim adapter As New OleDbDataAdapter
        Dim adapter2 As New OleDbDataAdapter

        adapter.SelectCommand = comandos
        adapter2.SelectCommand = comandos2

        Dim lector As OleDbDataReader
        Dim lector2 As OleDbDataReader

        lector = comandos.ExecuteReader
        lector2 = comandos2.ExecuteReader
        If lector.HasRows = True Then
            MsgBox("Login exitoso", MsgBoxStyle.Information, "Login")
            If lector2.HasRows = True Then
                Dim ventanaVotacion As New VentanaVotacion
                ventanaVotacion.Owner = Me
                Me.Hide()
                Me.Owner.Hide()
                ventanaVotacion.Show()

            Else
                MsgBox("Usted ya ha votado", MsgBoxStyle.Exclamation, "Error")
            End If
        Else
            MsgBox("No esta dentro de la base de datos", MsgBoxStyle.Critical, "Error")
        End If
        dbConexion.Close()
    End Sub



End Class
