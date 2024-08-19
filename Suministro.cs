using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSurtidores
{
    public class Suministro
    {
        public Surtidor Surtidor { get; }
        public DateTime FechaHora { get; }
        public int? ImportePrefijado { get; }
        public double ImporteFinal { get; }

        public Suministro(Surtidor surtidor, DateTime fechaHora, int? importePrefijado, double importeFinal)
        {
            Surtidor = surtidor;
            FechaHora = fechaHora;
            ImportePrefijado = importePrefijado;
            ImporteFinal = importeFinal;
        }
    }
}
