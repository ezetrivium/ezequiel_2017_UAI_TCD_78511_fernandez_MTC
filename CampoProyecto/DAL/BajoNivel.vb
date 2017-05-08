Imports System.Data.SqlClient
Imports System.Configuration


Public Class BajoNivel


    Private Shared conexion As SqlConnection
    Private Shared com As SqlCommand
    Public Shared Function Command(p0 As String, p1 As SqlConnection) As SqlCommand
        com = New SqlCommand
        com.CommandText = p0
        com.CommandType = CommandType.Text
        com.Connection = p1
        Return com
    End Function
    Public Shared Function ConnectionObj() As SqlConnection
        If conexion Is Nothing Then
            conexion = New SqlConnection
        End If
        Dim mString As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("MiBD")
        conexion.ConnectionString = mString.ConnectionString
        Return conexion
    End Function


    Public Shared Sub ActualizaBase(P0 As DataTable, p1 As String)
        Dim DA As New SqlDataAdapter
        DA.SelectCommand = BajoNivel.Command(p1, BajoNivel.ConnectionObj())
        Dim mCB As New SqlCommandBuilder(DA)
        DA.InsertCommand = mCB.GetInsertCommand
        DA.DeleteCommand = mCB.GetDeleteCommand
        DA.UpdateCommand = mCB.GetUpdateCommand
        DA.Update(P0)
    End Sub

    Public Shared Function obtenerdatos(p0 As String) As DataTable
        Dim DA As New SqlDataAdapter
        Dim DT As New DataTable
        DA.SelectCommand = BajoNivel.Command(p0, BajoNivel.ConnectionObj())
        DA.Fill(DT)
        Return DT
    End Function


    Public Shared Function obtenerestructura(p0 As String) As DataTable
        Dim DA As New SqlDataAdapter
        Dim DT As New DataTable
        DA.SelectCommand = BajoNivel.Command(p0, BajoNivel.ConnectionObj())
        DA.FillSchema(DT, SchemaType.Mapped)
        Return DT

    End Function



End Class
