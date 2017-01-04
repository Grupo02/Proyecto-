
Imports System.Xml
Module Module1

    Sub Main()
        Dim ruta As String = "C:\Users\JOEL COLLAHUAZO\Downloads\Persona.xml"
        Dim xml As New Persistencia(ruta)

        Dim seguirMenu As Boolean = True
        Dim opcion, opcion1, opcion2, votante As Integer
        Dim admin, contraseña, extra As String
        Dim seguir As Boolean = True
        While seguirMenu

            Do

                Console.WriteLine("-----------------------------------------------------------")
                Console.WriteLine("******** Bienvenido al sistema De Voto Electronico ********")
                Console.WriteLine("Elija una opcion :")
                Console.WriteLine("1.   Iniciar Administrador")
                Console.WriteLine("2.   Iniciar Votante")
                Console.WriteLine("3.   Iniciar Candidato")
                Console.WriteLine("4.   Salir")
                Console.WriteLine("Opcion:     ")
                opcion = validarDatosnumerico()
                Console.WriteLine("------------------------------------------------------------")
            Loop Until opcion < 5 And opcion > 0

            Select Case opcion

                Case 1
                    Dim existe

                    Dim administrador As Administrador

                    Console.Write("Digite su usuario    :")
                    admin = Console.ReadLine()
                    Console.Write("Digite su clave     :")
                    contraseña = Console.ReadLine()
                    Dim estado As Boolean = xml.VerificarAdministrador(ruta, admin, contraseña)
                    If estado = True Then
                        Console.WriteLine(".........................BIENVENIDO.........................")
                        Console.WriteLine("------------------------------------------------------------")
                        Console.WriteLine("ADMINISTRADOR")

                        Do

                            Console.WriteLine("Elja una accion que desee realizar como administrador :")
                            Console.WriteLine("1.   Agregar Dignidad")
                            Console.WriteLine("2.   Agregar votante")
                            Console.WriteLine("3.   Mostrar Dignidades")
                            Console.WriteLine("4.   Mostrar Votantes")

                            Console.Write("Opcion #:")
                            opcion1 = validarDatosnumerico()
                        Loop Until opcion1 > 0 And opcion1 < 4

                        Select Case opcion1
                            Case 1

                                Console.WriteLine("Agrega informacion de dignidad     :")
                                Console.WriteLine("Ingrese su usuario Candidato")
                                Dim user As String = Console.ReadLine
                                Console.WriteLine("Ingrese su contraseña de Candidato")
                                Dim pass As String = Console.ReadLine
                                Console.WriteLine("Ingrese el nombre de su dignidad")
                                Dim dignidad As String = Console.ReadLine
                                Console.WriteLine("Ingrese el nro de lista")
                                Dim lista As Integer = Console.ReadLine
                                Dim cand As New Candidato(AgregarDatos, user, pass, dignidad, lista)
                                xml.AgregarCandidato(ruta, cand)
                                Console.ReadLine()
                                Console.WriteLine("dignidad agregada :")


                            Case 2

                                Console.WriteLine("Agrega informacion de votante     :")
                                Dim voto As New Votante(AgregarDatos, False)
                                xml.AgregarVotante(ruta, voto)
                                Console.ReadLine()
                                Console.WriteLine("Candidato agregado :")
                            Case 3

                                Console.WriteLine("Los resultados son : ")
                                xml.MostrarCandidatos(ruta)
                                Console.ReadLine()
                            Case 4

                                Console.WriteLine("Los resultados son : ")
                                xml.MostrarVotantes(ruta)
                                Console.ReadLine()
                        End Select
                    Else
                        Console.WriteLine("Usted no es un administrador")
                    End If






                Case 2

                    Console.WriteLine(".........................BIENVENIDO.........................")
                    Console.WriteLine("------------------------------------------------------------")
                    Console.WriteLine("VOTANTE")

                    Console.Write("Digite su numero de cedula   :")
                    votante = Console.ReadLine()
                    Dim estado As Boolean = xml.VerificarVotante(ruta, votante)
                    Dim estado2 As Boolean = xml.VerificarVotoVotante(ruta, votante)
                    If estado = True Then
                        Console.WriteLine("..........Bienvenido.......... :")
                        If estado2 = True Then
                            Do
                                Console.WriteLine("Elija una opcion... :")
                                Console.WriteLine("1.   Votar")

                                Console.Write("Opcion:     ")
                                opcion2 = validarDatosnumerico()
                            Loop Until opcion2 > 0 And opcion1 < 2


                            Select Case opcion2
                                Case 1
                                    Console.WriteLine()
                                    Console.WriteLine("CANDIDATOS A LA PRESIDENCIA")
                                    xml.ListarCandidatos(ruta, 1)

                                    Console.WriteLine("Elija su candidato: ")
                                    extra = Console.ReadLine()
                                    xml.AumentarVotoCandidato(ruta, 1, extra)

                                    Console.WriteLine()
                                    Console.WriteLine("CANDIDATOS A LA ASAMBLEA")
                                    xml.ListarCandidatos(ruta, 2)

                                    Console.WriteLine("Elija su candidato: ")
                                    extra = Console.ReadLine()
                                    xml.AumentarVotoCandidato(ruta, 2, extra)

                                    Console.WriteLine()
                                    Console.WriteLine("CANDIDATOS AL CONSEJO")
                                    xml.ListarCandidatos(ruta, 3)

                                    Console.WriteLine("Elija su candidato: ")
                                    extra = Console.ReadLine()
                                    xml.AumentarVotoCandidato(ruta, 3, extra)

                                    Console.WriteLine("Usted ha votado")
                                    xml.Votar(ruta, votante)

                            End Select
                        ElseIf estado2 = False Then
                            Console.WriteLine("Usted ya voto")
                        End If

                    Else
                        Console.WriteLine("No existe ese votante")
                    End If



                Case 3

                    Console.Write("Digite su usuario    :")
                    admin = Console.ReadLine()
                    Console.Write("Digite su clave     :")
                    contraseña = Console.ReadLine()
                    Dim estado As Boolean = xml.VerificarCandidato(ruta, admin, contraseña)
                    If estado = True Then
                        Console.WriteLine(".........................BIENVENIDO.........................")
                        Console.WriteLine("------------------------------------------------------------")
                        Console.WriteLine("CANDIDATO")

                        Do

                            Console.WriteLine("Elja una accion que desee realizar como candidato :")
                            Console.WriteLine("1.   Mostrar resultados")
                            Console.WriteLine("2.   Salir")

                            Console.Write("Opcion #:")
                            opcion1 = validarDatosnumerico()
                        Loop Until opcion1 > 0 And opcion1 < 3

                        Select Case opcion1
                            Case 1
                                Console.WriteLine("Los resultados son : ")
                                xml.MostrarAvancesCandidato(ruta, admin, contraseña)
                                Console.ReadLine()

                            Case 2
                                Console.WriteLine("Adios")
                                Console.ReadLine()
                                End
                        End Select
                    Else
                        Console.WriteLine("Usted no es un candidato")
                    End If


                Case 4
                    Console.WriteLine("Gracias por ingresar")
                    Console.WriteLine("Adios")
                    Console.ReadLine()
                    End

            End Select

            Dim seguirOp As Integer
            Do
                Console.WriteLine("1.- Salir")
                seguirOp = validarDatosnumerico()
            Loop Until seguirOp > 0 And seguirOp < 2
            If seguirOp <> 1 Then
                seguirMenu = True
            Else
                seguirMenu = False
                Console.WriteLine("Gracias por ingresar")
            End If
        End While

        Console.ReadLine()

    End Sub

    Public Function validarDatosnumerico() As Integer
        Dim numero As Integer = 0
        Dim aux As Object = 0
        Dim bol As Boolean = True
        Do While True
            aux = Console.ReadLine()
            bol = IsNumeric(aux)
            If bol Then
                numero = aux
                Return numero
            Else
                Console.WriteLine("-----Error Vuelva a Ingresar-----")
            End If
        Loop
        numero = aux
        Return numero
    End Function
    Function AgregarDatos()
        Console.WriteLine("Ingrese la cedula")
        Dim id As Integer = Console.ReadLine

        Console.WriteLine("Ingrese su nombre")
        Dim nombre As String = Console.ReadLine

        Console.WriteLine("Ingrese su apellido")
        Dim apellido As String = Console.ReadLine

        Console.WriteLine("Ingrese su edad")
        Dim edad As Integer = Console.ReadLine
        Dim personita As New Persona(id, nombre, apellido, edad)
        Return personita
    End Function
End Module