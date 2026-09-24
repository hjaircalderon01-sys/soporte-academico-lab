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
            // Lista local del programa principal (NO variable global) -> Req. 9
            List<Solicitud> solicitudes = new List<Solicitud>();
            bool salir = false;

            while (!salir)
            {
                MostrarMenu();

                Console.Write("Elige una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarNuevaSolicitud(solicitudes);
                        break;
                    case "2":
                        MostrarTodasLasSolicitudes(solicitudes);
                        break;
                    case "3":
                        EjecutarPruebas(); // Req. 11
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

        // Req. 4: Función SIN retorno para mostrar el menú principal
        static void MostrarMenu()
        {
            Console.WriteLine("=== SOPORTE ACADÉMICO - REGISTRO DE ATENCIONES ===");
            Console.WriteLine("1. Registrar nueva solicitud");
            Console.WriteLine("2. Ver solicitudes registradas");
            Console.WriteLine("3. Ejecutar pruebas de validación");
            Console.WriteLine("0. Salir");
        }

        // Req. 2: Valida que el código de estudiante no esté vacío y tenga al menos 5 caracteres
        static bool ValidarCodigoEstudiante(string codigo)
        {
            const int LONGITUD_MINIMA = 5;
            if (string.IsNullOrWhiteSpace(codigo))
                return false;
            return codigo.Trim().Length >= LONGITUD_MINIMA;
        }

        // Req. 3: Valida que el tipo de consulta esté dentro de la lista de tipos permitidos
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

        // Req. 5: Asigna la prioridad de atención según el tipo de consulta recibido
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

        // Req. 6: Función CON retorno para validar texto obligatorio
        static bool ValidarTextoObligatorio(string texto, int longitudMinima)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return false;
            return texto.Trim().Length >= longitudMinima;
        }

        // Req. 7: Función SIN retorno para mostrar el resumen de una solicitud
        static void MostrarResumenSolicitud(Solicitud s)
        {
            Console.WriteLine("----- Resumen de la solicitud -----");
            Console.WriteLine($"Código estudiante : {s.CodigoEstudiante}");
            Console.WriteLine($"Nombre            : {s.Nombre}");
            Console.WriteLine($"Tipo de consulta  : {s.TipoConsulta}");
            Console.WriteLine($"Descripción       : {s.Descripcion}");
            Console.WriteLine($"Prioridad         : {s.Prioridad}");
            Console.WriteLine("------------------------------------\n");
        }

        // Req. 8, 9, 10: Registra una nueva solicitud. La lista llega por parámetro (Req. 8),
        // 'nueva' es variable local (Req. 9), y permite registrar cuantas solicitudes se quiera (Req. 10).
        static void RegistrarNuevaSolicitud(List<Solicitud> solicitudes)
        {
            Solicitud nueva = new Solicitud();

            Console.Write("Código de estudiante: ");
            nueva.CodigoEstudiante = Console.ReadLine();
            if (!ValidarCodigoEstudiante(nueva.CodigoEstudiante))
            {
                Console.WriteLine("Código inválido (vacío o menor a 5 caracteres). Registro cancelado.\n");
                return;
            }

            Console.Write("Nombre del estudiante: ");
            nueva.Nombre = Console.ReadLine();
            if (!ValidarTextoObligatorio(nueva.Nombre, 2))
            {
                Console.WriteLine("Nombre inválido. Registro cancelado.\n");
                return;
            }

            Console.Write("Tipo de consulta (matricula, pagos, constancia, plataforma, otro): ");
            nueva.TipoConsulta = Console.ReadLine();
            if (!ValidarTipoConsulta(nueva.TipoConsulta))
            {
                Console.WriteLine("Tipo de consulta no reconocido. Registro cancelado.\n");
                return;
            }

            Console.Write("Descripción breve: ");
            nueva.Descripcion = Console.ReadLine();
            if (!ValidarTextoObligatorio(nueva.Descripcion, 3))
            {
                Console.WriteLine("Descripción inválida. Registro cancelado.\n");
                return;
            }

            nueva.Prioridad = AsignarPrioridad(nueva.TipoConsulta);

            solicitudes.Add(nueva);
            Console.WriteLine("Solicitud registrada con éxito.\n");
            MostrarResumenSolicitud(nueva);
        }

        // Muestra todas las solicitudes registradas (recibe la lista por parámetro)
        static void MostrarTodasLasSolicitudes(List<Solicitud> solicitudes)
        {
            if (solicitudes.Count == 0)
            {
                Console.WriteLine("Aún no hay solicitudes registradas.\n");
                return;
            }

            Console.WriteLine($"Total de solicitudes registradas: {solicitudes.Count}\n");
            foreach (Solicitud s in solicitudes)
            {
                MostrarResumenSolicitud(s);
            }
        }

        // ---------------------------------------------------------------------
        // Req. 11: Al menos 5 pruebas: datos válidos, datos vacíos,
        // tipo de consulta incorrecto, prioridad alta y prioridad baja.
        // ---------------------------------------------------------------------
        static void EjecutarPruebas()
        {
            Console.WriteLine("===== EJECUTANDO PRUEBAS DE VALIDACIÓN =====\n");

            bool p1 = ValidarCodigoEstudiante("EST001") && ValidarTipoConsulta("pagos");
            Console.WriteLine($"Prueba 1 (datos válidos) - Esperado: True | Obtenido: {p1}");

            bool p2 = ValidarCodigoEstudiante("");
            Console.WriteLine($"Prueba 2 (código vacío) - Esperado: False | Obtenido: {p2}");

            bool p3 = ValidarTipoConsulta("reclamo");
            Console.WriteLine($"Prueba 3 (tipo inválido 'reclamo') - Esperado: False | Obtenido: {p3}");

            string p4 = AsignarPrioridad("plataforma");
            Console.WriteLine($"Prueba 4 (prioridad de 'plataforma') - Esperado: Alta | Obtenido: {p4}");

            string p5 = AsignarPrioridad("constancia");
            Console.WriteLine($"Prueba 5 (prioridad de 'constancia') - Esperado: Baja | Obtenido: {p5}");

            Console.WriteLine("\n===== FIN DE PRUEBAS =====\n");
        }
    }
}