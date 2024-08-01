<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Habitaciones.EditarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div>
        </div>
        <div class="mt-4 mb-4"> 
        <h1>Agregar habitación</h1>
        </div>
 
                    <div>
        <div>
        <asp:Label ID="lblHabitacion" runat="server" Text="Hotel" ></asp:Label>
        </div>
 
        <div>
        <asp:TextBox ID="txtIdhotel" runat="server" class="form-control"></asp:TextBox>
        </div>
 
        <div>
        <asp:Label ID="lblNumeroHabitacion" runat="server" Text="Número de habitación"></asp:Label>
        </div>
        <div>
        <asp:TextBox ID="txtNumeroHabitacion" runat="server" class="form-control"></asp:TextBox>
        </div>
 
        <div>
        <asp:Label ID="lblCapacidadMaxima" runat="server" Text="Capacidad Máxima"></asp:Label>
        </div>
 
        <div>
        <asp:TextBox ID="txtCapacidadMaxima" runat="server" class="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <div>
        <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" ></asp:Label>
        </div>
 
     
        <div>
        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" TextMode="MultiLine" Rows="4" Columns="80" MaxLength="500"  placeholder="Ingrese una descripción  aquí..." ></asp:TextBox>
        </div>     
        </div>

 
      
        <%--Botenes--%>
 
                <div  class="mt-4 mb-4">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Cssclass="btn btn-primary" Onclick="btnGuardar_Click" />
        <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-danger" Onclick="btnInactivar_Click" />
        <!-- Enlace para cancelar y volver a la página principal -->
        <a href="ListaHabitaciones.aspx" class="btn btn-info" >Cancelar</a>
        </div >
 
    </div>


</asp:Content>
