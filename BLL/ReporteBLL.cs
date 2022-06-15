using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;
using Entidades.DTOs;

namespace BLL
{
    public class ReporteBLL
    {
        ReporteDAL _reporteDAL = new ReporteDAL();

        //REPORTE 1
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosActivosPorFechas(int idProfesional, DateTime fecha1, DateTime fecha2)
        {
            return _reporteDAL.ObtenerTurnosActivosPorFechas(idProfesional,fecha1, fecha2);
        }

        //REPORTE 2
        public List<ObtenerFormasDePagosDTO> ObtenerFormasDePagos(int idProfesional,  int mes)
        {
            return _reporteDAL.ObtenerFormasDePagos(idProfesional, mes);
        }

        //REPORTE 3
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosCanceladosPorFechas(int idProfesional, DateTime fecha1, DateTime fecha2)
        {
            return _reporteDAL.ObtenerTurnosCanceladosPorFechas(idProfesional, fecha1, fecha2);
        }

        //REPORTE 4
        public List<ObtenerTurnosPorMesDTO> ObtenerTurnosPorMes(int idProfesional, DateTime fecha1, DateTime fecha2)
        {
            return _reporteDAL.ObtenerTurnosPorMes(idProfesional, fecha1, fecha2);
        }




    }
}
