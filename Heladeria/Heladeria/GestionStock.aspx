<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionStock.aspx.cs" Inherits="Heladeria.GestionStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    
    <div class="col">
        <asp:GridView ID="gvStock" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
            <Columns>
 
                <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                <asp:BoundField DataField="Nombre" HeaderText="Codigo" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad en Stock" />
                <asp:BoundField DataField="FechaActualizacion" HeaderText="Fecha de Actualización" />

            </Columns>
        </asp:GridView>
    </div>
</div>



</asp:Content>
