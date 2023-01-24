using Filmutleie;

namespace Filmutleieprivate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Account user = new Account(300);
            List<Film> filmList = new()
            {
                new Film
                {
                    MovieName = "Puss in boots",
                    Id = "1",
                    AmountInInventory = 10,
                    MonthlyPriceKr = 40,
                },
                new Film
                {
                    MovieName = "Better call Saul Shrek Crossover",
                    Id = "2",
                    AmountInInventory = 12,
                    MonthlyPriceKr = 99,
                },
                new Film
                {
                    MovieName = "Shrek 2",
                    Id = "3",
                    AmountInInventory = 11,
                    MonthlyPriceKr = 50
                }
            };

            FilmLibrary library = new(filmList);

            while (true)
            {
                Console.WriteLine($"Welcome to GoodmanFilms, have you come to return or rent a movie?\n" +
                                  $"1: Rent\n" +
                                  $"2: Return\n");


                string command = Console.ReadLine();

                if (command is "1")
                {
                    library.ListFilms();
                    Console.WriteLine($"\nBalance: {user.Balance}kr");
                    Console.WriteLine("Please enter the id of the film you would like to rent");
                    string filmId = Console.ReadLine();
                    library.RentMovie(user, filmId);
                }

                if (command is "2")
                {
                    Console.WriteLine("Please enter the id of the film you would like to return");
                    user.PrintRentedFilms();
                    string filmId = Console.ReadLine();
                    library.ReturnMovie(user, filmId);
                }

            }
        }
    }
}

