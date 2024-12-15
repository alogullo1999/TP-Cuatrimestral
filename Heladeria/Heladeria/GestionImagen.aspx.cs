using System;
using System.Collections.Generic;
using System.IO;
using negocio;
using dominio;
using Microsoft.Ajax.Utilities;

namespace Heladeria
{
    public partial class GestionImagen : System.Web.UI.Page
    {
        ImagenNegocio imagenNegocio = new ImagenNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarIdProductos();
                listarImagenes();
            }
        }



        private void CargarIdProductos()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();
            ddlIdProducto.DataSource = productoNegocio.listarProducto();
            ddlIdProducto.DataTextField = "Nombre";
            ddlIdProducto.DataValueField = "IdProducto";
            ddlIdProducto.DataBind();
        }


        private void listarImagenes()
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            List<Imagen> listaImagen = imagenNegocio.listarImagen();


            gvImagenes.DataSource = imagenNegocio.listarImagen();
            gvImagenes.DataBind();
        }

        protected void btnSubirLink_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtImagenUrl.Text) && ddlIdProducto.SelectedValue != null)
                {


                   
                    int idProducto = int.Parse(ddlIdProducto.SelectedValue);
                    string urlImagen = txtImagenUrl.Text;

                    if (!imagenNegocio.ExisteImagenParaProducto(idProducto))

                    {
                        imagenNegocio.Agregar(idProducto, urlImagen);

                        lblError.Text = "Enlace guardado con éxito.";
                        lblError.CssClass = "text-success";

                        txtImagenUrl.Text = "";
                        listarImagenes();
                    }
                    else
                    {
                        lblError.Text = "Ya existe imagen para este producto";
                        lblError.CssClass = "text-danger";
                    }
                }
                else
                {
                    lblError.Text = "Ingrese un enlace válido y seleccione un producto.";
                    lblError.CssClass = "text-danger";
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar el enlace: " + ex.Message;
                lblError.CssClass = "text-danger";
            }
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {

                if (!string.IsNullOrEmpty(txtIdImagen.Text))
                {

                    int idImagen = int.Parse(txtIdImagen.Text);

                    ImagenNegocio imagenNegocio = new ImagenNegocio();

                    imagenNegocio.Eliminar(idImagen);

                    lblError.Text = "Imagen eliminada correctamente.";
                    lblError.CssClass = "text-success";

                    txtIdImagen.Text = "";
                    listarImagenes();
                }
                else
                {
                    lblError.Text = "Por favor, ingrese un ID válido.";
                    lblError.CssClass = "text-danger";
                }
            }
        }
    }
