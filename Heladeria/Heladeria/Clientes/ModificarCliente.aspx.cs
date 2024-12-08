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
    public partial class ModificarCliente: System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idCliente"] != null)
                {
                    int idCliente = int.Parse(Request.QueryString["idCliente"]);
                    CargarCliente(idCliente);
                }
            }
        }

        private void CargarCliente(int idCliente)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = clienteNegocio.obtenerClientePorId(idCliente);

            if (cliente != null)
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDNI.Text = cliente.Dni;
                txtCiudad.Text = cliente.Ciudad;
                txtEmail.Text = cliente.Email;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('No se encontró un cliente con el ID proporcionado.');", true);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Por favor, complete todos los campos antes de guardar.');", true);
                return;
            }

            Cliente cliente = new Cliente
            {
                IdCliente = int.Parse(Request.QueryString["idCliente"]),
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Dni = txtDNI.Text,
                Ciudad = txtCiudad.Text,
                Email = txtEmail.Text
            };

            ClienteNegocio clienteNegocio = new ClienteNegocio();

            try
            {
                clienteNegocio.modificarCliente(cliente);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Cliente modificado correctamente.');", true);
                Response.Redirect("GestionCliente.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al modificar cliente: {ex.Message}');", true);
            }
        }



    }
}