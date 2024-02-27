using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using dominio;
using negocio;
using presentacion;

namespace catalogo_web
{
    public partial class FormularioArticulo : System.Web.UI.Page
    {
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmaEliminacion = false;
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    MarcaNegocio MarcaNegocio = new MarcaNegocio();
                    List<Marca> MarcaLista = MarcaNegocio.listar();

                    CategoriaNegocio CategoriaNegocio = new CategoriaNegocio();
                    List<Categoria> CategoriaLista = CategoriaNegocio.listar();

                    ddlMarca.DataSource = MarcaLista;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataBind();

                    ddlCategoria.DataSource = CategoriaLista;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataBind();
                }

                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Articulo seleccionado = (negocio.listarConId(id))[0];

                    //Session.Add("artSeleccionado", seleccionado);

                    txtId.Text = id;
                    txtCodigo.Text = seleccionado.Codigo;
                    txtNombre.Text = seleccionado.Nombre;
                    txtDescripcion.Text = seleccionado.Descripcion;

                    ddlMarca.SelectedValue = seleccionado.Marca.Id.ToString();

                    ddlCategoria.SelectedValue = seleccionado.Categoria.Id.ToString();

                    txtPrecio.Text = seleccionado.Precio.ToString();

                    txtImagenUrl.Text = seleccionado.ImagenUrl;
                    txtImagenUrl_TextChanged(sender, e);

                    //if (!seleccionado.Activo)
                    //    btnInactivar.Text = "Reactivar";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Articulo nuevo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                nuevo.Codigo = txtCodigo.Text;
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);

                nuevo.Precio = decimal.Parse(txtPrecio.Text);
                nuevo.ImagenUrl = txtImagenUrl.Text;


                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(txtId.Text);
                    negocio.modificar(nuevo);
                }
                else
                    negocio.agregar(nuevo);

                Response.Redirect("ArticulosLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgArticulo.ImageUrl = txtImagenUrl.Text;
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }
        protected void btnConfirmaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("ArticulosLista.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }
        }
    }
}