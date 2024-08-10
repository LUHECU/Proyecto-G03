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
                    btnGestionarReserv.Visible = true;
                    break;
                case 1:
                    lblMensajeError.Text = "Ha surgido un error al consultar la reservación seleccionada";
                    btnGestionarReserv.Visible = true;
                    break;
                case 2:
                    lblMensajeError.Text = "La habitación no puede ser modificada debido a que existen reservaciones “En proceso” o “En espera” asociadas a la habitación";
                    btnListaHab.Visible = true;
                    break;
                case 3:
                    lblMensajeError.Text = "La habitación que intentas editar está inactiva. Por favor, selecciona una habitación activa para continuar.";
                    btnListaHab.Visible = true;
                    break;
                case 4:
                    lblMensajeError.Text = "La habitación que estás intentando editar no existe. Por favor, verifica el ID y vuelve a intentarlo.";
                    btnListaHab.Visible = true;
                    break;
                case 5:
                    lblMensajeError.Text = "Ha surgido un error al insertar en la base de datos.";
                    btnGestionarReserv.Visible = true;
                    break;
                case 6:
                    lblMensajeError.Text = "Ha surgido un error al editar en la base de datos.";
                    btnGestionarReserv.Visible = true;
                    break;
                case 7:
                    lblMensajeError.Text = "Se ha intentado insertar o actualizar un registro con un valor de campo duplicado. Verifica los datos e intenta de nuevo.";
                    btnListaHab.Visible = true;
                    break;
                case 8:
                    lblMensajeError.Text = "No hay habitaciones disponibles con la capacidad solicitada.";
                    btnListaHab.Visible = true;
                    break;
                case 9:
                    lblMensajeError.Text = "No hay habitaciones disponibles.";
                    btnListaHab.Visible = true;
                    break;
                case 10:
                    lblMensajeError.Text = "Ha surgido un error al consultar la base de datos";
                    btnListaHab.Visible = true;
                    break;

                default:
                    Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    break;

            }

        }

        protected void btnListaHab_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Habitaciones/ListaHabitaciones.aspx");
        }

        protected void btnGestionarReserv_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
        }
    }
}