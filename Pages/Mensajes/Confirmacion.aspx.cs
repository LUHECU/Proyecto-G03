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
                    lblMensaje.Text = "Ha registrado correctamente una nueva reservación";
                    break;
                case 1:
                    lblMensaje.Text = "Ha modificado correctamente una reservación";
                    break;
                case 2:
                    lblMensaje.Text = "Ha cancelado correctamente una reservación";
                    break;
                case 3:
                    lblMensaje.Text = "Ha registrado correctamente una nueva habitación";
                    break;
                case 4:
                    lblMensaje.Text = "Ha modificado correctamente una habitación";
                    break;
                case 5:
                    lblMensaje.Text = "Ha cancelado correctamente una habitación";
                    break;
                default:
                    Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    break;

            }

        }
    }
}