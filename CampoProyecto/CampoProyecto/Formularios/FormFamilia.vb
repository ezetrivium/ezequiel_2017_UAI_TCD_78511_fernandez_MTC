Imports BE
Imports BLL

Public Class FormFamilia
    Dim listafamilias As New List(Of Familia)
    Private Sub FormFamilia_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim lista As New List(Of GrupoPatente)
        lista = MapperPatente.CargarArbol()
        listafamilias = MapperFamilia.CargarFamilias
        lista.Item(0).MostrarTreeView(TreeView1.Nodes)
        combobox()
        TreeView1.ExpandAll()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nombre As String

        Dim fam As New Familia



        nombre = InputBox("Ingrese nombre de la nueva Familia: ")
        If nombre <> "" Then
            fam.nombre = nombre
            MapperFamilia.alta(fam)
        End If



        If Me.TreeView1.Nodes.Item(0).Checked = True Then
            fam.Listapatentes.Add(TreeView1.Nodes.Item(0).Tag)
        End If
        agregarpatenteafam(fam, TreeView1.Nodes.Item(0))

        listafamilias.Add(fam)

        sacarcheck()
        GuardarRelacion()
        combobox()
    End Sub
    Public Sub agregarpatenteafam(p0 As Familia, p1 As TreeNode)
        For Each no As TreeNode In p1.Nodes
            If no.Checked = True Then
                p0.Listapatentes.Add(no.Tag)
            End If

            If Not no.Nodes Is Nothing Then
                agregarpatenteafam(p0, no)
            End If
        Next

    End Sub

    Public Sub combobox()


        ComboBox1.Items.Clear()
        listafamilias = MapperFamilia.CargarFamilias

        For Each f As Familia In listafamilias
            ComboBox1.Items.Add(f.nombre)
        Next
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        GuardarRelacion()
        Me.Close()

    End Sub


    Public Sub GuardarRelacion()

        Dim DTfp As DataTable = MapperFamilia.traerfamiliapatente
        Dim DTfgp As DataTable = MapperFamilia.traerfamiliagrupopatente
        Dim IDfg As Integer = 1
        Dim IDfp As Integer = 1
        Dim b As Boolean = False
        For Each f As Familia In listafamilias
            For Each p As PatenteAbstracta In f.Listapatentes
                If TypeOf p Is Patente Then
                    If DTfp.Rows.Count > 0 Then
                        For i = 0 To DTfp.Rows.Count - 1
                            If IDfp = DTfp.Rows(i).Item(0) Then
                                DTfp.Rows(i).ItemArray = {IDfp, f.ID, p.ID}
                                b = True
                            End If
                        Next
                        If b = True Then
                            IDfp = IDfp + 1
                        End If
                    End If
                    If b = False Then
                        Dim drfp As DataRow = DTfp.NewRow
                        drfp.ItemArray = {IDfp, f.ID, p.ID}
                        DTfp.Rows.Add(drfp)
                        IDfp = IDfp + 1

                    End If

                ElseIf TypeOf p Is GrupoPatente Then
                    If DTfgp.Rows.Count > 0 Then
                        For i = 0 To DTfgp.Rows.Count - 1
                            If IDfg = DTfgp.Rows(i).Item(0) Then
                                DTfgp.Rows(i).ItemArray = {IDfg, f.ID, p.ID}
                                b = True

                            End If
                        Next
                        If b = True Then
                            IDfg = IDfg + 1
                        End If
                    End If
                    If b = False Then
                        Dim drfg As DataRow = DTfgp.NewRow
                        drfg.ItemArray = {IDfg, f.ID, p.ID}
                        DTfgp.Rows.Add(drfg)
                        IDfg = IDfg + 1

                    End If
                End If
                b = False
            Next
        Next
        MapperFamilia.Altafamiliagrupopatente(DTfgp)
        MapperFamilia.Altafamiliapatente(DTfp)
    End Sub





    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If ComboBox1.Text <> "" Then
            Dim fam As Familia
            For Each f As Familia In listafamilias
                If f.nombre = ComboBox1.SelectedItem Then
                    fam = f

                    listafamilias.Remove(f)
                    Exit For

                End If
            Next
            MapperFamilia.borrar(fam)
        End If

        ComboBox1.Text = ""
        combobox()
        sacarcheck()
     


    End Sub

    Public Sub sacarcheck()
        For Each a As TreeNode In TreeView1.Nodes
            a.Checked = False
        Next

    End Sub

    Public Sub checkear(p0 As TreeNode, p1 As PatenteAbstracta)

        For Each a As TreeNode In p0.Nodes
            If p1.Nombre = a.Text Then
                a.Checked = True
                checkear(a, p1)
            Else
                checkear(a, p1)
            End If
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Close()

    End Sub

    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try
            Dim nodo As TreeNode = e.Node
            If nodo.Checked = True Then
                For Each n As TreeNode In nodo.Nodes
                    n.Checked = True
                Next
            ElseIf nodo.Checked = False Then
                For Each n As TreeNode In nodo.Nodes
                    n.Checked = False
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub



    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        sacarcheck()


        Dim listapat As New List(Of PatenteAbstracta)

        Dim fam As New Familia
        For Each f As Familia In listafamilias
            If f.nombre = ComboBox1.SelectedItem Then
                fam = f
                Exit For
            End If
        Next

        listapat = fam.Listapatentes

        For Each p As PatenteAbstracta In listapat
            For Each a As TreeNode In TreeView1.Nodes
                If a.Text = p.Nombre Then
                    a.Checked = True
                    checkear(a, p)
                Else
                    checkear(a, p)
                End If
            Next
        Next


    End Sub
End Class