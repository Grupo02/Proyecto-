Imports System.Data
Imports System.Data.OleDb

Public Class VentanaVotacion
    Private dbPath As String = "../../Proyecto_Visual.mdb"
    Private strConexion As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbPath
    Private dsPesonas As DataSet
    Private dsPesonas2 As DataSet
    Private dsPesonas3 As DataSet
    Private dsCandidato As DataSet
    Private dsVotante As DataSet

    Private _cedula As Integer
    Public Property Cedula() As Integer
        Get
            Return _cedula
        End Get
        Set(ByVal value As Integer)
            _cedula = value
        End Set
    End Property

    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Owner.Show()
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

            Dim consultaCan As String = "Select * FROM Candidato;"
            Dim adapterCan As New OleDbDataAdapter(New OleDbCommand(consultaCan, conexion))
            Dim personaCmdBuilderCan = New OleDbCommandBuilder(adapterCan)
            dsCandidato = New DataSet("Candidato")
            adapterCan.FillSchema(dsCandidato, SchemaType.Source)

            adapterCan.Fill(dsCandidato, "Candidato")
        End Using
    End Sub



    Private Sub dtgVotarPresidente_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgVotarPresidente.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        Dim id As Integer = fila("Id")
        dtgVotarPresidente.IsEnabled = False
        MsgBox("Usted ha votado por " & fila("Nombre") & " " & fila("Apellido"), MsgBoxStyle.Information)

        UpdateCandidato()

    End Sub

    Public Sub UpdateCandidato()
        Dim dsVotante As DataSet
        Using conectar As New OleDbConnection(strConexion)
            Dim consultar As String = "Select * FROM Votante;"
            Dim adapterV As New OleDbDataAdapter(New OleDbCommand(consultar, conectar))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapterV)
            dsVotante = New DataSet("Votante")
            adapterV.FillSchema(dsVotante, SchemaType.Source)

            adapterV.Fill(dsVotante, "Votante")
        End Using
        For Each persona As DataRow In dsVotante.Tables("Votante").Rows
            Dim uno = 1
            If persona("Id") = Cedula Then
                persona("estado") = uno
            End If
        Next
        Using conexion As New OleDbConnection(strConexion)
            Dim consultar As String = "Select * FROM Votante;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consultar, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsVotante.Tables("Votante"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try

        End Using

    End Sub

    Private Sub dtgVotarConsejal_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgVotarConsejal.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        Dim id As Integer = fila("Id")
        dtgVotarConsejal.IsEnabled = False
        MsgBox("Usted ha votado por " & fila("Nombre") & " " & fila("Apellido"))
        UpdateCandidato()
    End Sub

    Private Sub dtgVotarAsambleista_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles dtgVotarAsambleista.SelectionChanged
        Dim fila As DataRowView = sender.SelectedItem
        Dim id As Integer = fila("Id")
        dtgVotarAsambleista.IsEnabled = False
        MsgBox("Usted ha votado por " & fila("Nombre") & " " & fila("Apellido"))
        UpdateCandidato()
    End Sub
End Class
