<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionarCategorias.aspx.cs" Inherits="Heladeria.GestionarCategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Gestión de Categorias</h2>

        <div class="row">
            <div class="col text-center">
                <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Nombre de Categoria para agregar"></asp:TextBox>
                <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar" CssClass="btn btn-success mx-2" OnClick="btnAgregarCategoria_Click" />
                <asp:TextBox ID="txtIdCategoria" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;" Placeholder="Ingresar ID Categoria"></asp:TextBox>
                <asp:Button ID="btnModificarCategoria" runat="server" Text="Modificar" CssClass="btn btn-warning mx-2" OnClick="btnModificarCategoria_Click" />
                <asp:Button ID="btnEliminarCategoria" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminarCategoria_Click" />
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
                <asp:GridView ID="gvCategoria" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdCategoria" HeaderText="ID Categoria" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
