<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="WebForm1.aspx.vb" Inherits="ExamenAl.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <div class="container mt-4">
        <div class="text-center mb-4">
            <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
        </div>

        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="mb-3">
                    <div class="form-group">
                        <label class="form-label">Nombre:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tbNombre"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="tbNombre" ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Apellido Paterno:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tbAPaterno"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Apellido Materno:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="tbAMaterno"></asp:TextBox>
                    </div>
                </div>

                <div class="text-center">
                    <asp:Button runat="server" CssClass="btn btn-primary mx-2" ID="BtnCrear" Text="Crear" Visible="false" OnClick="BtnCrear_Click"/>
                    <asp:Button runat="server" CssClass="btn btn-primary mx-2" ID="BtnActualiza" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click"/>
                    <asp:Button runat="server" CssClass="btn btn-primary mx-2" ID="BtnBorrar" Text="Borrar" Visible="false" OnClick="BtnBorrar_Click"/>
                    <asp:Button CausesValidation="False" runat="server" CssClass="btn btn-primary mx-2" ID="BtnVolver" Text="Volver" Visible="true" OnClick="BtnVolver_Click"/>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
