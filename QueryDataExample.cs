using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.Common;
using MySql.Data.MySqlClient;
using CsMySQLTutorial;

using System.Data;


namespace CsMySQLTutorial
{
    internal class QueryDataExample
    {
        public void run(MySqlConnection conn)
        {
            // Получить объект Connection подключенный к DB.

            try
            {
                QueryEmployee(conn);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                // Закрыть соединение.
                //conn.Close();
                // Уничтожить объект, освободить ресурс.
                //conn.Dispose();
            }

        }
        private void QueryEmployee(MySqlConnection conn)
        {
            string sql = "Select Emp_Id, Emp_No, Emp_Name, Mng_Id from Employee";
            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();
            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;
            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Индекс (index) столбца Emp_ID в команде SQL.
                        int empIdIndex = reader.GetOrdinal("Emp_Id"); // 0

                        long empId = Convert.ToInt64(reader.GetValue(0));
                        // Столбец Emp_No имеет index = 1.
                        string empNo = reader.GetString(1);
                        int empNameIndex = reader.GetOrdinal("Emp_Name");// 2
                        string empName = reader.GetString(empNameIndex);
                        // Индекс (index) столбца Mng_Id в команде SQL.
                        int mngIdIndex = reader.GetOrdinal("Mng_Id");
                        long? mngId = null;
                        // Проверить значение данного столбца может являться null или нет.
                        if (!reader.IsDBNull(mngIdIndex))
                        {
                            mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                        }
                        Console.WriteLine("--------------------");
                        Console.WriteLine("empIdIndex:" + empIdIndex);
                        Console.WriteLine("EmpId:" + empId);
                        Console.WriteLine("EmpNo:" + empNo);
                        Console.WriteLine("EmpName:" + empName);
                        Console.WriteLine("MngId:" + mngId);
                    }
                }
            }
        }
        public void inserData(MySqlConnection connection)
        {

            try
            {
                // Команда Insert.
                string sql = "Insert into Salary_Grade (Grade, High_Salary, Low_Salary) "
                                                 + " values (@grade, @highSalary, @lowSalary) ";
                MySqlCommand
                cmd = connection.CreateCommand();
                cmd.CommandText= sql;
                // Создать объект Parameter.
                MySqlParameter gradeParam = new MySqlParameter("@grade", SqlDbType.Int);
                gradeParam.Value= 3;
                cmd.Parameters.Add(gradeParam);
                // Добавить параметр @highSalary (Написать кратко).
                MySqlParameter highSalaryParam = cmd.Parameters.Add("@highSalary", MySqlDbType.Float);
                highSalaryParam.Value= 20000;
                // Добавить параметр @lowSalary (Написать кратко).
                cmd.Parameters.Add("@lowSalary", MySqlDbType.Float).Value = 10000;
                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine
        ("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //connection.Close();
                //connection.Dispose();
                //connection = null;
            }

        }
        public void updateData(MySqlConnection conn)
        {
            try
            {
                string sql = "Update Employee set Salary = @salary where Emp_Id = @empId";

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = sql;
                // Добавить и настроить значение для параметра.
                cmd.Parameters.Add("@salary", MySqlDbType.Float).Value = 1000;
                cmd.Parameters.Add("@empId", MySqlDbType.Decimal).Value = 7369;
                // Выполнить Command (Использованная для delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //conn.Close();
                //conn.Dispose();
                //conn = null;

            }
        }
        public void removeData(MySqlConnection conn)
        {
            try
            {
                string sql = "Update Employee set Salary = @salary where Emp_Id = @empId";

                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = sql;
                // Добавить и настроить значение для параметра.
                cmd.Parameters.Add("@salary", MySqlDbType.Float).Value = 850;
                cmd.Parameters.Add("@empId", MySqlDbType.Decimal).Value = 7369;
                // Выполнить Command (Использованная для delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();
                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //conn.Close();
               //conn.Dispose();
                //conn = null;
            }
        }
        public void scalarExecute(MySqlConnection conn)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("Select count(*) From Employee", conn);

                cmd.CommandType = CommandType.Text;
                // Метод ExecuteScalar возвращает значение первого столбца в первой строке.
                object countObj = cmd.ExecuteScalar();
                int count = 0;
                if (countObj != null)
                {
                    count = Convert.ToInt32(countObj);
                }
                Console.WriteLine("Emp Count: " + count);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                //conn.Close();
                //conn.Dispose();
            }
        }
    }
}
            
       
    