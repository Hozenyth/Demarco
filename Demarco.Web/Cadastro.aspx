<%@ Page Title="Cadastro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="Demarco.Web.Cadastro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Cadastro</h2>
        <asp:Label ID="lblMensagem" runat="server" CssClass="text-danger"></asp:Label>
        
        <div class="form-group">
            <label for="txtNome">Nome:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtUsuario">Usuário (e-mail):</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
        </div>

        <div class="form-group">
            <label for="txtSenha">Senha:</label>
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control" TextMode="Password" />
        </div>

        <asp:Button ID="btnCadastrar" runat="server" CssClass="btn btn-success mt-2" Text="Cadastrar" OnClick="btnCadastrar_Click" />

        <br /><br />
        <asp:LinkButton ID="btnVoltarLogin" runat="server" CssClass="btn btn-link" OnClick="btnVoltarLogin_Click">
            Já tem conta? Voltar ao login
        </asp:LinkButton>
    </div>

     <div class="mensagens">
      <asp:Literal ID="ltMensagemSucesso" runat="server" EnableViewState="false" />
      <asp:Literal ID="ltMensagemError" runat="server" />
     </div>
</asp:Content>
