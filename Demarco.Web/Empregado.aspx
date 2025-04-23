
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Empregado.aspx.cs" Inherits="Demarco.Web.Empregado" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
            <div class="col-md-12">
                <h2>Empregados</h2>
                <div style="clear: both; padding-top: 10px; align:center">
                    <asp:GridView ID="grv" runat="server" runat="server" EnableModelValidation="True"
                        GridLines="None" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
                        Width="100%">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="CPF" HeaderText="CPF"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="DataNascimento" HeaderText="Nascimento"
                                HeaderStyle-HorizontalAlign="Left" />
                        </Columns>
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>
