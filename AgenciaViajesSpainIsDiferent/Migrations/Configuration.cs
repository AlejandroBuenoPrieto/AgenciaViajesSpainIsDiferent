namespace AgenciaViajesSpainIsDiferent.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AgenciaViajesSpainIsDiferent.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AgenciaViajesSpainIsDiferent.Models.ApplicationDbContext";
        }

        protected override void Seed(AgenciaViajesSpainIsDiferent.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Trens.AddOrUpdate(t => t.cantidad,
                new Tren
                {
                    trenid = 0521,
                    cantidad = 8,
                    precio = 89,
                    cafeteria = "si",
                    compania = "spain",
                    origen = "madrid",
                    destino = "houston",
                    numeroplazas = 9
                },
                new Tren
                {
                    trenid = 0522,
                    cantidad = 88,
                    precio = 898,
                    cafeteria = "si",
                    compania = "spain",
                    origen = "madrid",
                    destino = "bruselas",
                    numeroplazas = 9
                }

                );
            context.Excursiones.AddOrUpdate(e =>e.nombreExcursion,
                new Excursiones
            {
                    ExcursionId = 19517,
                    nombreExcursion = "Ir a la Moncloa",
                    ciudad = "Madrid",
                    tipo = "Visita guiada"

                
            }
                );
        }
    }
}
