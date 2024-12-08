using negocio;
using System;
using System.Data;
using System.Web.UI;

namespace Heladeria.Registros
{
    public partial class RegistroVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetalleVentas();
            }
        }

        private void CargarDetalleVentas(string fechaVenta = null, string idCliente = null)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
 
                string query = @"SELECT FechaVenta, IdVenta, IdEmpleado, IdCliente, IdProducto, Cantidad, PrecioUnitario, TotalVenta 
                                 FROM DetalleVentas WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(fechaVenta))
                {
                    query += " AND CONVERT(VARCHAR, FechaVenta, 23) = @FechaVenta"; 
                    datos.setearParametro("@FechaVenta", fechaVenta);
                }

                if (!string.IsNullOrWhiteSpace(idCliente))
                {
                    query += " AND IdCliente = @IdCliente";
                    datos.setearParametro("@IdCliente", idCliente);
                }

                datos.setearConsulta(query);
                datos.EjecutarLectura();

                dt.Load(datos.Lector);

                gvDetalleVentas.DataSource = dt;
                gvDetalleVentas.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al cargar datos: {ex.Message}');", true);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            string fechaVenta = txtFechaVenta.Text.Trim();
            string idCliente = txtIdCliente.Text.Trim();

            CargarDetalleVentas(fechaVenta, idCliente);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
 
            txtFechaVenta.Text = string.Empty;
            txtIdCliente.Text = string.Empty;


            CargarDetalleVentas();
        }
    }
}
