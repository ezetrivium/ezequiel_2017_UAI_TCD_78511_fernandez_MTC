Imports System.Windows.Forms
Public Class Patente
    Inherits PatenteAbstracta


    Property form As String


    Public Overloads Overrides Sub MostrarTreeView(ByRef padre As Windows.Forms.TreeNodeCollection)
        Dim nodo As TreeNode = padre.Add(Me.Nombre)
        nodo.Tag = Me

    End Sub
End Class
