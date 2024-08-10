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

            //Se valida y obtiene el código de éxito
            int msgCod;
            bool msg = int.TryParse(Request.QueryString["msg"], out msgCod);
            msgCod = msg == true ? int.Parse(Request.QueryString["msg"]) : 400;

            //Se valida el código de éxitos
            switch (msgCod)
            {
                case 0:
                    lblMensajeError.Text = "Ha surgido un error al consultar la base de datos";
                    break;
                case 1:
                    lblMensajeError.Text = "Ha surgido un error al consultar la reservación seleccionada";
                    break;
                case 2:
                    lblMensajeError.Text = "La habitación no puede ser modificada debido a que existen reservaciones “En proceso” o “En espera” asociadas a la habitación";
                    break;
                case 3:
                    lblMensajeError.Text = "La habitación que intentas editar está inactiva. Por favor, selecciona una habitación activa para continuar.";
                    break;
                case 4:
                    lblMensajeError.Text = "La habitación que estás intentando editar no existe. Por favor, verifica el ID y vuelve a intentarlo.";
                    break;
                case 5:
                    lblMensajeError.Text = "Ha surgido un error al insertar en la base de datos.";
                    break;
                case 6:
                    lblMensajeError.Text = "Ha surgido un error al editar en la base de datos.";
                    break;
                case 7:
                    lblMensajeError.Text = "Se ha intentado insertar o actualizar un registro con un valor de campo duplicado. Verifica los datos e intenta de nuevo.";
                    break;
                case 8:
                    lblMensajeError.Text = "No hay habitaciones disponibles con la capacidad solicitada.";
                    break;
                case 9:
                    lblMensajeError.Text = "No hay habitaciones disponibles.";
                    break;

                default:
                    Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    break;

            }

        }
    }
}