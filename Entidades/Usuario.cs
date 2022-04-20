using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        private int _edad;
        public int idUsuario { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }        
        public string dni { get; set; }        
        public string email { get; set; }
        public string pass { get; set; }        
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string ocupacion { get; set; }
        public DateTime fechaIngreso { get; set; }
        public DateTime fechaNacimiento { get; set; }        
        public string matricula { get; set; }
        public bool esAdmin { get; set; }        
        public bool cuentaConfirmada { get; set; }
        public int idRol { get; set; }
        public int idEspecialidad { get; set; }
        public int idReferencia { get; set; }
        public int idObraSocial { get; set; }        

        public int edad
        {
            get
            {//calculando la edad de la persona si es menor o igual a 0 dependiendo la fecha de nacimiento que ingrese.
                if (this._edad <= 0)
                {
                    this._edad = new DateTime(DateTime.Now.Subtract(this.fechaNacimiento).Ticks).Year - 1;
                }
                return _edad;
            }
        }
        
    }
}
