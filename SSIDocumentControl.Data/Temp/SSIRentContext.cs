using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Rent.Data
{
    public partial class SSIRentContext : DbContext
    {
        public SSIRentContext()
        {
        }

        public SSIRentContext(DbContextOptions<SSIRentContext> options)
            : base(options)
        {
        }

        // Unable to generate entity type for table 'dbo.tblSys_Objects_ObjectLinkedFiles'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Dev-Eric;Database=SSIRent;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");
        }
    }
}
