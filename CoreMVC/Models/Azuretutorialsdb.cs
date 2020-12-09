using CoreMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace NetCoreWebApp.Models
{
    public class Azuretutorialsdb
    {
        public int Id { get; set; }
        public string Employee_Name { get; set; }        
        public string ConnectionString { get; set; }
        public Azuretutorialsdb(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public List<EmployeeModel> GetAllAlbums()
        {
            List<EmployeeModel> list = new List<EmployeeModel>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from employee_mst where id < 10", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new EmployeeModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Employee_Name = reader["EmployeeName"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}