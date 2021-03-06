using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class Genres
    {
        public static void Create(string name) => Sql.Execute($"INSERT INTO {typeof(Genres).Name} VALUES ('{name}')");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change name\nChoise:", -1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(Genres).Name} SET Name = '{Program.StringInput("Name")}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(Genres).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(Genres).Name}");
    }
}
