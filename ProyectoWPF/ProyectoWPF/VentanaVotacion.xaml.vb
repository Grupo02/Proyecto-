Imports System.Data
Imports System.Data.OleDb

Public Class VentanaVotacion
    Private dbPath As String = "../../Proyecto_Visual.mdb"
    Private strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Private dsPesonas As DataSet
    Private dsPesonas2 As DataSet
    Private dsPesonas3 As DataSet
    Private dsCandidato As DataSet


    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Owner.Show()
    End Sub

    Private Sub btnVotarConsejal_Click(sender As Object, e As RoutedEventArgs) Handles btnVotarConsejal.Click

    End Sub

    Private Sub btnVotarAsamblesita_Click(sender As Object, e As RoutedEventArgs)

    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim VenVotante As LoginVotante
        VenVotante = Me.Owner
        VenVotante.Hide()

        Using conexion As New OleDbConnection(strConexion)

            Dim consulta As String = "SELECT Candidato.Id, Candidato.nombre, Candidato.apellido FROM Candidato INNER JOIN Dignidad ON Candidato.dignidad = Dignidad.Id WHERE Candidato.dignidad=1;"
            Dim consulta2 As String = "SELECT Candidato.Id, Candidato.nombre, Candidato.apellido FROM Candidato INNER JOIN Dignidad ON Candidato.dignidad = Dignidad.Id WHERE Candidato.dignidad=2;"
            Dim consulta3 As String = "SELECT Candidato.Id, Candidato.nombre, Candidato.apellido FROM Candidato INNER JOIN Dignidad ON Candidato.dignidad = Dignidad.Id WHERE Candidato.dignidad=3;"
            'Dim adapter As New OleDbDataAdapter(consulta, conexion)
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion))
            Dim adapter3 As New OleDbDataAdapter(New OleDbCommand(consulta3, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            Dim personaCmdBuilder3 = New OleDbCommandBuilder(adapter3)
            dsPesonas = New DataSet("Candidato")
            dsPesonas2 = New DataSet("Candidato")
            dsPesonas3 = New DataSet("Candidato")
            adapter.FillSchema(dsPesonas, SchemaType.Source)
            adapter.Fill(dsPesonas, "Candidato")
            adapter2.FillSchema(dsPesonas2, SchemaType.Source)
            adapter2.Fill(dsPesonas2, "Candidato")
            adapter3.FillSchema(dsPesonas3, SchemaType.Source)
            adapter3.Fill(dsPesonas3, "Candidato")

            dtgVotarPresidente.DataContext = dsPesonas
            dtgVotarAsambleista.DataContext = dsPesonas2
            dtgVotarConsejal.DataContext = dsPesonas3


        End Using
    End Sub
End Class
