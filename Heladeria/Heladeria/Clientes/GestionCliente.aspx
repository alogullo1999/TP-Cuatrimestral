<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionCliente.aspx.cs" Inherits="Heladeria.GestionCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-center">
     
                <div class="row mb-3">
                    <div class="col text-center">
                        <asp:Label ID="lblIngresarID" runat="server" CssClass="form-label" Text="Ingresar ID:"></asp:Label>
                        <asp:TextBox ID="txtID" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" />
                    </div>
                </div>
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success mx-2" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-warning mx-2" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminar_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="card shadow p-4">
                    <h3 class="text-center mb-4">Listado de Clientes</h3>
                    <asp:GridView ID="gvClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="IdCliente" HeaderText="ID" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Dni" HeaderText="DNI" />
                            <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
