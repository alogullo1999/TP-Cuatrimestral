using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class GestionStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarStock();
        }

        private void CargarStock()
        {
            AccesoDatos datos = new AccesoDatos();
            DataTable dt = new DataTable();

            try
            {
                datos.setearConsulta("select  s.IdProducto,  p.Codigo, p.Nombre, p.Descripcion,  s.Cantidad,  s.FechaActualizacion  from Stock s inner  join Productos p  on s.IdProducto = p.IdProducto");
                datos.EjecutarLectura();
                dt.Load(datos.Lector);

                gvStock.DataSource = dt;
                gvStock.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error al cargar compras: {ex.Message}');", true);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }




    }
}