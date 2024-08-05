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
            try
            {
                // Verificar si el usuario está autenticado y es un empleado
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];

                    // Verificar si el usuario es un empleado
                    if (usuario.esEmpleado)
                    {
                        // Usar 'using' para construir la conexión
                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {
                            var lista = db.SpConsultarHabitaciones().ToList();
                            grdHabitaciones.DataSource = lista;
                            grdHabitaciones.DataBind();
                        }
                    }
                    else
                    {
                        // Si no es empleado, redirigir a una página de error o de acceso denegado
                        Response.Redirect("~/Pages/Mensajes/AccesoDenegado.aspx");
                    }
                }
                else
                {
                    // Si no hay sesión activa, redirigir al usuario a la página de login
                    Response.Redirect("~/Pages/Acceso/Login.aspx");
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores
                Response.Redirect("~/Pages/Mensajes/Error.aspx");
            }
        }
    }
}