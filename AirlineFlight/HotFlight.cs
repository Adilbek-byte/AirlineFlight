using AirlineFlightl;
using System;

namespace AirlineFlight
{
    public class HotFlight
    {
        public string AviaName { get; set; }
        public LocationPath Direction { get; set; }
        public int CountOfTicket { get; set; }
        public int TypeOfPrice { get; set; }
        public DateTime DateTimeOfTicket { get; set; }

        public static List<HotFlight> CreateHotFlights()
        {
            List<HotFlight> hotFlights = new List<HotFlight>
            {
                new HotFlight { AviaName = "Pegasus", Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "London" }, CountOfTicket = CountOfTickets(), TypeOfPrice = HotPriceOfTickets(), DateTimeOfTicket= DateTimes() },
                new HotFlight { AviaName = "Pegasus", Direction = new LocationPath { FromWhere = "Bishkek", ToWhere = "Dubai" }, CountOfTicket = CountOfTickets(), TypeOfPrice = HotPriceOfTickets(), DateTimeOfTicket = DateTimes() },
                new HotFlight { AviaName = "Pegasus", Direction = new LocationPath { FromWhere = "Batken", ToWhere = "Nha Trang" }, CountOfTicket = CountOfTickets(), TypeOfPrice = HotPriceOfTickets(), DateTimeOfTicket = DateTimes() },
                new HotFlight { AviaName = "Pegasus", Direction = new LocationPath { FromWhere = "Osh", ToWhere = "Bishkek" }, CountOfTicket = CountOfTickets(), TypeOfPrice = HotPriceOfTickets(), DateTimeOfTicket = DateTimes() },
            };
            return hotFlights;

        }
        public static int CountOfTickets()
        {
            Random random = new Random();
            int res = random.Next(1, 8);

            return res;

        }
        public static int HotPriceOfTickets()
        {
            Random random = new Random();
            int res = random.Next(99, 199);
            return res;
        }
        public static DateTime DateTimes()
        {
            Random rand = new Random();
            int res = rand.Next(1, 12);
            DateTime result = DateTime.Now.AddHours(res);
            return result;
        }
    }
    //public class CountOfTickets
    //{
    //    public int Count { get; set; }
    //}


}
