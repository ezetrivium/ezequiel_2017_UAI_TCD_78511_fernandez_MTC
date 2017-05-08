Imports System.Reflection
Public Class FormPatentesDialog

    Private Sub Patentes_Dialogo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim assem As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

        For Each t As Type In assem.GetTypes()
            If t.IsSubclassOf(GetType(Form)) Then
                Me.ComboBox1.Items.Add(t.FullName)
            End If

        Next



    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()

    End Sub


    Public Function nombre() As String
        Return Me.TextBox1.Text
    End Function

    Public Function form() As String
        Return Me.ComboBox1.Text
    End Function
End Class