<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lista de Productos.aspx.cs" Inherits="Proyecto2.Catalogos.Lista_de_Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="max-width: 800px;">
    <div class="row mb-3">
        <div class="col-6">
            <asp:Label ID="lblId" runat="server">Id</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtId" runat="server" placeholder="Id" CssClass="form-control" ValidateRequestMode="Disabled"/>
        </div>
        <div class="col-6">
            <asp:Label ID="lblDescripcion" runat="server">Descripcion</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtDescripcion" runat="server" placeholder="Descripcion" MaxLength="100" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
    </div>

    <div class="row mb-3">
        <div class="col-6">
            <%--xxxxxxxxxxxxxxxxxxxxxx
                
                xxxxxxxxxxxxxxxxxxxxxxx--%>
            <asp:Label ID="lblDescCorta" runat="server">Desc Corta</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtDescCorta" runat="server" placeholder="Descripcion Corta" MaxLength="200" CssClass="form-control" ValidateRequestMode="Disabled"/>
        </div>
        <div class="col-6">
            <asp:Label ID="lblPeso" runat="server">Peso</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtPeso" runat="server" placeholder="Peso" MaxLength="100" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
    </div>
    
    <div class="row mb-3">
        <div class="col-6">
            <asp:Label ID="lblCodBarras" runat="server">Codigo de Barras</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtCodBarras" runat="server" placeholder="CodBarras" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-6">
            <asp:Label ID="lblEstado" runat="server">Estado</asp:Label>
            <asp:DropDownList ID="DDLEstado" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row mb-3">
    <div class="col-6">
        <asp:Label ID="lblObservaciones" runat="server">Observaciones</asp:Label>
        <asp:TextBox ClientIDMode="Static" ID="txtObservaciones" runat="server" placeholder="Observaciones" MaxLength="200" CssClass="form-control" ValidateRequestMode="Disabled"/>
    </div>
</div>

    <div class="row mb-3">
        <div class="col-4">
            <asp:Button ClientIDMode="Static" ID="btnRegistrarNuevo" CssClass="btn btn-success btn-sm w-100" Width="200px" Text="Registrar Nuevo Producto" runat="server" OnClick="btnRegistrarNuevo_Click"/>
        </div>
    </div>

    

    </div>
<div class="container text-center">
    <div class="row mb-3">
        <%--<div class="col-3 align-text-center">--%>
             <div class="col-12">
                <h1>Productos</h1>
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
                        ID="GVProductos"
                        runat="server"
                        CssClass="table table-bordered table-striped table-condensed mt-3"
                        AutoGenerateColumns="false"
                        DataKeyNames="PRODUC_CODIGO_K"
                        OnSelectedIndexChanged="GVProductos_SelectedIndexChanged"
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

                         <asp:BoundField
                             DataField="PRODUC_CODIGO_K"
                             HeaderText="Id"
                             ItemStyle-Width="50px"
                             SortExpression="PRODUC_CODIGO_K" />

                         <%--Nombre--%>
                         <asp:BoundField
                             DataField="PRODUC_DESCRIPCION"
                             HeaderText="Descripcion"
                             ItemStyle-Width="50px"
                             SortExpression="PRODUC_DESCRIPCION" />

                         <%--Razon Social--%>
                         <asp:BoundField
                             DataField="PRODUC_DESCCORTA"
                             HeaderText="DescCorta"
                             ItemStyle-Width="50px"
                             SortExpression="PRODUC_DESCCORTA" />

                         <%--Correo--%>
                         <asp:BoundField
                             DataField="PRODUC_PESO"
                             HeaderText="Peso"
                             ItemStyle-Width="50px"
                             SortExpression="PRODUC_PESO" />

                         <%--Direccion--%>
                         <asp:BoundField
                             DataField="PRODUC_OBSERVACIONES"
                             HeaderText="Observaciones"
                             ItemStyle-Width="50px"
                             SortExpression="PRODUC_OBSERVACIONES" />

                        <%--Direccion--%>
                        <asp:BoundField
                            DataField="PRODUC_CODIGO_BARRAS"
                            HeaderText="CodBarras"
                            ItemStyle-Width="50px"
                            SortExpression="PRODUC_CODIGO_BARRAS" />

                                                <%--Direccion--%>
                        <asp:BoundField
                            DataField="CFGEDO_CODIGO_K"
                            HeaderText="Estado"
                            ItemStyle-Width="50px"
                            SortExpression="CFGEDO_CODIGO_K" />
                    </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>

<script src="../../Scripts/ListaDeClientes.js"></script>   
</asp:Content>
