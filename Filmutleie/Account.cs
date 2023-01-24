using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmutleie;


internal class Account
{
    public List<Film> CurrentRentals { get; set; }
    public int Balance { get; set; }

    public Account(int balance)
    {
        CurrentRentals = new List<Film>();
        Balance = balance;
    }

    public void PrintRentedFilms()
    {
        Console.WriteLine($"You have rented out: ");
        foreach (var film in CurrentRentals)
        {
            Console.WriteLine($"Film: {film.MovieName}\n" +
                              $"Id: {film.Id}\n");
        }
    }

}

