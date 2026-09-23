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

        // ---------------------------------------------------------
        // Req. 2: Valida que el código de estudiante no esté vacío
        // y tenga al menos 5 caracteres
        // ---------------------------------------------------------
        static bool ValidarCodigoEstudiante(string codigo)
        {
            const int LONGITUD_MINIMA = 5;

            if (string.IsNullOrWhiteSpace(codigo))
                return false;

            return codigo.Trim().Length >= LONGITUD_MINIMA;
        }

        // ---------------------------------------------------------
        // Req. 3: Valida que el tipo de consulta esté dentro de
        // la lista de tipos permitidos
        // ---------------------------------------------------------
        static bool ValidarTipoConsulta(string tipo)
        {
            string[] tiposValidos = { "matricula", "pagos", "constancia", "plataforma", "otro" };

            if (string.IsNullOrWhiteSpace(tipo))
                return false;

            string tipoNormalizado = tipo.Trim().ToLower();

            foreach (string t in tiposValidos)
            {
                if (t == tipoNormalizado)
                    return true;
            }
            return false;
        }

        // ---------------------------------------------------------
        // Req. 5: Asigna la prioridad de atención según el tipo
        // de consulta recibido
        // ---------------------------------------------------------
        static string AsignarPrioridad(string tipoConsulta)
        {
            string tipo = tipoConsulta.Trim().ToLower();

            switch (tipo)
            {
                case "plataforma":
                case "pagos":
                    return "Alta";
                case "matricula":
                    return "Media";
                case "constancia":
                case "otro":
                    return "Baja";
                default:
                    return "Sin clasificar";
            }
        }
    }
}
