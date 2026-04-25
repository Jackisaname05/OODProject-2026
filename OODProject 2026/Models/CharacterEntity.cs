using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OODProject_2026.Models
{
    public class CharacterEntity: BaseEntity, IHasPublisher
    {
        
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int DebutYear { get; set; }

        public int YearsSinceDebut
        {
            get
            {
                int currentYear = DateTime.Now.Year;
                return currentYear - DebutYear;
            }
        }

        [Required, MaxLength(80)]
        public string Publisher { get; set; }

        //a brief description of the character's backstory
        [Required, MaxLength(800)]
        public string Description { get; set; }

        //needed for issue credits endpoint i comic vine API
        public int ComicVineCharacterId { get; set; }

        public string ComicVineSearchName { get; set; }
    }
}
