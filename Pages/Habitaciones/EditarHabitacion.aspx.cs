using DataModels;
using LinqToDB;
using Microsoft.IdentityModel.Tokens;
using ProyectoFinal_G03.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
            if (Session["usuario"] != null)
            {

                Usuario objUsuario = (Usuario)Session["usuario"];

                // Verifica si el usuario es un empleado

                if (objUsuario.esEmpleado)
                {
                    if (!Page.IsPostBack)
                    {
                        try
                        {
                            // Obtiene el ID de la habitación de la cadena de consulta (QueryString)
                            int id = int.Parse(Request.QueryString["id"]);
                            using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                            {
                                // Consulta la habitación por su ID
                                var habitacion = db.ConsultarHabitacionesPorID(id).FirstOrDefault();

                                // Verifica si la habitación existe
                                if (habitacion != null)
                                {
                                    // Verifica si la habitación está inactiva
                                    if (habitacion.Estado == 'I')
                                    {
                                        Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=3", false);
                                    }

                                    // Verifica si tiene reservaciones activas
                                    var reservaciones = db.Reservacions.Where(r => r.IdHabitacion == id &&
                                                r.Estado == 'A' &&
                                                r.FechaSalida > DateTime.Now).ToList();

                                    // Si existen reservaciones activas, redirige a la página de error
                                    if (reservaciones.Count > 0)
                                    { //mensaje estado
                                        Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=2", false);
                                    }
                                    // Asigna los valores de la habitación a los controles de la página
                                    txtIdhotel.Text = habitacion.Nombre;
                                    txtNumeroHabitacion.Text = habitacion.NumeroHabitacion;
                                    txtCapacidadMaxima.Text = habitacion.CapacidadMaxima.ToString();
                                    txtDescripcion.Text = habitacion.Descripcion;
                                }
                                else
                                { //id
                                    Response.Redirect("~/Pages/Reservaciones/Error.aspx?msg=4", false);
                                }
                            }

                        }
                        catch(Exception ex)
                        {
                            Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=10");
                        }
                    }
                }
                else
                {
                    // Si el usuario no es un empleado, redirige a la página "Mis Reservaciones"
                    Response.Redirect("~/Pages/Reservaciones/MisReservaciones.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
            }
        
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid == true)
            {
                try
                {
                    int idHotel = int.Parse(Request.QueryString["idHotel"]);
                    int id = int.Parse(Request.QueryString["id"]);
                    string numeroHabitacion = txtNumeroHabitacion.Text;
                    int capacidadMaxima = int.Parse(txtCapacidadMaxima.Text);
                    string descripcion = txtDescripcion.Text;
                    char estado = 'A';

                   


                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {
                            // Si no existe, procede a actualizar la habitación
                            db.SpEditarHabitacion(id, idHotel, numeroHabitacion, capacidadMaxima, descripcion, estado);
                        }
                                        
                    
                }
                catch (SqlException ex)
                {
                    //campos duplicados
                    Response.Redirect("~/Pages/Mensajes/error.aspx?msg=7");

                }
                catch (Exception ex)
                {

                    Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=10");
                }
               
                    Response.Redirect("~/Pages/Mensajes/Confirmacion.aspx?msg=4");
                

            }
        }


        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            phAlerta.Visible = true;
            pnlContenido.Style["pointer-events"] = "none";
            pnlContenido.Style["opacity"] = "0.5";
        }

        protected void btnNoConfirmar_Click(object sender, EventArgs e)
        {
            phAlerta.Visible = false;
            pnlContenido.Style["pointer-events"] = "auto";
            pnlContenido.Style["opacity"] = "1";
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
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

                Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=10");
            }
            finally
            {
                Response.Redirect("~/Pages/Mensajes/Confirmacion.aspx?msg=5");
            }
        }
    }
}