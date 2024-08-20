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

namespace ProyectoFinal_G03.Pages.InicioSesion
{
    public partial class Inicio : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] != null)
            {
                Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
            }

            
        }

        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario objUsuario = new Usuario();

                string email = txtEmail.Text;
                string clave = txtClave.Text;

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    var usuario = db.SpConsultarPersonaUsuario(email, clave).FirstOrDefault();

                    if (usuario != null)
                    {
                        objUsuario.idPersona = usuario.IdPersona;
                        objUsuario.nombreCompleto = usuario.NombreCompleto;
                        objUsuario.esEmpleado = usuario.EsEmpleado;

                        Session["usuario"] = objUsuario;
                        Session.Timeout = 5;

                        Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
                    }
                    else 
                    {
                        lblError.Visible = true;
                    }

                }
            }
            catch{}
        }
    }
}