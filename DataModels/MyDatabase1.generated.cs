//---------------------------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated by T4Model template for T4 (https://github.com/linq2db/linq2db).
//    Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//---------------------------------------------------------------------------------------------------

#pragma warning disable 1573, 1591

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;

namespace DataModels
{
	/// <summary>
	/// Database       : PV_ProyectoFinal
	/// Data Source    : LAPTOP-TKFN345G\SQLEXPRESS
	/// Server Version : 14.00.2056
	/// </summary>
	public partial class PvProyectoFinalDB : LinqToDB.Data.DataConnection
	{
		public ITable<Bitacora>    Bitacoras    { get { return this.GetTable<Bitacora>(); } }
		public ITable<Habitacion>  Habitacions  { get { return this.GetTable<Habitacion>(); } }
		public ITable<Hotel>       Hotels       { get { return this.GetTable<Hotel>(); } }
		public ITable<Persona>     Personas     { get { return this.GetTable<Persona>(); } }
		public ITable<Reservacion> Reservacions { get { return this.GetTable<Reservacion>(); } }

		public PvProyectoFinalDB()
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(string configuration)
			: base(configuration)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(DataOptions options)
			: base(options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		public PvProyectoFinalDB(DataOptions<PvProyectoFinalDB> options)
			: base(options.Options)
		{
			InitDataContext();
			InitMappingSchema();
		}

		partial void InitDataContext  ();
		partial void InitMappingSchema();
	}

	[Table(Schema="dbo", Name="Bitacora")]
	public partial class Bitacora
	{
		[Column("idBitacora"),      PrimaryKey, Identity] public int      IdBitacora      { get; set; } // int
		[Column("idReservacion"),   NotNull             ] public int      IdReservacion   { get; set; } // int
		[Column("idPersona"),       NotNull             ] public int      IdPersona       { get; set; } // int
		[Column("accionRealizada"), NotNull             ] public string   AccionRealizada { get; set; } // varchar(25)
		[Column("fechaDeLaAccion"), NotNull             ] public DateTime FechaDeLaAccion { get; set; } // datetime

		#region Associations

		/// <summary>
		/// FK_Bitacora_Persona (dbo.Persona)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=false)]
		public Persona Persona { get; set; }

		/// <summary>
		/// FK_Bitacora_Reservacion (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdReservacion", OtherKey="IdReservacion", CanBeNull=false)]
		public Reservacion Reservacion { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Habitacion")]
	public partial class Habitacion
	{
		[Column("idHabitacion"),     PrimaryKey, Identity] public int    IdHabitacion     { get; set; } // int
		[Column("idHotel"),          NotNull             ] public int    IdHotel          { get; set; } // int
		[Column("numeroHabitacion"), NotNull             ] public string NumeroHabitacion { get; set; } // varchar(10)
		[Column("capacidadMaxima"),  NotNull             ] public int    CapacidadMaxima  { get; set; } // int
		[Column("descripcion"),      NotNull             ] public string Descripcion      { get; set; } // varchar(500)
		[Column("estado"),           NotNull             ] public char   Estado           { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Habitacion_Hotel (dbo.Hotel)
		/// </summary>
		[Association(ThisKey="IdHotel", OtherKey="IdHotel", CanBeNull=false)]
		public Hotel Hotel { get; set; }

		/// <summary>
		/// FK_Reservacion_Habitacion_BackReference (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdHabitacion", OtherKey="IdHabitacion", CanBeNull=true)]
		public IEnumerable<Reservacion> Reservacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Hotel")]
	public partial class Hotel
	{
		[Column("idHotel"),            PrimaryKey,  Identity] public int     IdHotel            { get; set; } // int
		[Column("nombre"),             NotNull              ] public string  Nombre             { get; set; } // varchar(150)
		[Column("direccion"),             Nullable          ] public string  Direccion          { get; set; } // varchar(500)
		[Column("costoPorCadaAdulto"), NotNull              ] public decimal CostoPorCadaAdulto { get; set; } // numeric(10, 2)
		[Column("costoPorCadaNinho"),  NotNull              ] public decimal CostoPorCadaNinho  { get; set; } // numeric(10, 2)

		#region Associations

		/// <summary>
		/// FK_Habitacion_Hotel_BackReference (dbo.Habitacion)
		/// </summary>
		[Association(ThisKey="IdHotel", OtherKey="IdHotel", CanBeNull=true)]
		public IEnumerable<Habitacion> Habitacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Persona")]
	public partial class Persona
	{
		[Column("idPersona"),      PrimaryKey, Identity] public int    IdPersona      { get; set; } // int
		[Column("nombreCompleto"), NotNull             ] public string NombreCompleto { get; set; } // varchar(250)
		[Column("email"),          NotNull             ] public string Email          { get; set; } // varchar(150)
		[Column("clave"),          NotNull             ] public string Clave          { get; set; } // varchar(15)
		[Column("esEmpleado"),     NotNull             ] public bool   EsEmpleado     { get; set; } // bit
		[Column("estado"),         NotNull             ] public char   Estado         { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Bitacora_Persona_BackReference (dbo.Bitacora)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=true)]
		public IEnumerable<Bitacora> Bitacoras { get; set; }

		/// <summary>
		/// FK_Reservacion_Persona_BackReference (dbo.Reservacion)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=true)]
		public IEnumerable<Reservacion> Reservacions { get; set; }

		#endregion
	}

	[Table(Schema="dbo", Name="Reservacion")]
	public partial class Reservacion
	{
		[Column("idReservacion"),        PrimaryKey,  Identity] public int       IdReservacion        { get; set; } // int
		[Column("idPersona"),            NotNull              ] public int       IdPersona            { get; set; } // int
		[Column("idHabitacion"),         NotNull              ] public int       IdHabitacion         { get; set; } // int
		[Column("fechaEntrada"),         NotNull              ] public DateTime  FechaEntrada         { get; set; } // datetime
		[Column("fechaSalida"),          NotNull              ] public DateTime  FechaSalida          { get; set; } // datetime
		[Column("numeroAdultos"),        NotNull              ] public int       NumeroAdultos        { get; set; } // int
		[Column("numeroNinhos"),         NotNull              ] public int       NumeroNinhos         { get; set; } // int
		[Column("totalDiasReservacion"), NotNull              ] public int       TotalDiasReservacion { get; set; } // int
		[Column("costoPorCadaAdulto"),   NotNull              ] public decimal   CostoPorCadaAdulto   { get; set; } // numeric(10, 2)
		[Column("costoPorCadaNinho"),    NotNull              ] public decimal   CostoPorCadaNinho    { get; set; } // numeric(10, 2)
		[Column("costoTotal"),           NotNull              ] public decimal   CostoTotal           { get; set; } // numeric(14, 2)
		[Column("fechaCreacion"),        NotNull              ] public DateTime  FechaCreacion        { get; set; } // datetime
		[Column("fechaModificacion"),       Nullable          ] public DateTime? FechaModificacion    { get; set; } // datetime
		[Column("estado"),               NotNull              ] public char      Estado               { get; set; } // varchar(1)

		#region Associations

		/// <summary>
		/// FK_Bitacora_Reservacion_BackReference (dbo.Bitacora)
		/// </summary>
		[Association(ThisKey="IdReservacion", OtherKey="IdReservacion", CanBeNull=true)]
		public IEnumerable<Bitacora> Bitacoras { get; set; }

		/// <summary>
		/// FK_Reservacion_Habitacion (dbo.Habitacion)
		/// </summary>
		[Association(ThisKey="IdHabitacion", OtherKey="IdHabitacion", CanBeNull=false)]
		public Habitacion Habitacion { get; set; }

		/// <summary>
		/// FK_Reservacion_Persona (dbo.Persona)
		/// </summary>
		[Association(ThisKey="IdPersona", OtherKey="IdPersona", CanBeNull=false)]
		public Persona Persona { get; set; }

		#endregion
	}

	public static partial class PvProyectoFinalDBStoredProcedures
	{
		#region ConsultarHabitacionesPorID

		public static IEnumerable<ConsultarHabitacionesPorIDResult> ConsultarHabitacionesPorID(this PvProyectoFinalDB dataConnection, int? @idHabitaciones)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitaciones", @idHabitaciones, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<ConsultarHabitacionesPorIDResult>("[dbo].[ConsultarHabitacionesPorID]", parameters);
		}

		public partial class ConsultarHabitacionesPorIDResult
		{
			[Column("idHabitacion")    ] public int    IdHabitacion     { get; set; }
			[Column("numeroHabitacion")] public string NumeroHabitacion { get; set; }
			[Column("capacidadMaxima") ] public int    CapacidadMaxima  { get; set; }
			[Column("descripcion")     ] public string Descripcion      { get; set; }
			[Column("estado")          ] public char   Estado           { get; set; }
			[Column("nombre")          ] public string Nombre           { get; set; }
		}

		#endregion

		#region SpAlterdiagram

		public static int SpAlterdiagram(this PvProyectoFinalDB dataConnection, string @diagramname, int? @ownerId, int? @version, byte[] @definition)
		{
			var parameters = new []
			{
				new DataParameter("@diagramname", @diagramname, LinqToDB.DataType.NVarChar)
				{
					Size = 128
				},
				new DataParameter("@owner_id",    @ownerId,     LinqToDB.DataType.Int32),
				new DataParameter("@version",     @version,     LinqToDB.DataType.Int32),
				new DataParameter("@definition",  @definition,  LinqToDB.DataType.VarBinary)
				{
					Size = -1
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_alterdiagram]", parameters);
		}

		#endregion

		#region SpConsultarBitacoras

		public static IEnumerable<Bitacora> SpConsultarBitacoras(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<Bitacora>("[dbo].[SpConsultarBitacoras]");
		}

		#endregion

		#region SpConsultarHabitaciones

		public static IEnumerable<SpConsultarHabitacionesResult> SpConsultarHabitaciones(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpConsultarHabitacionesResult>("[dbo].[SpConsultarHabitaciones]");
		}

		public partial class SpConsultarHabitacionesResult
		{
			[Column("idHabitacion")    ] public int    IdHabitacion     { get; set; }
			[Column("nombreHotel")     ] public string NombreHotel      { get; set; }
			[Column("numeroHabitacion")] public string NumeroHabitacion { get; set; }
			[Column("capacidadMaxima") ] public int    CapacidadMaxima  { get; set; }
			[Column("descripcion")     ] public string Descripcion      { get; set; }
			[Column("estado")          ] public char   Estado           { get; set; }
			[Column("idHotel")         ] public int    IdHotel          { get; set; }
		}

		#endregion

		#region SpConsultarHoteles

		public static IEnumerable<Hotel> SpConsultarHoteles(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<Hotel>("[dbo].[SpConsultarHoteles]");
		}

		#endregion

		#region SpConsultarPersonas

		public static IEnumerable<Persona> SpConsultarPersonas(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<Persona>("[dbo].[SpConsultarPersonas]");
		}

		#endregion

		#region SpConsultarPersonaUsuario

		public static IEnumerable<SpConsultarPersonaUsuarioResult> SpConsultarPersonaUsuario(this PvProyectoFinalDB dataConnection, string @email, string @clave)
		{
			var parameters = new []
			{
				new DataParameter("@email", @email, LinqToDB.DataType.VarChar)
				{
					Size = 150
				},
				new DataParameter("@clave", @clave, LinqToDB.DataType.VarChar)
				{
					Size = 15
				}
			};

			return dataConnection.QueryProc<SpConsultarPersonaUsuarioResult>("[dbo].[SpConsultarPersonaUsuario]", parameters);
		}

		public partial class SpConsultarPersonaUsuarioResult
		{
			[Column("idPersona") ] public int    IdPersona      { get; set; }
			                       public string NombreCompleto { get; set; }
			[Column("esEmpleado")] public bool   EsEmpleado     { get; set; }
		}

		#endregion

		#region SpConsultarReservacionesExcluyendoIdPersona

		public static IEnumerable<SpConsultarReservacionesExcluyendoIdPersonaResult> SpConsultarReservacionesExcluyendoIdPersona(this PvProyectoFinalDB dataConnection, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona", @idPersona, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpConsultarReservacionesExcluyendoIdPersonaResult>("[dbo].[SpConsultarReservacionesExcluyendoIdPersona]", parameters);
		}

		public partial class SpConsultarReservacionesExcluyendoIdPersonaResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("cliente")             ] public string    Cliente              { get; set; }
			[Column("idHabitacion")        ] public int       IdHabitacion         { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("nombreHotel")         ] public string    NombreHotel          { get; set; }
			[Column("fechaEntrada")        ] public DateTime  FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime  FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal   CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal   CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("fechaCreacion")       ] public DateTime  FechaCreacion        { get; set; }
			[Column("fechaModificacion")   ] public DateTime? FechaModificacion    { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpConsultarReservacionPorId

		public static IEnumerable<Reservacion> SpConsultarReservacionPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<Reservacion>("[dbo].[SpConsultarReservacionPorId]", parameters);
		}

		#endregion

		#region SpCosultarBitacoraPorId

		public static IEnumerable<SpCosultarBitacoraPorIdResult> SpCosultarBitacoraPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpCosultarBitacoraPorIdResult>("[dbo].[SpCosultarBitacoraPorId]", parameters);
		}

		public partial class SpCosultarBitacoraPorIdResult
		{
			[Column("idBitacora")     ] public int      IdBitacora      { get; set; }
			[Column("idReservacion")  ] public int      IdReservacion   { get; set; }
			[Column("idPersona")      ] public int      IdPersona       { get; set; }
			[Column("nombreCompleto") ] public string   NombreCompleto  { get; set; }
			[Column("accionRealizada")] public string   AccionRealizada { get; set; }
			[Column("fechaDeLaAccion")] public DateTime FechaDeLaAccion { get; set; }
		}

		#endregion

		#region SpCosultarBitacoraPorIdIdCliente

		public static IEnumerable<SpCosultarBitacoraPorIdIdClienteResult> SpCosultarBitacoraPorIdIdCliente(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpCosultarBitacoraPorIdIdClienteResult>("[dbo].[SpCosultarBitacoraPorId_IdCliente]", parameters);
		}

		public partial class SpCosultarBitacoraPorIdIdClienteResult
		{
			[Column("idBitacora")     ] public int      IdBitacora      { get; set; }
			[Column("idReservacion")  ] public int      IdReservacion   { get; set; }
			[Column("idPersona")      ] public int      IdPersona       { get; set; }
			[Column("nombreCompleto") ] public string   NombreCompleto  { get; set; }
			[Column("accionRealizada")] public string   AccionRealizada { get; set; }
			[Column("fechaDeLaAccion")] public DateTime FechaDeLaAccion { get; set; }
		}

		#endregion

		#region SpCosultarReservaciones

		public static IEnumerable<SpCosultarReservacionesResult> SpCosultarReservaciones(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.QueryProc<SpCosultarReservacionesResult>("[dbo].[SpCosultarReservaciones]");
		}

		public partial class SpCosultarReservacionesResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("cliente")             ] public string    Cliente              { get; set; }
			[Column("idHabitacion")        ] public int       IdHabitacion         { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("nombreHotel")         ] public string    NombreHotel          { get; set; }
			[Column("fechaEntrada")        ] public DateTime  FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime  FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal   CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal   CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("fechaCreacion")       ] public DateTime  FechaCreacion        { get; set; }
			[Column("fechaModificacion")   ] public DateTime? FechaModificacion    { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpCosultarReservacionesPorId

		public static IEnumerable<SpCosultarReservacionesPorIdResult> SpCosultarReservacionesPorId(this PvProyectoFinalDB dataConnection, int? @idReservacion)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpCosultarReservacionesPorIdResult>("[dbo].[SpCosultarReservacionesPorId]", parameters);
		}

		public partial class SpCosultarReservacionesPorIdResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("cliente")             ] public string    Cliente              { get; set; }
			[Column("idHabitacion")        ] public int       IdHabitacion         { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("nombreHotel")         ] public string    NombreHotel          { get; set; }
			[Column("fechaEntrada")        ] public DateTime  FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime  FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal   CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal   CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("fechaCreacion")       ] public DateTime  FechaCreacion        { get; set; }
			[Column("fechaModificacion")   ] public DateTime? FechaModificacion    { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpCosultarReservacionesPorIdIdCliente

		public static IEnumerable<SpCosultarReservacionesPorIdIdClienteResult> SpCosultarReservacionesPorIdIdCliente(this PvProyectoFinalDB dataConnection, int? @idReservacion, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idReservacion", @idReservacion, LinqToDB.DataType.Int32),
				new DataParameter("@idPersona",     @idPersona,     LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpCosultarReservacionesPorIdIdClienteResult>("[dbo].[SpCosultarReservacionesPorId_IdCliente]", parameters);
		}

		public partial class SpCosultarReservacionesPorIdIdClienteResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("cliente")             ] public string    Cliente              { get; set; }
			[Column("idHabitacion")        ] public int       IdHabitacion         { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("nombreHotel")         ] public string    NombreHotel          { get; set; }
			[Column("fechaEntrada")        ] public DateTime  FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime  FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal   CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal   CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("fechaCreacion")       ] public DateTime  FechaCreacion        { get; set; }
			[Column("fechaModificacion")   ] public DateTime? FechaModificacion    { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpCosultarReservacionesPorIdPersona

		public static IEnumerable<SpCosultarReservacionesPorIdPersonaResult> SpCosultarReservacionesPorIdPersona(this PvProyectoFinalDB dataConnection, int? @idPersona)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona", @idPersona, LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpCosultarReservacionesPorIdPersonaResult>("[dbo].[SpCosultarReservacionesPorIdPersona]", parameters);
		}

		public partial class SpCosultarReservacionesPorIdPersonaResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("cliente")             ] public string    Cliente              { get; set; }
			[Column("idHabitacion")        ] public int       IdHabitacion         { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("nombreHotel")         ] public string    NombreHotel          { get; set; }
			[Column("fechaEntrada")        ] public DateTime  FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime  FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal   CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal   CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("fechaCreacion")       ] public DateTime  FechaCreacion        { get; set; }
			[Column("fechaModificacion")   ] public DateTime? FechaModificacion    { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpCrearHabitacion

		public static int SpCrearHabitacion(this PvProyectoFinalDB dataConnection, string @NumeroHabitacion, int? @CapacidadMaxima, string @Descripcion, char? @Estado, int? @IdHotel)
		{
			var parameters = new []
			{
				new DataParameter("@NumeroHabitacion", @NumeroHabitacion, LinqToDB.DataType.VarChar)
				{
					Size = 10
				},
				new DataParameter("@CapacidadMaxima",  @CapacidadMaxima,  LinqToDB.DataType.Int32),
				new DataParameter("@Descripcion",      @Descripcion,      LinqToDB.DataType.VarChar)
				{
					Size = 500
				},
				new DataParameter("@Estado",           @Estado,           LinqToDB.DataType.NVarChar)
				{
					Size = 1
				},
				new DataParameter("@IdHotel",          @IdHotel,          LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[SpCrearHabitacion]", parameters);
		}

		#endregion

		#region SpCreatediagram

		public static int SpCreatediagram(this PvProyectoFinalDB dataConnection, string @diagramname, int? @ownerId, int? @version, byte[] @definition)
		{
			var parameters = new []
			{
				new DataParameter("@diagramname", @diagramname, LinqToDB.DataType.NVarChar)
				{
					Size = 128
				},
				new DataParameter("@owner_id",    @ownerId,     LinqToDB.DataType.Int32),
				new DataParameter("@version",     @version,     LinqToDB.DataType.Int32),
				new DataParameter("@definition",  @definition,  LinqToDB.DataType.VarBinary)
				{
					Size = -1
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_creatediagram]", parameters);
		}

		#endregion

		#region SpDropdiagram

		public static int SpDropdiagram(this PvProyectoFinalDB dataConnection, string @diagramname, int? @ownerId)
		{
			var parameters = new []
			{
				new DataParameter("@diagramname", @diagramname, LinqToDB.DataType.NVarChar)
				{
					Size = 128
				},
				new DataParameter("@owner_id",    @ownerId,     LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[sp_dropdiagram]", parameters);
		}

		#endregion

		#region SpEditarHabitacion

		public static int SpEditarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion, int? @idHotel, string @numeroHabitacion, int? @capacidadMaxima, string @descripcion, char? @Estado)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion",     @idHabitacion,     LinqToDB.DataType.Int32),
				new DataParameter("@idHotel",          @idHotel,          LinqToDB.DataType.Int32),
				new DataParameter("@numeroHabitacion", @numeroHabitacion, LinqToDB.DataType.VarChar)
				{
					Size = 10
				},
				new DataParameter("@capacidadMaxima",  @capacidadMaxima,  LinqToDB.DataType.Int32),
				new DataParameter("@descripcion",      @descripcion,      LinqToDB.DataType.VarChar)
				{
					Size = 500
				},
				new DataParameter("@Estado",           @Estado,           LinqToDB.DataType.VarChar)
				{
					Size = 1
				}
			};

			return dataConnection.ExecuteProc("[dbo].[spEditarHabitacion]", parameters);
		}

		#endregion

		#region SpEliminarHabitaciones

		public static int SpEliminarHabitaciones(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[SpEliminarHabitaciones]", parameters);
		}

		#endregion

		#region SpFiltrarReservaciones

		public static IEnumerable<SpFiltrarReservacionesResult> SpFiltrarReservaciones(this PvProyectoFinalDB dataConnection, int? @idPersona, DateTime? @fechaEntrada, DateTime? @fechaSalida)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",    @idPersona,    LinqToDB.DataType.Int32),
				new DataParameter("@fechaEntrada", @fechaEntrada, LinqToDB.DataType.Date),
				new DataParameter("@fechaSalida",  @fechaSalida,  LinqToDB.DataType.Date)
			};

			return dataConnection.QueryProc<SpFiltrarReservacionesResult>("[dbo].[SpFiltrarReservaciones]", parameters);
		}

		public partial class SpFiltrarReservacionesResult
		{
			[Column("idReservacion")       ] public int       IdReservacion        { get; set; }
			[Column("idPersona")           ] public int       IdPersona            { get; set; }
			[Column("cliente")             ] public string    Cliente              { get; set; }
			[Column("idHabitacion")        ] public int       IdHabitacion         { get; set; }
			[Column("numeroHabitacion")    ] public string    NumeroHabitacion     { get; set; }
			[Column("nombreHotel")         ] public string    NombreHotel          { get; set; }
			[Column("fechaEntrada")        ] public DateTime  FechaEntrada         { get; set; }
			[Column("fechaSalida")         ] public DateTime  FechaSalida          { get; set; }
			[Column("numeroAdultos")       ] public int       NumeroAdultos        { get; set; }
			[Column("numeroNinhos")        ] public int       NumeroNinhos         { get; set; }
			[Column("totalDiasReservacion")] public int       TotalDiasReservacion { get; set; }
			[Column("costoPorCadaAdulto")  ] public decimal   CostoPorCadaAdulto   { get; set; }
			[Column("costoPorCadaNinho")   ] public decimal   CostoPorCadaNinho    { get; set; }
			[Column("costoTotal")          ] public decimal   CostoTotal           { get; set; }
			[Column("fechaCreacion")       ] public DateTime  FechaCreacion        { get; set; }
			[Column("fechaModificacion")   ] public DateTime? FechaModificacion    { get; set; }
			[Column("estado")              ] public char      Estado               { get; set; }
		}

		#endregion

		#region SpHelpdiagramdefinition

		public static IEnumerable<SpHelpdiagramdefinitionResult> SpHelpdiagramdefinition(this PvProyectoFinalDB dataConnection, string @diagramname, int? @ownerId)
		{
			var parameters = new []
			{
				new DataParameter("@diagramname", @diagramname, LinqToDB.DataType.NVarChar)
				{
					Size = 128
				},
				new DataParameter("@owner_id",    @ownerId,     LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpHelpdiagramdefinitionResult>("[dbo].[sp_helpdiagramdefinition]", parameters);
		}

		public partial class SpHelpdiagramdefinitionResult
		{
			[Column("version")   ] public int?   Version    { get; set; }
			[Column("definition")] public byte[] Definition { get; set; }
		}

		#endregion

		#region SpHelpdiagrams

		public static IEnumerable<SpHelpdiagramsResult> SpHelpdiagrams(this PvProyectoFinalDB dataConnection, string @diagramname, int? @ownerId)
		{
			var parameters = new []
			{
				new DataParameter("@diagramname", @diagramname, LinqToDB.DataType.NVarChar)
				{
					Size = 128
				},
				new DataParameter("@owner_id",    @ownerId,     LinqToDB.DataType.Int32)
			};

			return dataConnection.QueryProc<SpHelpdiagramsResult>("[dbo].[sp_helpdiagrams]", parameters);
		}

		public partial class SpHelpdiagramsResult
		{
			public string Database { get; set; }
			public string Name     { get; set; }
			public int    ID       { get; set; }
			public string Owner    { get; set; }
			public int    OwnerID  { get; set; }
		}

		#endregion

		#region SpInactivarHabitacion

		public static int SpInactivarHabitacion(this PvProyectoFinalDB dataConnection, int? @idHabitacion)
		{
			var parameters = new []
			{
				new DataParameter("@idHabitacion", @idHabitacion, LinqToDB.DataType.Int32)
			};

			return dataConnection.ExecuteProc("[dbo].[SpInactivarHabitacion]", parameters);
		}

		#endregion

		#region SpRegistrarBitacora

		public static int SpRegistrarBitacora(this PvProyectoFinalDB dataConnection, int? @idPersona, int? @idReseracion, string @accionRealizada)
		{
			var parameters = new []
			{
				new DataParameter("@idPersona",       @idPersona,       LinqToDB.DataType.Int32),
				new DataParameter("@idReseracion",    @idReseracion,    LinqToDB.DataType.Int32),
				new DataParameter("@accionRealizada", @accionRealizada, LinqToDB.DataType.VarChar)
				{
					Size = 25
				}
			};

			return dataConnection.ExecuteProc("[dbo].[SpRegistrarBitacora]", parameters);
		}

		#endregion

		#region SpRenamediagram

		public static int SpRenamediagram(this PvProyectoFinalDB dataConnection, string @diagramname, int? @ownerId, string @newDiagramname)
		{
			var parameters = new []
			{
				new DataParameter("@diagramname",     @diagramname,    LinqToDB.DataType.NVarChar)
				{
					Size = 128
				},
				new DataParameter("@owner_id",        @ownerId,        LinqToDB.DataType.Int32),
				new DataParameter("@new_diagramname", @newDiagramname, LinqToDB.DataType.NVarChar)
				{
					Size = 128
				}
			};

			return dataConnection.ExecuteProc("[dbo].[sp_renamediagram]", parameters);
		}

		#endregion

		#region SpUpgraddiagrams

		public static int SpUpgraddiagrams(this PvProyectoFinalDB dataConnection)
		{
			return dataConnection.ExecuteProc("[dbo].[sp_upgraddiagrams]");
		}

		#endregion
	}

	public static partial class SqlFunctions
	{
		#region FnDiagramobjects

		[Sql.Function(Name="[dbo].[fn_diagramobjects]", ServerSideOnly=true)]
		public static int? FnDiagramobjects()
		{
			throw new InvalidOperationException();
		}

		#endregion
	}

	public static partial class TableExtensions
	{
		public static Bitacora Find(this ITable<Bitacora> table, int IdBitacora)
		{
			return table.FirstOrDefault(t =>
				t.IdBitacora == IdBitacora);
		}

		public static Habitacion Find(this ITable<Habitacion> table, int IdHabitacion)
		{
			return table.FirstOrDefault(t =>
				t.IdHabitacion == IdHabitacion);
		}

		public static Hotel Find(this ITable<Hotel> table, int IdHotel)
		{
			return table.FirstOrDefault(t =>
				t.IdHotel == IdHotel);
		}

		public static Persona Find(this ITable<Persona> table, int IdPersona)
		{
			return table.FirstOrDefault(t =>
				t.IdPersona == IdPersona);
		}

		public static Reservacion Find(this ITable<Reservacion> table, int IdReservacion)
		{
			return table.FirstOrDefault(t =>
				t.IdReservacion == IdReservacion);
		}
	}
}
