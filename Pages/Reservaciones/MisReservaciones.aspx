<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MisReservaciones.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.MisReservaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Mis Reservaciones</h2>
        </div>
   
        <div class="m my-3">
            <a href="CrearReservacion.aspx" class="btn btn-primary">Nueva Resevación</a>
        </div>

        <div>

            <%-- Agregar validacion de persona --%>
            <asp:GridView ID="grdMisReserv" runat="server" AutoGenerateColumns="false" CssClass="border-1" CellPadding="10">
                <Columns>
                    <asp:BoundField DataField="idReservacion" HeaderText="# reservación" ItemStyle-CssClass="text-center w-auto" HeaderStyle-CssClass="text-center"/>
                    <asp:BoundField DataField="nombreHotel" HeaderText="Hotel" ItemStyle-CssClass="w-auto"/>
                    <asp:BoundField DataField="fechaEntrada" HeaderText="Fecha entrada" ItemStyle-CssClass="w-auto" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:BoundField DataField="fechaSalida" HeaderText="Fecha salida" ItemStyle-CssClass="w-auto" DataFormatString="{0:dd/MM/yyyy}"/>
                    <asp:TemplateField ItemStyle-CssClass="w-auto m-auto h-auto" HeaderText="Costo">
                        <ItemTemplate>
                            $<%# Decimal.Parse(Eval("costoTotal").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="w-auto m-auto h-auto" HeaderText="Estado">
                        <ItemTemplate>
                            <%# estadoReservacion(DateTime.Parse(Eval("FechaEntrada").ToString()), DateTime.Parse(Eval("fechaSalida").ToString()), Eval("estado").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-CssClass="w-auto m-auto h-auto" >
                        <ItemTemplate>
                            <a href="Detalle.aspx?id=<%# Eval("idReservacion")%>" class="btn btn-light btn-outline-secondary">Consultar</a>
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>
            </asp:GridView>
        </div>

    </div>

</asp:Content>
