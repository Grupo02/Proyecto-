Imports System.Xml
Module Module1

    Sub Main()
        Dim ruta As String = "D:\docs\Desktop\Personas.xml"
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
    Private Sub AgregarAdministrador(ruta As String, admin As Administrador)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("collection").Item(0)
        collection.AppendChild(CrearAdministrador(xmlDoc, admin))
        xmlDoc.Save(ruta)
    End Sub
    Private Sub AgregarCandidato(ruta As String, can As Candidato)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("collection").Item(0)
        collection.AppendChild(CrearCandidato(xmlDoc, can))
        xmlDoc.Save(ruta)
    End Sub
    Private Sub AgregarVotante(ruta As String, voto As Votante)
        Dim xmlDoc As New XmlDocument()
        xmlDoc.Load(ruta)
        Dim collection As XmlNode = xmlDoc.GetElementsByTagName("collection").Item(0)
        collection.AppendChild(CrearVotante(xmlDoc, voto))
        xmlDoc.Save(ruta)
    End Sub
    Sub MostrarAdministradores(ruta As String)
        Dim documento As XmlDocument = New XmlDocument
        Dim listaNodo As XmlNodeList
        Dim nodo As XmlNode
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
        Dim documento As XmlDocument = New XmlDocument
        Dim listaNodo As XmlNodeList
        Dim nodo As XmlNode
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

            Console.WriteLine("Candidato: " & admin & vbNewLine & vbTab & "Usuario " & nodo1 & vbNewLine & vbTab & "Clave " & nodo2 & vbNewLine & vbTab & "Dignidad " & nodo3 & vbNewLine & vbTab & "Nombre " & nodo4 & vbNewLine & vbTab & "Apellido " & nodo5 & vbNewLine & vbTab & "Edad " & nodo6)
        Next
    End Sub
    Sub MostrarVotantes(ruta As String)
        Dim documento As XmlDocument = New XmlDocument
        Dim listaNodo As XmlNodeList
        Dim nodo As XmlNode
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
    Dim menu
End Module
