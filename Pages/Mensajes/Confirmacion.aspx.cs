using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03.Pages.Mensajes
{
    public partial class Confirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Se valida y obtiene el código de éxito
            int msgCod;
            bool msg = int.TryParse(Request.QueryString["msg"], out msgCod);
            msgCod = msg == true? int.Parse(Request.QueryString["msg"]) : 400;

            //Se valida el código de éxito
            switch (msgCod) 
            {
                case 0:
                    lblMensaje.Text = "¡La creación de la reservación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    break;
                case 1:
                    lblMensaje.Text = "¡La edición de la reservación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    break;
                case 2:
                    lblMensaje.Text = "¡La cancelación de la reservación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    break;
                case 3:
                    lblMensaje.Text = "¡La creación de la habitación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    break;
                case 4:
                    lblMensaje.Text = "¡La edición de la habitación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    break;
                case 5:
                    lblMensaje.Text = "¡La cancelación de la habitación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    break;
                default:
                    Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    break;

            }

        }
    }
}