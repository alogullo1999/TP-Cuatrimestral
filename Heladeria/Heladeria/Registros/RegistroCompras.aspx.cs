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
                string query = @"SELECT FechaCompra,IdCompra,p.Nombre as Proveedor,pr.Nombre as Producto ,Cantidad,PrecioUnitario,TotalCompra FROM DetalleCompras dc inner join Proveedores p on dc.IdProveedor = p.IdProveedor  inner join Productos pr on dc.IdProducto = pr.IdProducto WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(fechaCompra))
                {
                    query += " AND CONVERT(VARCHAR, FechaCompra, 23) = @FechaCompra";
                    datos.setearParametro("@FechaCompra", fechaCompra);
                }

                if (!string.IsNullOrWhiteSpace(idProducto))
                {
                    query += " AND pr.Nombre = @Nombre";
                    datos.setearParametro("@Nombre", idProducto);
                }

                datos.setearConsulta(query);
                datos.EjecutarLectura();

                dt.Load(datos.Lector);

                gvDetalleCompras.DataSource = dt;
                gvDetalleCompras.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al aplicar el filtro";
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