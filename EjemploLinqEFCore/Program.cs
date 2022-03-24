using System;
using System.Linq;

namespace EjemploLinqEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                var persona1 = new Persona() { Nombre = "Felipe" };
                var persona2 = new Persona() { Nombre = "Claudia" };

                context.AddRange(persona1, persona2);
                context.SaveChanges();
            }

            using (var context = new ApplicationDbContext())
            {
                var personas = context.Personas.ToList();
                var personasNombre = context.Personas.Select(p => p.Nombre).ToList();
                var felipe = context.Personas.FirstOrDefault(p => p.Nombre == "Felipe");
                var guillermo = context.Personas.FirstOrDefault(p=> p.Nombre == "Guillermo");

                var felipe_2 = (from p in context.Personas
                                where p.Nombre == "Felipe"
                                select p).FirstOrDefault();

                
            }
        }
    }
}
