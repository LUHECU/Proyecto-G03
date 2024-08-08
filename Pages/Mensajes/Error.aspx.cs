using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03.Pages.Mensajes
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Se obtiene el código de éxito
            int msg = int.Parse(Request.QueryString["msgError"]);

            //Se valida el código de éxito
            switch (msg)
            {
                case 0:
                    lblMensajeError.Text = "";
                    break;
                case 1:
                    lblMensajeError.Text = "";
                    break;
                case 2:
                    lblMensajeError.Text = "";
                    break;
                case 3:
                    lblMensajeError.Text = "";
                    break;
                case 4:
                    lblMensajeError.Text = "";
                    break;
                case 5:
                    lblMensajeError.Text = "";
                    break;
                default:
                    Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    break;

            }

        }
    }
}