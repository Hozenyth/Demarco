<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demarco.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Desafio Demarco</h1>
        <p class="lead">Bem Vindo ao desafio técnico da Demarco! Esse desafio foi criado para conhecer suas habilidades e identificarmos se estão alinhadas a necessidade da vaga que você está concorrendo. </p>
        <p><a href="http://demarco.com.br/" class="btn btn-primary btn-lg">Conheça a Demarco &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Especificação</h2>
            <p>
                Leia atentamente a especificação, desenvolva o máximo possível dos requisitos especificados, os requisitos não funcionais contam como bônus na sua avaliação.
            </p>
            <p>
                <a class="btn btn-default" href="EF – Desafio Demarco.pdf">Especificação &raquo;</a>
            </p>
        </div>
        <div class="col-md-6">
            <h2>Começar</h2>
            <p>
                Acesse a tela do desafio, lembre de levantar a API que está na soluction Demarco, Demarco.API, ela deve responder na porta 44346.
                A aplicação está utilizando SQLLite, a base está no arquivo Demarco.db dentro da pasta Demarco.
            </p>
            <p>
                <a class="btn btn-default" href="Empregado">Cadastro Empregado &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
