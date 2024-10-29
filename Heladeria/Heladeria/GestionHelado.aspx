<%@ Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionHelado.aspx.cs" Inherits="Heladeria.GestionHelado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <!-- Formulario para agregar Helado -->
    <h3>Agregar Nuevo Helado</h3>
    <asp:TextBox ID="txtNombre" runat="server" PlacerHolder="Nombre"></asp:TextBox>
    <asp:Button ID="btnAgregarHelado" runat="server" Text="Agregar Helado" OnClick="btnAgregarHelado_Click" /><br /><br />

    <!--GridView personalizado para mostrar los helados -->
    <asp:GridView ID="gvHelado" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="IdHelado" HeaderText="ID"/>
            <asp:BoundField DataField="NombreHelado" HeaderText="Nombre" />
        </Columns>

    </asp:GridView>
    </div>
    
</asp:Content>

