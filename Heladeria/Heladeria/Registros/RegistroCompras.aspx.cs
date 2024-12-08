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

        private void CargarDetalleCompras()
        {

            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
                datos.setearConsulta(@"SELECT FechaCompra, IdProveedor, IdProducto, Cantidad, PrecioUnitario, TotalCompra  FROM DetalleCompras");
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
    }
}