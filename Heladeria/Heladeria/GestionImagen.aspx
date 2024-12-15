<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionImagen.aspx.cs" Inherits="Heladeria.GestionImagen" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2 class="text-center">Gestión de Imágenes</h2>

       <div class="row">
    <div class="col text-center">
        <asp:DropDownList ID="ddlIdProducto" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 200px;"></asp:DropDownList>

        <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 300px;" Placeholder="Pega el enlace de la imagen"></asp:TextBox>

        <asp:Button ID="btnSubirLink" runat="server" Text="Guardar Enlace" CssClass="btn btn-success mx-2" OnClick="btnSubirLink_Click" />

        <asp:TextBox ID="txtIdImagen" runat="server" CssClass="form-control d-inline-block mx-2" Style="width: 300px;" Placeholder="Ingrese ID Imagen para eliminar"></asp:TextBox>

        <asp:Button ID="btnEliminarImagen" runat="server" Text="Eliminar" CssClass="btn btn-danger mx-2" OnClick="btnEliminarImagen_Click" />



    </div>
</div>

<div class="row mt-2">
    <div class="col text-center">
        <asp:Label ID="Label1" runat="server" CssClass="text-danger" />
    </div>
</div>

        <div class="row mt-2">
            <div class="col text-center">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col">
                <asp:GridView ID="gvImagenes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID Imagen" />
                        <asp:BoundField DataField="IdProducto" HeaderText="ID Producto" />
                        <asp:BoundField DataField="NombreProducto" HeaderText="Nombre del Producto" />
                        <asp:BoundField DataField="UrlImagen" HeaderText="ImagenUrl" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <img src='<%# Eval("UrlImagen") %>' alt="Imagen" style="width: 100px; height: 100px;" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
