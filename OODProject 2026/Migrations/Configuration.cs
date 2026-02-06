namespace OODProject_2026.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using OODProject_2026.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OODProject_2026.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OODProject_2026.Data.AppDbContext context)
        {
            try
            {


                context.Characters.AddOrUpdate(c => c.Name,
                    new CharacterEntity
                    {
                        Name = "Spider-Man",
                        DebutYear = 1962,
                        Publisher = "Marvel Comics",
                        Description = "Short description here.....",
                        ComicVineCharacterId = 1443,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },
                    new CharacterEntity
                    {
                        Name = "Batman",
                        DebutYear = 1939,
                        Publisher = "DC Comics",
                        Description = "Short description here.....",
                        ComicVineCharacterId = 1699,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    }
                );
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    System.Diagnostics.Debug.WriteLine("Entity: " + eve.Entry.Entity.GetType().Name);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("  Property: " + ve.PropertyName + " Error: " + ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }
    }
}
