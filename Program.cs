using CsMySQLTutorial;
using MySql.Data.MySqlClient;


internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine("Getting Connection ...");
        MySqlConnection conn = DBUtils.GetDBConnection();
        try
        {
            Console.WriteLine("Openning Connection ...");
            conn.Open();
            Console.WriteLine("Connection successful!");

            QueryDataExample example = new QueryDataExample();
            example.run(conn);
            // Console.WriteLine("----------------------INSERT DATA------------------------");
            // example.inserData(conn);
            // example.updateData(conn);
            // example.removeData(conn);
            example.scalarExecute(conn);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        Console.Read();
    }
}
