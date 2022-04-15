using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class Halls
    {
        public static void Create(string name, int SeatCount) => Sql.Execute($"INSERT INTO {typeof(Halls).Name} VALUES ('{name}',{SeatCount})");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change name\n2-Change SeatCount\nChoise:", -1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(Halls).Name} SET Name = '{Program.StringInput("Name")}' WHERE Id={id}");
                        break;
                    case 2:
                        Sql.Execute($"UPDATE {typeof(Halls).Name} SET SeatCount = '{Program.NumberInput<int>("SeatCount")}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(Halls).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(Halls).Name}");
    }
}
