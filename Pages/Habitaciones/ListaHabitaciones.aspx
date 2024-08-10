<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaHabitaciones.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Habitaciones.ListaHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">

                <div class="mt-4 mb-4">

                    <h1>Lista de habitaciones</h1>

                </div>

                <div class="m my-3">

                    <a href="CrearHabitacion.aspx" class="btn btn-primary">Agregar habitación</a>

                </div>
 
                <div>

                <asp:GridView ID="grdHabitaciones" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered">

                    <Columns>

                        <asp:BoundField DataField="idHabitacion" HeaderText="ID" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="data-center" />

                        <asp:BoundField DataField="nombreHotel" HeaderText="Hotel" HeaderStyle-CssClass="header-left" ItemStyle-CssClass="data-left" />

                        <asp:BoundField DataField="numeroHabitacion" HeaderText="Número Habitación" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="data-center" />

                        <asp:BoundField DataField="capacidadMaxima" HeaderText="Capacidad Máxima" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="data-center" />

                        <asp:BoundField DataField="idHotel" HeaderText="Id Hotel" HeaderStyle-CssClass="header-center" ItemStyle-CssClass="data-center" Visible="false" />
 
                        <asp:TemplateField HeaderText="Estado">

                        <HeaderStyle CssClass="header-center" />

                        <ItemStyle CssClass="data-center" />

                        <ItemTemplate>

                        <!-- TemplateField para mostrar el estado como Activo o Inactivo -->

                        <asp:Label ID="lblEstado" runat="server"

                        Text='<%# Eval("estado").ToString() == "A" ? "Activo" : (Eval("estado").ToString() == "I" ? "Inactivo" : "") %>'>

                        </asp:Label>

                        </ItemTemplate>

                        </asp:TemplateField>
 
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="EditarHabitacion.aspx?id=<%# Eval("idHabitacion")%>&idHotel=<%# Eval("idHotel")%>" class="btn btn-light btn-outline-secondary">Modificar</a>

                            </ItemTemplate>

                        </asp:TemplateField>

                        </Columns>

                        </asp:GridView>

            </div>

        </div>
 

</asp:Content>
