using System;
using GestionDeTareas;

public class Programa
{
    public static void Main(string[] args)
    {
        bool salir = false;

        while (!salir)
        {
            Console.Clear();
            Console.WriteLine("Menú de tareas:");
            Console.WriteLine("1. Crear tarea");
            Console.WriteLine("2. Listar tareas");
            Console.WriteLine("3. Actualizar tarea");
            Console.WriteLine("4. Eliminar tarea");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    GestorDeTareas.CrearTarea();
                    break;
                case 2:
                    GestorDeTareas.ListarTareas();
                    break;
                case 3:
                    GestorDeTareas.ActualizarTarea();
                    break;
                case 4:
                    GestorDeTareas.EliminarTarea();
                    break;
                case 5:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            if (!salir)
            {
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
