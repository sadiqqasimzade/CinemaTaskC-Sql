using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class Films
    {
        public static void Create(string name,DateTime date)=> Sql.Execute($"INSERT INTO {typeof(Films).Name} VALUES ('{name}','{date}')");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change name\n2-Change date\nChoise:", -1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(Films).Name} SET Name = '{Program.StringInput("Name")}' WHERE Id={id}");
                        break;
                    case 2:
                        Sql.Execute($"UPDATE {typeof(Films).Name} SET ReleaseDate = '{DateInput()}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(Films).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(Films).Name}");

        public static DateTime DateInput()
        {
            Point:
            try
            {
                DateTime date = new DateTime(
                Program.NumberInput<int>("Year", 1900),
                Program.NumberInput<int>("Month", 0, 12),
                Program.NumberInput<int>("Day", 0, 31)
                );

                return date;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Point;
            }   
                
                
                
                
            
        
        }
    }

  
}
