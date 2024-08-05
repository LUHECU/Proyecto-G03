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
    public partial class EditarHabitacion : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {// Verificar si el usuario está autenticado y es un empleado
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];

                    // Verificar si el usuario es un empleado
                    if (usuario.esEmpleado)
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
                    else
                    {
                        // Redirigir a una página de acceso denegado si el usuario no es un empleado
                        Response.Redirect("~/Pages/Mensajes/Error.aspx");
                    }
                }
                else
                {
                    // Redirigir a la página de login si no hay sesión activa
                    Response.Redirect("~/Pages/Acceso/Login.aspx");
                }
            }
            catch
            {
                // Manejo de errores
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

                if (string.IsNullOrEmpty(numeroHabitacion) ||
                    string.IsNullOrEmpty(descripcion) ||
                    string.IsNullOrEmpty(txtCapacidadMaxima.Text))
                {
                    // Redirige a la página de error si hay campos vacíos
                    Response.Redirect("../Mensajes/Error.aspx?mensaje=Todos los campos son obligatorios.");
                    return;
                }

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    // Verifica si el número de habitación ya existe
                    bool existeHabitacion = db.Habitacions
                        .Any(h => h.NumeroHabitacion == numeroHabitacion && h.IdHabitacion != id);

                    if (existeHabitacion)
                    {
                        // Redirige a la página de error si el número de habitación ya existe
                        Response.Redirect("../Mensajes/Error.aspx?mensaje=El número de habitación ya existe.");
                        return;
                    }

                    // Si no existe, procede a actualizar la habitación
                    db.SpEditarHabitacion(id, idHotel, numeroHabitacion, capacidadMaxima, descripcion, estado);
                }

                // Redirige a la página de confirmación solo si todo salió bien
                Response.Redirect("../Mensajes/Confirmacion.aspx");
            }
            catch (Exception ex)
            {
                // Redirige a la página de error con el mensaje de excepción general
                Response.Redirect($"../Mensajes/Error.aspx?mensaje=Ocurrió un error: {ex.Message}");
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