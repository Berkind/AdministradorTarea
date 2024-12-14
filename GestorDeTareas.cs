namespace GestionDeTareas
{
    using System;
    using System.Collections.Generic;

    public class GestionTarea
    {
        private static List<Tarea> _tareas = new List<Tarea>();

        public static void CrearTarea()
        {
            Console.WriteLine("Ingrese el título de la tarea:");
            string titulo = Console.ReadLine();

            Console.WriteLine("Ingrese la descripción de la tarea (opcional):");
            string descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de vencimiento (formato: yyyy-mm-dd):");
            DateTime fechaVencimiento;
            while (!DateTime.TryParse(Console.ReadLine(), out fechaVencimiento))
            {
                Console.WriteLine("Fecha inválida. Intente nuevamente.");
            }

            Tarea nuevaTarea = new Tarea(titulo, fechaVencimiento, descripcion);
            _tareas.Add(nuevaTarea);
            Console.WriteLine("Tarea creada con éxito.");
        }

        public static void ListarTareas()
        {
            if (_tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas.");
                return;
            }

            Console.WriteLine("\nListado de tareas:");
            foreach (var tarea in _tareas)
            {
                Console.WriteLine($"ID: {tarea.Id}, Título: {tarea.Titulo}, Estado: {tarea.Estado}, Fecha de Vencimiento: {tarea.FechaVencimiento.ToShortDateString()}");
                if (!string.IsNullOrEmpty(tarea.Descripcion))
                    Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine();
            }
        }

        public static void ActualizarTarea()
        {
            Console.WriteLine("Ingrese el ID de la tarea a actualizar:");
            Guid id;
            if (!Guid.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Tarea tarea = _tareas.Find(t => t.Id == id);
            if (tarea == null)
            {
                Console.WriteLine("Tarea no encontrada.");
                return;
            }

            Console.WriteLine($"Tarea encontrada: {tarea.Titulo} - Estado: {tarea.Estado}");
            Console.WriteLine("¿Qué desea actualizar?");
            Console.WriteLine("1. Título");
            Console.WriteLine("2. Descripción");
            Console.WriteLine("3. Fecha de Vencimiento");
            Console.WriteLine("4. Estado");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el nuevo título:");
                    tarea.Titulo = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Ingrese la nueva descripción:");
                    tarea.Descripcion = Console.ReadLine();
                    break;

                case 3:
                    Console.WriteLine("Ingrese la nueva fecha de vencimiento (formato: yyyy-mm-dd):");
                    DateTime nuevaFecha;
                    while (!DateTime.TryParse(Console.ReadLine(), out nuevaFecha))
                    {
                        Console.WriteLine("Fecha inválida. Intente nuevamente.");
                    }
                    tarea.FechaVencimiento = nuevaFecha;
                    break;

                case 4:
                    Console.WriteLine("Ingrese el nuevo estado (1. Pendiente, 2. En Progreso, 3. Completada):");
                    int nuevoEstado = int.Parse(Console.ReadLine());
                    tarea.Estado = (EstadoTarea)(nuevoEstado - 1);
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("Tarea actualizada con éxito.");
        }

        public static void EliminarTarea()
        {
            Console.WriteLine("Ingrese el ID de la tarea a eliminar:");
            Guid id;
            if (!Guid.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }

            Tarea tarea = _tareas.Find(t => t.Id == id);
            if (tarea == null)
            {
                Console.WriteLine("Tarea no encontrada.");
                return;
            }

            _tareas.Remove(tarea);
            Console.WriteLine("Tarea eliminada con éxito.");
        }
    }
}
