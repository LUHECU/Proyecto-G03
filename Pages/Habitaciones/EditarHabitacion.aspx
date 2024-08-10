﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarHabitacion.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Habitaciones.EditarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="pnlContenido"  runat="server">
    <div class="container">
<div>
</div>
<div class="mt-4 mb-4"> 
<h1>Agregar habitación</h1>
</div>

<div >
<asp:ValidationSummary ID="vsGeneral" runat="server" DisplayMode="BulletList" HeaderText="Error al editar" class="alert alert-danger tras"/>
</div>

<div>
<div>
<asp:Label ID="lblHabitacion" runat="server" Text="Hotel" ></asp:Label>
</div>
<div>
<asp:TextBox ID="txtIdhotel" runat="server" class="form-control" ReadOnly="true"></asp:TextBox>
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
<div  class="mt-4 mb-4">
<asp:Button ID="btnGuardar" runat="server" Text="Guardar" Cssclass="btn btn-success" Onclick="btnGuardar_Click" />
<asp:Button ID="btnInactivar" runat="server" Text="Inactivar" CssClass="btn btn-danger" Onclick="btnInactivar_Click"/>
<!-- Enlace para cancelar y volver a la página principal -->
<a href="ListaHabitaciones.aspx" class="btn btn-light btn-outline-secondary" >Regresar</a>
</div >
</div>


     </asp:Panel>
<asp:PlaceHolder ID="phAlerta" runat="server" Visible="false">
  <div class="card text-center position-fixed" style="top: 50%; left: 50%; transform: translate(-50%, -50%); width: 18rem;">
     <div class="card-body">
         <h5 class="card-title text-danger">Alerta</h5>
         <p class="card-text ">¿Desea inactivar la habitación?</p>
         <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" CssClass="card-link btn btn-danger" OnClick="btnConfirmar_Click"/>
         <asp:Button ID="btnNoConfirmar" runat="server" Text="Regresar"  CssClass="card-link btn btn-light btn-outline-secondary" OnClick="btnNoConfirmar_Click"/>
     </div>
 </div>
    </asp:PlaceHolder>

</asp:Content>
