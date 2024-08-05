using ProyectoFinal_G03.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Se verifica si se ha iniciado una sesión
            if (Session["usuario"] != null)
            {
                try
                {
                    //Se obtienen los datos de la sesión
                    Usuario objUsuario = (Usuario)Session["usuario"];

                    lblNombreCompleto.Text = objUsuario.nombreCompleto;//Se asigna el nombre del usuario para ser mostrado

                    //Se habilita la vista del nombre de usuario y el botón para cerrar sesión
                    lblNombreCompleto.Visible = true;
                    btnCerrarSesion.Visible = true;

                }
                catch 
                {
                    Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
                }
            }
            //else
            //{
            //    // Oculta la opción de "Gestionar Habitaciones" y el botón de cerrar sesión si el usuario no está autenticado
            //    liGestionarHabitaciones.Visible = false;
            //}

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            //Se cierra la sesión
            Session.RemoveAll();
            Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
        }
    }
}