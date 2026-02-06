using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OODProject_2026.Models;

namespace OODProject_2026.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        
    }
}
