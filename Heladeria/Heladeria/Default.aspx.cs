using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Heladeria
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Ejemplo básico de validación de credenciales
            if (username == "admin" && password == "password123")
            {
                // Redirige al usuario si las credenciales son correctas
                Response.Redirect("About.aspx");
            }
            else
            {
                // Mostrar un mensaje de error
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Usuario o contraseña incorrectos');", true);
            }
        }




    }
}