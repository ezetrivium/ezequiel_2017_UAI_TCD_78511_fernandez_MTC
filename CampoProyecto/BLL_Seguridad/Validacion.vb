Imports System.Text.RegularExpressions
Imports BE
Imports BLL
Public Class Validacion

    Shared Function validarnombre(p0 As String) As Boolean

        Dim b As Boolean
        b = False
        Dim reg As New Regex("([a-zA-Z]{1,20})")
        If reg.IsMatch(p0) Then
            b = True
            Dim Lista As New List(Of Usuario)
            Lista = MapperUsuario.TraerUsuarios()
            For Each u As Usuario In Lista
                If u.Nombre = p0 Then
                    b = False
                    Exit For
                End If

            Next

        Else
            b = False

        End If

        Return b

    End Function

    Shared Function ValidarContraseña(p0 As Usuario) As Boolean
        Dim lista As New List(Of Usuario)
        lista = MapperUsuario.TraerUsuarios
        Dim b As Boolean = False
        Dim usu As Usuario = p0

        For i = 0 To lista.Count - 1
            If lista.Item(i).Nombre = usu.Nombre And lista.Item(i).Contraseña = usu.Contraseña Then
                b = True
                usu.ID = lista.Item(i).ID
                Dim fam As New Familia
                fam.ID = lista.Item(i).familia.ID
                Exit For
            End If
        Next
        Return b

    End Function

End Class
