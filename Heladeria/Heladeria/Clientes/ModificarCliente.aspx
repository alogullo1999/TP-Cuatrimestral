<%@ Page Title="Modificar Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarCliente.aspx.cs" Inherits="Heladeria.ModificarCliente" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Modificar Cliente</h2>
                    <div class="form-group">
                        
                        
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtApellido">Apellido:</label>
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtDNI">DNI:</label>
                        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtCiudad">Ciudad:</label>
                        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtEmail">Correo Electrónico:</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
                    </div>
                    <div class="text-center">
                        <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary" OnClick="btnModificar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>