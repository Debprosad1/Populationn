using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Population.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Population.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SSCBoards> SSCBoards { get; set; }
        public DbSet<HSCBoards> HSCBoards { get; set; }
        public DbSet<BloodGroups> BloodGroups { get; set; }
        public DbSet<People> peoples { get; set; }
    }
}
