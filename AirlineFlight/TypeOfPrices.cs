
namespace AirlineFlightl;

public class TypeOfPrices
{
    public enum Category
    {
        Adult = 1,
        Children = 2
    }

    public static int PriceOfTickets(Category category)
    {
        Random random = new Random();

        switch (category)
        {
            case Category.Adult:
                return random.Next(299, 1499);
            case Category.Children:
                return random.Next(50, 300);
            default:
                throw new ArgumentOutOfRangeException(nameof(category), "Invalid category");
        }
       
    }
}