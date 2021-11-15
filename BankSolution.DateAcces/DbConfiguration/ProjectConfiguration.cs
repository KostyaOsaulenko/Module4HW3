using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSolution.DateAccess.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSolution.DateAccess.DbConfiguration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.HasOne(c => c.Client)
                .WithMany(p => p.Projects)
                .HasForeignKey(k => k.ClientId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Project { Id = 1, Name = "Lonesome", Budget = 806, StartedDate = new DateTime(2006, 04, 10), ClientId = 5 },
                new Project { Id = 2, Name = "DejaVu", Budget = 4466, StartedDate = new DateTime(2007, 04, 19), ClientId = 4 },
                new Project { Id = 3, Name = "Whistler", Budget = 14451, StartedDate = new DateTime(2015, 03, 27), ClientId = 3 },
                new Project { Id = 4, Name = "RuddyRex", Budget = 84479, StartedDate = new DateTime(2015, 11, 16), ClientId = 2 },
                new Project { Id = 5, Name = "Uzzin", Budget = 7333, StartedDate = new DateTime(2020, 06, 01), ClientId = 1 });
        }
    }
}
