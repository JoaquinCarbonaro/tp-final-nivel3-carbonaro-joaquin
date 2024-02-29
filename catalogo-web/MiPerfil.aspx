<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="catalogo_web.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script>
     function validar() {
         const txtApellido = document.getElementById("txtApellido");
         const txtNombre = document.getElementById("txtNombre");

         // Validación para el campo Apellido
         if (txtApellido.value.trim() === "") {
             txtApellido.classList.add("is-invalid");
             txtApellido.classList.remove("is-valid");
         } else {
             txtApellido.classList.remove("is-invalid");
             txtApellido.classList.add("is-valid");
         }

         // Validación para el campo Nombre
         if (txtNombre.value.trim() === "") {
             txtNombre.classList.add("is-invalid");
             txtNombre.classList.remove("is-valid");
         } else {
             txtNombre.classList.remove("is-invalid");
             txtNombre.classList.add("is-valid");
         }

         // Si alguno de los campos está vacío, retorna falso
         if (txtApellido.value.trim() === "" || txtNombre.value.trim() === "") {
             return false;
         }

         // Si ambos campos tienen contenido, retorna verdadero
         return true;
     }
 </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="text-center m-5"> Mi Perfil</h1>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8">
                </asp:TextBox>
            </div>
        </div>
        
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClientClick="return validar()" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>
</asp:Content>
