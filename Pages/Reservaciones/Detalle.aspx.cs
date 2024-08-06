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
using static LinqToDB.Common.Configuration;

namespace ProyectoFinal_G03.Pages.Reservaciones
{
    public partial class Detalle : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] != null)
            {
                try
                {

                    if (!Page.IsPostBack)
                    {
                        //Se obtiene el id de la reservación a editar
                        int idReserv = int.Parse(Request.QueryString["id"]);

                        //Se obtiene el id del usuario y el cargo
                        Usuario objUsuario = (Usuario)Session["usuario"];
                        int idPersona = objUsuario.idPersona;
                        bool esEmpleado = objUsuario.esEmpleado;

                    
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
                                    lblNumReserv.Text = reservacion.IdReservacion.ToString();
                                    lblHotel.Text = reservacion.NombreHotel.ToString();
                                    lblNumHabitacion.Text = reservacion.NumeroHabitacion.ToString();
                                    lblCLiente.Text = reservacion.Cliente;
                                    lblFechaEntrada.Text = reservacion.FechaEntrada.ToString("dd-MM-yyyy");
                                    lblFechaSalida.Text = reservacion.FechaSalida.ToString("dd-MM-yyyy");
                                    lblDiasReserva.Text = reservacion.TotalDiasReservacion.ToString();
                                    lblNumNunhos.Text = reservacion.NumeroNinhos.ToString();
                                    lblNumAdultos.Text = reservacion.NumeroAdultos.ToString();
                                    lblCostoTotal.Text = "$" + reservacion.CostoTotal.ToString();

                                    //Se obtienen los datos de la bitacora seleccionado
                                    var bitacora = db.SpCosultarBitacoraPorId(idReserv).ToList();

                                    //Se comprueba si los datos son nulos
                                    if (bitacora != null)
                                    {
                                        grdBitacora.DataSource = bitacora;
                                        grdBitacora.DataBind();
                                    }
                                    else
                                    {
                                        //Error
                                    }

                                }
                                else
                                {
                                    //ERROR DE ID
                                }
                            }
                            else
                            {
                                // Se obtienen los datos de la reservación seleccionada
                                var reservacion = db.SpCosultarReservacionesPorIdIdCliente(idReserv, idPersona).FirstOrDefault();

                                //Se comprueba si los datos son nulos
                                if (reservacion != null)
                                {

                                    //Se cargan los campos con la información obtenida
                                    lblNumReserv.Text = reservacion.IdReservacion.ToString();
                                    lblHotel.Text = reservacion.NombreHotel.ToString();
                                    lblNumHabitacion.Text = reservacion.NumeroHabitacion.ToString();
                                    lblCLiente.Text = reservacion.Cliente;
                                    lblFechaEntrada.Text = reservacion.FechaEntrada.ToString("dd-MM-yyyy");
                                    lblFechaSalida.Text = reservacion.FechaSalida.ToString("dd-MM-yyyy");
                                    lblDiasReserva.Text = reservacion.TotalDiasReservacion.ToString();
                                    lblNumNunhos.Text = reservacion.NumeroNinhos.ToString();
                                    lblNumAdultos.Text = reservacion.NumeroAdultos.ToString();
                                    lblCostoTotal.Text = "$" + reservacion.CostoTotal.ToString();

                                    //Se obtienen los datos de la bitacora seleccionado
                                    var bitacora = db.SpCosultarBitacoraPorIdIdCliente(idReserv, idPersona).ToList();

                                    //Se comprueba si los datos son nulos
                                    if (bitacora != null)
                                    {
                                        grdBitacora.DataSource = bitacora;
                                        grdBitacora.DataBind();
                                    }
                                    else
                                    {
                                        //Error ID
                                    }


                                }
                                else
                                {
                                    //ERROR DE ID
                                }
                            }


                        }


                    }

                }
                catch
                {
                    //ERROR
                } 
            }
            else
            {
                Response.Redirect("~/Pages/InicioSesion/Inicio.aspx");
            }





        }

        protected void btnEditarReserv_Click(object sender, EventArgs e)
        {
            int idReserv = int.Parse(Request.QueryString["id"]);

            Response.Redirect("~/Pages/Reservaciones/EditarReservacion.aspx?id=" + idReserv);

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Usuario objUsuario = (Usuario)Session["usuario"];

            if (objUsuario.esEmpleado)
            {
                Response.Redirect("~/Pages/Reservaciones/GestionarReservaciones.aspx");
            }
            else
            {
                Response.Redirect("~/Pages/Reservaciones/MisReservaciones.aspx");
            }


        }
    }
}