Imports System.Data
Imports System.Data.OleDb

Public Class VentanaAgregarDignidad
    Private dbPath As String = "../../Proyecto_Visual.mdb"
    Private strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Private dsDignidad As DataSet

    Private Sub btnGuardarDignidad_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarDignidad.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim id = 0
        Try
            id = Me.DataContext.Id()
        Catch ex As Exception

        End Try

        If txtNombresDignidad.Text = "" Then
            MsgBox("No se puede dejar vacío")
        Else
            UpdateDignidad(id, txtNombresDignidad.Text)
            MsgBox("Dignidad Guardada")
            Me.Close()

        End If


    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM Dignidad;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsDignidad = New DataSet("Dignidad")
            adapter.FillSchema(dsDignidad, SchemaType.Source)

            adapter.Fill(dsDignidad, "Dignidad")

            'dataGridPersona.DataContext = dsPersonas

        End Using
    End Sub

    Public Sub UpdateDignidad(id As Integer, nombre As String)
        If id = 0 Then
            Me.dsDignidad.Tables("Dignidad").Rows.Add(id, nombre)
        End If

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM Dignidad;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            'adapter.FillSchema(dsPersonas, SchemaType.Source)


            Try
                adapter.Update(dsDignidad.Tables("Dignidad"))

            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub

    'Public Sub AgregarPanel()
    '    Dim ventanaVotacion As New VentanaVotacion
    '    ventanaVotacion.Owner = Me
    '    ventanaVotacion.ad
    'End Sub

End Class
