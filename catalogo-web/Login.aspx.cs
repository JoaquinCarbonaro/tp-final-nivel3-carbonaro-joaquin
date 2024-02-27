using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace catalogo_web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            UserNegocio negocio = new UserNegocio();
            try
            {
                //if (Validacion.validaTextoVacio(txtEmail) || Validacion.validaTextoVacio(txtPassword))
                //{
                //    Session.Add("error", "Debes completar ambos campos");
                //    Response.Redirect("Error.aspx");
                //}

                user.Email = txtEmail.Text;
                user.Pass = txtPassword.Text;
                if (negocio.Login(user))
                {
                    Session.Add("user", user);
                    Response.Redirect("MiPerfil.aspx", false);
                }
                else
                {
                    Session.Add("error", "User o Password incorrecto.");
                    Response.Redirect("Error.aspx", false);
                }
            }
            catch (System.Threading.ThreadAbortException) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        //private void Page_Error(object sender, EventArgs e)
        //{
        //    Exception exc = Server.GetLastError();

        //    Session.Add("error", exc.ToString());
        //    Server.Transfer("Error.aspx");
        //}
    }
}