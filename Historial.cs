using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSurtidores
{
    public class Historial
    {
        public static List<Suministro> historialGlobal = new List<Suministro>();
        public List<Suministro> ObtenerHistorialOrdenadoPorImporte(List<Suministro> historialSuministros)
        {
            return historialSuministros
                .OrderByDescending(x => x.ImporteFinal)
                .ThenByDescending(x => x.FechaHora)
                .ToList();
        }
    }
}
