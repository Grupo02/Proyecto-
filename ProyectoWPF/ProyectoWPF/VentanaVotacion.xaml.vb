Imports System.Data
Imports System.Data.OleDb

Public Class VentanaVotacion
    Private dsPesonas As DataSet
    Private dsCandidato As DataSet
    Private dsCandidato2 As DataSet
    Dim btn_actual As New Button
    Dim dbPath = "../../Proyecto_Visual.mdb"
    Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath

    Private _cedula As Integer
    Public Property Cedula() As Integer
        Get
            Return _cedula
        End Get
        Set(ByVal value As Integer)
            _cedula = value
        End Set
    End Property

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim nombre As String
        Dim dsPersonas As DataSet
        Dim dsPersonas2 As DataSet
        Using conexion As New OleDbConnection(strConexion)
            Dim consulta As String = "Select * FROM Dignidad;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consulta, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            dsPersonas = New DataSet("Dignidad")
            adapter.FillSchema(dsPersonas, SchemaType.Source)

            adapter.Fill(dsPersonas, "Dignidad")
        End Using
        Using conexion2 As New OleDbConnection(strConexion)

            Dim consulta2 As String = "Select * FROM Candidato;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion2))
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            dsPersonas2 = New DataSet("Candidato")
            adapter2.FillSchema(dsPersonas2, SchemaType.Source)

            adapter2.Fill(dsPersonas2, "Candidato")
        End Using
        For Each dig As DataRow In dsPersonas.Tables("Dignidad").Rows
            Dim uno As Integer = 0
            Dim dos As Integer = 250
            Dim suma As Integer = 0


            nombre = dig("nombre")

            Dim ti As New TabItem
            ti.Header = nombre
            Dim grid As New StackPanel
            Dim scroll As New ScrollViewer

            For Each dig2 As DataRow In dsPersonas2.Tables("Candidato").Rows
                If dig("Id") = dig2("dignidad") Then
                    suma = suma + dig2("votos")
                End If
            Next
            'MsgBox(suma)
            For Each dig2 As DataRow In dsPersonas2.Tables("Candidato").Rows
                If dig("Id") = dig2("dignidad") Then
                    Dim lbl As New Label
                    lbl.Content = dig2("nombre") & " " & dig2("apellido")
                    Dim btn As New Button
                    btn.DataContext = dig2
                    AddHandler btn.Click, AddressOf btn_Click
                    btn.Margin = New Thickness(0, -20, 0, 0)
                    btn.Width = 100
                    btn.Content = "Votar"
                    lbl.Margin = New Thickness(0, 0, 0, 0)
                    grid.Children.Add(lbl)
                    grid.Children.Add(btn)
                End If
            Next
            scroll.Content = grid
            ti.Content = scroll
            tbC.Items.Add(ti)
        Next
    End Sub
    Private Sub btn_Click(sender As Object, e As RoutedEventArgs)
        Me.btn_actual = sender
        ' MsgBox(btn_actual.DataContext("nombre"))
        MsgBox(btn_actual.DataContext("Dignidad"))
        Using conexion2 As New OleDbConnection(strConexion)
            Dim consulta2 As String = "Select * FROM Candidato;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion2))
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            dsCandidato2 = New DataSet("Candidato")
            adapter2.FillSchema(dsCandidato2, SchemaType.Source)

            adapter2.Fill(dsCandidato2, "Candidato")
        End Using
        '------------------------
        For Each persona As DataRow In dsCandidato2.Tables("Candidato").Rows
            Dim uno = 1
            If persona("Id") = btn_actual.DataContext("Id") Then
                persona("votos") += uno
            End If
        Next
        '------------------------
        Using conexion As New OleDbConnection(strConexion)
            Dim consultar As String = "Select * FROM Candidato;"
            Dim adapter As New OleDbDataAdapter(New OleDbCommand(consultar, conexion))
            Dim personaCmdBuilder = New OleDbCommandBuilder(adapter)
            Try
                adapter.Update(dsCandidato2.Tables("Candidato"))
            Catch ex As Exception
                MessageBox.Show("Error al guardar")
            End Try
        End Using
        '------------------------
        Dim contador = 1
        For Each tabi As TabItem In tbC.Items
            If contador = btn_actual.DataContext("Dignidad") Then
                tabi.Content.IsEnabled = False
                Exit For
            End If
            contador += 1
        Next
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

    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Owner.Owner.Show()
        Me.Close()
    End Sub
End Class
