<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionCliente.aspx.cs" Inherits="Heladeria.GestionCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <!-- Formulario para agregar nuevos clientes -->
        <h3>Agregar Nuevo Cliente </h3>
        <asp:TextBox ID="txtNombre" runat="server" PlaceHolder="Nombre"></asp:TextBox><br />
        <asp:TextBox ID="txtApellido" runat="server" PlaceHolder="Apellido"></asp:TextBox><br />
        <asp:TextBox ID="txtDni" runat="server" PlaceHoolder="DNI"></asp:TextBox><br />
        <asp:TextBox ID="txtEmail" runat="server" PlaceHolder="Email"></asp:TextBox><br />
        <asp:TextBox ID="txtCiudad" runat="server" PlaceHolder="Ciudad"></asp:TextBox><br />
        <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" OnClick="btnAgregarCliente_Click"/><br /><br />

        <!--GridView personalizado para mostrar los clientes -->
        <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False">
          <Columns>
              <asp:BoundField DataField="IdCliente" HeaderText="ID"/>
              <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
              <asp:BoundField DataField="Email" HeaderText="Email" />
              <asp:BoundField DataField="Dni" HeaderText="DNI" />
              <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
          </Columns>

        </asp:GridView>

    </div>
</asp:Content>
