<%@ Page Title="Alta de Clientes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroClientes.aspx.cs" Inherits="Heladeria.RegistroClientes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registro de Nuevo Cliente</h2>
    <div class="form-group">
        <label for="txtNombre">Nombre:</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtApellido">Apellido:</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtDireccion">DNI:</label>
        <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtTelefono">Ciudad:</label>
        <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control" />
    </div>
    <div class="form-group">
        <label for="txtEmail">Correo Electrónico:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
    </div>
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
</asp:Content>
