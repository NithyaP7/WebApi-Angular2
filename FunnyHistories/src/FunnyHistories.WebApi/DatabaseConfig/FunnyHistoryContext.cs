using FunnyHistories.Core.Models.Histories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyHistories.WebApi.DatabaseConfig
{
    public class FunnyHistoryContext :DbContext
    {

        public FunnyHistoryContext(DbContextOptions<FunnyHistoryContext> options) : base(options)
        {

        }

        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>().ToTable("History");
        }
    }
}

