using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class Seances
    {
        public static void Create(DateTime time) => Sql.Execute($"INSERT INTO {typeof(Seances).Name} VALUES ('{time}')");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change date\nChoise:", -1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(Seances).Name} SET StartTime = '{Films.DateInput()}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(Seances).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(Seances).Name}");
    }
}
