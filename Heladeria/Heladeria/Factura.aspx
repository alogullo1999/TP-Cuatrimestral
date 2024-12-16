<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Factura.aspx.cs" Inherits="Heladeria.Factura" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h1 class="text-center mb-4">Factura</h1>


        <div class="mb-4">
            <label for="txtIdVenta">Ingrese el ID de la Venta:</label>
            <asp:TextBox ID="txtIdVenta" runat="server" CssClass="form-control" Width="200px"></asp:TextBox>
            <asp:Button ID="btnGenerarFactura" runat="server" Text="Generar Factura" CssClass="btn btn-primary mt-2" OnClick="btnGenerarFactura_Click" />
        </div>

                    <div class="text-center">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    </div>


        <div class="mb-4">
            <h4>Número de Factura: <asp:Label ID="lblNumeroFactura" runat="server"></asp:Label></h4>
            <h5>Fecha de Venta: <asp:Label ID="lblFechaVenta" runat="server"></asp:Label></h5>
        </div>

        <div class="mb-4">
            <h5>Cliente:</h5>
            <p>
                Nombre: <asp:Label ID="lblNombreCliente" runat="server"></asp:Label><br />
                Dirección: <asp:Label ID="lblCiudadCliente" runat="server"></asp:Label><br />
                Teléfono: <asp:Label ID="lblEmailCliente" runat="server"></asp:Label>
            </p>
        </div>


        <div class="mb-4">
            <h5>Detalle de Productos:</h5>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Cantidad</th>
                        <th>Precio Unitario</th>
                        <th>Total</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptDetalleProductos" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Producto") %></td>
                                <td><%# Eval("Cantidad") %></td>
                                <td><%# Eval("PrecioUnitario", "{0:C}") %></td>
                                <td><%# Eval("Subtotal", "{0:C}") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>


        <div class="text-end">
            <h5>Subtotal: <asp:Label ID="lblSubtotal" runat="server"></asp:Label></h5>
            <h5>IVA (21%): <asp:Label ID="lblIVA" runat="server"></asp:Label></h5>
            <h4>Total: <asp:Label ID="lblTotal" runat="server"></asp:Label></h4>
        </div>
    </div>
</asp:Content>
