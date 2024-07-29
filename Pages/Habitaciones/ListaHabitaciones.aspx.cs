using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03.Pages.Habitaciones
{
    public partial class ListaHabitaciones : System.Web.UI.Page
    {

        //coneccion a la base
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //using para contruir la conexión
                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {

                    var lista = db.SpConsultarHabitaciones().ToList();
                    grdHabitaciones.DataSource = lista;
                    grdHabitaciones.DataBind();
                }
            }
            catch
            {
                Response.Redirect("~/Pages/Mensajes/Error.aspx");
            }

        }
    }
}