using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class GestionarCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarCategoria();
            }
        }


        private void listarCategoria()
        {


            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            List<Categoria> listaCategoria = categoriaNegocio.listarCategoria();


            gvCategoria.DataSource = listaCategoria;
            gvCategoria.DataBind();


        }


        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Escribe Categoria para agregar');", true);
                    return;
                }

                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Categoria nuevaCategoria = new Categoria { Nombre = txtCategoria.Text };

                categoriaNegocio.Agregar(nuevaCategoria);
                listarCategoria();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al agregar la categoria: {ex.Message}');", true);
            }
        }






        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtIdCategoria.Text))
            {
                string nombreMarca = txtCategoria.Text.Trim();

                try
                {
                    modificar.Visible = true;
                }

                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, ingrese el nombre de la marca a modificar.');", true);
            }
        }


        protected void btnAceptarModificacion_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNuevoNombre.Text))
            {
                int idCategoria;

                if (int.TryParse(txtIdCategoria.Text, out idCategoria))
                {
                    try
                    {

                        Categoria categoria = new Categoria
                        {
                            IdCategoria = idCategoria,
                            Nombre = txtNuevoNombre.Text.Trim()
                        };

                        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                        categoriaNegocio.Modificar(categoria);

                        listarCategoria();
                        txtIdCategoria.Text = "";
                        txtNuevoNombre.Text = "";

                        modificar.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al modificar la marca: {ex.Message}');", true);
                    }
                }

            }

        }





        protected void btnEliminarCategoria_Click(object sender, EventArgs e)

        {
            if (!string.IsNullOrEmpty(txtCategoria.Text))
            {
                int idMarca;

                if (int.TryParse(txtCategoria.Text, out idMarca))
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();

                    marcaNegocio.Eliminar(idMarca);

                    listarCategoria();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, ingrese un ID.');", true);
                }
            }

        }

    }
}
  


