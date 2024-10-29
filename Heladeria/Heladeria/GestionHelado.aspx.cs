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
    public partial class GestionHelado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CargarHelados();
            }
        }

        private void CargarHelados()
        {
            HeladoNegocio heladoNegocio = new HeladoNegocio();
            List<Helado> listaHelados= new List<Helado>();
            gvHelado.DataSource = listaHelados;
            gvHelado.DataBind();
        }

        protected void btnAgregarHelado_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();

            HeladoNegocio heladoNegocio=new HeladoNegocio();

            if (heladoNegocio.ExisteHelado(nombre))
            {
                Response.Write("<script>alert('El ID o Nombre del helado ya existe');<script>");
            }
            else
            {
                Helado nuevoHelado = new Helado
                {
                    NombreHelado = nombre
                };

                heladoNegocio.AgregarHelado(nuevoHelado);
                Response.Write("<script>alert('Helado fue agregado existosamente');</script>");

                CargarHelados();
            }
        }
    }
}