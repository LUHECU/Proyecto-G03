using DataModels;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal_G03.Pages.Reservaciones
{
    public partial class GestiornarReservaciones : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (!Page.IsPostBack)
                {

                    var listaPersonas = new List<ListItem>();
                    listaPersonas.Add(new ListItem("Selecione un cliente", "0"));

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))//Se utiliza la conexión para asociar la base de datos
                    {
                        //Se obtienen los datos para cargar el gridview
                        var misReserv = db.SpCosultarReservaciones().ToList();

                        //Se cargan los datos en el gridview
                        grdGestReserv.DataSource = misReserv;
                        grdGestReserv.DataBind();

                        //Se obtienen los datos para cargar el dropdownlist
                        var query = db.SpConsultarPersonas().Select(per => new ListItem(per.NombreCompleto, per.IdPersona.ToString()));
                        listaPersonas.AddRange(query);

                        //Se cargan los datos en el dropdownlist
                        ddlPersona.DataSource = listaPersonas;
                        ddlPersona.DataTextField = "Text";
                        ddlPersona.DataValueField = "Value";
                        ddlPersona.DataBind();
                    }
                }
            }
            catch
            {

            }

        }


        //Función para validar el estado de la reservación
        protected string estadoReservacion(DateTime fechaEntrada, DateTime fechaSalida, string estadoCod)
        {
            string estado = "";


            if (estadoCod.Equals("I"))//Comprueba si la reservación fue cancelada
            {
                estado = "Cancelada";
            }
            else
            {
                if (fechaEntrada > DateTime.Now && fechaSalida > DateTime.Now)//Comprueba si la reservación esta en espera
                {
                    estado = "En espera";
                }
                else if (fechaSalida < DateTime.Now)//Comprueba si la reservación esta finalizada
                {
                    estado = "Finalizada";
                }
                else if (fechaEntrada <= DateTime.Now)//Comprueba si la reservación esta en proceso
                {
                    estado = "En proceso";
                }
            }


            return estado;//Retorna el estado de la reservación


        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {

            try
            {
                if (Page.IsValid)
                {

                    using (PvProyectoFinalDB db = new PvProyectoFinalDB(new DataOptions().UseSqlServer(conn)))//Se utiliza la conexión para asociar la base de datos
                    {

                        object misReservFilt;

                        int idPersona = int.TryParse(ddlPersona.SelectedValue.ToString(), out idPersona) == true ? int.Parse(ddlPersona.SelectedValue.ToString()) : 0;

                        DateTime fechaEntrada = DateTime.Parse(txtFechaEntrada.Text);

                        DateTime fechaSalida =  DateTime.Parse(txtFechaSalida.Text);

                        //Sse obtienen los datos para cargar el gridview según los filtros administrados
                        misReservFilt = db.SpFiltrarReservaciones(idPersona, fechaEntrada, fechaSalida).ToList();
                        
                        //Se cargan los datos en el gridview
                        grdGestReserv.DataSource = misReservFilt;
                        grdGestReserv.DataBind();

                    }
                }
            }
            catch
            {

                
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
    }
}