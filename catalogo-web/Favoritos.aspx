<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="catalogo_web.Favoritos" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1"></asp:ScriptManager>
    <h1 class="text-center m-5">Articulos Favoritos</h1>

    <%if (Session["Favoritos"] == null)
        { %>
    <h3 class="text-center mb-5">Agregue aqui sus productos favoritos
    </h3>
    <% } %>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="DetalleArticulo.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                            <asp:Button ID="btnEliminarFav" CssClass="btn btn-primary" runat="server" Text="Eliminar"
                                CommandName="ArticuloId" CommandArgument='<%#Eval("Id")%>' OnClick="btnEliminarFav_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>