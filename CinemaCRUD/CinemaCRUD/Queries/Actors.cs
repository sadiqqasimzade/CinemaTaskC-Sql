using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class Actors
    {
        
        public static void Create(string name, string surname, int age) => Sql.Execute($"INSERT INTO {typeof(Actors).Name} VALUES ('{name}','{surname}',{age})");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change name\n2-Change surname\n3-Change Age\nChoise:",-1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(Actors).Name} SET Name = '{Program.StringInput("Name")}' WHERE Id={id}");
                        break;
                    case 2:
                        Sql.Execute($"UPDATE {typeof(Actors).Name} SET Surname = '{Program.StringInput("Surname")}' WHERE Id={id}");
                        break;
                    case 3:
                        Sql.Execute($"UPDATE {typeof(Actors).Name} SET Age = '{Program.NumberInput<byte>("Age")}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(Actors).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(Actors).Name}");
    }
}
