using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiForMobile.Models
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PT432LC\LOCAL;Database=VatanProj;Trusted_Connection=True;");
        }
        public DbSet<User> Users { get; set; }
    }
}
