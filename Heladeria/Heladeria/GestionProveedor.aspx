<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionProveedor.aspx.cs" Inherits="Heladeria.WebForm1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <!-- Formulario para agregar nuevos proveedores -->
        <h3>Agregar Nuevo Proveedor</h3>
        <asp:TextBox ID="txtNombre" runat="server" Placeholder="Nombre"></asp:TextBox><br />
        <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email"></asp:TextBox><br />
        <asp:TextBox ID="txtDni" runat="server" Placeholder="DNI"></asp:TextBox><br />
        <asp:TextBox ID="txtCiudad" runat="server" Placeholder="Ciudad"></asp:TextBox><br />
        <asp:Button ID="btnAgregarProveedor" runat="server" Text="Agregar Proveedor" OnClick="btnAgregarProveedor_Click" /><br /><br />

        <!-- GridView personalizado para mostrar proveedores -->
        <asp:GridView ID="gvProveedores" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="IdProveedor" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>