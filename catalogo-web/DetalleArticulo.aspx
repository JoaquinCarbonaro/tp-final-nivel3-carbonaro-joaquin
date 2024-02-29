﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="catalogo_web.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center m-5">Detalles del producto</h1>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca: </label>
                <asp:TextBox runat="server" ID="txtMarca" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio: </label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <a href="Default.aspx">Regresar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control" AutoPostBack="true" />
            </div>
            <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                runat="server" ID="imgArticulo" Width="60%" />
        </div>
    </div>
</asp:Content>
