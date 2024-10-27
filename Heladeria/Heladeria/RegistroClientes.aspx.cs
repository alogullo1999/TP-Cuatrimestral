using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Heladeria
{
    public partial class RegistroClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dni = txtDNI.Text;
            string ciudad = txtCiudad.Text;
            string email = txtEmail.Text;

            negocio.AccesoDatos datos = new negocio.AccesoDatos();

            string query = "INSERT INTO Clientes (Nombre, Apellido, Dni, Ciudad, Email) VALUES (@Nombre, @Apellido, @Dni, @Ciudad, @Email)";
            datos.setearConsulta(query);
            datos.setearParametro("@Nombre", nombre);
            datos.setearParametro("@Apellido", apellido);
            datos.setearParametro("@Dni", dni);
            datos.setearParametro("@Ciudad", ciudad);
            datos.setearParametro("@Email", email);

            try
            {
                datos.ejecutarAccion();
                Response.Write("<script>alert('Cliente registrado exitosamente');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al registrar cliente: " + ex.Message + "');</script>");
            }
            finally
            {
                datos.cerrarConexion();
            }

            Response.Write("<script>alert('Cliente registrado exitosamente');</script>");
        }










    }
}