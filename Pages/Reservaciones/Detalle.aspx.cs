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
using System.Windows.Forms;
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
                                    lblIdReservacion.Text = reservacion.IdReservacion.ToString();
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
                                    

                                    if (reservacion.Estado.ToString() == "A" && reservacion.FechaEntrada > DateTime.Now)
                                    {
                                        btnCancelarReserv.Visible = true;
                                        btnEditarReserv.Visible = true;
                                    }

                                }
                                else
                                {
                                    //Error al consultar con el id
                                    Response.Redirect("~/Pages/Mensajes/Error.aspx?msg=1");

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
                                    lblIdReservacion.Text = reservacion.IdReservacion.ToString();
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

                                    if (reservacion.Estado.ToString() == "A" && reservacion.FechaEntrada > DateTime.Now)
                                    {
                                        btnCancelarReserv.Visible = true;
                                        btnEditarReserv.Visible = true;
                                    }

                                }
                                else
                                {
                                    Response.Redirect("~/Pages/Reservaciones/MisReservaciones.aspx");
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

        protected void btnCancelarReserv_Click(object sender, EventArgs e)
        {
            phAlerta.Visible = true;
            pnlContenido.Style["pointer-events"] = "none";
            pnlContenido.Style["opacity"] = "0.5";


        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            try
            {
                //Se obtiene el id de la reservación a editar
                int idReserv = int.Parse(lblIdReservacion.Text);

                //Se obtiene el id del usuario
                Usuario objUsuario = (Usuario)Session["usuario"];
                int idPersona = objUsuario.idPersona;

                using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))
                {
                    db.SpCancelarReservacion(idReserv, idPersona);
                }
            }
            catch
            {

            }
            finally 
            {
                Response.Redirect("~/Pages/Mensajes/Confirmacion.aspx?msg=2");
            }
            
        }

        protected void btnNoConfirmar_Click(object sender, EventArgs e)
        {
            phAlerta.Visible = false;
            pnlContenido.Style["pointer-events"] = "auto";
            pnlContenido.Style["opacity"] = "1";
        }
    }
}