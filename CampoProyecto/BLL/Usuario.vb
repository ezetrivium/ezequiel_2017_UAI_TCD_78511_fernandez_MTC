Public Class Usuario

    Sub New()

    End Sub
    Sub New(p0 As String, p1 As Date, p2 As String, p3 As Familia)
        Me.Nombre = p0 : Me.fechanac = p1 : Me.Contraseña = p2 : Me.familia = p3
    End Sub

    Property Nombre As String
    Property fechanac As Date

    Property Contraseña As String

    Property familia As Familia

    Private pid As Integer
    Public Property ID() As Integer
        Get

            Return pid
        End Get
        Set(ByVal value As Integer)
            pid = value
        End Set
    End Property




End Class
