using OODProject_2026.Models;
using OODProject_2026.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OODProject_2026.Services
{
    public class CharacterRepository : ICharacterRepository
    {
        public List<CharacterEntity> GetAllCharacters()
        {
            using (var db = new AppDbContext())
            {
                return db.Characters
                    .OrderBy(c => c.Name)
                    .ToList();
            }
        }

        public List<CharacterEntity> Search(string text, string publisher)
        {
            using (var db = new AppDbContext())
            {
                var query = db.Characters.AsQueryable();

                text = (text ?? string.Empty).Trim();
                publisher = (publisher ?? "All").Trim();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    query = query.Where(c =>
                        c.Name.Contains(text) ||
                        (c.Description != null && c.Description.Contains(text)));
                }

                if (!string.IsNullOrWhiteSpace(publisher) && publisher != "All")
                {
                    query = query.Where(c => c.Publisher == publisher);
                }

                return query
                    .OrderBy(c => c.Name)
                    .ToList();
            }
        }

        public void Add(CharacterEntity character)
        {
            using (var db = new AppDbContext())
            {
                character.CreatedAt = DateTime.Now;
                character.UpdatedAt = DateTime.Now;

                db.Characters.Add(character);
                db.SaveChanges();
            }
        }

        public void Update(CharacterEntity character)
        {
            using (var db = new AppDbContext())
            {
                character.UpdatedAt = DateTime.Now;
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new AppDbContext())
            {
                var found = db.Characters.FirstOrDefault(c => c.Id == id);

                if (found == null)
                {
                    return;
                }

                db.Characters.Remove(found);
                db.SaveChanges();
            }
        }
    }
}