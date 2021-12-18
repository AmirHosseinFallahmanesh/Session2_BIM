using Demo.Core.Entities;
using Demo.Infra.EF.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace Demo.Infra.EF
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options)
            :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AccountConfig());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
