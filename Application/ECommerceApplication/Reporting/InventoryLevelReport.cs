using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ECommerceApplication.Reporting
{
    public class InventoryLevelReport
    {
        public InventoryLevelReport(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int LevelByDate(string sku, DateTime Date)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("ECommerceContext")))
            {
                using (var cmd = new SqlCommand("SELECT Stock FROM dbo.InventoryItem WHERE SKU=@sku", sqlConnection))
                {
                    var parameter = new SqlParameter("@sku", SqlDbType.VarChar)
                    {
                        Value = sku
                    };

                    cmd.Parameters.Add(parameter);

                    sqlConnection.Open();

                    var reader = cmd.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            return int.Parse(reader[0].ToString());
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }
    
                }

                using (var cmd = new SqlCommand("SELECT Order FROM dbo.Order WHERE SKU=@sku", sqlConnection))
                {
                    var parameter = new SqlParameter("@sku", SqlDbType.VarChar)
                    {
                        Value = sku
                    };

                    cmd.Parameters.Add(parameter);

                    sqlConnection.Open();

                    var reader = cmd.ExecuteReader();

                    try
                    {
                        while (reader.Read())
                        {
                            return int.Parse(reader[0].ToString());
                        }
                    }
                    finally
                    {
                        reader.Close();
                    }

                }
            }

            return 0;
        }

        private readonly IConfiguration _configuration;
    }
}
