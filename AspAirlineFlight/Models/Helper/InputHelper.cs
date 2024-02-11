using AspAirlineFlight.Models;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;

namespace AspAirlineFlight.Models.Helper;

public class InputHelper
{

    public static int CalculateTotalFee(int total, TypeOfPrices.Category type)
    {
        var res = int.Parse(string.Concat(TypeOfPrices.PriceOfTickets(type).Where(char.IsDigit)));
        return total * res;
    }

    public static string getPassengerHelper(List<Flight> flight, string passenger, int number)
    {
        string res = string.Empty;

        foreach(var item in flight)
        {
            
            if (passenger == TypeOfPrices.Category.Adult.ToString())
                item.Passengers!.Adult += number;
            else if(passenger == TypeOfPrices.Category.Children.ToString())
                item.Passengers!.Child += number;

            item.Passengers!.TotalPeople = item.Passengers.Adult + item.Passengers.Child;
            item.Passengers.TotalSum = (CalculateTotalFee(item.Passengers!.Adult, TypeOfPrices.Category.Adult) +
            CalculateTotalFee(item.Passengers!.Child, TypeOfPrices.Category.Children)).ToString();
       
       

            res += item.Passengers.TotalSum;

        }
        return res;


    }
    


}
