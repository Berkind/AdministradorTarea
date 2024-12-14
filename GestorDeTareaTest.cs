using System;
using Xunit;
using GestionDeTareas; 

namespace GestionDeTareas.Tests
{
    public class GestionTareaTests
    {
        
        [Fact]
        public void CrearTarea_Correctamente()
        {
            string titulo = "Tarea de prueba";
            DateTime fechaVencimiento = DateTime.Now.AddDays(2);
            string descripcion = "Descripción de la tarea de prueba";

            Tarea tarea = new Tarea(titulo, fechaVencimiento, descripcion);

            
            Assert.NotNull(tarea);
            Assert.Equal(titulo, tarea.Titulo);
            Assert.Equal(fechaVencimiento, tarea.FechaVencimiento);
            Assert.Equal(descripcion, tarea.Descripcion);
            Assert.Equal(EstadoTarea.Pendiente, tarea.Estado);
        }

        
        [Fact]
        public void EliminarTarea_Correctamente()
        {
            Tarea tarea = new Tarea("Tarea a eliminar", DateTime.Now.AddDays(2), "Descripción de la tarea");
            GestionTarea.CrearTarea(tarea);

            GestionTarea.EliminarTarea(tarea.Id);

            var tareaEliminada = GestionTarea.ListarTareas().Find(t => t.Id == tarea.Id);
            Assert.Null(tareaEliminada);
        }

        
        [Fact]
        public void ActualizarTarea_Correctamente()
        {
            
            Tarea tarea = new Tarea("Tarea original", DateTime.Now.AddDays(2));
            GestionTarea.CrearTarea(tarea);

            
            tarea.Titulo = "Tarea actualizada";
            tarea.Estado = EstadoTarea.EnProgreso;
            GestionTarea.ActualizarTarea(tarea);

            
            Assert.Equal("Tarea actualizada", tarea.Titulo);
            Assert.Equal(EstadoTarea.EnProgreso, tarea.Estado);
        }
    }
}
