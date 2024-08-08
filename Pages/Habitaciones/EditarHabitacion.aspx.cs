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
                        Response.Redirect("~/Pages/Reservaciones/MisReservaciones.aspx");
                    }
                }

                catch
                {
                    // Manejo de errores
                    Response.Redirect("../Mensajes/Error.aspx");
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

                    if (!string.IsNullOrEmpty(numeroHabitacion) &&
                        !string.IsNullOrEmpty(descripcion) &&
                        capacidadMaxima > 0)
                    {


                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {
                            // Si no existe, procede a actualizar la habitación
                            db.SpEditarHabitacion(id, idHotel, numeroHabitacion, capacidadMaxima, descripcion, estado);
                        }
                       
                    }
                    else
                    {
                        //Campos vacios
                        Response.Redirect("../Mensajes/Error.aspx");
                    }
                }
                catch (SqlException ex)
                {
                    //campos duplicados
                    Response.Redirect("~/Pages/Mensajes/error.aspx");

                }
                catch (Exception ex)
                {

                    Response.Redirect("../Mensajes/Error.aspx");
                }
               
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