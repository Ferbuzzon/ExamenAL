Imports System.Data.SqlClient
Imports System.Reflection.Emit

Public Class WebForm1
    Inherits System.Web.UI.Page

    Public Shared Rid As String = ""
    Public Shared ROp As String = ""

    Private Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("conexion").ConnectionString
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Request.QueryString("id") IsNot Nothing Then

                Rid = Request.QueryString("id").ToString()
                CargarDatos()

            End If

            If Request.QueryString("op") IsNot Nothing Then

                ROp = Request.QueryString("op").ToString()

                Select Case ROp
                    Case "C"
                        lblTitulo.Text = "Crear nuevo empleado:"
                        BtnCrear.Visible = True
                    Case "B"
                        lblTitulo.Text = "Eliminar empleado:"
                        BtnBorrar.Visible = True
                    Case "A"
                        lblTitulo.Text = "Actualizar empleado:"
                        BtnActualiza.Visible = True
                    Case "L"
                        lblTitulo.Text = "Consulta empleado:"

                End Select

            End If

        End If



    End Sub

    Sub CargarDatos()

        Dim connectionString As String = GetConnectionString()
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(connectionString)

        Try
            sqlConnection.Open()

            Dim sqlCommand As New SqlCommand("sp_lee", sqlConnection)

            sqlCommand.CommandType = CommandType.StoredProcedure

            Dim SqlDataAdapter As New SqlDataAdapter(sqlCommand)

            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@Id", Rid)

            Dim tabla As New DataTable()

            tabla.Clear()

            SqlDataAdapter.Fill(tabla)

            Dim row As DataRow = tabla.Rows(0)

            tbNombre.Text = row(1).ToString()

            tbAPaterno.Text = row(2).ToString()

            tbAMaterno.Text = row(3).ToString()


        Catch ex As Exception

            Console.WriteLine("Error: " & ex.Message)

        Finally

            If sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

    End Sub
    Protected Sub BtnCrear_Click(sender As Object, e As EventArgs)

        Dim connectionString As String = GetConnectionString()
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(connectionString)

        Try
            sqlConnection.Open()

            Dim sqlCommand As New SqlCommand("sp_crea", sqlConnection)

            sqlCommand.CommandType = CommandType.StoredProcedure


            sqlCommand.Parameters.AddWithValue("@Nombre", tbNombre.Text)

            sqlCommand.Parameters.AddWithValue("@Apaterno", tbAPaterno.Text)

            sqlCommand.Parameters.AddWithValue("@AMaterno", tbAMaterno.Text)

            sqlCommand.ExecuteNonQuery()



        Catch ex As Exception

            Console.WriteLine("Error: " & ex.Message)

        Finally

            If sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

        Response.Redirect("~/Default.aspx")

    End Sub

    Protected Sub BtnActualizar_Click(sender As Object, e As EventArgs)

        Dim connectionString As String = GetConnectionString()
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(connectionString)

        Try
            sqlConnection.Open()

            Dim sqlCommand As New SqlCommand("sp_actualiza", sqlConnection)

            sqlCommand.CommandType = CommandType.StoredProcedure



            sqlCommand.Parameters.AddWithValue("@Id", Rid)

            sqlCommand.Parameters.AddWithValue("@Nombre", tbNombre.Text)

            sqlCommand.Parameters.AddWithValue("@Apaterno", tbAPaterno.Text)

            sqlCommand.Parameters.AddWithValue("@AMaterno", tbAMaterno.Text)

            sqlCommand.ExecuteNonQuery()



        Catch ex As Exception

            Console.WriteLine("Error: " & ex.Message)

        Finally

            If sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

        Response.Redirect("~/Default.aspx")


    End Sub

    Protected Sub BtnBorrar_Click(sender As Object, e As EventArgs)

        Dim connectionString As String = GetConnectionString()
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(connectionString)

        Try
            sqlConnection.Open()

            Dim sqlCommand As New SqlCommand("sp_borra", sqlConnection)

            sqlCommand.CommandType = CommandType.StoredProcedure



            sqlCommand.Parameters.AddWithValue("@Id", Rid)

            sqlCommand.ExecuteNonQuery()


        Catch ex As Exception

            Console.WriteLine("Error: " & ex.Message)

        Finally

            If sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try

        Response.Redirect("~/Default.aspx")

    End Sub

    Protected Sub BtnVolver_Click(sender As Object, e As EventArgs)

        Response.Redirect("~/Default.aspx")

    End Sub
End Class