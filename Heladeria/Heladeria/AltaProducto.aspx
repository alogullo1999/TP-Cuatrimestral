<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaProducto.aspx.cs" Inherits="Heladeria.AltaProducto" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Registro de Nuevo Producto</h2>
                    <div class="form-group">
                        <label for="txtCodigo">Código:</label>
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="txtNombre">Nombre:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <label for="txtPrecio">Precio:</label>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" TextMode="Number" />
                    </div>

                    <div class="form-group">
                        <label for="txtDescripcion">Descripción:</label>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
                    </div>



                    <div class="form-group">
                        <label for="ddlMarca">Marca:</label>
                        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control">
     
                        </asp:DropDownList>
                    </div>



                    <div class="form-group">
                        <label for="ddlProveedor">Proveedor:</label>
                        <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control">
           
                        </asp:DropDownList>
                    </div>


                    <div 
                        class="form-group">
                        <label for="ddlCategoria">Categoría:</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">
                      
                        </asp:DropDownList>

                    </div>
                    
                    <div class="form-group">
                        <label for="ddlImagen">URL de Imagen:<label for="ddlImagenes">Seleccionar Imagen:</label></label>
                        <asp:DropDownList ID="ddlImagen" runat="server" CssClass="form-control">
                    
                        </asp:DropDownList>
                    </div>


                    <div class="form-group">
                         <asp:FileUpload ID="FileUpload1" runat="server" />
&nbsp;<label for="txtDescripcion"><asp:Image ID="Image1" runat="server" Height="179px" Width="223px" />
                         </label>
                    </div>






                    <div class="text-center">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                    </div>

                    <div class="text-center">
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    </div>

                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
