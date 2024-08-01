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
    public partial class EditarHabitacion : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == false)
                {
                    int id = int.Parse(Request.QueryString["id"]);
                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        var habitaciones = db.ConsultarHabitacionesPorID(id).FirstOrDefault();

                        if (habitaciones != null)
                        {
                            txtIdhotel.Text = habitaciones.Nombre;
                            txtNumeroHabitacion.Text = habitaciones.NumeroHabitacion;
                            txtCapacidadMaxima.Text = habitaciones.CapacidadMaxima.ToString();
                            txtDescripcion.Text = habitaciones.Descripcion;
                        }
                        else
                        {
                            Response.Redirect("../Mensajes/Error.aspx");
                        }
                    }
                }
            }
            catch
            {
                Response.Redirect("../Mensajes/Error.aspx");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idHotel = int.Parse(Request.QueryString["idHotel"]);
                int id = int.Parse(Request.QueryString["id"]);
                string numeroHabitacion = txtNumeroHabitacion.Text;
                int capacidadMaxima = int.Parse(txtCapacidadMaxima.Text);
                string descripcion = txtDescripcion.Text;
                char estado = 'A';

                if (!string.IsNullOrEmpty(txtNumeroHabitacion.Text) &&
                    !string.IsNullOrEmpty(txtDescripcion.Text) &&
                    !string.IsNullOrEmpty(txtCapacidadMaxima.Text))
                {

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                    {
                        db.SpEditarHabitacion(id, idHotel, numeroHabitacion, capacidadMaxima, descripcion, estado);

                    }

                }
                else
                {
                    // Redirige a la página de error si hay campos vacíos
                    Response.Redirect("../Mensajes/Error.aspx");

                }
            }
            catch
            {
                // Redirige a la página de error si ocurre una excepción
                Response.Redirect("../Mensajes/Error.aspx");
            }
            finally
            {
                // Redirige a la página de confirmación solo si todo salió bien
                Response.Redirect("../Mensajes/Confirmacion.aspx");
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request.QueryString["id"]);

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    // Llama al procedimiento almacenado para inactivar la habitación
                    db.SpInactivarHabitacion(id);
                }


            }
            catch (Exception ex)
            {
                Response.Redirect("../Mensajes/Error.aspx");
            }
            finally
            {
                Response.Redirect("../Mensajes/Confirmacion.aspx");
            }
        }
    }
}