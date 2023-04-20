using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using MySql.Data.MySqlClient;
using CsMySQLTutorial;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
        Console.WriteLine("Getting Connection ...");
        MySqlConnection conn = DBUtils.GetDBConnection();
        try
        {
            Console.WriteLine("Openning Connection ...");
            conn.Open();
            Console.WriteLine("Connection successful!");

            QueryDataExample example = new QueryDataExample();
            example.run(conn);
            example.inserData(conn);
            Console.WriteLine("---------------------------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        Console.Read();
    }
}
