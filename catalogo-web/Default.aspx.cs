using presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace catalogo_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListArticulo = negocio.listar();

            if (!IsPostBack)
            {
                repRepetidor.DataSource = ListArticulo;
                repRepetidor.DataBind();
            }
        }

        protected void btnFavorito_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument; //capturamos el id en la variable "valor"
        }
    }
}