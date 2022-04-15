using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class Tickets
    {
        public static void Create(DateTime SoldDate,decimal Price,int seat,int SeanceId,int HallId,int CustomerId,int FilmId) => Sql.Execute($"INSERT INTO {typeof(Tickets).Name} VALUES ('{SoldDate}',{Price},{seat},{SeanceId},{HallId},{CustomerId},{FilmId})");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change SoldDate\n2-Change Price\n3-Change SeanceId\n4-Change CustomerId\n5-Change FilmId\nChoise:", -1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(Tickets).Name} SET SoldDate = '{Films.DateInput()}' WHERE Id={id}");
                        break;
                    case 2:
                        Sql.Execute($"UPDATE {typeof(Tickets).Name} SET Price = '{Program.NumberInput<decimal>("Price")}' WHERE Id={id}");
                        break;
                    case 3:
                        Sql.Execute($"UPDATE {typeof(Tickets).Name} SET SeanceId = '{Program.NumberInput<int>("SeanceId")}' WHERE Id={id}");
                        break;
                    case 4:
                        Sql.Execute($"UPDATE {typeof(Tickets).Name} SET CustomerId = '{Program.NumberInput<int>("CustomerId")}' WHERE Id={id}");
                        break;
                    case 5:
                        Sql.Execute($"UPDATE {typeof(Tickets).Name} SET FilmId = '{Program.NumberInput<int>("FilmId")}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);

        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(Tickets).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(Tickets).Name}");
    }
}
