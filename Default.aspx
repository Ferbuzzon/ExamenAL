<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ExamenAl._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
            <h2 class="text-center">Empleados:</h2>
        </div>
        <br />
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-4 d-flex justify-content-center align-items-end">
                    <asp:Button runat="server" ID="BtnCrear" CssClass="btn btn-primary" text="Crear" OnClick="BtnCrear_Click"/>
                </div>
            </div>
        </div>
        <br />  
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gridempleados" CssClass="table table-borderless table-hover" AutoGenerateColumns="False">  
                    <Columns>
                        <asp:BoundField DataField="Idusuario" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="ApellidoPaterno" HeaderText="Apellido Paterno" />
                        <asp:BoundField DataField="ApellidoMaterno" HeaderText="Apellido Materno" />
                        <asp:TemplateField HeaderText="Opciones">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Leer" CssClass="btn btn-info" ID="btnleer" OnClick="BtnLeer_Click"/>
                                <asp:Button runat="server" Text="Actualizar" CssClass="btn btn-success" ID="btnactualiza" OnClick="BtnActualiza_Click"/>
                                <asp:Button runat="server" Text="Borrar" CssClass="btn btn-danger" ID="btnborrar" OnClick="BtnBorrar_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

</asp:Content>
