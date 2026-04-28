using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OODProject_2026.Models;


namespace OOdProject_2026.Tests
{
    //tests for the Search method of the ICharacterRepository, using a fake repository implementation to test filtering by publisher and character name
    public class RepositoryTests
    {
        [Test]
        public void Search_FiltersByPublisher()
        {
            // Arrange
            var data = new List<CharacterEntity>
            {
                new CharacterEntity { Id = 1, Name = "Batman", Publisher = "DC" },
                new CharacterEntity { Id = 2, Name = "Spider-Man", Publisher = "Marvel" }
            };

            var repository = new FakeCharacterRepo(data);

            // Act
            var results = repository.Search("", "DC");

            // Assert
            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Name, Is.EqualTo("Batman"));
        }

        [Test]
        public void Search_FiltersbyCharacterName()
        {
            var data = new List<CharacterEntity>
            {
                new CharacterEntity { Id = 1, Name = "Batman", Publisher = "DC" },
                new CharacterEntity { Id = 2, Name = "Spider-Man", Publisher = "Marvel" }
            };

            var repository = new FakeCharacterRepo(data);

            var results = repository.Search("Spider", "All");

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First().Name, Is.EqualTo("Spider-Man"));
        }
    }
}