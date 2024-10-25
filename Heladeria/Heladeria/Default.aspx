<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Heladeria._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        
         <div class="login-box"><h2>Iniciar Sesión</h2> </div>
       
        
        <div class="login-box","text-center">
            <label for="username">Usuario</label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="input-field" placeholder="Ingrese su usuario"></asp:TextBox>

            <label for="password">Contraseña</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="input-field" placeholder="Ingrese su contraseña"></asp:TextBox>

            <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="login-button" OnClick="btnLogin_Click" />
        </div>
    </div>

</asp:Content>
