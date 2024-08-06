<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="ProyectoFinal_G03.Pages.Reservaciones.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">

        <div class="mt-4 mb-4">
            <h2>Detalle de Reservación</h2>
        </div>


        <div>

            <asp:Label ID="lblIdReservacion" runat="server" Text="" Visible="false"></asp:Label>

            <asp:Table runat="server" CssClass="table table-bordered border-secondary border-opacity-50 w-25">
                <asp:TableRow>
                    <asp:TableCell CssClass="w-25 bg-secondary bg-opacity-25 fw-bold">
                        # reservación
                    </asp:TableCell>
                    <asp:TableCell CssClass="w-25">
                        <asp:Label ID="lblNumReserv" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>



                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Hotel
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblHotel" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Número habitación
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblNumHabitacion" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>


                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Cliente
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblCLiente" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Fecha de entrada
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblFechaEntrada" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>


                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Fecha de salida
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblFechaSalida" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Días de la reserva
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblDiasReserva" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Número de niños
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblNumNunhos" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Número de adultos
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblNumAdultos" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell CssClass="bg-secondary bg-opacity-25 fw-bold">
                        Costo total
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblCostoTotal" runat="server" Text=""></asp:Label>
                    </asp:TableCell>

                </asp:TableRow>

            </asp:Table>

            
            
        </div>


        <div class="row">

            <div class="col col-sm-6 col-md-4 col-lg-1 mr-5">
                 <div class="mt-4">
                     <asp:Button ID="btnEditarReserv" runat="server" Text="Editar reservación" CssClass="btn btn-primary" OnClick="btnEditarReserv_Click"/>
                 </div>
             </div>

            <div class="col col-sm-6 col-md-4 col-lg-1 mx-5 ">
                 <div class="mt-4 mx-4">
                     <asp:Button ID="btnCancelarReserv" runat="server" Text="Cancelar reservacion" CssClass="btn btn-danger" OnClick="btnCancelarReserv_Click"/>
                 </div>
             </div>

            <div class="col col-sm-6 col-md-4 col-lg-1 mx-5">
                 <div class="mt-4 mx-4">
                     <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-light btn-outline-secondary" OnClick="btnRegresar_Click" />
                 </div>
             </div>


        </div>


        <div class="mt-4">

            <div>
                <h2>Lista de acciones realizadas</h2>
            </div>

            <div>
                <asp:GridView ID="grdBitacora" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered w-auto">
                    <Columns>
                        <asp:BoundField DataField="fechaDeLaAccion" HeaderText="Fecha" HeaderStyle-CssClass="w-25" DataFormatString="{0:dd/MM/yyyy HH:mm}"/>
                        <asp:BoundField DataField="accionRealizada" HeaderText="Acción" HeaderStyle-CssClass="w-auto"/>
                        <asp:BoundField DataField="nombreCompleto" HeaderText="Realizado por" HeaderStyle-CssClass="w-auto"/>
                    </Columns>
                </asp:GridView>
            </div>
            
        </div>
        
    </div>

</asp:Content>
