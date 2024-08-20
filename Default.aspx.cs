using ProyectoFinal_G03.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se verifica si se ha iniciado una sesión
            if (Session["usuario"] == null)
            {

                Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");

            }
        }
    }
}