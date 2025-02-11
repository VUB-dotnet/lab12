using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConferenceAPI.Models;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ConferenceAPI.Models.Conference> Conference { get; set; } = default!;

public DbSet<ConferenceAPI.Models.Talk> Talk { get; set; } = default!;
    }
