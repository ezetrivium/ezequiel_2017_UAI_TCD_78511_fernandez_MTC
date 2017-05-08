Imports System.Windows.Forms
Public MustInherit Class PatenteAbstracta

    Property ID As Integer
    Property Nombre As String

    Property IDpadre As Integer

    Public MustOverride Sub MostrarTreeView(ByRef padre As TreeNodeCollection)


End Class
