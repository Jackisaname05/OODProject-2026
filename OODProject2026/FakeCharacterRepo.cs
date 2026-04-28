using OODProject_2026.Models;
using OODProject_2026.Services;
using System.Collections.Generic;
using System.Linq;

namespace OOdProject_2026.Tests
{
    // A simple fake implementation of the ICharacterRepository interface for testing purposes, using an in-memory list to store character data and providing basic search functionality based on character name and publisher.
    public class FakeCharacterRepo : ICharacterRepository
    {
        private readonly List<CharacterEntity> _data;

        public FakeCharacterRepo(List<CharacterEntity> data)
        {
            _data = data;
        }

        public List<CharacterEntity> GetAllCharacters()
        {
            return _data
                .OrderBy(c => c.Name)
                .ToList();
        }

        public List<CharacterEntity> Search(string text, string publisher)
        {
            var query = _data.AsQueryable();

            text = (text ?? string.Empty).Trim();
            publisher = (publisher ?? "All").Trim();

            if (!string.IsNullOrWhiteSpace(text))
            {
                query = query.Where(c =>
                    c.Name.ToLower().Contains(text.ToLower()) ||
                    (c.Description != null && c.Description.ToLower().Contains(text.ToLower())));
            }

            if (!string.IsNullOrWhiteSpace(publisher) && publisher != "All")
            {
                query = query.Where(c => c.Publisher == publisher);
            }

            return query
                .OrderBy(c => c.Name)
                .ToList();
        }

        public void Add(CharacterEntity character)
        {
            _data.Add(character);
        }

        public void Update(CharacterEntity character)
        {
            // Not needed for these tests
        }

        public void Delete(int id)
        {
            var found = _data.FirstOrDefault(c => c.Id == id);

            if (found != null)
            {
                _data.Remove(found);
            }
        }
    }
}
