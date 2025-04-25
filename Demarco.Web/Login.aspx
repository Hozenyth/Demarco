<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Demarco.Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Login</h2>
        <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger"></asp:Label>
        <div class="form-group">
            <label for="txtUsuario">Email:</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
            <label for="txtSenha">Senha:</label>
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" />
        </div>
        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary mt-2" Text="Entrar" OnClick="btnLogin_Click" />
       
        <br /><br />

         <asp:LinkButton ID="btnIrParaCadastro" runat="server" CssClass="btn btn-link" OnClick="btnIrParaCadastro_Click">
         Não tem conta? Cadastre-se
        </asp:LinkButton>

    </div>

     <div class="mensagens">
      <asp:Literal ID="ltMensagemSucesso" runat="server" EnableViewState="false" />
      <asp:Literal ID="ltMensagemError" runat="server" />
 </div>
</asp:Content>
