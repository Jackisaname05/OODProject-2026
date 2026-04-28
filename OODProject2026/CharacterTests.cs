using System;
using NUnit.Framework;
using OODProject_2026.Models;

namespace OOdProject_2026.Tests
{
    //tests for the CharacterEntity class, specifically the YearsSinceDebut property
    public class CharacterTests
    {
        [Test]
        public void YearsSinceDebut_CalculatesCorrectly()
        {
            // Arrange
            int debutYear = 2000;

            var character = new CharacterEntity
            {
                DebutYear = debutYear
            };

            int expected = DateTime.Now.Year - debutYear;

            // Act
            int actual = character.YearsSinceDebut;

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
