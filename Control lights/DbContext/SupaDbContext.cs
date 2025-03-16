using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Supabase;
using Microsoft.Extensions.Configuration;

namespace Control_lights.DbContext
{
    public class SupaDbContext
    {
        private string _connectionString;

        public SupaDbContext(IConfiguration configuration)
        {
            _connectionString = "User Id=postgres.trvbslieviqciqecwuws;Password=CTRLights123;Server=aws-0-eu-central-1.pooler.supabase.com;Port=5432;Database=postgres";
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
