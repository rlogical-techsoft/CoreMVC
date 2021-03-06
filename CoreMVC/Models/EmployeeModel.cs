﻿using CoreMVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace NetCoreWebApp.Models
{
    public class EmployeeModel 
    {

        public int Id { get; set; }
        public string Employee_Name { get; set; }        
        public List<EmployeeModel> GetAllAlbums(string connect)
        {
            List<EmployeeModel> list = new List<EmployeeModel>();

            using (SqlConnection conn = new SqlConnection(connect))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee_Mst where id < 10", conn);

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
