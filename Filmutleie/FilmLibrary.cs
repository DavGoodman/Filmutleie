using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmutleie;

internal class FilmLibrary
{
    public List<Film> Inventory { get; set; }

    public FilmLibrary(List<Film> films)
    {
        Inventory = films;
    }

    public void ListFilms()
    {
        Console.WriteLine("Movies available for rent: ");
        foreach (var film in Inventory)
        {
            Console.WriteLine($"Film: {film.MovieName}\n" +
                              $"Id: {film.Id}\n" +
                              $"In stock: {film.AmountInInventory}\n" +
                              $"Monthly price: {film.MonthlyPriceKr}kr\n");
        }
        Console.WriteLine("Input film ID to rent");
    }

    public void RentMovie(Account User, string filmId)
    {
        Film chosenFilm = Inventory.Where(i => i.Id == filmId).FirstOrDefault();
        if (User.Balance < chosenFilm.MonthlyPriceKr) return;
        if (User.CurrentRentals.Count == 2)
        {
            Console.WriteLine("You have the maximum number of movies rented out, please return one first.");
            return;
        };


        if (chosenFilm == null || chosenFilm.AmountInInventory == 0)
        {
            Console.WriteLine(chosenFilm == null ? "Invalid input, please input a valid number" : "Movie is out of stock please check back later");
            return;
        };

        User.CurrentRentals.Add(chosenFilm);
        chosenFilm.AmountInInventory--;
        chosenFilm.CurrentAmountRented++;
        User.Balance -= chosenFilm.MonthlyPriceKr;
        Console.WriteLine($"You have successfully rented out {chosenFilm.MovieName} for {chosenFilm.MonthlyPriceKr}kr");
    }

    public void ReturnMovie(Account User, string filmId)
    {
        Film chosenFilm = Inventory.Where(i => i.Id == filmId).FirstOrDefault();
        if (chosenFilm == null)
        {
            Console.WriteLine("Invalid input, please input a valid number");
            return;
        };

        chosenFilm.AmountInInventory++;
        chosenFilm.CurrentAmountRented--;
        User.CurrentRentals.Remove(chosenFilm);
        Console.WriteLine($"You returned {chosenFilm.MovieName}");
        User.PrintRentedFilms();
    }
}

