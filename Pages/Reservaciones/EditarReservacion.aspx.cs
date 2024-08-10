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
    public partial class EditarReservacion : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] != null)
            {
                try
                {   
                    //Se obtiene el id de la reservación a editar
                    int idReserv = int.Parse(Request.QueryString["id"]);

                    //Se obtiene el id del usuario y el cargo
                    Usuario objUsuario = (Usuario)Session["usuario"];
                    int idUsuario = objUsuario.idPersona;
                    bool esEmpleado = objUsuario.esEmpleado;

                    if (!Page.IsPostBack)
                    {

                        using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                        {

                            //Se verifica el empleado
                            if (esEmpleado)
                            {
                                //Se obtienen los datos de la reservación seleccionada
                                var reservacion = db.SpCosultarReservacionesPorId(idReserv).FirstOrDefault();

                                //Se comprueba si los datos son nulos
                                if (reservacion != null)
                                {

                                    //Se cargan los campos con la información obtenida

                                    txtIdReservacion.Text = reservacion.IdReservacion.ToString();
                                    txtHotel.Text = reservacion.NombreHotel.ToString();
                                    txtIdHotel.Text = reservacion.IdHotel.ToString();
                                    txtNumHabitacion.Text = reservacion.NumeroHabitacion.ToString();
                                    txtIdHabitacion.Text = reservacion.IdHabitacion.ToString();
                                    txtPersona.Text = reservacion.Cliente;
                                    txtIdPersona.Text = reservacion.IdPersona.ToString();
                                    txtFechaEntrada.Text = reservacion.FechaEntrada.ToString("yyyy-MM-dd");
                                    txtFechaSalida.Text = reservacion.FechaSalida.ToString("yyyy-MM-dd");
                                    txtNumNinhos.Text = reservacion.NumeroNinhos.ToString();
                                    txtNumAdultos.Text = reservacion.NumeroAdultos.ToString();


                                    DateTime fechaEntrada = reservacion.FechaEntrada;//Obtiene la fecha de entrada de la reservacion y la asigana a un campo

                                    //Vefica la fecha de entrada y en caso de que sea menor a la actual, desabilita la opcion para poder editar esta misma
                                    if (fechaEntrada < DateTime.Now)
                                    {
                                        txtFechaEntrada.ReadOnly = true;
                                    }


                                }
                                else
                                {
                                    //Error al consultar la base de datos por id
                                    Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=1");
                                }
                            }
                            else
                            {

                                //Se obtienen los datos de la reservación seleccionada
                                var reservacion = db.SpCosultarReservacionesPorIdIdCliente(idReserv, idUsuario).FirstOrDefault();

                                //Se comprueba si los datos son nulos
                                if (reservacion != null)
                                {

                                    //Se cargan los campos con la información obtenida

                                    txtIdReservacion.Text = reservacion.IdReservacion.ToString();
                                    txtHotel.Text = reservacion.NombreHotel.ToString();
                                    txtIdHotel.Text = reservacion.IdHotel.ToString();
                                    txtNumHabitacion.Text = reservacion.NumeroHabitacion.ToString();
                                    txtIdHabitacion.Text = reservacion.IdHabitacion.ToString();
                                    txtPersona.Text = reservacion.Cliente;
                                    txtIdPersona.Text = reservacion.IdPersona.ToString();
                                    txtFechaEntrada.Text = reservacion.FechaEntrada.ToString("yyyy-MM-dd");
                                    txtFechaSalida.Text = reservacion.FechaSalida.ToString("yyyy-MM-dd");
                                    txtNumNinhos.Text = reservacion.NumeroNinhos.ToString();
                                    txtNumAdultos.Text = reservacion.NumeroAdultos.ToString();


                                    DateTime fechaEntrada = reservacion.FechaEntrada;//Obtiene la fecha de entrada de la reservacion y la asigana a un campo

                                    //Vefica la fecha de entrada y en caso de que sea menor a la actual, desabilita la opcion para poder editar esta misma
                                    if (fechaEntrada < DateTime.Now)
                                    {
                                        txtFechaEntrada.ReadOnly = true;
                                    }


                                }
                                else
                                {
                                    //Error al consultar la base de datos por id
                                    Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=1");
                                }

                            }

                        }

                    }

                }
                catch
                {
                    //Error al consultar la base de datos
                    Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=0");
                }


            }
            else
            {
                Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
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

                    int idReservacion = int.Parse(txtIdReservacion.Text);
                    int idHotel = int.Parse(txtIdHotel.Text);
                    int idHabitacion = int.Parse(txtIdHabitacion.Text);
                    int idPersona = int.Parse(txtIdPersona.Text);
                    int numNinhos = int.Parse(txtNumNinhos.Text == null || txtNumNinhos.Text.Equals("") ? "0" : txtNumNinhos.Text);
                    int numAdultos = int.Parse(txtNumAdultos.Text);
                    int totalPersonas = numAdultos + numNinhos;
                    DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);
                    DateTime fechaSalida = DateTime.Parse(txtFechaSalida.Text);



                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))//Se utiliza la conexión para asociar la base de datos
                    {
                        var vefCapHabitacion = db.SpVerificarCapacidadHabitacion(totalPersonas, idHabitacion).FirstOrDefault();
                        if (vefCapHabitacion != null)
                        {
                            db.SpEditarReservacion(idPersona, idUsuario, idReservacion, fechaEntrada, fechaSalida, numNinhos, numAdultos);
                            Response.Redirect("~/Pages/Mensajes/Confirmacion.aspx?msg=1");
                        }
                        else
                        {
                            //Error capacida maxima excedida
                            var ObtCapMaxHabitacion = db.SpObtenerCapacidadHabitacion(idHabitacion).FirstOrDefault();
                            int capacidadMaxima = int.Parse(ObtCapMaxHabitacion.HabConCapMaxima.ToString());
                            phAlerta.Visible = true;
                            pnlContenido.Style["pointer-events"] = "none";
                            pnlContenido.Style["opacity"] = "0.5";
                            lblMsg.Text = "Está habitación solo permite " + capacidadMaxima + " personas, debe disminuir el número de personas de la reservación";

                        }
                    }
                }
                catch 
                {
                    //Error al editar la base de datos
                    Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=6");
                }
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

        protected void btnContinuar_Click(object sender, EventArgs e)
        {
            phAlerta.Visible = false;
            pnlContenido.Style["pointer-events"] = "auto";
            pnlContenido.Style["opacity"] = "1";
        }
    }
}