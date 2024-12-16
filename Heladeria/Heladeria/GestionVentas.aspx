<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionVentas.aspx.cs" Inherits="Heladeria.GestionVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Ventas</h2>
        

    <div class="container">
        <div class="card shadow p-4 mb-4">
            <div class="row">


                <div class="col-md-4">
                    <label for="ddlCliente">Cliente:</label>
                    <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                     <label for="ddlEmpleado">Empleado:</label>
                     <asp:DropDownList ID="ddlEmpleado" runat="server" CssClass="form-control">
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
                    <label for="txtSabores">Sabores:</label>
                    <asp:TextBox ID="txtSabores" runat="server" CssClass="form-control" />
              </div>

                 <div class="col-md-2">
                     <label for="txtPrecioUnitario">Precio:</label>
                     <asp:TextBox ID="txtPrecioUnitario" runat="server" CssClass="form-control" />
                 </div>



                
                <div class="text-center mt-4">
                    <asp:Button ID="btnRealizarVenta" runat="server" Text="Agregar producto" CssClass="btn btn-primary" OnClick="btnRealizarVenta_Click" />
                </div>

                 <div class="col-md-2">
                <asp:Button ID="btnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn btn-success" OnClick="btnFinalizarVenta_Click" />
                   </div>
         </div>

        </div>
              <div class="text-center">
                  <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
              </div>
    </div>
         <p> </p>

        <h4 class="text-center">Resumen de Venta</h4>
        <p> </p>
 <div class="col">
        <asp:GridView ID="gvResumenVenta" runat="server" AutoGenerateColumns="True" CssClass="table table-striped table-bordered">

        </asp:GridView>
    </div>


    </div>
</asp:Content>