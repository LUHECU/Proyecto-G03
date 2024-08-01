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
    public partial class CrearReservacion : System.Web.UI.Page
    {

        string conn = ConfigurationManager.ConnectionStrings["MyDatabase"].ConnectionString;//Se crea una conexión para asociar la base de datos

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    var listaPersonas = new List<ListItem>();//Creación de una lista para personas
                    listaPersonas.Add(new ListItem("Selecione un cliente", "0"));//Valor inicial de la lista

                    var listaHoteles = new List<ListItem>();//Creación de una lista para hoteles
                    listaHoteles.Add(new ListItem("Selecione un hotel", "0"));//Valor inicial de la lista

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
                catch { }
            }
        }
    }
}