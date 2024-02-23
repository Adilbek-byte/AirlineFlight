
using System.ComponentModel.DataAnnotations;
using System.Security;


namespace AirlineFlightl;

public class TypeOfPricesEntity
{
    //the first generated origin string numbers are stored in readonly type of variables to preserve consistency of the numbers
    private static readonly string adultPrice = TypeOfPricesEntity.PriceOfTickets(TypeOfPricesEntity.Category.Adult);
    private static readonly string childPrice = TypeOfPricesEntity.PriceOfTickets(TypeOfPricesEntity.Category.Children);

    [Key]
    public int PriceId { get; set; }
    public string Adults { get; } = adultPrice;
    public string Children { get; } = childPrice;
    public enum Category
    {
        Adult = 1,
        Children = 2
    }

    
    /// <summary>
    /// this method generates random string numbers 
    /// </summary>
    /// <param name="category"></param>
    /// <returns>random string numbers </returns>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static string PriceOfTickets(Category category)
    {
        Random random = new Random();

        switch (category)
        {
            case Category.Adult:
                return $"{random.Next(299, 1499)} $";
            case Category.Children:
                return $"{random.Next(50, 300)} $";
            default:
                throw new ArgumentOutOfRangeException(nameof(category), "Invalid category");
        }
    }
}