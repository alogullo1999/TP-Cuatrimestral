<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCompras.aspx.cs" Inherits="Heladeria.RegistroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-center">
                <div class="row mb-3">
        </div>
        <div class="row">
            <div class="col">
                <div class="card shadow p-4">
                    <h3 class="text-center mb-4">Gestión de Compras</h3>
                    <asp:GridView ID="gvDetalleCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" />
                            <asp:BoundField DataField="IdProveedor" HeaderText="ID Proveedor" />
                            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                            <asp:BoundField DataField="TotalCompra" HeaderText="Total Compra" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>
</div>
</asp:Content>
