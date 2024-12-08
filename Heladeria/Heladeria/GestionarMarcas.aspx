<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarMarcas.aspx.cs" Inherits="Heladeria.GestionarMarcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Gestión de Marcas</h2>

        <div class="row">
            <div class="col text-center">
                <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Marca para agregar"></asp:TextBox>
                <asp:Button ID="btnAgregarMarca" runat="server" Text="Agregar" CssClass="btn btn-success mx-2" OnClick="btnAgregarMarca_Click" />
                <asp:TextBox ID="txtIdMarca" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="ID Marca"></asp:TextBox>
                <asp:Button ID="btnModificarMarca" runat="server" Text="Modificar" CssClass="btn btn-warning mx-2" OnClick="btnModificarMarca_Click" />
                <asp:Button ID="btnEliminarMarca" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminarMarca_Click" />
            </div>
        </div>

              <div class="row mt-4" id="modificar" runat="server" visible="false">
            <div class="col text-center">
                <asp:TextBox ID="txtNuevoNombre" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Nuevo nombre"></asp:TextBox>
                <asp:Button ID="btnAceptarModificacion" runat="server" Text="Aceptar" CssClass="btn btn-primary mx-2" OnClick="btnAceptarModificacion_Click" />
            </div>
        </div>




        <div class="row mt-4">
            <div class="col">
                <asp:GridView ID="gvMarcas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdMarca" HeaderText="ID Marca" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
