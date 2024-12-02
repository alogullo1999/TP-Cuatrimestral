<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gestiones.aspx.cs" Inherits="Heladeria.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h3>Gestiones</h3>

<div class="button-container">
        <!-- Botón para Gestionar Proveedores -->
        <asp:Button ID="btnGestionarProveedores" runat="server" Text="Gestionar Proveedores" CssClass="btn btn-primary" OnClick="btnGestionarProveedores_Click" />
        
        <!-- Botón para Gestionar Marcas -->
        <asp:Button ID="btnGestionarMarcas" runat="server" Text="Gestionar Marcas" CssClass="btn btn-primary" OnClick="btnGestionarMarcas_Click" />
        
        <!-- Botón para Gestionar Helados -->
        <asp:Button ID="btnGestionarHelados" runat="server" Text="Gestionar Helados" CssClass="btn btn-primary" OnClick="btnGestionarHelados_Click" />
        
        <!-- Botón para Gestionar Productos -->
        <asp:Button ID="btnGestionarProductos" runat="server" Text="Gestionar Productos" CssClass="btn btn-primary" OnClick="btnGestionarProductos_Click" />

        <!-- Botón para Gestionar Ventas -->
        <asp:Button ID="btnGestionarVentas" runat="server" Text="Gestionar Ventas" CssClass="btn btn-primary" OnClick="btnGestionarVentas_Click" />

        <!-- Botón para Gestionar Compras -->
        <asp:Button ID="btnGestionarCompras" runat="server" Text="Gestionar Compras" CssClass="btn btn-primary" OnClick="btnGestionarCompras_Click" />

        <!-- Botón para Gestionar Clientes -->
        <asp:Button ID="btnGestionarClientes" runat="server" Text="Gestionar Clientes" CssClass="btn btn-primary" OnClick="btnGestionarClientes_Click" />

    </div>

    </main>
</asp:Content>