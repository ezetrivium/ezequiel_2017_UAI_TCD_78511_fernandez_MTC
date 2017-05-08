Imports BLL
Imports DAL
Public Class MapperPatente


    Shared Sub alta(p0 As Object)

        If TypeOf p0 Is Patente Then

            Dim pat As Patente = p0
            Dim DTpat As DataTable = BajoNivel.obtenerdatos("Select * from Patente")
            Dim DRpat As DataRow = DTpat.NewRow
            If DTpat.Rows.Count > 0 Then
                pat.ID = DTpat.Rows(DTpat.Rows.Count - 1).Item(0) + 1
            Else
                pat.ID = 1
            End If
            DRpat.ItemArray = {pat.ID, pat.Nombre, pat.form, pat.IDpadre}
            DTpat.Rows.Add(DRpat)
            BajoNivel.ActualizaBase(DTpat, "Select * from Patente")

        ElseIf TypeOf p0 Is GrupoPatente Then
            Dim gpat As GrupoPatente = p0
            Dim DTgpat As DataTable = BajoNivel.obtenerdatos("Select * from GrupoPatente")
            Dim DRgpat As DataRow = DTgpat.NewRow
            If DTgpat.Rows.Count > 0 Then
                gpat.ID = DTgpat.Rows(DTgpat.Rows.Count - 1).Item(0) + 1
            Else
                gpat.ID = 1
            End If
            DRgpat.ItemArray = {gpat.ID, gpat.Nombre, gpat.IDpadre}
            DTgpat.Rows.Add(DRgpat)
            BajoNivel.ActualizaBase(DTgpat, "Select * from GrupoPatente")


        End If




    End Sub


    Shared Sub Borrar(p0 As Object)

        Try
            If TypeOf p0 Is Patente Then
                Dim pat As Patente = p0
                Dim DTpat As DataTable = BajoNivel.obtenerdatos("Select * from Patente")
                For i = 0 To DTpat.Rows.Count - 1
                    If DTpat.Rows(i).Item(0) = pat.ID Then
                        DTpat.Rows(i).Delete()
                    End If
                Next
                BajoNivel.ActualizaBase(DTpat, "Select * from Patente")
            ElseIf TypeOf p0 Is GrupoPatente Then
                Dim gpat As GrupoPatente = p0
                Dim DTpat As DataTable = BajoNivel.obtenerdatos("Select * from Patente")
                Dim DTgpat As DataTable = BajoNivel.obtenerdatos("Select * from GrupoPatente")
                For i = 0 To DTgpat.Rows.Count - 1
                    If DTgpat.Rows(i).Item(0) = gpat.ID Then
                        DTpat.Rows(i).Delete()
                    End If
                Next
                For i = 0 To DTpat.Rows.Count - 1
                    If DTpat.Rows(i).Item(3) = gpat.ID Then
                        DTpat.Rows(i).Delete()
                    End If
                Next
                BajoNivel.ActualizaBase(DTpat, "Select * from Patente")
                BajoNivel.ActualizaBase(DTgpat, "Select * from GrupoPatente")
            End If




        Catch ex As Exception

        End Try



    End Sub


    Public Function traerpatentes() As DataTable
        Dim dt As New DataTable
        dt = BajoNivel.obtenerdatos("Select * from Patente")
        Return dt

    End Function

    Public Function traergrupopatentes() As DataTable
        Dim dt As New DataTable
        dt = BajoNivel.obtenerdatos("Select * from GrupoPatente")
        Return dt

    End Function


    Shared Function CargarArbol() As List(Of GrupoPatente)
        Dim MP As New MapperPatente
        Dim DTpat As New DataTable
        Dim DTgpat As New DataTable
        Dim listagp As New List(Of GrupoPatente)
        DTpat = MP.traerpatentes
        DTgpat = MP.traergrupopatentes
        For i = 0 To DTgpat.Rows.Count - 1
            Dim GP As New GrupoPatente
            GP.ID = DTgpat.Rows(i).Item(0)
            GP.Nombre = DTgpat.Rows(i).Item(1)
            GP.IDpadre = DTgpat.Rows(i).Item(2)
            listagp.Add(GP)
            For Each grp As GrupoPatente In listagp
                If grp.ID = GP.IDpadre Then
                    grp.listapatentes.Add(GP)
                End If
            Next
        Next
        For i = 0 To DTpat.Rows.Count - 1
            Dim Pat As New Patente
            Pat.ID = DTpat.Rows(i).Item(0)
            Pat.Nombre = DTpat.Rows(i).Item(1)
            Pat.form = DTpat.Rows(i).Item(2)
            Pat.IDpadre = DTpat.Rows(i).Item(3)
            For Each p As GrupoPatente In listagp
                If p.ID = Pat.IDpadre Then
                    p.listapatentes.Add(Pat)
                End If
            Next

        Next

        Return listagp
    End Function
End Class
