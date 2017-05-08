Public Class FormularioPrincipal

    

    Private Sub PatentesToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PatentesToolStripMenuItem.Click
        FormPatentes.ShowDialog()

    End Sub

    Private Sub FamiliasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamiliasToolStripMenuItem.Click
        FormFamilia.ShowDialog()
    End Sub
End Class