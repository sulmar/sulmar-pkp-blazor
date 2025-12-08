using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sakila.Infrastructure;

public partial class SakilaContext
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Customer>()
            .Property(p => p.FirstName)
            .HasColumnType("varchar(45)");

        modelBuilder
            .Entity<Customer>()
            .Navigation(p => p.Address) // Navigation Property
            .AutoInclude();             // Automatyczny Include

    }
}
