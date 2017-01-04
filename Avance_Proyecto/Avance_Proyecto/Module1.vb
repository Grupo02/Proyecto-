Imports System.Xml
Module Module1

    Sub Main()
        Dim ruta As String = ".\xml\Personas.xml"
        Dim xml As New Persistencia(ruta)

        Dim seguirMenu As Boolean = True
        Dim opcion, opcion1, opcion2 As Integer
        Dim votante, admin, contraseña As String
        Dim seguir As Boolean = True
        While seguirMenu

            Do
                Console.Clear()
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
                    Console.Clear()
                    Console.Write("Digite su usuario    :")
                    admin = Console.ReadLine()
                    Console.Write("Digite su clave     :")
                    contraseña = Console.ReadLine()


                    Console.WriteLine(".........................BIENVENIDO.........................")
                    Console.WriteLine("------------------------------------------------------------")
                    Console.WriteLine("ADMINISTRADOR")

                    Do

                        Console.WriteLine("Elja una accion que desee realizar como administrador :")
                        Console.WriteLine("1.   Agregar Dignidad")
                        Console.WriteLine("2.   Agregar Candidato")
                        Console.WriteLine("3.   Mostrar resultados")

                        Console.Write("Opcion #:")
                        opcion1 = validarDatosnumerico()
                    Loop Until opcion1 > 0 And opcion1 < 4

                    Select Case opcion1
                        Case 1
                            Console.Clear()
                            Console.WriteLine("Agrega informacion de dignidad     :")
                            Console.ReadLine()
                            Console.WriteLine("dignidad agregada :")


                        Case 2
                            Console.Clear()
                            Console.WriteLine("Agrega informacion de candidato     :")
                            Console.ReadLine()
                            Console.WriteLine("Candidato agregado :")
                        Case 3
                            Console.Clear()
                            Console.WriteLine("Los resultados son : ")
                            Console.ReadLine()
                    End Select


                Case 2
                    Console.Clear()
                    Console.WriteLine(".........................BIENVENIDO.........................")
                    Console.WriteLine("------------------------------------------------------------")
                    Console.WriteLine("VOTANTE")

                    Console.Write("Digite su numero de cedula   :")
                    votante = Console.ReadLine()


                    Console.WriteLine("..........Bienvenido.......... :")

                    Console.Clear()
                    Do
                        Console.WriteLine("Elija una opcion... :")
                        Console.WriteLine("1.   Voto - Presidencia")

                        Console.Write("Opcion:     ")
                        opcion2 = validarDatosnumerico()
                    Loop Until opcion2 > 0 And opcion1 < 2


                    Select Case opcion2
                        Case 1
                            Console.Clear()
                            Console.WriteLine("CANDIDATOS A LA PRESIDENCIA")
                            Console.WriteLine("Elija su candidato: ")


                    End Select

                Case 3
                    Console.Clear()
                    Console.Write("Digite su usuario    :")
                    admin = Console.ReadLine()
                    Console.Write("Digite su clave     :")
                    contraseña = Console.ReadLine()


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
                            Console.ReadLine()

                        Case 2
                            Console.WriteLine("Adios")
                            Console.ReadLine()
                            End
                    End Select

                Case 4
                    Console.WriteLine("Gracias por ingresar")
                    Console.WriteLine("Adios")
                    Console.ReadLine()
                    End

            End Select

            Dim seguirOp As Integer
            Do
                Console.WriteLine("1.- Salir")
                Console.WriteLine("2.- Regresar a menu principal")
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

End Module
