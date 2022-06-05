<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PreguntasFrecuentes.aspx.cs" Inherits="MeetingApp.PreguntasFrecuentes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeaderContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h3 style="color: red; text-align: center">Preguntas frecuentes</h3>
        <hr />

        <%--ACORDION--%>
        <div class="accordion" id="accordionExample">
            <div class="card">
                <div class="card-header" id="headingOne">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left" type="button" data-toggle="collapse" data-target="#collapseOne" aria-expanded="false" aria-controls="collapseOne">
                            ¿Como hago para utilizar el sistema?
                        </button>
                    </h2>
                </div>

                <div id="collapseOne" class="collapse" aria-labelledby="headingOne" data-parent="#accordionExample">
                    <div class="card-body">
                        En el Login hacer click en "Registrarme", luego debe completar los datos segun corresponda si es Paciente o Profesional se le enviara un email a su casilla de correo informando su Usuario y Contraseña, a partir de eso ya puede Iniciar sesión al sistema. Usted podra ingresar al sistema con su Email o su numero de D.N.I.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingTwo">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            ¿Cómo puedo obtener un turno?
                            <%--¿Cómo puedo obtener un turno para que me atienda un profesional?--%>
                        </button>
                    </h2>
                </div>
                <div id="collapseTwo" class="collapse" aria-labelledby="headingTwo" data-parent="#accordionExample">
                    <div class="card-body">
                        <b>Soy Paciente:</b> Debe dirigirse a la solapa "Nuevo Turno", una vez alli debe seleccionar una especialidad y se desplegaran los profesioles a cargo, selecciona un profesional y selecciona una fecha en el calendario, luego dar click en el boton "Mostrar horarios" y si hay horarios disponibles apareceran en el desplegable para que seleccione el horario que desee, sino hay horarios puede seleccionar otra fecha, luego elegir una forma de pago y el motivo del turno, dar click en "Reservar turno" y se le informara en una ventana emergente los datos del turno para asi poder confirmar si es todo correcto, una vez de hacer click en "Confirmar" y vera una notificacion si el turno fue reservado correctamente.<br />
                        <b>Soy Profesional:</b> Debe dirigirse a la solapa "Asignar Turno", una vez alli debe ingresar el D.N.I del paciente y si es correcto vera sus datos, selecciona una fecha en el calendario, luego dar click en el boton "Mostrar horarios" y si hay horarios disponibles apareceran en el desplegable para que seleccione el horario que desee, sino hay horarios puede seleccionar otra fecha, luego elegir una forma de pago y el motivo del turno, dar click en "Reservar turno" y se le informara en una ventana emergente los datos del turno para asi poder confirmar si es todo correcto, una vez de hacer click en "Confirmar" y vera una notificacion si el turno fue reservado correctamente.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingThree">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            ¿Puedo cambiar mi turno?
                        </button>
                    </h2>
                </div>
                <div id="collapseThree" class="collapse" aria-labelledby="headingThree" data-parent="#accordionExample">
                    <div class="card-body">
                        El turno no se puede cambiar, debe cancelar el que tiene y sacar uno nuevo.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingFour">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                            ¿Como cancelo un turno?
                        </button>
                    </h2>
                </div>
                <div id="collapseFour" class="collapse" aria-labelledby="headingFour" data-parent="#accordionExample">
                    <div class="card-body">
                        <b>Soy Paciente:</b> Debe dirigirse a la solapa "Mis Turnos", usted podra ver su turno y los datos correspondientes, luego debe dar click en el boton "Cancelar turno" y una notificacion confirmara que esta dado de baja.<br />
                        <b>Soy Profesional:</b> Debe dirigirse a la solapa "Turnos Asignados", debera ingresar el D.N.I del paciente al cual quiere cancelarle el turno y dar click en "Buscar Paciente" y podra ver los datos correspondientes del turno, luego dar click en el boton "Cancelar turno" y una notificacion confirmara que esta dado de baja.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingFive">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseFive" aria-expanded="false" aria-controls="collapseFive">
                            ¿Puedo modificar mis datos?
                        </button>
                    </h2>
                </div>
                <div id="collapseFive" class="collapse" aria-labelledby="headingFive" data-parent="#accordionExample">
                    <div class="card-body">
                        Debe dirigirse a la solapa "Mis datos", alli dar click en el boton "Modificar", luego de completar los datos debe dar click en "Aceptar" y recibira una notificacion de que sus datos fueron actualizados correctamente.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingSix">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseSix" aria-expanded="false" aria-controls="collapseSix">
                            ¿Cuales son los medios de pagos que se aceptan?
                        </button>
                    </h2>
                </div>
                <div id="collapseSix" class="collapse" aria-labelledby="headingSix" data-parent="#accordionExample">
                    <div class="card-body">
                        Los medios de pagos son: Efectivo, Debito, Transferencia Bancaria y Tarjeta de Credito.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingSeven">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseSeven" aria-expanded="false" aria-controls="collapseSeven">
                            Soy Profesional ¿Cómo hago para definir mi rango horario de atención?
                        </button>
                    </h2>
                </div>
                <div id="collapseSeven" class="collapse" aria-labelledby="headingSeven" data-parent="#accordionExample">
                    <div class="card-body">
                        Debe comunicarse con el Administrador del sistema y el podra cargar sus horarios correspondientes para cada dia de la semana.
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header" id="headingEight">
                    <h2 class="mb-0">
                        <button class="btn btn-link btn-block text-left collapsed" type="button" data-toggle="collapse" data-target="#collapseEight" aria-expanded="false" aria-controls="collapseEight">
                            Soy Profesional ¿Puedo ver mis turnos Activos y Cancelados?
                        </button>
                    </h2>
                </div>
                <div id="collapseEight" class="collapse" aria-labelledby="headingEight" data-parent="#accordionExample">
                    <div class="card-body">
                        Usted dispone de cuatro reportes. Turnos Activos, Turnos Cancelados, Formas de pagos mas utilizadas por mes y Pacientes que tuvieron mas de un turno por mes.
                    </div>
                </div>
            </div>
        </div>
        <%--FIN ACORDION--%>
    </div>


</asp:Content>
