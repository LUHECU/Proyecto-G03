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

namespace ProyectoFinal_G03.Pages.Reservaciones
{
    public partial class CrearReservacion : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null)
            {

                if (!Page.IsPostBack)
                {
                    try
                    {
                        Usuario objUsuario = (Usuario)Session["usuario"];//Se obtienen los datos de la sesión
                        int idUsuario = objUsuario.idPersona;
                        bool esEmpleado = objUsuario.esEmpleado;

                        var listaPersonas = new List<ListItem>();//Creación de una lista para personas
                        listaPersonas.Add(new ListItem("Selecione un cliente", ""));//Valor inicial de la lista

                        var listaHoteles = new List<ListItem>();//Creación de una lista para hoteles
                        listaHoteles.Add(new ListItem("Selecione un hotel", ""));//Valor inicial de la lista

                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))//Se utiliza la conexión para asociar la base de datos
                        {

                            //Se obtienen los datos para cargar el dropdownlist personas
                            var queryPersonas = db.SpConsultarPersonas().Select(per => new ListItem(per.NombreCompleto, per.IdPersona.ToString()));
                            listaPersonas.AddRange(queryPersonas);

                            //Se cargan los datos en el dropdownlist personas
                            ddlPersona.DataSource = listaPersonas;
                            ddlPersona.DataTextField = "Text";
                            ddlPersona.DataValueField = "Value";
                            ddlPersona.DataBind();

                            //Se carga un ddl con el nombre del usuario en caso de que este sea cliente
                            if (!esEmpleado) 
                            { 
                                ddlPersona.Enabled = false;
                                ddlPersona.SelectedValue = idUsuario.ToString();
                            }


                            //Se obtienen los datos para cargar el dropdownlist hoteles
                            var queryHoteles = db.SpConsultarHoteles().Select(h => new ListItem(h.Nombre, h.IdHotel.ToString()));
                            listaHoteles.AddRange(queryHoteles);

                            //Se cargan los datos en el dropdownlist hoteles
                            ddlHotel.DataSource = listaHoteles;
                            ddlHotel.DataTextField = "Text";
                            ddlHotel.DataValueField = "Value";
                            ddlHotel.DataBind();
                        }

                    }
                    catch 
                    {
                        //ERROR
                    }
                }

            }
            else
            {
                Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
            }
        }

        protected void cvFechaEntrada_ServerValidate(object source, ServerValidateEventArgs args)
        {

            try
            {

                //Se comprueba que la fecha sea mayor a la actual
                args.IsValid = false;
                if (args.IsValid != null)
                {
                    if (DateTime.Parse(args.Value) > DateTime.Now)
                    {
                        args.IsValid = true;
                    }
                }
            }
            catch
            {

                args.IsValid = false;
            }

        }

        protected void cvFechaSalida_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {

                //Se comprueba que la fecha sea menor o igual a la de entrada
                args.IsValid = false;
                if (args.IsValid != null)
                {
                    if (DateTime.Parse(args.Value) >= DateTime.Parse(txtFechaEntrada.Text))
                    {
                        args.IsValid = true;
                    }
                }
            }
            catch
            {

                args.IsValid = false;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) 
            {
                try
                {
                    Usuario objUsuario = (Usuario)Session["usuario"];//Se obtienen los datos de la sesión
                    int idUsuario = objUsuario.idPersona;

                    int idReservacion = 0;
                    int idHotel = int.Parse(ddlHotel.SelectedValue);
                    int idPersona = int.Parse(ddlPersona.SelectedValue);
                    int numNinhos = int.Parse(txtNumNinhos.Text == null || txtNumNinhos.Text.Equals("") ? "0" : txtNumNinhos.Text);
                    int numAdultos = int.Parse(txtNumAdultos.Text);
                    int totalPersonas = numAdultos + numNinhos;
                    DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
                    DateTime fechaSalida = DateTime.Parse(txtFechaSalida.Text);



                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))//Se utiliza la conexión para asociar la base de datos
                    {
                        var vefHabActivas = db.SpVerificarHabitacionesActivas(totalPersonas, idHotel).FirstOrDefault();

                        if (vefHabActivas != null)
                        {
                            var vefCapHabitaciones = db.SpVerificarCapacidadHabitaciones(totalPersonas, idHotel).FirstOrDefault();
                            if (vefCapHabitaciones != null)
                            {
                                var obtHabitacion = db.SpObtenerHabitacion(totalPersonas, idHotel).FirstOrDefault();
                                if (obtHabitacion != null)
                                {
                                    int idHabitacion = int.Parse(obtHabitacion.IdHabitacion.ToString());

                                    db.SpCrearReservacion(idPersona, idHotel, idHabitacion, fechaEntrada, fechaSalida, numNinhos, numAdultos);

                                    var ultimaReservCreada = db.SpObtenerUltimoIdReservacion().FirstOrDefault();

                                    idReservacion = int.Parse(ultimaReservCreada.UltimoIdReservacion.ToString());

                                    db.SpRegistrarBitacora(idUsuario, idReservacion, "CREADA");

                                    Response.Redirect("~/Pages/Mensajes/Confirmacion.aspx?msg=0");

                                }
                                else
                                {
                                    //Error
                                }


                            }
                            else
                            {
                                //Error capacida maxima excedida
                                var ObtCapMaxHabitaciones = db.SpObtenerCapacidadHabitaciones(idHotel).FirstOrDefault();
                                int capacidadMaxima = int.Parse(ObtCapMaxHabitaciones.HabConCapMaxima.ToString());
                                phAlerta.Visible = true;
                                pnlContenido.Style["pointer-events"] = "none";
                                pnlContenido.Style["opacity"] = "0.5";
                                lblMsg.Text = "La habitación con la mayor capacidad solo admite " + capacidadMaxima + " personas, debe disminuir el número de personas de la reservación";
                            }

                        }
                        else
                        {
                            //Error no hay habitaciones activas
                        }
                    }
                }
                catch { }
            }
        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            phAlerta.Visible = false;
            pnlContenido.Style["pointer-events"] = "auto";
            pnlContenido.Style["opacity"] = "1";
        }
    }
}