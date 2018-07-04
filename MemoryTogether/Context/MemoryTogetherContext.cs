using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemoryTogether.Model;
using Microsoft.EntityFrameworkCore;

namespace MemoryTogether.Context
{
    public class MemoryTogetherContext : DbContext
    {
        public DbSet<AccountingBook> AccountingBooks { get; set; }

        public MemoryTogetherContext(DbContextOptions<MemoryTogetherContext> options) : base(options)
        {
        }
    }
}
