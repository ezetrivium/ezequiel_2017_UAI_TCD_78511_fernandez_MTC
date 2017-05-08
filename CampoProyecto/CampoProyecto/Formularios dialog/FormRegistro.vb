Imports BE
Imports BLL
Imports BLL_Seguridad
Public Class FormRegistro


    Dim lista As New List(Of Familia)

    Private Sub FormRegistro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lista = MapperFamilia.CargarFamilias
        For Each f As Familia In lista
            ComboBox1.Items.Add(f.nombre)
        Next
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        If Validacion.validarnombre(TextBox1.Text) = True Then
            Dim fam As New Familia
            fam.nombre = ComboBox1.SelectedItem
            For Each f As Familia In lista
                If fam.nombre = f.nombre Then
                    fam = f
                    Exit For
                End If
            Next
            Dim Usu As New Usuario(TextBox1.Text, DateTimePicker1.Value, TextBox2.Text, fam)

            MapperUsuario.alta(Usu)
            Me.Close()
        Else
            MessageBox.Show("El nombre ya esta registrado en el sistema")
        End If
     
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class