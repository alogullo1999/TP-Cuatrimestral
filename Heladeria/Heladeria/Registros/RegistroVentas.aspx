<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"  CodeBehind="RegistroVentas.aspx.cs" Inherits="Heladeria.Registros.RegistroVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-center">
                <div class="row mb-3">

                    <div class="col-md-3">
                        <asp:Label ID="lblFecha" runat="server" Text="Fecha de Venta:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtFechaVenta" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:Label ID="lblCliente" runat="server" Text="ID Cliente:" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtIdCliente" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-3 align-self-end">
                        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" CssClass="btn btn-primary mx-2" OnClick="btnFiltrar_Click" />
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col">
                <div class="card shadow p-4">
                    <h3 class="text-center mb-4">Registro de Ventas</h3>
                    <asp:GridView ID="gvDetalleVentas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="IdVenta" HeaderText="ID Venta" />
                            <asp:BoundField DataField="FechaVenta" HeaderText="Fecha de Venta" />
                            <asp:BoundField DataField="IdEmpleado" HeaderText="ID Empleado" />
                            <asp:BoundField DataField="IdCliente" HeaderText="ID Cliente" />
                            <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                            <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" />
                            <asp:BoundField DataField="TotalVenta" HeaderText="Total Venta" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
