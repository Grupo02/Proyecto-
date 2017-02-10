Imports System.Data.OleDb
Imports System.Data

Public Class LoginCandidato
    Public Const generico As Integer = 0
    Dim dbPath = "../../Proyecto_Visual.mdb"
    Dim strConexion = "Provider=Microsoft.Jet.OLEDB.4.0; " &
            "Data Source=" & dbPath
    Dim candi As Candidato
    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)


        Using dbConexion As New OleDbConnection(strConexion)

        End Using
    End Sub
    Private Sub btnIngresarCandidato_Click(sender As Object, e As RoutedEventArgs) Handles btnIngresarCandidato.Click
        My.Computer.Audio.Play(My.Resources.Click, AudioPlayMode.Background)
        Dim dbConexion As New OleDbConnection(strConexion)

        dbConexion.Open()
        Console.WriteLine("Conexion exitosa")
        Dim strQuery1 As String = "SELECT usuario, clave FROM Candidato WHERE usuario ='" & txtUserCandidato.Text & "'AND clave ='" & passCandidato.Password & "'"
        Dim dsPersonas2 As DataSet
        Dim consulta2 As String = "Select * FROM Candidato;"

        Using conexion2 As New OleDbConnection(strConexion)
            Dim adapter2 As New OleDbDataAdapter(New OleDbCommand(consulta2, conexion2))
            Dim personaCmdBuilder2 = New OleDbCommandBuilder(adapter2)
            dsPersonas2 = New DataSet("Candidato")
            adapter2.FillSchema(dsPersonas2, SchemaType.Source)
            adapter2.Fill(dsPersonas2, "Candidato")
        End Using

        Dim comandos = New OleDbCommand(strQuery1, dbConexion)
        Dim adapter As New OleDbDataAdapter
        adapter.SelectCommand = comandos
        Dim lector As OleDbDataReader
        lector = comandos.ExecuteReader
        Dim cero As Integer = 0

        If lector.HasRows = True Then
            MsgBox("Login exitoso", MsgBoxStyle.Information, "Login")
            Me.Hide()
            Me.Owner.Hide()
            For Each dig2 As DataRow In dsPersonas2.Tables("Candidato").Rows
                If dig2("usuario").ToString = txtUserCandidato.Text Then
                    candi = New Candidato(dig2("usuario"), dig2("clave"), dig2("dignidad"), dig2("nombre"), dig2("apellido"))
                End If
            Next
            Dim ventanaResultadoCandidato As New VentanaResultadoCandidato
            ventanaResultadoCandidato.Variable = Integer.Parse(candi.Dignidad)
            ventanaResultadoCandidato.Owner = Me
            ventanaResultadoCandidato.Show()
            ventanaResultadoCandidato.DataContext = candi
        Else
            MsgBox("No esta dentro de la base de datos", MsgBoxStyle.Critical, "Error")
        End If
        dbConexion.Close()
    End Sub


End Class
