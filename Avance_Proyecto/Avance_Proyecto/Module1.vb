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
                Console.WriteLine("1.   Inicie sesion como Votante")
                Console.WriteLine("2.   Inicie sesion como Administrador")
                Console.WriteLine("3.   Inicie sesion como Candidato")
                Console.WriteLine("4.   Salir")
                Console.WriteLine("Opcion:     ")
                opcion = validarDatosnumerico()
                Console.WriteLine("------------------------------------------------------------")
            Loop Until opcion < 5 And opcion > 0

            Select Case opcion
                Case 1
                    Console.WriteLine(".........................BIENVENIDO........................")
                    Console.WriteLine("-----------------------------------------------------------")
                    Console.WriteLine("VOTANTE")

                    Console.Write("Digite su numero de cedula   :")
                    votante = Console.ReadLine()

                    Console.WriteLine("..........Bienvenido.......... :")

                    Console.Clear()
                    Do
                        Console.WriteLine("Elija una opcion... :")
                        Console.WriteLine("1.   Voto - Presidencia")
                        Console.WriteLine("2.   Voto - Asambleista")
                        Console.Write("Opcion:     ")
                        opcion2 = validarDatosnumerico()
                    Loop Until opcion2 > 0 And opcion1 < 2


                    Select Case opcion2
                        Case 1
                            Console.WriteLine("CANDIDATOS A LA PRESIDENCIA")
                            Console.WriteLine("Elija su candidato: ")


                    End Select
                Case 2


                    Console.Write("Digite su usuario    :")
                    admin = Console.ReadLine()
                    Console.Write("Digite su clave     :")
                    contraseña = Console.ReadLine()


                    Console.WriteLine(".........................BIENVENIDO........................")
                    Console.WriteLine("-----------------------------------------------------------")
                    Console.WriteLine("ADMINISTRADOR")

                    Do

                        Console.WriteLine("Elja una accion que desee realizar como administrador :")
                        Console.WriteLine("1.   Agregar Candidatos")
                        Console.WriteLine("2.   Eliminar Candidatos")
                        Console.WriteLine("3.   Listar Candidatos")
                        Console.WriteLine("4.   Mostrar resultados ")
                        Console.Write("Opcion #:")
                        opcion1 = validarDatosnumerico()
                    Loop Until opcion1 > 0 And opcion1 < 5

                    Select Case opcion1
                        Case 1

                            Console.WriteLine("Agrega informacion de candidato     :")
                            Console.ReadLine()
                            Console.WriteLine("Candidato agregado :")

                        Case 2

                            Console.WriteLine("¿Que candidato desea eliminar?")
                            Console.ReadLine()
                        Case 3

                            Console.WriteLine("Listar de candidatos")
                            Console.ReadLine()
                        Case 4

                            Console.WriteLine("Los resultados son : ")
                            Console.ReadLine()
                    End Select

                Case 3

                    Console.Write("Digite su usuario    :")
                    admin = Console.ReadLine()
                    Console.Write("Digite su clave     :")
                    contraseña = Console.ReadLine()


                    Console.WriteLine(".........................BIENVENIDO........................")
                    Console.WriteLine("-----------------------------------------------------------")
                    Console.WriteLine("USUARIO")
                    Do

                        Console.WriteLine("Elja una accion que desee realizar como candidato :")
                        Console.WriteLine("1.   Mostrar Resultados")
                        Console.Write("Opcion #:")
                        opcion1 = validarDatosnumerico()
                    Loop Until opcion1 > 0 And opcion1 < 2

                    Select Case opcion1
                        Case 1

                            Console.WriteLine("Mostrando Resultados... ")
                            Console.ReadLine()

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
            Loop Until seguirOp > 0 And seguirOp < 3
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
