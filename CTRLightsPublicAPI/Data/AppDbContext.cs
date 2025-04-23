using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using CTRLightsPublicAPI.Data.Models;
using Npgsql;

namespace CTRLightsPublicAPI.Data
{
    public class AppDbContext : DbContext
    {
        public string _connectionString;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            _connectionString = "User Id=postgres.dsjldaeychcwforjctvq;Password=m1e2r3t4;Server=aws-0-eu-central-1.pooler.supabase.com;Port=5432;Database=postgres";
        }

        public AppDbContext()
        {
            _connectionString = "User Id=postgres.dsjldaeychcwforjctvq;Password=m1e2r3t4;Server=aws-0-eu-central-1.pooler.supabase.com;Port=5432;Database=postgres";
        }

        // Add your DbSets (Tables)
        public DbSet<TrafficLights> TrafficLights { get; set; }
        public DbSet<AirQuality> AirQuality { get; set; }
        public DbSet<EspDevice> EspDevice { get; set; }
        public DbSet<AdminUsers> AdminUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("User Id=postgres.dsjldaeychcwforjctvq;Password=m1e2r3t4;Server=aws-0-eu-central-1.pooler.supabase.com;Port=5432;Database=postgres");

            }
        }

        public string Test()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    return "YES";
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
