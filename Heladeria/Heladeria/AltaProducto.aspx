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
                        <label for="ddlImagen">URL de Imagen:</label>
                        <asp:DropDownList ID="ddlImagen" runat="server" CssClass="form-control">
                    
                        </asp:DropDownList>
                    </div>


                    <div class="form-group">
                         <label for="ddlImagenes">Seleccionar Imagen:</label>
                          <asp:Repeater ID="rptImagenes" runat="server">
                                   <ItemTemplate>
                                    <div class="form-check">
                                    <input type="radio" name="imagenes" value='<%# Eval("Id") %>' class="form-check-input" />
                                    <img src='<%# Eval("UrlImagen") %>' alt="Imagen" style="width: 50px; height: 50px;" />
                                    </div>
                                 </ItemTemplate>
                         </asp:Repeater>
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
