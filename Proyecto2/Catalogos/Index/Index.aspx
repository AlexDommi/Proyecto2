<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Proyecto2.Catalogos.Clientes.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
<asp:Image ID="imgPreview" runat="server" class="img-fluid"  ImageUrl="~/Imagenes/Index/Lo bueno y saludable está aquí..png"/>
    <br />
    <br />
<div class="container">
        <div class="row">
            <div class="col-lg-3 col-md-6 mb-4">
                <div class="card">
                    <img src='<%= ResolveUrl("~/Imagenes/Index/1.png") %>' class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text...</p>
                    </div>
                </div>
            </div>

            <div class="col-lg-3 col-md-6 mb-4">
                <div class="card">
                    <img src='<%= ResolveUrl("~/Imagenes/Index/2.png") %>' class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text...</p>
                    </div>
                </div>
            </div>

            <div class="col-lg-3 col-md-6 mb-4">
                <div class="card">
                    <img src='<%= ResolveUrl("~/Imagenes/Index/3.png") %>' class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text...</p>
                    </div>
                </div>
            </div>

            <div class="col-lg-3 col-md-6 mb-4">
                <div class="card">
                    <img src='<%= ResolveUrl("~/Imagenes/Index/4.png") %>' class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text...</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
