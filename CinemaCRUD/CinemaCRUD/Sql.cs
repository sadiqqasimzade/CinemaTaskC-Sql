using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Xml;

namespace CinemaCRUD
{
    internal class Sql
    {
        private static string connectionPermisson = @$"Server={FindServer()};Database={ChoseDataBase()};Trusted_Connection=True;";

        public static void Select(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionPermisson))
            {
                connection.Open();
                using (SqlDataAdapter sDA = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    sDA.Fill(dataTable);
                    string columnNames = "";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                        columnNames += dataTable.Columns[i].ColumnName + " | ";

                    Console.WriteLine(columnNames);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        string result = "";
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                            result += dataRow[i] + " | ";

                        Console.WriteLine(result);
                    }
                }
            }
        }
        public static void Execute(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionPermisson))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        if (command.ExecuteNonQuery() > 0)
                            Console.WriteLine("Done");

                        else
                            Console.WriteLine("Something went wrong");

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Data not found");
                    }
                }
            }

        }

        public static string FindServer()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@$"{Directory.GetDirectoryRoot(Directory.GetCurrentDirectory())}Users\{Environment.UserName}\AppData\Roaming\Microsoft\SQL Server Management Studio\18.0");
            FileInfo fileInfo = new FileInfo(dirInfo + @"\UserSettings.xml");

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileInfo.ToString());

            var node = xmlDoc.DocumentElement.SelectNodes(@"/SqlStudio/SSMS/ConnectionOptions/ServerTypes/Element/Value/ServerTypeItem/Servers/Element/Item/ServerConnectionItem/Instance");

            foreach (XmlNode node2 in node)
                return node2.InnerXml;

            throw new Exception("Cant Find Server Enter Manulaly");
        }

        public static List<string> SelectDataBase1()
        {
            using (SqlConnection connection = new SqlConnection(@$"Server={FindServer()};Trusted_Connection=True;"))
            {
                List<string> list = new List<string>();
                connection.Open();
                using (SqlDataAdapter sDA = new SqlDataAdapter("SELECT name FROM sys.databases", connection))
                {
                    DataTable dataTable = new DataTable();
                    sDA.Fill(dataTable);
                    string columnNames = "";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                        columnNames += dataTable.Columns[i].ColumnName + " ";

                    Console.WriteLine(columnNames);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        string result = "";
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                            result += dataRow[i] + " ";

                        list.Add(result);
                    }
                    return list;
                }
            }
            throw new Exception();
        }

        /*public static void FillData()
        {
            using (SqlConnection connection = new SqlConnection(connectionPermisson))
            {
                connection.Open();
                using (SqlDataAdapter sDA = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    sDA.Fill(dataTable);
                    string columnNames = "";
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                        columnNames += dataTable.Columns[i].ColumnName + " | ";

                    Console.WriteLine(columnNames);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        string result = "";
                        for (int i = 0; i < dataTable.Columns.Count; i++)
                            result += dataRow[i] + " | ";

                        Console.WriteLine(result);
                    }
                }
            }
        }*/
        public static string ChoseDataBase()
        {

            do
            {
                foreach (var item in Sql.SelectDataBase1())
                    Console.WriteLine(item);

                string temp = Program.StringInput("Chose DataBase");

                foreach (string item in Sql.SelectDataBase1())
                {
                    if (temp==item.Trim()) return temp;
                }
            } while (true);


        }
    }
}
