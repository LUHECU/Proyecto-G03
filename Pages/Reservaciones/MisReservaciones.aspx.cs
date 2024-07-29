using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03.Pages.Reservaciones
{
    public partial class MisReservaciones : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {

                    var misReserv = db.SpCosultarReservaciones().ToList();
                    grdMisReserv.DataSource = misReserv;
                    grdMisReserv.DataBind();
                }
            }
            catch
            {

            }

        }

        //Función para validar el estado de la reservación
        protected string estadoReservacion(DateTime fechaEntrada, DateTime fechaSalida, string estadoCod)
        {
            string estado = "";


            if (estadoCod.Equals("I"))//Comprueba si la reservación fue cancelada
            {
                estado = "Cancelada";
            }
            else
            {
                if (fechaEntrada > DateTime.Now && fechaSalida > DateTime.Now)//Comprueba si la reservación esta en espera
                {
                    estado = "En espera";
                }
                else if (fechaSalida < DateTime.Now)//Comprueba si la reservación esta finalizada
                {
                    estado = "Finalizada";
                }
                else if (fechaEntrada <= DateTime.Now)//Comprueba si la reservación esta en proceso
                {
                    estado = "En proceso";
                }
            }


            return estado;//Retorna el estado de la reservación


        }

    }
}