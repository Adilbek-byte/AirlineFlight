using AirlineFlightl;
using System;

namespace AirlineFlight
{
    /// <summary>
    /// Класс представляет информацию о горящих авиабилетах.
    /// </summary>
    public class HotFlight
    {
        public string AviaName { get; set; }
        public LocationPath Direction { get; set; }
        public int CountOfTicket { get; set; }
        public int TypeOfPrice { get; set; }
        public DateTime DateTimeOfTicket { get; set; }

        /// <summary>
        /// Создает и возвращает список объектов HotFlight с предопределенными значениями.
        /// </summary>
        /// </summary>
        /// <returns>Список объектов HotFlight.</returns>
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
        /// <summary>
        /// Генерирует и возвращает случайное количество билетов от 1 до 8.
        /// </summary>
        /// <returns>Случайное количество билетов.</returns>
        public static int CountOfTickets()
        {
            Random random = new Random();
            int res = random.Next(1, 8);

            return res;

        }
        /// <summary>
        /// Генерирует и возвращает случайную цену на билеты от 99 до 199.
        /// </summary>
        /// <returns>Случайная цена на билеты.</returns>
        public static int HotPriceOfTickets()
        {
            Random random = new Random();
            int res = random.Next(99, 199);
            return res;
        }
        /// <summary>
        /// Генерирует и возвращает случайную дату и время, прибавляя случайное количество часов к текущему времени.
        /// </summary>
        /// <returns>Случайная дата и время.</returns>
        public static DateTime DateTimes()
        {
            Random rand = new Random();
            int res = rand.Next(1, 12);
            DateTime result = DateTime.Now.AddHours(res);
            return result;
        }
    }


}
