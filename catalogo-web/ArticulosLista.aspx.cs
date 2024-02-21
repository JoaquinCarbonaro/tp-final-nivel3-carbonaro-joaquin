using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using presentacion;

namespace catalogo_web
{
    public partial class CatalogoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvCatalogo.DataSource = negocio.listar();
            dgvCatalogo.DataBind();
        }
    }
}