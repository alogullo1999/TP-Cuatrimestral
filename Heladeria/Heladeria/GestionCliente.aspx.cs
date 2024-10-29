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
    public partial class GestionCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientes();
            }
        }

        private void CargarClientes()
        {
           ClienteNegocio clienteNegocio = new ClienteNegocio();
           gvClientes.DataBind();
        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido=txtApellido.Text.Trim();
            string dni=txtDni.Text.Trim();
            string email=txtEmail.Text.Trim();
            string ciudad=txtCiudad.Text.Trim();

            ClienteNegocio clienteNegocio=new ClienteNegocio();

            if (clienteNegocio.ExisteCliente(nombre))
            {
                Response.Write("<script>alert('El id del cliente ya existe');</script>");
            }
            else
            {
                Cliente nuevoCliente = new Cliente()
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Dni = dni,
                    Email = email,
                    Ciudad = ciudad
                };

                clienteNegocio.AgregarCliente(nuevoCliente);
                Response.Write("<script>alert('Cliente fue agregado existosamente);</script>");
            }
        }
    }
}