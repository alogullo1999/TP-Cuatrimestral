using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class GestionarMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listarMarcas();
            }
        }


        private void listarMarcas()
        {


            MarcaNegocio marcaNegocio = new MarcaNegocio();
            List<Marca> listaMarcas = marcaNegocio.listarMarca();


            gvMarcas.DataSource = listaMarcas;
            gvMarcas.DataBind();


        }


        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Escribe marca para agregar');", true);
                    return;
                }

                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Marca nuevaMarca = new Marca { Nombre = txtMarca.Text };

                marcaNegocio.Agregar(nuevaMarca);
                listarMarcas();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al agregar la marca: {ex.Message}');", true);
            }
        }

        protected void btnModificarMarca_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtIdMarca.Text))
            {
                string nombreMarca = txtMarca.Text.Trim();

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
                int idMarca;

                if (int.TryParse(txtIdMarca.Text, out idMarca))
                {
                    try
                    {

                        Marca marca = new Marca
                        {
                            IdMarca = idMarca,
                            Nombre = txtNuevoNombre.Text.Trim()
                        };

                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        marcaNegocio.Modificar(marca); 

                        listarMarcas(); 
                        txtIdMarca.Text = ""; 
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





        protected void btnEliminarMarca_Click(object sender, EventArgs e)

        {
            if (!string.IsNullOrEmpty(txtMarca.Text))
            {
                int idMarca;

                if (int.TryParse(txtMarca.Text, out idMarca))
                {
                    MarcaNegocio marcaNegocio = new MarcaNegocio();

                    marcaNegocio.Eliminar(idMarca);

                    listarMarcas();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, ingrese un ID.');", true);
                }
            }

        }

    }
}
  




