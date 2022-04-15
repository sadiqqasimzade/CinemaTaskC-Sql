using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaCRUD.Queries
{
    internal class GenresOfFilm
    {
        public static void Create(int FilmId, int GenreId) => Sql.Execute($"INSERT INTO {typeof(GenresOfFilm).Name} VALUES ({FilmId},{GenreId})");
        public static void Update()
        {
            byte choise;
            int id;
            do
            {
                id = Program.NumberInput<int>("Id:");
                choise = Program.NumberInput<byte>("0-Break\n1-Change FilmId\n2-Change GenreId\nChoise:", -1);
                switch (choise)
                {
                    case 0: break;
                    case 1:
                        Sql.Execute($"UPDATE {typeof(GenresOfFilm).Name} SET FilmId = '{Program.NumberInput<int>("FilmId")}' WHERE Id={id}");
                        break;
                    case 2:
                        Sql.Execute($"UPDATE {typeof(GenresOfFilm).Name} SET GenreId = '{Program.NumberInput<int>("GenreId")}' WHERE Id={id}");
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }
            } while (choise != 0);
        }
        public static void Delete(int id) => Sql.Execute($"DELETE {typeof(GenresOfFilm).Name} WHERE Id = {id}");
        public static void GetAll() => Sql.Select($"Select * from {typeof(GenresOfFilm).Name}");
    }
}
