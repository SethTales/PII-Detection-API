using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PIIApi.Models
{
    public class TextEntriesContext : DbContext
    {
        public TextEntriesContext(DbContextOptions<TextEntriesContext> connectionString)
            : base(connectionString)
        {
            

        }

        public DbSet<TextItem> TextItems { get; set; }
    }
}
