using System;

public enum EstadoTarea
{
    Pendiente,
    EnProgreso,
    Completada
}

public class Tarea
{
    public Guid Id { get; }
    public string Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public EstadoTarea Estado { get; set; }

    public Tarea(string titulo, DateTime fechaVencimiento, string? descripcion = null)
    {
        Id = Guid.NewGuid(); // Genera un identificador único
        Titulo = titulo;
        FechaVencimiento = fechaVencimiento;
        Descripcion = descripcion;
        Estado = EstadoTarea.Pendiente; 
    }
}

