<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Reporte.aspx.vb" Inherits="ExamenAl.Reporte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
    <div class="container">
            <div class="form-group">
                <label for="fechaMovimiento">Fecha de Movimiento:</label>
                <asp:TextBox ID="tbFechaMovimiento" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="tipoMovimiento">Tipo de Movimiento:</label>
                <asp:DropDownList ID="ddlTipoMovimiento" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Seleccionar" Value=""></asp:ListItem>
                    <asp:ListItem Text="Alta" Value="ALTA"></asp:ListItem>
                    <asp:ListItem Text="Baja" Value="BAJA"></asp:ListItem>
                    <asp:ListItem Text="Cambio" Value="CAMBIOS"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="btnFiltrar" runat="server" CssClass="btn btn-primary" Text="Filtrar" OnClick="BtnFiltrar_Click" />
            <asp:GridView ID="gridMovimientos" runat="server" CssClass="table table-bordered table-hover"></asp:GridView>
        </div>

</asp:Content>
