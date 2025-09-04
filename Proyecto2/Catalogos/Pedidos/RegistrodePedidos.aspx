<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrodePedidos.aspx.cs" Inherits="Proyecto2.Catalogos.Pedidos.RegistrodePedidos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center" style="max-width: 800px;">
        <div class="row mb-3">
            <div class="col-12">
                <h1>Nuevo Pedido</h1>
                <hr />
            </div>
        </div>
    </div>
    <div class="container" style="max-width: 800px;">
    <div class="row mb-3">
        <div class="col-6">
            <asp:Label ID="lblCliente" runat="server">Cliente</asp:Label>
            <asp:DropDownList ID="DDLCliente" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-6">
            <asp:Label ID="lblFecha" runat="server">Fecha</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtFecha" runat="server" placeholder="Fecha" MaxLength="100" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
    </div>

    <div class="row mb-3">
        <div class="col-6">
            <asp:Label ID="lblObservaciones" runat="server">Observaciones</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtObservaciones" runat="server" placeholder="Observaciones" MaxLength="200" CssClass="form-control" ValidateRequestMode="Disabled"/>
        </div>
        <div class="col-6">
            <asp:Label ID="lblEstado" runat="server">Estado</asp:Label>
            <asp:DropDownList ID="DDLEstado" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
    </div>
    <div class="row mb-3">
        <div class="col-6">
        </div>
    <div class="col-6">
        <br />
        <asp:Button ClientIDMode="Static" ID="btnRegistrarPedido" CssClass="btn btn-dark btn-sm w-100" Width="200px" Text="Registrar Pedido" runat="server"/>
    </div>
    
</div>
    </div>
<div class="container text-center">
    <div class="row mb-3">
        <%--<div class="col-3 align-text-center">--%>
             <div class="col-12">
                <h1>Detalle</h1>
                <hr />
            </div>
    </div>
    <div class="row">
            <div class="col-3">
            <asp:Label ID="Label1" runat="server">Producto</asp:Label>
            <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-3">
            <asp:Label ID="Label2" runat="server">Cantidad</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="TextBox1" runat="server" placeholder="CodBarras" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-2">
            <asp:Label ID="Label3" runat="server">Pieza</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="TextBox2" runat="server" placeholder="CodBarras" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-2">
            <asp:Label ID="Label4" runat="server">Precio</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="TextBox3" runat="server" placeholder="CodBarras" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-2">
            <asp:Label ID="Label5" runat="server">Accion</asp:Label>
            <asp:Button ClientIDMode="Static" ID="btnAgregarItem" CssClass="btn btn-success btn-sm w-100" Width="200px" Text="Agregar Item" runat="server" UseSubmitBehavior="false" OnClientClick="return false;"/> 
        </div>  
    </div>
    
    <br />

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
                        >
                        <%--<asp:GridView
                        ID="GridView1"
                        runat="server"
                        CssClass="table table-bordered table-striped table-condensed mt-3"
                        AutoGenerateColumns="false"
                        DataKeyNames="PRODUC_CODIGO_K"
                        OnSelectedIndexChanged="GVProductos_SelectedIndexChanged"
                        >--%>
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
