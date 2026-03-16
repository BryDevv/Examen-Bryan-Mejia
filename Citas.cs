using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Bryan_Mejia
{
    internal class Citas
    {
        string iddoc;
        string idpaciente;
        DateTime fecha;

        public string Iddoc { get => iddoc; set => iddoc = value; }
        public string Idpaciente { get => idpaciente; set => idpaciente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
