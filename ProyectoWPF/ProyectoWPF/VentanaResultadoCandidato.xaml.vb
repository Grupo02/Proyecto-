Imports System.Data
Imports System.Data.OleDb
Imports ProyectoWPF.LoginCandidato


Public Class VentanaResultadoCandidato
    Private _variable As Integer
    Public Property Variable() As Integer
        Get
            Return _variable
        End Get
        Set(ByVal value As Integer)
            _variable = value
        End Set
    End Property

    Private Sub Window_Closed(sender As Object, e As EventArgs)
        Me.Owner.Owner.Close()
    End Sub
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        Dim dbPath = "../../Proyecto_Visual.mdb"
        Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
        Dim dsPersonas2 As DataSet

        Using conexion2 As New OleDbConnection(strConexion)

            Dim consulta2 As String = "Select * FROM Candidato;"
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion2))
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            dsPersonas2 = New DataSet("Candidato")
            adapter2.FillSchema(dsPersonas2, SchemaType.Source)

            adapter2.Fill(dsPersonas2, "Candidato")
        End Using
        Dim suma As Integer = 0
        Dim index = Variable
        For Each dig2 As DataRow In dsPersonas2.Tables("Candidato").Rows
            If index = dig2("dignidad") Then
                suma = suma + dig2("votos")
            End If
        Next
        Dim gridi As New StackPanel
        For Each dig2 As DataRow In dsPersonas2.Tables("Candidato").Rows
            If index = dig2("dignidad") Then
                Dim porcentaje As Integer = CInt((dig2("votos") + 1) * 100 / suma)
                Dim lbl As New Label
                lbl.Content = dig2("nombre") & " " & dig2("apellido") & " : " & dig2("votos") & "%"
                lbl.Margin = New Thickness(0, 20, 0, 0)
                gridi.Children.Add(lbl)
                Dim barra As New ProgressBar
                barra.Height = 30
                barra.Width = 150
                barra.Value = porcentaje
                barra.Margin = New Thickness(150, -20, 0, 0)
                gridi.Children.Add(barra)
            End If
        Next
        bar.Content = gridi
    End Sub

    Private Sub btnCerrarSesionCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btnCerrarSesionCandidato.Click
        Me.Owner.Close()
        Me.Owner.Owner.Show()
    End Sub
End Class
