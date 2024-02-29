using dominio;
using presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace catalogo_web
{
    public partial class DetalleArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Enabled = false;
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtMarca.Enabled = false;
            txtCategoria.Enabled = false;
            txtPrecio.Enabled = false;
            txtDescripcion.Enabled = false;
            txtImagenUrl.Enabled = false;

            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listarConId(id))[0];

                    Session.Add("artSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;

                    txtMarca.Text = seleccionado.Marca.Descripcion;

                    txtCategoria.Text = seleccionado.Categoria.Descripcion;

                    txtPrecio.Text = seleccionado.Precio.ToString();

                    // Verificar si la URL es una imagen válida
                    if (EsImagenValida(seleccionado.ImagenUrl))
                    {
                        imgArticulo.ImageUrl = seleccionado.ImagenUrl;
                    }
                    else
                    {
                        // Asignar la URL de la imagen por defecto si la URL no es válida
                        imgArticulo.ImageUrl = "https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png";
                    }
                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        private bool EsImagenValida(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                // Verificar si la URL contiene "https://" o ".jpg"
                if (url.Contains("https") || url.Contains(".jpg") || url.Contains(".png") || url.Contains(".gif"))
                {
                    return true; // Es considerada como imagen válida
                }
            }
            return false; // Por defecto, no es una imagen válida
        }
    }
}