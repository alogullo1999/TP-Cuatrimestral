<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCompras.aspx.cs" Inherits="Heladeria.RegistroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-center">
                <div class="row mb-3">
                <div class="col-md-3">
                    <asp:Label ID="lblFecha" runat="server" Text="Fecha de Compra:" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtFechaCompra" runat="server" CssClass="form-control" PlaceHolder="YYYY-MM-DD"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-3">
                    <asp:Label ID="lblCliente" runat="server" Text="Ingresar Producto" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3 align-self-end">
                    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mx-2" OnClick="btnFiltrar_Click" />
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
                </div>
            </div>

            <asp:Label ID="lblError" runat="server" Text="" CssClass="form-label"></asp:Label>

        </div>
    </div>
    <div class="row">
            <div class="col">
                <div class="card shadow p-4">
                    <h3 class="text-center mb-4">Registro de Compras</h3>
                    <asp:GridView ID="gvDetalleCompras" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" />
                            <asp:BoundField DataField="Proveedor" HeaderText="Proveedor" />
                            <asp:BoundField DataField="Producto" HeaderText="Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                            <asp:BoundField DataField="TotalCompra" HeaderText="Total Compra" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>

</asp:Content>
