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
    public partial class EditarReservacion : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //Se obtiene el id de la reservación a editar
                int idReserv = int.Parse(Request.QueryString["id"]);

                if (!Page.IsPostBack)
                {

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        //Se obtienen los datos de la reservación seleccionada
                        var reservacion = db.SpCosultarReservacionesPorId(idReserv).FirstOrDefault();

                        //Se comprueba si los datos son nulos
                        if (reservacion != null)
                        {

                            //Se cargan los campos con la información obtenida
                            
                            txtHotel.Text = reservacion.NombreHotel.ToString();
                            txtNumHabitacion.Text = reservacion.NumeroHabitacion.ToString();
                            txtCliente.Text = reservacion.Cliente;
                            txtFechaEntrada.Text = reservacion.FechaEntrada.ToString("yyyy-MM-dd");
                            txtFechaSalida.Text = reservacion.FechaSalida.ToString("yyyy-MM-dd");
                            txtNumNinhos.Text = reservacion.NumeroNinhos.ToString();
                            txtNumAdultos.Text = reservacion.NumeroAdultos.ToString();
                            

                        }


                    }

                }

            }
            catch
            {

            }

        }
    }
}