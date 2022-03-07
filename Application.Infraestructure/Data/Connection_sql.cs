using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Infraestructure.Data
{
    public class Connection_sql
    {
        public static string Cadenacnx()
        {
            return @"Data Source=LAPTOP-2D54LLI8\SQLEXPRESS;Initial Catalog=app_test;Integrated Security=true";
        }
    }
}
