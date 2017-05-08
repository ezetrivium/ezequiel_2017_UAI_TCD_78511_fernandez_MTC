Imports DAL
Imports BLL
Public Class MapperUsuario

    Public Shared Sub alta(p0 As Usuario)
        Dim Usuario As Usuario = p0
        Dim dt As DataTable = BajoNivel.obtenerdatos("Select * from Usuario")
        Dim dr As DataRow = dt.NewRow
        If dt.Rows.Count > 0 Then
            Usuario.ID = dt.Rows(dt.Rows.Count - 1).Item(0) + 1
        Else
            Usuario.ID = 1
        End If

        dr.ItemArray = {Usuario.ID, Usuario.Nombre, Usuario.fechanac, Usuario.Contraseña, Usuario.familia.ID}
        dt.Rows.Add(dr)
        BajoNivel.ActualizaBase(dt, "Select * from Usuario")
    End Sub


    Public Shared Function TraerUsuarios() As List(Of Usuario)

        Dim ListaUsuario As New List(Of Usuario)
        Dim dt As DataTable = BajoNivel.obtenerdatos("Select * from Usuario")
        If dt.Rows.Count > 0 Then
            For Each x As DataRow In dt.Rows
                Dim fam As New Familia
                fam.ID = x.Item(4)
                ListaUsuario.Add(New Usuario(x.Item(1), x.Item(2), x.Item(3), fam))


            Next
        End If
        Return ListaUsuario


    End Function



End Class
