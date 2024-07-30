Imports System.Data.SqlClient

Public Class Reporte
    Inherits System.Web.UI.Page

    Private Function GetConnectionString() As String
        Return ConfigurationManager.ConnectionStrings("conexion").ConnectionString
    End Function

    Protected Sub BtnFiltrar_Click(sender As Object, e As EventArgs)
        Dim fechaMovimiento As Date
        Dim tipoMovimiento As String = ddlTipoMovimiento.SelectedValue

        ' Validar la fecha
        If Not Date.TryParse(tbFechaMovimiento.Text, fechaMovimiento) Then
            ' Manejar el error de fecha inválida (opcional)
            Console.WriteLine("Fecha inválida.")
            Return
        End If

        Dim connectionString As String = GetConnectionString()
        Using sqlConnection As New SqlConnection(connectionString)
            Try
                sqlConnection.Open()
                Dim sqlCommand As New SqlCommand("sp_FiltrarMovimientos", sqlConnection)
                sqlCommand.CommandType = CommandType.StoredProcedure

                sqlCommand.Parameters.AddWithValue("@FechaMovimiento", fechaMovimiento)
                sqlCommand.Parameters.AddWithValue("@TipoMovimiento", tipoMovimiento)

                Dim SqlDataAdapter As New SqlDataAdapter(sqlCommand)
                Dim dataTable As New DataTable()
                SqlDataAdapter.Fill(dataTable)

                gridMovimientos.DataSource = dataTable
                gridMovimientos.DataBind()
            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
            End Try
        End Using
    End Sub

End Class