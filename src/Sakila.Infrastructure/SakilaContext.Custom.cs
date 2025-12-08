using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = ChangeTracker.Entries();

        foreach (var entity in entities)
        {
            ChangeTracker.TrackGraph(entity.Entity, node =>
            {
                Console.WriteLine(node.Entry.Entity);

                if (node.Entry.IsKeySet)
                    node.Entry.State = EntityState.Unchanged;
                else
                    node.Entry.State = EntityState.Added;
            });

        }


        return base.SaveChangesAsync(cancellationToken);
    }
}
