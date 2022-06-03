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
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosActivosPorFechas(DateTime fecha1, DateTime fecha2)
        {
            return _reporteDAL.ObtenerTurnosActivosPorFechas(fecha1, fecha2);
        }

        //REPORTE 2
        public List<ObtenerFormasDePagosDTO> ObtenerFormasDePagos(int mes)
        {
            return _reporteDAL.ObtenerFormasDePagos(mes);
        }

        //REPORTE 3
        public List<ObtenerTurnosActivosPorFechasDTO> ObtenerTurnosCanceladosPorFechas(DateTime fecha1, DateTime fecha2)
        {
            return _reporteDAL.ObtenerTurnosCanceladosPorFechas(fecha1, fecha2);
        }

        //REPORTE 4
        public List<ObtenerTurnosPorMesDTO> ObtenerTurnosPorMes(int mes)
        {
            return _reporteDAL.ObtenerTurnosPorMes(mes);
        }




    }
}
