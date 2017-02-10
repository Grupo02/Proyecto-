Imports System.Data
Imports System.Data.OleDb

Public Class VentanaResultados
    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Hide()
        Me.Owner.Show()
    End Sub

    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "../../Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
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
                    Dim porcentaje As Integer = CInt((dig2("votos") + 1) * 100 / suma)
                    'MsgBox((dig2("votos") + 1) * 100 / suma)
                    Dim lbl As New Label
                    lbl.Content = dig2("nombre") & " " & dig2("apellido") & " : " & porcentaje & "%"
                    lbl.Margin = New Thickness(0, 20, 0, 0)
                    grid.Children.Add(lbl)
                    Dim barra As New ProgressBar
                    barra.Height = 30
                    barra.Width = 150
                    barra.Value = porcentaje
                    barra.Margin = New Thickness(150, -20, 0, 0)
                    grid.Children.Add(barra)
                End If
            Next
            scroll.Content = grid
            ti.Content = scroll
            tbC.Items.Add(ti)
        Next
    End Sub
End Class
