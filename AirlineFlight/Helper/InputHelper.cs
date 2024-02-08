using AirlineFlightl;
using System.Reflection.Metadata.Ecma335;

namespace AirlineFlight.Helper;

public class InputHelper
{

    public static string CalculateTotalFee(int total, TypeOfPrices.Category type)
    {
        var res = int.Parse(string.Concat(TypeOfPrices.PriceOfTickets(type).Where(char.IsDigit)));
        return (total * res).ToString();

    }
    public static string getPassengerHelper(List<Flight> flight, string passenger, int number)
    {
        var res = string.Empty;
        foreach(var item in flight)
        {
            if (passenger == TypeOfPrices.Category.Adult.ToString())
                item.Passengers!.Adult += number;
            else if(passenger == TypeOfPrices.Category.Children.ToString())
                item.Passengers!.Child += number;
                item.Passengers!.TotalPeople = item.Passengers.Adult + item.Passengers.Child;
            item.Passengers!.TotalSum = CalculateTotalFee(item.Passengers!.TotalPeople, TypeOfPrices.Category.Adult)
            + CalculateTotalFee(item.Passengers!.TotalPeople, TypeOfPrices.Category.Children);


            res += item.Passengers.TotalSum;
        }
        return $"Total cost : {res}$";


    }
    


}
