using System;
using System.Collections.Generic;

namespace SoporteAcademico
{
    // Estructura para representar una solicitud (Req. 1)
    struct Solicitud
    {
        public string CodigoEstudiante;
        public string Nombre;
        public string TipoConsulta;
        public string Descripcion;
        public string Prioridad;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Lista local del programa principal (Req. 1: base para registrar solicitudes)
            List<Solicitud> solicitudes = new List<Solicitud>();
            bool salir = false;

            while (!salir)
            {
                // Menú básico por ahora, sin función aparte todavía (eso llega en el Req. 4)
                Console.WriteLine("=== SOPORTE ACADÉMICO - REGISTRO DE ATENCIONES ===");
                Console.WriteLine("1. Registrar nueva solicitud");
                Console.WriteLine("0. Salir");

                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("(Registro de solicitud pendiente de implementar)\n");
                        break;
                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.\n");
                        break;
                }
            }

            Console.WriteLine("Programa finalizado.");
        }
    }
}