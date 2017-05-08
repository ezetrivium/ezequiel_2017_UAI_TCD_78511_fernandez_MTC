Imports System.Windows.Forms
Public Class GrupoPatente
    Inherits PatenteAbstracta


    Public Property listapatentes As New List(Of PatenteAbstracta)




    Public Overloads Overrides Sub MostrarTreeView(ByRef padre As Windows.Forms.TreeNodeCollection)
        Dim nodo As TreeNode = padre.Add(Me.Nombre)  'igualas el nombre de la patente a un nodo
        nodo.Tag = Me ' le pasas la info

        For Each Patente As PatenteAbstracta In listapatentes
            Patente.MostrarTreeView(nodo.Nodes) 'recorres la lista de hijos y le pasas el nodo padre, ya que ME es la patente hija 
        Next
    End Sub


    
End Class
