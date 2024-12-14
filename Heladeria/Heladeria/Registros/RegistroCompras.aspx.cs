using negocio;
using System;
using System.Data; // Para DataTable
using System.Web.UI;
using System.Web.UI.WebControls; // Para GridView

namespace Heladeria
{
    public partial class RegistroCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetalleCompras();
            }
        }

        private void CargarDetalleCompras(string fechaCompra=null, string idProducto=null)
        {

            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
                string query = @"SELECT FechaCompra,IdCompra,IdProveedor,IdProducto,Cantidad,PrecioUnitario,TotalCompra FROM DetalleCompras WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(fechaCompra))
                {
                    query += " AND CONVERT(VARCHAR, FechaCompra, 23) = @FechaCompra";
                    datos.setearParametro("@FechaCompra", fechaCompra);
                }

                if (!string.IsNullOrWhiteSpace(idProducto))
                {
                    query += " AND IdProducto=@IdProducto";
                    datos.setearParametro("@IdProducto", idProducto);
                }

                datos.setearConsulta(query);
                datos.EjecutarLectura();

                dt.Load(datos.Lector);

                gvDetalleCompras.DataSource = dt;
                gvDetalleCompras.DataBind();
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
            string FechaCompra = txtFechaCompra.Text.Trim();
            string idProducto = txtIdCliente.Text.Trim();

            CargarDetalleCompras(FechaCompra,idProducto);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e) {
            txtFechaCompra.Text = string.Empty;
            txtIdCliente.Text = string.Empty;

            CargarDetalleCompras();
        
        }
    }
}