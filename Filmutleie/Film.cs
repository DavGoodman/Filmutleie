using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filmutleie;

internal class Film
{
    public string MovieName { get; set; }
    public int AmountInInventory { get; set; }
    public int CurrentAmountRented { get; set; }
    public int MonthlyPriceKr { get; set; }
    public string Id { get; set; }



}

