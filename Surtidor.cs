using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSurtidores
{
    public class Surtidor
    {
        public int Id { get; }
        public bool Estado { get; private set; }
        public List<Suministro> historialSuministros;
        public enum Surtidores
        {
            ComprobarEstadoSurtidores,
            PrefijarSurtidor,
            ComprobarHistorialSurtidores
        }
        public int? ImportePrefijado { get; private set; }
        public Surtidor(int id, bool estado)
        {
            Id = id;
            Estado = estado;
            historialSuministros = new List<Suministro>();
        }

        public void NotificarSuministro(DateTime fechaHora, int? importePrefijado, double importeFinal, List<Suministro> historialGlobal)
        {
            if (Estado)
                throw new InvalidOperationException("El surtidor está bloqueado y no puede realizar suministros.");

            Suministro suministro = new Suministro(this, fechaHora, importePrefijado, importeFinal);
            historialSuministros.Add(suministro);
            historialGlobal.Add(suministro);

            // Bloquear el surtidor y eliminar el importe prefijado
            Estado = false;
            ImportePrefijado = null;
        }
        public List<bool> ObtenerEstados()
        {
            return historialSuministros.Select(x => x.Surtidor.Estado).ToList();
        }
        public void LiberarSurtidor()
        {
            Estado = false;
            ImportePrefijado = null;
        }
        public void OcuparSurtidor()
        {
            Estado = true;
        }
        public void PrefijarImporte(int? importe, List<Suministro> historialGlobal)
        {
            ImportePrefijado = importe;
            NotificarSuministro(DateTime.Now, importe, 0, historialGlobal);
        }
    }
}
