<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionCompras.aspx.cs" Inherits="Heladeria.GestionCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Gestión de Compras</h2>
        

    <div class="container">
        <div class="card shadow p-4 mb-4">
            <div class="row">
                <div class="col-md-4">
                    <label for="ddlProveedor">Proveedor:</label>
                    <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label for="ddlProducto">Producto:</label>
                    <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label for="txtCantidad">Cantidad:</label>
                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" />
                </div>
                <div class="col-md-2">
                    <label for="txtPrecioUnitario">Precio Unitario:</label>
                    <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="text-center mt-4">
                <asp:Button ID="btnAgregarCompra" runat="server" Text="Realizar Compra" CssClass="btn btn-primary" OnClick="btnAgregarCompra_Click" />
            </div>
        </div>

    <div class="col">
        <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
 
                <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad en Stock" />
                <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha de Actualización" />

            </Columns>
        </asp:GridView>
    </div>
</div>

    </div>
</asp:Content>
