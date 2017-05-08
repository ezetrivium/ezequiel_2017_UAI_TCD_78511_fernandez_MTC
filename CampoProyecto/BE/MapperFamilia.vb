Imports DAL
Imports BLL

Public Class MapperFamilia
    Public Shared Sub alta(p0 As Familia)

        Dim fam As Familia

        fam = p0
        Dim DTfam As DataTable = BajoNivel.obtenerdatos("Select * from Familia")
        Dim DRfam As DataRow = DTfam.NewRow
        If DTfam.Rows.Count > 0 Then
            fam.ID = DTfam.Rows(DTfam.Rows.Count - 1).Item(0) + 1
        Else
            fam.ID = 1

        End If
        DRfam.ItemArray = {fam.ID, fam.nombre}
        DTfam.Rows.Add(DRfam)
        BajoNivel.ActualizaBase(DTfam, "Select * from Familia")



    End Sub


    Public Shared Sub borrar(p0 As Familia)

        Dim fam As Familia
        If TypeOf p0 Is Familia Then
            fam = p0
            Dim DTfam As DataTable = BajoNivel.obtenerdatos("Select * from Familia")
            Dim DTfampat As DataTable = BajoNivel.obtenerdatos("Select * from FamiliaPatente")
            Dim DTfamgrppat As DataTable = BajoNivel.obtenerdatos("Select * from FamiliaGrupoPatente")
            For i = 0 To DTfam.Rows.Count - 1
                If DTfam.Rows(i).Item(0) = fam.ID Then
                    DTfam.Rows(i).Delete()
                End If
            Next
            For i = 0 To DTfampat.Rows.Count - 1
                If DTfampat.Rows(i).Item(1) = fam.ID Then
                    DTfampat.Rows(i).Delete()
                End If
            Next
            For i = 0 To DTfamgrppat.Rows.Count - 1
                If DTfamgrppat.Rows(i).Item(1) = fam.ID Then
                    DTfamgrppat.Rows(i).Delete()
                End If
            Next

            BajoNivel.ActualizaBase(DTfam, "Select * from Familia")
            BajoNivel.ActualizaBase(DTfampat, "Select * from FamiliaPatente")
            BajoNivel.ActualizaBase(DTfamgrppat, "Select * from FamiliaGrupoPatente")

        End If






    End Sub



    Shared Function CargarFamilias() As List(Of Familia)
        Dim listafam As New List(Of Familia)
        listafam.Clear()
        Dim DTfam As New DataTable
        DTfam = BajoNivel.obtenerdatos("Select * from Familia")
        Dim DTgpat As DataTable = BajoNivel.obtenerdatos("Select * from GrupoPatente")
        Dim DTpat As DataTable = BajoNivel.obtenerdatos("Select * from Patente")
        Dim DTfamgpat As DataTable = BajoNivel.obtenerdatos("Select * from FamiliaGrupoPatente")
        Dim DTfampat As DataTable = BajoNivel.obtenerdatos("Select * from FamiliaPatente")

        For i = 0 To DTfam.Rows.Count - 1
            Dim fam As New Familia
            fam.ID = DTfam.Rows(i).Item(0) : fam.nombre = DTfam.Rows(i).Item(1)
            For h = 0 To DTfamgpat.Rows.Count - 1
                If fam.ID = DTfamgpat.Rows(h).Item(1) Then
                    For j = 0 To DTgpat.Rows.Count - 1
                        If DTfamgpat.Rows(h).Item(2) = DTgpat.Rows(j).Item(0) Then
                            Dim gp As New GrupoPatente
                            gp.ID = DTgpat.Rows(j).Item(0)
                            gp.Nombre = DTgpat.Rows(j).Item(1)
                            gp.IDpadre = DTgpat.Rows(j).Item(2)
                            fam.Listapatentes.Add(gp)
                        End If
                    Next
                End If
            Next
            For h = 0 To DTfampat.Rows.Count - 1
                If fam.ID = DTfampat.Rows(h).Item(1) Then
                    For j = 0 To DTpat.Rows.Count - 1
                        If DTfampat.Rows(h).Item(2) = DTpat.Rows(j).Item(0) Then
                            Dim pat As New Patente
                            pat.ID = DTpat.Rows(j).Item(0)
                            pat.Nombre = DTpat.Rows(j).Item(1)
                            pat.form = DTpat.Rows(j).Item(2)
                            pat.IDpadre = DTpat.Rows(j).Item(3)
                            fam.Listapatentes.Add(pat)
                        End If
                    Next
                End If
            Next

            listafam.Add(fam)
        Next

        Return listafam

    End Function




    Shared Function traerfamiliapatente() As DataTable
        Dim dt As New DataTable
        dt = BajoNivel.obtenerdatos("Select * from FamiliaPatente")
        Return dt

    End Function

    Shared Function traerfamiliagrupopatente() As DataTable
        Dim dt As New DataTable
        dt = BajoNivel.obtenerdatos("Select * from FamiliaGrupoPatente")
        Return dt

    End Function


    Shared Sub Altafamiliapatente(p0 As DataTable)
        BajoNivel.ActualizaBase(p0, "Select * from FamiliaPatente")
    End Sub

    Shared Sub Altafamiliagrupopatente(p0 As DataTable)
        BajoNivel.ActualizaBase(p0, "Select * from FamiliaGrupoPatente")
    End Sub
End Class
