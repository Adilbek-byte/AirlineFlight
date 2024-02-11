using System.Diagnostics.Eventing.Reader;
using System.Numerics;
using System.Transactions;

namespace AspAirlineFlight.Models;

public class Passenger
{

    public int Adult { get; set; } = 0;
    public int Child { get; set; } = 0;
    public int TotalPeople { get; set; } = 0;
    public string? TotalSum { get; set; } = null;



    
     
}
