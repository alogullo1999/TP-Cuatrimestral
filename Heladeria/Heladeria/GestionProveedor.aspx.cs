using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using negocio;
using dominio;

namespace Heladeria
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
        }

        private void CargarProveedores()
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            List<Proveedor> listaProveedores = proveedorNegocio.listar();
            gvProveedores.DataSource = listaProveedores;
            gvProveedores.DataBind();
        }


        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
        

            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dni = txtDni.Text.Trim();
            string ciudad = txtCiudad.Text.Trim();

            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            // Verificar duplicados por Id o Nombre
            if (proveedorNegocio.ExisteProveedor( nombre))
            {
                Response.Write("<script>alert('El ID o Nombre del proveedor ya existe');</script>");
            }
            else
            {
                // Insertar el nuevo proveedor
                Proveedor nuevoProveedor = new Proveedor
                {
                    Nombre = nombre,
                    Email = email,
                    Dni = dni,
                    Ciudad = ciudad
                };

                proveedorNegocio.AgregarProveedor(nuevoProveedor);
                Response.Write("<script>alert('Proveedor agregado exitosamente');</script>");

                // Recargar el GridView
                CargarProveedores();
            }
        }





    }
}