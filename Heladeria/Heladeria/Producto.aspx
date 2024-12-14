<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="Heladeria.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:Button ID="btnGestionarMarca" runat="server" Text="Agregar Marca" CssClass="btn btn-primary mb-4" OnClick="btnGestionarMarca_Click" />


        <asp:Button ID="btnGestionarCategoria" runat="server" Text="Agregar Categoria" CssClass="btn btn-primary mb-4" OnClick="btnGestionarCategoria_Click" />


        <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" CssClass="btn btn-primary mb-4" OnClick="btnAgregarProducto_Click" />

        <div class="row">
            <div class="col">
                <h2 class="text-center">Listado de Productos</h2>
                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="Codigo" HeaderText="Código" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="marca.IdMarca" HeaderText="ID Marca" />
                        <asp:BoundField DataField="marca.Nombre" HeaderText="Nombre Marca" />
                        <asp:BoundField DataField="proveedor.IdProveedor" HeaderText="ID Proveedor" />
                        <asp:BoundField DataField="proveedor.Nombre" HeaderText="Nombre Proveedor" />
                        <asp:BoundField DataField="categoria.IdCategoria" HeaderText="Categoría" />
                        <asp:BoundField DataField="categoria.Nombre" HeaderText="Categoría" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <asp:Image ID="imgProducto" runat="server" ImageUrl='<%# Eval("imagenUrl") %>' Width="100px" Height="100px" AlternateText="Sin Imagen" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
