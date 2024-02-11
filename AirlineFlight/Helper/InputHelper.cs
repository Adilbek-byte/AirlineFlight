using AirlineFlightl;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AirlineFlight.Helper;

public class InputHelper
{
   // This method helper is in use of calculating the totalSum
    public static int CalculateTotalFee(int total, int price)
    {
        
        return total * price;
    }
    /// <summary>
    /// getPassengerHelper is used as an assistance for calculating the number
    /// of Adults and children summed up together then 
    /// it will add the number of Adults multiplyed by the ticket price for 
    /// Adults to number of children multiplyed by the ticket price for 
    /// children to get totalSum
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="passenger"></param>
    /// <param name="number"></param>
    /// <returns>totalSum </returns>
    

    public static string getPassengerHelper(List<Flight> flight, string passenger, int number)
    {
        string res = "";

        var data = new TypeOfPrices();
 
        foreach (var item in flight)
        {
            switch (passenger)
            {
                case "Adult":
                    if(passenger == TypeOfPrices.Category.Adult.ToString())
                        item.Passengers!.Adult += number;
                    break;
                case "Children":
                    if (passenger == TypeOfPrices.Category.Children.ToString())
                        item.Passengers!.Child += number;
                    break;
                default:
                    break;
            }

            // this way of getting a generated random string number with symbols converted back to integer 
            item.Passengers!.TotalPeople = item.Passengers.Adult + item.Passengers.Child;
            int adultPrice = int.Parse(string.Concat(data.Adults.Where(char.IsDigit)));
            int childPrice = int.Parse(string.Concat(data.Children.Where(char.IsDigit)));
            item.Passengers.TotalSum = (CalculateTotalFee(item.Passengers!.Adult, adultPrice) +
                                        CalculateTotalFee(item.Passengers!.Child, childPrice)).ToString() + " $";


            res += item.Passengers.TotalSum;

        }
        return res;


    }
    /// <summary>
    /// getPassengerOutHelper is the same as getPassengerHelper but it subtracts 
    /// </summary>
    /// <param name="flight"></param>
    /// <param name="passenger"></param>
    /// <param name="number"></param>
    /// <returns> totalSum </returns>

    public static string getPassengerOutHelper(List<Flight> flight, string passenger, int number)
    {
        string res = "";
        var data = new TypeOfPrices();
        foreach (var item in flight)
        {

            if (passenger == TypeOfPrices.Category.Adult.ToString() && item.Passengers!.Adult != 0)
                item.Passengers!.Adult -= number;
            else if (passenger == TypeOfPrices.Category.Children.ToString() && item.Passengers!.Child != 0)
                item.Passengers!.Child -= number;

            item.Passengers!.TotalPeople = item.Passengers!.Adult + item.Passengers!.Child;

            // this way of getting a generated random string number with symbols converted back to integer 
            int adultPrice = int.Parse(string.Concat(data.Adults.Where(char.IsDigit)));
            int childPrice = int.Parse(string.Concat(data.Children.Where(char.IsDigit)));
            item.Passengers.TotalSum = (CalculateTotalFee(item.Passengers!.Adult, adultPrice) +
                                        CalculateTotalFee(item.Passengers!.Child, childPrice)).ToString() + " $";


            res += item.Passengers.TotalSum;

        }
        return res;








    }


    








}
