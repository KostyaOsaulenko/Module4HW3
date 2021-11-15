﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSolution.DateAccess.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankSolution.DateAccess.DbConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.HiredDate).HasColumnType("date");

            builder.HasOne(x => x.Title)
                .WithMany(y => y.Employees)
                .HasForeignKey(x => x.TitleId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Office)
                .WithMany(y => y.Employees)
                .HasForeignKey(x => x.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
