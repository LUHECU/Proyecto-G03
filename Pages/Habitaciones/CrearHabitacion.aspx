<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearHabitacion.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Habitaciones.CrearHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">
        <div>
        </div>
        <div class="mt-3 mb-3"> 
        <h1>Agregar habitación</h1>
        </div>
 
                    <div>
        <div>
        <asp:Label ID="lblIdhabitacion" runat="server" Text="Hotel" ></asp:Label>
        </div>
 
        <div>
        <asp:DropDownList ID="ddlHoteles" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvHotel" runat="server" ControlToValidate="ddlHoteles" InitialValue="" ErrorMessage="Seleccione un hotel" CssClass="text-danger" />
        </div>
 
        <div>
        <asp:Label ID="lblNumeroHabitacion" runat="server" Text="Número de habitación"></asp:Label>
 
        </div>
        <div>
        <asp:TextBox ID="txtNumeroHabitacion" runat="server" CssClass="form-control" MaxLength="10"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNumeroHabitacion" runat="server" ControlToValidate="txtNumeroHabitacion" ErrorMessage="Número de habitación es requerido" CssClass="text-danger" />
        </div>
 
        <div>
        <asp:Label ID="lblCapacidadMaxima" runat="server" Text="Capacidad Máxima"></asp:Label>
        </div>
 
        <div>
        <asp:TextBox ID="txtCapacidadMaxima" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCapacidadMaxima" runat="server" ControlToValidate="txtCapacidadMaxima" ErrorMessage="Capacidad máxima es requerida" CssClass="text-danger" />
        <asp:RangeValidator ID="rvCapacidadMaxima" runat="server" ControlToValidate="txtCapacidadMaxima" MinimumValue="1" MaximumValue="8" Type="Integer" ErrorMessage="Capacidad debe ser un número entre 1 y 8" CssClass="text-danger" />
        </div>
        <div>
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" ></asp:Label>
        </div>
 
     
        <div>
        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" CssClass="form-control" TextMode="MultiLine" Rows="4" Columns="80" MaxLength="500"  placeholder="Ingrese una descripción  aquí..." ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Descripción es requerida" CssClass="text-danger" />
        </div>     
        </div>

 
      
        <%--Botenes--%>
 
             <div  class="mt-3 mb-3">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Cssclass="btn btn-primary" OnClick="btnGuardar_Click" />
        <!-- Enlace para cancelar y volver a la página principal -->
        <a href="ListaHabitaciones.aspx" class="btn btn-info">Regresar</a>
        </div >
 
    </div>


</asp:Content>
