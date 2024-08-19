using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSurtidores
{
    public class Operaciones
    {
        public enum TipoOperaciones
        {
            LiberarSurtidor,
            ComprobarEstadoSurtidores,
            PrefijarSurtidor,
            ComprobarHistorialSurtidores
        }

        public static Dictionary<TipoOperaciones, string> DescripcionesOperaciones = new Dictionary<TipoOperaciones, string>
        {
            { TipoOperaciones.LiberarSurtidor, "Liberar surtidor." },
            { TipoOperaciones.ComprobarEstadoSurtidores, "Comprobar el estado de los surtidores." },
            { TipoOperaciones.PrefijarSurtidor, "Prefijar un surtidor." },
            { TipoOperaciones.ComprobarHistorialSurtidores, "Comprobar historial de los surtidores." }
        };
    }
}
