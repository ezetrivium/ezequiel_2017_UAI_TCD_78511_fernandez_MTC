Imports BE
Imports BLL
Imports BLL_Seguridad
Imports System.Data.Sql
Imports System.Configuration
Imports System.IO
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class FormLogin
    Dim Mu As New MapperUsuario
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormRegistro.Show()


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim usuario As New Usuario
        usuario.Nombre = TextBox1.Text
        usuario.Contraseña = TextBox2.Text
        If Validacion.ValidarContraseña(usuario) = True Then
            MessageBox.Show("Bienvenido")
            FormularioPrincipal.Show()
        Else
            MessageBox.Show("Los datos ingresados son incorrectos")
        End If

    End Sub

    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim servidores As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim tablaServidores As DataTable = servidores.GetDataSources()
        Dim mServerName As String = tablaServidores.Rows(0).Item(0).ToString & "\" & tablaServidores.Rows(0).Item(1).ToString
        CrearString(mServerName)
        CrearDB()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox1.Select()
    End Sub

    Public Sub CrearString(Optional pServer As String = Nothing)
        Try
            Dim mConfigsettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("MiBD")
            If Not mConfigsettings Is Nothing Then
                Dim mString As String
                Dim Constructor As New SqlConnectionStringBuilder(mConfigsettings.ConnectionString)
                If Not pServer Is Nothing Then
                    Constructor.DataSource = pServer
                Else
                    Constructor.DataSource = "EXO"
                End If
                Constructor.IntegratedSecurity = True
                mString = Constructor.ConnectionString
                escribirConfig(mString)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub CrearDB()
        Try
            Dim script As New FileStream(Application.StartupPath & "\Nutricion.sql", FileMode.Open)
            Dim Lector As New StreamReader(script)
            Dim mStringCon As String = ConfigurationManager.ConnectionStrings.Item("MiBD").ConnectionString
            Dim mStringBuild As New SqlConnectionStringBuilder
            mStringBuild.ConnectionString = mStringCon
            mStringBuild.InitialCatalog = "master"
            Dim mCon As New SqlConnection(mStringBuild.ConnectionString)
            Dim mComando As New SqlCommand("Create DATABASE [ProyectoCampo]", mCon)
            mCon.Open()
            mComando.ExecuteNonQuery()
            mCon.ChangeDatabase("ProyectoCampo")
            mComando.CommandText = Lector.ReadToEnd
            mComando.ExecuteNonQuery()
            mCon.Close()
            Lector.Close()
            script.Close()
        Catch
        End Try
    End Sub

    Public Sub escribirConfig(pstring As String)
        Dim mConfig As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim mAppSettingSection As ConnectionStringsSection = mConfig.ConnectionStrings
        Dim mSettings As ConnectionStringSettings = mAppSettingSection.ConnectionStrings.Item("MiBD")
        mSettings.ConnectionString = pstring
        mConfig.Save(ConfigurationSaveMode.Modified)
        ConfigurationManager.RefreshSection("connectionStrings")
    End Sub

    
End Class
