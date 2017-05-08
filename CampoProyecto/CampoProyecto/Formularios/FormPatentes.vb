Imports BE
Imports BLL

Public Class FormPatentes




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CrearPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearPatenteToolStripMenuItem.Click
        Try
            Dim nodo As TreeNode = TreeView1.SelectedNode
            If TypeOf nodo.Tag Is GrupoPatente Then
                Dim form As New FormPatentesDialog
                form.ShowDialog(Me)
                Dim nombre As String = form.nombre
                Dim f As String = form.form

                If nombre <> "" And f <> "" Then

                    Dim padre As GrupoPatente = nodo.Tag
                    Dim pat As New Patente
                    Dim nodonuevo As New TreeNode
                    nodonuevo.Text = nombre
                    pat.Nombre = nombre
                    nodonuevo.Tag = pat
                    nodo.Nodes.Add(nodonuevo)
                    padre.listapatentes.Add(pat)
                    pat.form = f
                    pat.IDpadre = padre.ID
                    MapperPatente.alta(pat)

                End If
            End If
            Dim arbol As New List(Of GrupoPatente)
            TreeView1.Nodes.Clear()
            arbol = MapperPatente.CargarArbol

            arbol.Item(0).MostrarTreeView(TreeView1.Nodes)
        Catch ex As Exception

        End Try
       





    End Sub

    Private Sub CrearGrupoPatenteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearGrupoPatenteToolStripMenuItem.Click
        

       

        Try
            Dim nodo As TreeNode = TreeView1.SelectedNode
            Dim arbol As New List(Of GrupoPatente)
            If TypeOf nodo.Tag Is GrupoPatente Then

                Dim nombre As String = InputBox("Ingrese nombre del nuevo grupo de patentes: ")


                If nombre <> "" Then
                    Dim padre As GrupoPatente = nodo.Tag
                    Dim gp As New GrupoPatente
                    Dim nodonuevo As New TreeNode
                    nodonuevo.Text = nombre
                    gp.Nombre = nombre
                    nodonuevo.Tag = gp
                    nodo.Nodes.Add(nodonuevo)
                    padre.listapatentes.Add(gp)
                    gp.IDpadre = padre.ID
                    MapperPatente.alta(gp)
                End If
            End If
            TreeView1.Nodes.Clear()
            arbol = MapperPatente.CargarArbol

            arbol.Item(0).MostrarTreeView(TreeView1.Nodes)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub EliminarElementoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarElementoToolStripMenuItem.Click
        Dim nodo As TreeNode = TreeView1.SelectedNode
        If TypeOf nodo.Tag Is PatenteAbstracta Then
            If Not nodo.Parent Is Nothing Then
                Dim padre As GrupoPatente = nodo.Parent.Tag()
                nodo.Remove()
                padre.listapatentes.Remove(nodo.Tag)
                MapperPatente.Borrar(nodo.Tag)
            End If
        End If

    End Sub

   
  
    Private Sub FormPatentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim arbol As New List(Of GrupoPatente)
            TreeView1.Nodes.Clear()
            arbol = MapperPatente.CargarArbol()
            arbol.Item(0).MostrarTreeView(TreeView1.Nodes)

        Catch ex As Exception

        End Try

        If TreeView1.Nodes.Count = 0 Then
            Dim gp As New GrupoPatente
            gp.ID = 1
            gp.Nombre = "Sistema"
            TreeView1.Nodes.Add(gp.Nombre)
            TreeView1.Nodes.Item(0).Tag = gp
            MapperPatente.alta(gp)
        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub


    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub
End Class