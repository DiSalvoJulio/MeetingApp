﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using Entidades;

namespace BLL
{
    public class ProfesionalBLL
    {
        ProfesionalDAL _profesionalDAL = new ProfesionalDAL();

        public void ActualizarDatosProfesional(Usuario user)
        {
            _profesionalDAL.ActualizarDatosProfesional(user);
        }
     


    }
}
