using DataModels;
using LinqToDB;
using ProyectoFinal_G03.Clases;
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
            if (Session["usuario"] != null)//Se valida la sesión
            {
                try
                {
                    Usuario objUsuario = (Usuario)Session["usuario"];//Se obtienen los datos de la sesión

                    int idPersona = objUsuario.idPersona;
                    if (objUsuario.esEmpleado)//Se comprueba si es un empleado o cliente
                    {
                        if (!Page.IsPostBack)
                        {
                            using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                            {
                                var lista = db.SpConsultarHabitaciones().ToList();
                                grdHabitaciones.DataSource = lista;
                                grdHabitaciones.DataBind();
                            }

                        }
                    }

                    else//Si es cliente, redireciona a la página de mis reservaciones
                    {
                        Response.Redirect("~/Pages/Reservaciones/MisReservaciones.aspx");
                    }

                }
                catch (Exception ex)
                {
                  
                }
            }
            else
            {
                Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
            }
           
        }
    }
}