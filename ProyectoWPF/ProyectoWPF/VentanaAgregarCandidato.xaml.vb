Imports System.Data
Imports System.Data.OleDb

Public Class VentanaAgregarCandidato

    Private dbPath As String = "../../Proyecto_Visual.mdb"
    Private strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath

    Private dsCandidato As DataSet

    Private Sub cBoxDignidad_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cBoxDignidad.SelectionChanged
        cBoxDignidad.Items.Add("Presidente")
        cBoxDignidad.Items.Add("Asambleísta")
        cBoxDignidad.Items.Add("Consejal")
    End Sub

    Private Sub btnGuardarCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btnGuardarCandidato.Click

        If txtApellidosCandidato.Text = "" Or txtNombresCandidato.Text = "" Or txtCedulaCandidato.Text = "" Or txtListaCandidato.Text = "" Or txtUsuarioCandidato.Text = "" Or cBoxDignidad.Text = "" Then
            MsgBox("Llenar todo los campos")
        Else
            UpdatePersona(txtCedulaCandidato.Text, txtNombresCandidato.Text, txtApellidosCandidato.Text, txtUsuarioCandidato.Text, passClaveUser.Password, cBoxDignidad.Text, txtListaCandidato.Text)
            MsgBox("Candidato Guardado")
            Me.Close()
        End If

    End Sub

    Public Sub UpdatePersona(id As Integer, nombre As String, apellido As String, usuario As String, clave As String, dignidades As String, listaCandidato As Integer)
        If dignidades = "Presidente" Then
            Me.dsCandidato.Tables("Candidato").Rows.Add(id, usuario, clave, 1, nombre, apellido, 0, listaCandidato, 0)
        End If
        If dignidades = "Asambleista" Then
            Me.dsCandidato.Tables("Candidato").Rows.Add(id, usuario, clave, 2, nombre, apellido, 0, listaCandidato, 0)
        End If
        If dignidades = "Consejal" Then
            Me.dsCandidato.Tables("Candidato").Rows.Add(id, usuario, clave, 3, nombre, apellido, 0, listaCandidato, 0)
        End If

        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM Candidato;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            'adapter.FillSchema(dsPersonas, SchemaType.Source)
            Try
                adapter.Update(dsCandidato.Tables("Candidato"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "Select * FROM Candidato;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsCandidato = New DataSet("Candidato")
            adapter.FillSchema(dsCandidato, SchemaType.Source)

            adapter.Fill(dsCandidato, "Candidato")

            'dataGridPersona.DataContext = dsPersonas

        End Using
    End Sub
End Class
