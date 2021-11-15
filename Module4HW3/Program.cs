﻿using System;
using BankSolution.DateAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW3;

namespace BankSolution.DateAccess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("config.json").Build();
            var dbOptionsBuilder = new DbContextOptionsBuilder<BankContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbOptionsBuilder.UseSqlServer(connectionString, i => i.CommandTimeout(60));

            var bankContext = new BankContext(dbOptionsBuilder.Options);
            bankContext.Database.Migrate();

            bankContext.SaveChanges();
        }
    }
}
