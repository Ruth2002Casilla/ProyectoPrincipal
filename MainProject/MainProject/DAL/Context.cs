using Microsoft.EntityFrameworkCore;
using MainProject.Models; 

namespace MainProject.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Tickets> Tickets { get; set; }
    }
}

//EXPLICACION

/*El DbContextFactory se encarga de crear instancias del contexto de la base de datos (Context) utilizando las opciones de contexto 
  (DbContextOptions<Context>) que se le proporcionan.La implementación que he creado cumple con este patrón. En la clase ContextFactory, 
  el constructor recibe DbContextOptions<Context> como parámetro y luego utiliza estas opciones para crear una instancia de Context 
  en el método CreateContext(). Además, al separar la lógica de creación de instancias del contexto en una clase ContextFactory, 
  estamos siguiendo las mejores prácticas recomendadas para el diseño de aplicaciones con Entity Framework Core, lo que permite una 
  mejor modularidad y flexibilidad en tu código.*/
