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
                    btnGestionarReserv.Visible = true;
                    break;
                case 1:
                    lblMensaje.Text = "¡La edición de la reservación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    btnGestionarReserv.Visible = true;
                    break;
                case 2:
                    lblMensaje.Text = "¡La cancelación de la reservación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    btnGestionarReserv.Visible = true;
                    break;
                case 3:
                    lblMensaje.Text = "¡La creación de la habitación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    btnListaHab.Visible = true;
                    break;
                case 4:
                    lblMensaje.Text = "¡La edición de la habitación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    btnListaHab.Visible = true;
                    break;
                case 5:
                    lblMensaje.Text = "¡La inactivación de la habitación se ha realizado con éxito! Los cambios han sido guardados correctamente.";
                    btnListaHab.Visible = true;
                    break;
                default:
                    Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    break;

            }

        }

        protected void btnGestionarReserv_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
        }

        protected void btnListaHab_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Habitaciones/ListaHabitaciones.aspx");
        }
    }
}