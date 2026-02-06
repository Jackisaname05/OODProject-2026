using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography.X509Certificates;

namespace OODProject_2026.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext() : base("name=AppDb")
        {
        
        }
        public DbSet<Models.CharacterEntity> Characters { get; set; }
    }
}
