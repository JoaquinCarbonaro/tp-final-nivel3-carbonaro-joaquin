using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Seguridad.sesionActiva(Session["user"]))
            {
                // Si hay una sesión activa, obtener los detalles del usuario
                User user = (User)Session["user"];
                lblUser.Text = user.Email;

                // Verificar si el usuario tiene una imagen de perfil personalizada
                if (!string.IsNullOrEmpty(user.ImagenPerfil))
                {
                    imgAvatar.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
                else
                {
                    // Si no tiene una imagen de perfil personalizada, mostrar la imagen predeterminada
                    imgAvatar.ImageUrl = "https://www.shutterstock.com/image-vector/blank-avatar-photo-place-holder-600nw-1095249842.jpg";
                }
            }
            else if (!(Page is Login || Page is Registro || Page is Default || Page is Error || Page is DetalleArticulo))
            {
                // Si no hay una sesión activa y la página actual no es una de las páginas mencionadas,
                // redirigir al usuario a la página de inicio de sesión
                Response.Redirect("Login.aspx", false);
            }else
            {
                //mostrar la imagen predeterminada
                imgAvatar.ImageUrl = "https://www.shutterstock.com/image-vector/blank-avatar-photo-place-holder-600nw-1095249842.jpg";
            }
        }
        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}