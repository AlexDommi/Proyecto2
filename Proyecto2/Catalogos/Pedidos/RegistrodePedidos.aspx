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
        <asp:Button ClientIDMode="Static" ID="btnRegistrarPedido" CssClass="btn btn-dark btn-sm w-100" Width="200px" Text="Registrar Pedido" runat="server" OnClick="btnRegistrarPedido_Click"/>
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
            <asp:Label ID="lblProducto" runat="server">Producto</asp:Label>
            <asp:DropDownList ID="DDLProducto" CssClass="form-control" runat="server"></asp:DropDownList>
        </div>
        <div class="col-3">
            <asp:Label ID="lblCantidad" runat="server">Cantidad</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtCantidad" runat="server" placeholder="Cantidad" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-2">
            <asp:Label ID="lblPieza" runat="server">Pieza</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtPieza" runat="server" placeholder="Pieza" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-2">
            <asp:Label ID="lblPrecio" runat="server">Precio</asp:Label>
            <asp:TextBox ClientIDMode="Static" ID="txtPrecio" runat="server" placeholder="Precio" MaxLength="10" CssClass="form-control" ValidateRequestMode="Disabled" />
        </div>
        <div class="col-2">
            <asp:Label ID="lblAccion" runat="server">Accion</asp:Label>
            <asp:Button ClientIDMode="Static" ID="btnAgregarItem" CssClass="btn btn-success btn-sm w-100" Width="200px" Text="Agregar Item" runat="server" UseSubmitBehavior="false" OnClick="btnAgregarItem_Click"/> 
        </div>  
    </div>
    
    <br />

    <div class="row">
        <div class="col-md-12 col-md-offset-1">
            <div class="form-group">
                <div class="table-responsive">
                    <%--ButtonField - Boton personalizado al gusto--%>
                    <asp:GridView
                        ID="GVPedidos"
                        runat="server"
                        CssClass="table table-bordered table-striped table-condensed mt-3"
                        AutoGenerateColumns="false"
                        OnRowCommand="GVPedidos_RowCommand"
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
                                    ID="btnEliminarItem" 
                                    runat="server" 
                                    ItemStyle-Width="50px"
                                    CssClass="btn btn-danger btn-xs btnSeleccionar"
                                    CommandName="EliminarRow" 
                                    CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                    Text="Eliminar Item"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:BoundField
                             DataField="PRODUC_CODIGO_K"
                             HeaderText="Id"
                             ItemStyle-Width="300px"
                             SortExpression="PRODUC_CODIGO_K" />

                         <%--Nombre--%>
                         <asp:BoundField
                             DataField="PEDCTED_CANTIDAD"
                             HeaderText="Cantidad"
                             ItemStyle-Width="300px"
                             SortExpression="PEDCTED_CANTIDAD" />

                         <%--Razon Social--%>
                         <asp:BoundField
                             DataField="PEDCTED_CANTPZA"
                             HeaderText="Pieza"
                             ItemStyle-Width="300px"
                             SortExpression="PEDCTED_CANTPZA" />

                         <%--Correo--%>
                         <asp:BoundField
                             DataField="PEDCTED_PRECIO"
                             HeaderText="Precio"
                             ItemStyle-Width="300px"
                             SortExpression="PEDCTED_PRECIO" />
                         <asp:BoundField
                             DataField="TOTAL"
                             HeaderText="Total"
                             ItemStyle-Width="300px"
                             SortExpression="TOTAL" />
                    </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</div>

<script src="../../Scripts/ListaDeClientes.js"></script>   
</asp:Content>
