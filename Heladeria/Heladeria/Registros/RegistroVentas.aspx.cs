using dominio;
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

        private void CargarDetalleVentas(string fechaVenta = null, string NombreCliente = null, string NombreProducto = null, string IdDetalleVenta = null)
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
 
                string query = @"SELECT FechaVenta, IdDetalleVenta, e.Nombre as Empleado, c.Nombre as Cliente, p.Nombre as Producto, Cantidad, PrecioUnitario, TotalVenta FROM DetalleVentas dv inner join Clientes c on dv.IdCliente = c.IdCliente inner join Productos p on dv.IdProducto = p.IdProducto inner join Empleados e on dv.IdEmpleado = e.IdEmpleado WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(fechaVenta))
                {
                    query += " AND CONVERT(VARCHAR, FechaVenta, 23) = @FechaVenta"; 
                    datos.setearParametro("@FechaVenta", fechaVenta);
                }

                if (!string.IsNullOrWhiteSpace(NombreCliente))
                {
                    query += " AND c.Nombre = @NombreCliente";
                    datos.setearParametro("@NombreCliente", NombreCliente);
                }

                if (!string.IsNullOrWhiteSpace(NombreProducto))
                {
                    query += " AND p.Nombre = @NombreProducto";
                    datos.setearParametro("@NombreProducto", NombreProducto);
                }

                if (!string.IsNullOrWhiteSpace(IdDetalleVenta))
                {
                    query += " AND IdDetalleVenta = @IdDetalleVenta";
                    datos.setearParametro("@IdDetalleVenta", IdDetalleVenta);
                }

                datos.setearConsulta(query);
                datos.EjecutarLectura();

                dt.Load(datos.Lector);

                gvDetalleVentas.DataSource = dt;
                gvDetalleVentas.DataBind();
            }
            catch 
            {
                lblError.Text = "Error al cargar datos";
                lblError.Visible = true;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            string fechaVenta = txtFechaVenta.Text.Trim();
            string NombreCliente = txtCliente.Text.Trim();
            string NombreProducto = txtProducto.Text.Trim();
            string IdDetalleVenta = txtDetalleVenta.Text.Trim();

            CargarDetalleVentas(fechaVenta, NombreCliente, NombreProducto, IdDetalleVenta);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
 
            txtFechaVenta.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtDetalleVenta.Text = string.Empty;


            CargarDetalleVentas();
        }
    }
}
