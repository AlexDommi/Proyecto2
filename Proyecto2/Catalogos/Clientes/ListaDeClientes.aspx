<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaDeClientes.aspx.cs" Inherits="Proyecto2.Catalogos.Clientes.ListaDeClientes"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width: 800px;">
        <div class="row mb-3">
            <div class="col-6">
                <asp:Label ID="lblId" runat="server">Id</asp:Label>
                <asp:TextBox ClientIDMode="Static" ID="txtId" runat="server" placeholder="Id" CssClass="form-control" ValidateRequestMode="Disabled"/>
            </div>
            <div class="col-6">
                <asp:Label ID="lblNombre" runat="server">Nombre</asp:Label>
                <asp:TextBox ClientIDMode="Static" ID="txtNombre" runat="server" placeholder="Nombre" MaxLength="100" CssClass="form-control" ValidateRequestMode="Disabled" />
            </div>
        </div>

        <div class="row mb-3">
            <div class="col-6">
                <asp:Label ID="lblRazonSocial" runat="server">Razon Social</asp:Label>
                <asp:TextBox ClientIDMode="Static" ID="txtRazonSocial" runat="server" placeholder="Razón Social" MaxLength="200" CssClass="form-control" ValidateRequestMode="Disabled"/>
            </div>
            <div class="col-6">
                <asp:Label ID="lblCorreo" runat="server">Correo</asp:Label>
                <asp:TextBox ClientIDMode="Static" ID="txtCorreo" runat="server" placeholder="Correo" MaxLength="100" CssClass="form-control" ValidateRequestMode="Disabled" />
            </div>
        </div>
        
        <div class="row mb-3">
            <div class="col-6">
                <asp:Label ID="lblTelefono" runat="server">Telefono</asp:Label>
                <asp:TextBox ClientIDMode="Static" ID="txtTelefono" runat="server" placeholder="Telefono" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
            </div>
            <div class="col-6">
                <asp:Label ID="lblDireccion" runat="server">Dirección</asp:Label>
                <asp:TextBox ClientIDMode="Static" ID="txtDireccion" runat="server" placeholder="Direccion" MaxLength="200" CssClass="form-control" ValidateRequestMode="Disabled"/>
            </div>
        </div>
        

        <div class="row mb-3">
            <div class="col-4">
                <asp:Button ClientIDMode="Static" ID="btnRegistrarNuevo" CssClass="btn btn-success btn-sm w-100" Width="200px" Text="Registrar Nuevo Cliente" runat="server" OnClick="btnRegistrarNuevo_Click"/>
            </div>
        </div>

        

        </div>
    <div class="container text-center">
        <div class="row mb-3">
            <%--<div class="col-3 align-text-center">--%>
                 <div class="col-12">
                    <h1>Clientes</h1>
                    <hr />
                </div>
                <div class="col-4">
                    <asp:Button ClientIDMode="Static" ID="btnNuevo" CssClass="btn btn-success btn-sm w-100" Width="200px" Text="Nuevo" runat="server" UseSubmitBehavior="false" OnClientClick="return false;"/> <%--OnClick="btnNuevo_Click" --%>
                </div>
                <div class="col-4">
                    <asp:Button ClientIDMode="Static" ID="btnEditar" CssClass="btn btn-primary btn-sm w-100" Width="200px" Text="Guardar Cambios" runat="server" OnClick="btnEditar_Click"/>
                </div>
                <div class="col-4">
                    <asp:Button ClientIDMode="Static" ID="btnEliminar" CssClass="btn btn-danger btn-sm w-100" Width="200px" Text="Eliminar" runat="server" OnClick="btnEliminar_Click" />
                </div>

            <%--</div>--%>
        </div>
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="form-group">
                    <div class="table-responsive">
                        <%--ButtonField - Boton personalizado al gusto--%>
                        <asp:GridView
                            ID="GVClientes"
                            runat="server"
                            CssClass="table table-bordered table-striped table-condensed mt-3"
                            AutoGenerateColumns="false"
                            DataKeyNames="CTECLI_CODIGO_K"
                            OnSelectedIndexChanged="GVClientes_SelectedIndexChanged"
                            >

                        <Columns>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button 
                                        ClientIDMode="Static"
                                        ID="btnSeleccionar" 
                                        runat="server" 
                                        CssClass="btn btn-success btn-xs btnSeleccionar"
                                        CommandName="Select" 
                                        Text="Seleccionar" />
                                </ItemTemplate>
                            </asp:TemplateField>


                            <%--<asp:ButtonField ButtonType="Button" CommandName="Select" ShowHeader="true" Text="Seleccionar" ControlStyle-CssClass="btn btn-success btn-xs">
                                <ItemStyle Width="70 px" />
                            </asp:ButtonField>--%>

                             <asp:BoundField
                                 DataField="CTECLI_CODIGO_K"
                                 HeaderText="Nombre"
                                 ItemStyle-Width="50px"
                                 SortExpression="CTECLI_CODIGO_K" />

                             <%--Nombre--%>
                             <asp:BoundField
                                 DataField="CTECLI_NOMBRE"
                                 HeaderText="Nombre"
                                 ItemStyle-Width="50px"
                                 SortExpression="CTECLI_NOMBRE" />

                             <%--Razon Social--%>
                             <asp:BoundField
                                 DataField="CTECLI_RAZONSOCIAL"
                                 HeaderText="Razon Social"
                                 ItemStyle-Width="50px"
                                 SortExpression="CTECLI_RAZONSOCIAL" />

                             <%--Correo--%>
                             <asp:BoundField
                                 DataField="CTECLI_CORREO"
                                 HeaderText="Correo"
                                 ItemStyle-Width="50px"
                                 SortExpression="CTECLI_CORREO" />

                             <%--Telefono--%>
                             <asp:BoundField
                                 DataField="CTECLI_TELEFONO"
                                 HeaderText="Telefono"
                                 ItemStyle-Width="50px"
                                 SortExpression="CTECLI_TELEFONO" />

                             <%--Direccion--%>
                             <asp:BoundField
                                 DataField="CTECLI_DIRECCION"
                                 HeaderText="Direccion"
                                 ItemStyle-Width="50px"
                                 SortExpression="CTECLI_DIRECCION" />
                        </Columns>
                        </asp:GridView>
        
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../../Scripts/ListaDeClientes.js"></script>   
</asp:Content>
