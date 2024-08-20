using System;
using System.Collections.Generic;
using System.Linq;
using h = System.Console;

namespace ClassSurtidores
{
    public class Program
    {
        private static List<Surtidor> surtidores = new List<Surtidor>
        {
            new Surtidor(1, true),
            new Surtidor(2, true),
            new Surtidor(3, true)
        };
        public static void Main(string[] args)
        {
            int idSurtidor = 0;
            h.WriteLine("Elige una operación:\n");

            foreach (KeyValuePair<Operaciones.TipoOperaciones, string> operacion in Operaciones.DescripcionesOperaciones)
            {
                int numeroOperacion = (int)operacion.Key + 1;
                h.WriteLine($"[{numeroOperacion}] {operacion.Value}");
            }

            int operacionEscogida = 0;
            try
            {
                operacionEscogida = Convert.ToInt32(h.ReadLine()) - 1;
            }
            catch (Exception ex)
            {
                h.WriteLine($"Operación no válida: {ex.Message.ToString()}");
                return;
            }
            if (operacionEscogida < 0 || operacionEscogida >= Operaciones.DescripcionesOperaciones.Count())
            {
                h.WriteLine($"La operación debe ser un número entre 1 y {Operaciones.DescripcionesOperaciones.Count.ToString()}");
                return;
            }
            Operaciones.TipoOperaciones tipoOperacion = (Operaciones.TipoOperaciones)operacionEscogida;
            h.WriteLine($"Has escogido la operación: {Operaciones.DescripcionesOperaciones[tipoOperacion]}");

            switch (tipoOperacion)
            {
                case Operaciones.TipoOperaciones.LiberarSurtidor:
                    h.WriteLine("Introduce el Id del surtidor a liberar:");
                    idSurtidor = Convert.ToInt32(h.ReadLine());
                    Surtidor surtidorLiberado = surtidores.FirstOrDefault(x => x.Id == idSurtidor);
                    if (surtidorLiberado != null)
                    {
                        surtidorLiberado.LiberarSurtidor();
                        string estadoSurtidor = surtidorLiberado.Estado ? "Ocupado" : "Libre";
                        h.WriteLine($"Surtidor {surtidorLiberado.Id} liberado. Estado: {estadoSurtidor}");
                        Main(args);
                    }
                    else
                    {
                        h.WriteLine($"No se encontró el surtidor con Id {idSurtidor}");
                    }
                    break;

                case Operaciones.TipoOperaciones.BloquearSurtidor:
                    h.WriteLine("Introduce el Id del surtidor a bloquear:");
                    idSurtidor = Convert.ToInt32(h.ReadLine());
                    Surtidor surtidorBloqueado = surtidores.FirstOrDefault(x => x.Id == idSurtidor);
                    if (surtidorBloqueado != null)
                    {
                        surtidorBloqueado.OcuparSurtidor();
                        string estadoSurtidor = surtidorBloqueado.Estado ? "Ocupado" : "Libre";
                        h.WriteLine($"Surtidor {surtidorBloqueado.Id} bloqueado. Estado: {estadoSurtidor}");
                        Main(args);
                    }
                    else
                    {
                        h.WriteLine($"No se encontró el surtidor con Id {idSurtidor}");
                    }
                    break;

                case Operaciones.TipoOperaciones.ComprobarEstadoSurtidores:
                    h.WriteLine("Ejecutando: Comprobar el estado de los surtidores.");
                    foreach (Surtidor surtidor in surtidores)
                    {
                        string estado = surtidor.Estado ? "ocupado" : "libre";
                        h.WriteLine($"Surtidor {surtidor.Id} está {estado}");
                    }
                    Main(args);
                    break;

                case Operaciones.TipoOperaciones.PrefijarSurtidor:
                    h.WriteLine("Introduce el Id del surtidor a prefijar:");
                    int idPrefijar = Convert.ToInt32(h.ReadLine());
                    Surtidor surtidorPrefijar = surtidores.FirstOrDefault(x => x.Id == idPrefijar);
                        if (surtidorPrefijar != null)
                        {
                            if (surtidorPrefijar.Estado)
                            {
                                h.WriteLine("El surtidor está ocupado");
                                Main(args);
                            }
                            else
                            {
                                h.WriteLine("Introduce el importe máximo a suministrar (o deja en blanco para no prefijar):");
                                string input = h.ReadLine();
                                int? importe = string.IsNullOrEmpty(input) ? (int?)null : Convert.ToInt32(input);
                                surtidorPrefijar.PrefijarImporte(importe, Historial.historialGlobal);
                                surtidorPrefijar.OcuparSurtidor();
                                string mensajeImporte = importe.HasValue ? $"{importe} euros" : "sin prefijar";
                                h.WriteLine($"Surtidor {surtidorPrefijar.Id} prefijado con un importe de {mensajeImporte}.");
                                Main(args);
                            }
                        }
                        else
                        {
                            h.WriteLine($"No se encontró el surtidor con Id {idPrefijar}");
                        }
                    break;

                case Operaciones.TipoOperaciones.ComprobarHistorialSurtidores:
                    h.WriteLine("Ejecutando: Comprobar historial de los suministros.");
                    Historial historial = new Historial();
                    List<Suministro> historialOrdenado = historial.ObtenerHistorialOrdenadoPorImporte(Historial.historialGlobal);
                    foreach (Suministro suministro in historialOrdenado)
                    {
                        h.WriteLine($"Surtidor {suministro.Surtidor.Id}, Fecha y Hora: {suministro.FechaHora}, Importe Prefijado: {suministro.ImportePrefijado}, Importe Final: {suministro.ImporteFinal}");
                    }
                    Main(args);
                    break;

                default:
                    h.WriteLine("Operación no válida.");
                    break;
            }
        }
    }
}