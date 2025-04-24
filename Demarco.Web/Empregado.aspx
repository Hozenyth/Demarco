
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Empregado.aspx.cs" Inherits="Demarco.Web.Empregado" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
            <div class="col-md-12">
                <h2>Empregados</h2>             
                <div style="clear: both; padding-top: 10px; align:center">
                    <asp:GridView ID="grv" runat="server" runat="server" EnableModelValidation="True"
                        GridLines="None" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"                                              
                        OnRowCommand="grv_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="CPF" HeaderText="CPF"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="Nome" HeaderText="Nome"
                                HeaderStyle-HorizontalAlign="Left" />
                            <asp:BoundField DataField="DataNascimento" HeaderText="Nascimento"
                                HeaderStyle-HorizontalAlign="Left" />
                           
    <asp:TemplateField HeaderText="Ações">
        <ItemTemplate>
            <asp:LinkButton ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("ID") %>' CssClass="btn btn-sm btn-outline-primary" ToolTip="Editar">
                <i class="fas fa-edit"></i>
            </asp:LinkButton>
        </ItemTemplate>
    </asp:TemplateField>
                        </Columns>
                        <HeaderStyle CssClass="thead-dark" />
                    </asp:GridView>                       
                   <asp:Button ID="btnNovo" runat="server" CssClass="btn btn-primary mb-3 btn-margin-bottom"
                   Text="Cadastrar Empregado" OnClientClick="$('#modalCadastro').modal('show'); return false;" />
                </div>
            </div>
        </div>

    <!-- modal cadastrar novo empregado -->
    <div class="modal fade" id="modalCadastro" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                     <button type="button" class="close" data-dismiss="modal" aria-label="Fechar">
                     <span aria-hidden="true">&times;</span>
                     </button>
                    <h5 class="modal-title">Cadastrar Empregado</h5>                  
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="txtNome" runat="server" CssClass="form-control mb-2" placeholder="Nome" />
                    <asp:TextBox ID="txtCPF" runat="server" CssClass="form-control mb-2" placeholder="CPF" />
                   <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="form-control mb-2" placeholder="Data de Nascimento" TextMode="Date" />
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" CssClass="btn btn-success"
                        OnClick="btnCadastrar_Click" />
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Fechar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal de Edição de Empregado -->
<div class="modal fade" id="modalEditarEmpregado" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Editar Empregado</h5>
        <button type="button" class="close" data-dismiss="modal">
          <span>&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <asp:HiddenField ID="hfEmpregadoId" runat="server" />
        <div class="form-group">
          <label for="txtNome">Nome</label>
          <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
          <label for="txtCPF">CPF</label>
          <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" />
        </div>
        <div class="form-group">
          <label for="txtDataNascimento">Data de Nascimento</label>         
          <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" TextMode="Date" />
        </div>
      </div>
      <div class="modal-footer">
        <asp:Button ID="btnSalvarEdicao" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnSalvarEdicao_Click" />
      </div>
    </div>
  </div>
</div>
 
 <div class="mensagens">
      <asp:Literal ID="ltMensagemSucesso" runat="server" EnableViewState="false" />
      <asp:Literal ID="ltMensagemError" runat="server" />
 </div>



</asp:Content>
