using System;
using CinemaCRUD.Queries;
namespace CinemaCRUD
{
    internal class Program
    {
        static void Main()
        {

            //yaxsisi kodu hisse hisse comentden cixarib isletmekdi

            DateTime dateTime = DateTime.Now;

            //Actors.Create("name", "surname", 40);
            //Actors.GetAll();
            //Actors.Update();
            //Actors.Delete(NumberInput<int>("Delete Id"));


            //Films.Create("name", dateTime);
            //Films.GetAll();
            //Films.Update();
            //Films.Delete(NumberInput<int>("Delete Id"));


            //Genres.Create("name");
            //Genres.GetAll();
            //Genres.Update();
            //Genres.Delete(NumberInput<int>("Delete Id"));


            //ActorsOfFilm.Create(22, 1);
            //ActorsOfFilm.GetAll();
            //ActorsOfFilm.Update();
            //ActorsOfFilm.Delete(NumberInput<int>("Delete Id"));


            //GenresOfFilm.Create(22, 1);
            //GenresOfFilm.GetAll();
            //GenresOfFilm.Update();
            //GenresOfFilm.Delete(NumberInput<int>("Delete Id"));


            //Customers.Create("name", "surname", 10);
            //Customers.GetAll();
            //Customers.Update();
            //Customers.Delete(NumberInput<int>("Delete Id"));


            //Halls.Create("name", 5);
            //Halls.GetAll();
            //Halls.Update();
            //Halls.Delete(NumberInput<int>("Delete Id"));


            //Seances.Create(dateTime);
            //Seances.GetAll();
            //Seances.Update();
            //Seances.Delete(NumberInput<int>("Delete Id"));


            //Tickets.Create(dateTime, 10, 1, 1, 1, 1, 1);
            //Tickets.GetAll();
            //Tickets.Update();
            //Tickets.Delete(NumberInput<int>("Delete Id"));

            //Actors.GetAll();
            //Films.GetAll();
            //Genres.GetAll();
            //ActorsOfFilm.GetAll();
            //GenresOfFilm.GetAll();
            //Customers.GetAll();
            //Halls.GetAll();
            //Seances.GetAll();
            //Tickets.GetAll();
        }

        public static T NumberInput<T>(string str,double min=0,double max=double.MaxValue)
        {
        Point:
            try
            {
                Console.Write(str + " :");
                dynamic temp = Console.ReadLine();
                temp = (T)Convert.ChangeType(temp, typeof(T));
                if(temp>=min||temp<=max)
                return temp;
                throw new Exception("Too Small");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                goto Point;
            }
        }

        public static string StringInput(string str)
        {
            string name;
            do
            {
                Console.Write(str + ":");
                name = Console.ReadLine();
            } while (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name));
            return name;
        }


    }
}
