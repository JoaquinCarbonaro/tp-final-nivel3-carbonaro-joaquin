using dominio;
using negocio;
using presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catalogo_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!negocio.Seguridad.sesionActiva(Session["user"]))
            {
                Response.Redirect("Login.aspx");
            }

            User user = (User)Session["user"];
            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id) && int.TryParse(id, out int idArticulo))
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                Favorito nuevo = new Favorito();

                nuevo.IdUser = user.Id;
                nuevo.IdArticulo = int.Parse(id);

                negocio.insertarNuevoFavorito(nuevo);
            }

            ListaArticulo = new List<Articulo>();

            if (user != null)
            {
                FavoritoNegocio negocio = new FavoritoNegocio();
                List<int> idArticulosFavoritos = negocio.listarFavUserId(user.Id);

                if (idArticulosFavoritos.Count > 0)
                {
                    ArticuloNegocio articulo = new ArticuloNegocio();
                    ListaArticulo = articulo.listarArtId(idArticulosFavoritos);

                    repRepetidor.DataSource = ListaArticulo;
                    repRepetidor.DataBind();
                }
            }else
            {
                Session.Add("error", "No se han podido cargar los articulos favoritos.");
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnEliminarFav_Click(object sender, EventArgs e)
        {
            User user = (User)Session["user"];
            FavoritoNegocio negocio = new FavoritoNegocio();

            // Obtener el IdArticuloFav del botón que se hizo click
            int idArticulo = int.Parse(((Button)sender).CommandArgument);

            // Obtener el IdUser del usuario logueado
            int idUser = user.Id;

            // Eliminar el registro de la tabla FAVORITOS, solo si pertenece al usuario logueado
            negocio.eliminarFavorito(idArticulo, idUser);

            //actualizar la pagina: 
            Page_Load(sender, e);
        }
    }
}