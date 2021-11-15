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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.OrderPrice).IsRequired().HasColumnType("money").HasColumnName("OrderPrice");

            builder.HasData(
                 new Client { Id = 1, FirstName = "Andrew", LastName = "Berry", Email = "andrew.berry@outlook.com", OrderPrice = 35520 },
                 new Client { Id = 2, FirstName = "Jasmine", LastName = "Clarkson", Email = "jasmine.clarkson@outlook.com", OrderPrice = 27873 },
                 new Client { Id = 3, FirstName = "Tim", LastName = "Coleman", Email = "tim.coleman@outlook.com", OrderPrice = 32522 },
                 new Client { Id = 4, FirstName = "Dominic", LastName = "Short", Email = "dominic.short@outlook.com", OrderPrice = 37973 },
                 new Client { Id = 5, FirstName = "Wendy", LastName = "Clark", Email = "wendy.clark@outlook.com", OrderPrice = 60478 });
        }
    }
}
