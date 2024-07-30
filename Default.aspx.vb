Imports System.Data.SqlClient

Public Class _Default
    Inherits Page
    Private Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("conexion").ConnectionString
    End Function
    Sub CargarTabla()

        Dim connectionString As String = GetConnectionString()
        Dim sqlConnection As SqlConnection
        sqlConnection = New SqlConnection(connectionString)

        Try
            sqlConnection.Open()

            Dim sqlCommand As New SqlCommand("sp_carga", sqlConnection)

            sqlCommand.CommandType = CommandType.StoredProcedure

            Dim SqlDataAdapter As New SqlDataAdapter(sqlCommand)

            Dim tabla As New DataTable()

            SqlDataAdapter.Fill(tabla)

            gridempleados.DataSource = tabla

            gridempleados.DataBind()

        Catch ex As Exception

            Console.WriteLine("Error: " & ex.Message)

        Finally

            If sqlConnection IsNot Nothing AndAlso sqlConnection.State = ConnectionState.Open Then
                sqlConnection.Close()
            End If

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        CargarTabla()
    End Sub

    Protected Sub BtnCrear_Click(sender As Object, e As EventArgs)

        Response.Redirect("~/WebForm1.aspx?op=C")

    End Sub

    Protected Sub BtnBorrar_Click(sender As Object, e As EventArgs)

        Dim id As String
        Dim BtnConsultar As Button = DirectCast(sender, Button)
        Dim selectedrow As GridViewRow = DirectCast(BtnConsultar.NamingContainer, GridViewRow)
        id = selectedrow.Cells(0).Text
        Response.Redirect("~/WebForm1.aspx?id=" & id & "&op=B")

    End Sub

    Protected Sub BtnActualiza_Click(sender As Object, e As EventArgs)

        Dim id As String
        Dim BtnConsultar As Button = DirectCast(sender, Button)
        Dim selectedrow As GridViewRow = DirectCast(BtnConsultar.NamingContainer, GridViewRow)
        id = selectedrow.Cells(0).Text
        Response.Redirect("~/WebForm1.aspx?id=" & id & "&op=A")

    End Sub

    Protected Sub BtnLeer_Click(sender As Object, e As EventArgs)

        Dim id As String
        Dim BtnConsultar As Button = DirectCast(sender, Button)
        Dim selectedrow As GridViewRow = DirectCast(BtnConsultar.NamingContainer, GridViewRow)
        id = selectedrow.Cells(0).Text
        Response.Redirect("~/WebForm1.aspx?id=" & id & "&op=L")

    End Sub
End Class