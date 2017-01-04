Imports System.Xml

Public Class Persistencia
    Private _ruta As String
    Dim documento As XmlDocument = New XmlDocument
    Dim listaNodo As XmlNodeList
    Dim nodo As XmlNode
    Public Property Ruta() As String
        Get
            Return _ruta
        End Get
        Set(ByVal value As String)
            _ruta = value
        End Set
    End Property
    Public Sub New(r As String)
        Me.Ruta = r
    End Sub
    Function CrearAdministrador(xmlDoc As XmlDocument, ad As Administrador)
        Dim admin As XmlElement = xmlDoc.CreateElement("Administrador")
        admin.SetAttribute("ID", ad.Id)

        Dim user As XmlElement = xmlDoc.CreateElement("Usuario")
        user.InnerText = ad.UsuarioAdministrador
        admin.AppendChild(user)

        Dim clave As XmlElement = xmlDoc.CreateElement("Clave")
        clave.InnerText = ad.ClaveAdministrador
        admin.AppendChild(clave)

        Dim nombre As XmlElement = xmlDoc.CreateElement("Nombre")
        nombre.InnerText = ad.Nombre
        admin.AppendChild(nombre)

        Dim apellido As XmlElement = xmlDoc.CreateElement("Apellido")
        apellido.InnerText = ad.Apellido
        admin.AppendChild(apellido)

        Dim edad As XmlElement = xmlDoc.CreateElement("Edad")
        edad.InnerText = ad.Edad
        admin.AppendChild(edad)


        Return admin
    End Function
    Function CrearCandidato(xmlDoc As XmlDocument, cand As Candidato)


        Dim candidato As XmlElement = xmlDoc.CreateElement("Candidato")
        candidato.SetAttribute("ID", cand.Id)

        Dim user As XmlElement = xmlDoc.CreateElement("Usuario")
        user.InnerText = cand.UsuarioCandidato
        candidato.AppendChild(user)

        Dim clave As XmlElement = xmlDoc.CreateElement("Clave")
        clave.InnerText = cand.ClaveCandidato
        candidato.AppendChild(clave)

        Dim dignidad As XmlElement = xmlDoc.CreateElement("Dignidad")
        dignidad.InnerText = cand.Dignidad
        candidato.AppendChild(dignidad)

        Dim nombre As XmlElement = xmlDoc.CreateElement("Nombre")
        nombre.InnerText = cand.Nombre
        candidato.AppendChild(nombre)

        Dim apellido As XmlElement = xmlDoc.CreateElement("Apellido")
        apellido.InnerText = cand.Apellido
        candidato.AppendChild(apellido)

        Dim edad As XmlElement = xmlDoc.CreateElement("Edad")
        edad.InnerText = cand.Edad
        candidato.AppendChild(edad)

        Dim lista As XmlElement = xmlDoc.CreateElement("Lista")
        lista.InnerText = cand.Lista
        candidato.AppendChild(lista)

        Dim votos As XmlElement = xmlDoc.CreateElement("Votos")
        votos.InnerText = cand.Votos
        candidato.AppendChild(votos)

        Return candidato
    End Function
    Function CrearVotante(xmlDoc As XmlDocument, voto As Votante)


        Dim votante As XmlElement = xmlDoc.CreateElement("Votante")
        votante.SetAttribute("ID", voto.Id)

        Dim nombre As XmlElement = xmlDoc.CreateElement("Nombre")
        nombre.InnerText = voto.Nombre
        votante.AppendChild(nombre)

        Dim apellido As XmlElement = xmlDoc.CreateElement("Apellido")
        apellido.InnerText = voto.Apellido
        votante.AppendChild(apellido)

        Dim edad As XmlElement = xmlDoc.CreateElement("Edad")
        edad.InnerText = voto.Edad
        votante.AppendChild(edad)

        Dim estado As XmlElement = xmlDoc.CreateElement("Estado")
        estado.InnerText = voto.Estado
        votante.AppendChild(estado)

        Return votante
    End Function

    Public Sub AgregarAdministrador(ruta As String, admin As Administrador)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("collection").Item(0)
        collection.AppendChild(CrearAdministrador(xmlDoc, admin))
        xmlDoc.Save(ruta)
    End Sub
    Public Sub AgregarCandidato(ruta As String, can As Candidato)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("collection").Item(0)
        collection.AppendChild(CrearCandidato(xmlDoc, can))
        xmlDoc.Save(ruta)
    End Sub
    Public Sub AgregarVotante(ruta As String, voto As Votante)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("collection").Item(0)
        collection.AppendChild(CrearVotante(xmlDoc, voto))
        xmlDoc.Save(ruta)
    End Sub

    Function VerificarAdministrador(ruta As String, user As String, pass As String)
        Dim estado = False
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Administrador")
        For Each nodo In listaNodo
            If user = nodo.ChildNodes.Item(0).InnerText And pass = nodo.ChildNodes.Item(1).InnerText Then
                estado = True
            End If
        Next
        Return estado
    End Function

    Function VerificarCandidato(ruta As String, user As String, pass As String)
        Dim estado = False
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Candidato")
        For Each nodo In listaNodo
            If user = nodo.ChildNodes.Item(0).InnerText And pass = nodo.ChildNodes.Item(1).InnerText Then
                estado = True
            End If
        Next
        Return estado
    End Function

    Function VerificarVotante(ruta As String, cedula As Integer)
        Dim estado = False
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Votante")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value

            If cedula = admin Then
                estado = True

            End If
        Next
        Return estado
    End Function

    Sub MostrarAdministradores(ruta As String)
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Administrador")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            Dim nodo1 = nodo.ChildNodes(0).InnerText
            Dim nodo2 = nodo.ChildNodes(1).InnerText
            Dim nodo3 = nodo.ChildNodes(2).InnerText
            Dim nodo4 = nodo.ChildNodes(3).InnerText
            Dim nodo5 = nodo.ChildNodes(4).InnerText

            Console.WriteLine("Administrador: " & admin & vbNewLine & vbTab & "Usuario " & nodo1 & vbNewLine & vbTab & "Clave " & nodo2 & vbNewLine & vbTab & "Nombre " & nodo3 & vbNewLine & vbTab & "Apellido " & nodo4 & vbNewLine & vbTab & "Edad " & nodo5)
        Next
    End Sub
    Sub MostrarCandidatos(ruta As String)
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Candidato")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            Dim nodo1 = nodo.ChildNodes(0).InnerText
            Dim nodo2 = nodo.ChildNodes(1).InnerText
            Dim nodo3 = nodo.ChildNodes(2).InnerText
            Dim nodo4 = nodo.ChildNodes(3).InnerText
            Dim nodo5 = nodo.ChildNodes(4).InnerText
            Dim nodo6 = nodo.ChildNodes(5).InnerText
            Dim nodo7 = nodo.ChildNodes(6).InnerText
            Dim nodo8 = nodo.ChildNodes(7).InnerText

            Console.WriteLine("Candidato: " & admin & vbNewLine & vbTab & "Usuario " & nodo1 & vbNewLine & vbTab & "Clave " & nodo2 & vbNewLine & vbTab & "Dignidad " & nodo3 & vbNewLine & vbTab & "Nombre " & nodo4 & vbNewLine & vbTab & "Apellido " & nodo5 & vbNewLine & vbTab & "Edad " & nodo6 & vbNewLine & vbTab & "Lista " & nodo7 & vbNewLine & vbTab & "Votos " & nodo8)
        Next
    End Sub
    Sub MostrarVotantes(ruta As String)
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Votante")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            Dim nodo1 = nodo.ChildNodes(0).InnerText
            Dim nodo2 = nodo.ChildNodes(1).InnerText
            Dim nodo3 = nodo.ChildNodes(2).InnerText
            Dim nodo4 = nodo.ChildNodes(3).InnerText

            Console.WriteLine("Votante: " & admin & vbNewLine & vbTab & "Nombre " & nodo1 & vbNewLine & vbTab & "Apellido " & nodo2 & vbNewLine & vbTab & "Edad " & nodo3 & vbNewLine & vbTab & "Estado " & nodo4)
        Next
    End Sub

    Sub ListarCandidatos(ruta As String, tipo As Integer)
        Dim nome
        Dim ape
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Candidato")
        For Each nodo In listaNodo
            If tipo = 1 Then
                If nodo.ChildNodes.Item(2).InnerText = "Presidente" Then
                    nome = nodo.ChildNodes(3).InnerText
                    ape = nodo.ChildNodes(4).InnerText
                    Console.WriteLine(nodo.ChildNodes(6).InnerText & ": " & nome & " " & ape)
                End If
            ElseIf tipo = 2 Then
                If nodo.ChildNodes.Item(2).InnerText = "Asambleista" Then
                    nome = nodo.ChildNodes(3).InnerText
                    ape = nodo.ChildNodes(4).InnerText
                    Console.WriteLine(nodo.ChildNodes(6).InnerText & ": " & nome & " " & ape)
                End If
            Else
                If nodo.ChildNodes.Item(2).InnerText = "Consejal" Then
                    nome = nodo.ChildNodes(3).InnerText
                    ape = nodo.ChildNodes(4).InnerText
                    Console.WriteLine(nodo.ChildNodes(6).InnerText & ": " & nome & " " & ape)
                End If
            End If
        Next
    End Sub

    Sub BuscarVotante(ruta As String, id As Integer)
        Console.Clear()
        Dim numero = 0
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Votante")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            If id = admin Then
                Dim nodo1 = nodo.ChildNodes(0).InnerText
                Dim nodo2 = nodo.ChildNodes(1).InnerText
                Dim nodo3 = nodo.ChildNodes(2).InnerText
                Dim nodo4 = nodo.ChildNodes(3).InnerText
                Console.WriteLine("Votante: " & admin & vbNewLine & vbTab & "Nombre " & nodo1 & vbNewLine & vbTab & "Apellido " & nodo2 & vbNewLine & vbTab & "Edad " & nodo3 & vbNewLine & vbTab & "Estado " & nodo4)
                numero += 1
            End If
        Next
        If numero = 0 Then
            Console.WriteLine("No existe esa persona")
            Console.ReadLine()
        End If
    End Sub
    Sub Votar(ruta As String, id As Integer)
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Votante")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            If id = admin Then
                nodo.ChildNodes.Item(3).InnerText = "True"
                Console.WriteLine("Voto enviado")
                documento.Save(ruta)
            End If
        Next
    End Sub

    Sub AumentarVotoCandidato(ruta As String, tipo As Integer, lista As Integer)
        Dim numero
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Candidato")

        For Each nodo In listaNodo
            If tipo = 1 Then
                Console.WriteLine("Inicio")
                If nodo.ChildNodes.Item(2).InnerText = "Presidente" And nodo.ChildNodes.Item(6).InnerText = CStr(lista) Then
                    numero = CInt(nodo.ChildNodes.Item(7).InnerText)
                    numero = numero + 1
                    nodo.ChildNodes.Item(7).InnerText = CStr(numero)
                    Console.WriteLine("Fin" & numero)
                End If
            ElseIf tipo = 2 Then
                If nodo.ChildNodes.Item(2).InnerText = "Asambleista" And nodo.ChildNodes.Item(6).InnerText = CStr(lista) Then
                    numero = CInt(nodo.ChildNodes.Item(7).InnerText)
                    numero += 1
                    nodo.ChildNodes.Item(7).InnerText = CStr(numero)
                End If
            Else
                If nodo.ChildNodes.Item(2).InnerText = "Consejal" And nodo.ChildNodes.Item(6).InnerText = CStr(lista) Then
                    numero = CInt(nodo.ChildNodes.Item(7).InnerText)
                    numero += 1
                    nodo.ChildNodes.Item(7).InnerText = CStr(numero)
                End If
            End If
        Next
        documento.Save(ruta)
    End Sub


    Sub EliminarVotante(ruta As String, id As Integer)
        Dim num = 0
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Votante")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            If id = admin Then
                nodo.ParentNode.RemoveChild(nodo)
                documento.Save(ruta)
                num += 1
                Console.WriteLine("Votante Eliminado")
                Console.ReadLine()
            End If
        Next
        If num = 0 Then
            Console.WriteLine("No existe ese votante")
            Console.ReadLine()
        End If
    End Sub
    Sub EliminarCandidato(ruta As String, id As Integer)
        Dim num = 0
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Candidato")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value
            If id = admin Then
                nodo.ParentNode.RemoveChild(nodo)
                documento.Save(ruta)
                num += 1
                Console.WriteLine("Candidato Eliminado")
                Console.ReadLine()
            End If
        Next
        If num = 0 Then
            Console.WriteLine("No existe ese votante")
            Console.ReadLine()
        End If
    End Sub

    Sub MostrarAvancesCandidato(ruta As String, user As String, pass As String)
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Candidato")
        For Each nodo In listaNodo
            If user = nodo.ChildNodes.Item(0).InnerText And pass = nodo.ChildNodes.Item(1).InnerText Then
                Console.WriteLine("Saludos " & nodo.ChildNodes.Item(3).InnerText & " actualmente cuentas con " & nodo.ChildNodes.Item(7).InnerText & " votos")
            End If
        Next
    End Sub
    Function VerificarVotoVotante(ruta As String, cedula As Integer)
        Dim estado = False
        documento.Load(ruta)
        listaNodo = documento.SelectNodes("collection/Votante")
        For Each nodo In listaNodo
            Dim admin = nodo.Attributes.GetNamedItem("ID").Value

            If cedula = admin Then
                If nodo.ChildNodes.Item(3).InnerText = "False" Then
                    estado = True
                End If
            End If
        Next
        Return estado
    End Function
End Class

