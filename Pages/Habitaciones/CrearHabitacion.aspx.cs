using DataModels;
using LinqToDB;
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
    public partial class CrearHabitacion : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)//Se valida la sesión
            {

                if (Page.IsPostBack == false)
                {
                    try
                    {
                        var lista = new List<ListItem>();

                        lista.Add(new ListItem("Seleccione un valor", "0"));
                        //lista.Add(new ListItem("gatos"));

                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {
                            var query = db.SpConsultarHoteles()
                            .OrderBy(hotel => hotel.Nombre) // Ordena por el nombre del hotel
                            .Select(S => new ListItem(S.Nombre, S.IdHotel.ToString()))
                            .ToList();

                            lista.AddRange(query);
                        }
                        // Ordenar la lista usando LINQ
                        var listaOrdenada = lista.OrderBy(item => item.Text).ToList();

                        ddlHoteles.DataSource = lista;
                        ddlHoteles.DataTextField = "Text";
                        ddlHoteles.DataValueField = "Value";
                        ddlHoteles.DataBind();


                        ddlHoteles.Items.FindByValue("0").Selected = true;

                    }
                    catch
                    {
                        Response.Redirect("~/Pages/Mensajes/Error.aspx");
                    }


                }

                else
                {
                    Response.Redirect("../Reservaciones/Error");
                }

            }
        }


            protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlHoteles.SelectedItem != null)
                {
                    string id = ddlHoteles.SelectedItem.Value;
                    string NombreHotel = ddlHoteles.SelectedItem.Text;


                    string numeroHabitacion = txtNumeroHabitacion.Text;
                    int capacidadMaxima = int.Parse(txtCapacidadMaxima.Text);
                    string descripcion = txtDescripcion.Text;
                    char estado = 'A'; // Asignar 'I' directamente
                    int idHotel = int.Parse(id);

                    // Verificar que todos los campos de la habitación están completos
                    if (!string.IsNullOrEmpty(numeroHabitacion) &&
                        !string.IsNullOrEmpty(descripcion) &&
                        //!string.IsNullOrEmpty(txtEstado.Text) && // Este campo es revisado, pero no se usa en la asignación
                        !string.IsNullOrEmpty(txtCapacidadMaxima.Text))
                    {
                     
                        // Guardar la habitación en la base de datos
                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {

                            db.SpCrearHabitacion(numeroHabitacion, capacidadMaxima, descripcion, estado, idHotel);
                        }

                    }
                    else
                    {
                        // Redirige a la página de error si hay campos vacíos
                        Response.Redirect("~/Pages/Mensajes/Error.aspx");
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601 || ex.Number == 2627) // Número de error para duplicados
                {
                    // Redirige a la página de error específica para duplicado
                    Response.Redirect("~/Pages/Mensajes/Error.aspx");
                }
                else
                {
                    // Redirige a la página de error genérica para otros errores de base de datos
                    Response.Redirect("~/Pages/Mensajes/Error.aspx");
                }
            }
            catch (Exception ex)
            {

                Response.Redirect("~/Pages/Mensajes/Error.aspx");

            }

            Response.Redirect("~/Pages/Mensajes//Confirmacion.aspx");
        }
    }
}





