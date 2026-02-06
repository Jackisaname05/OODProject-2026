using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OODProject_2026.Models;

namespace OODProject_2026.Services
{
    public interface ICharacterRepository
    {
        List<CharacterEntity> GetAllCharacters();
        List<CharacterEntity> Search(string text, string publisher);
        void Add(CharacterEntity character);
        void Update(CharacterEntity character);
        void Delete(int id);
    }
}
