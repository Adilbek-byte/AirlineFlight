using AirlineFlightl;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace AirlineFlight
{
    /// <summary>
    /// Класс представляет информацию о горящих авиабилетах.
    /// </summary>
    public class HotFlightEntity
    {
        [Key]
        public Guid HotId { get; set; }

        public string? AviaName { get; set; } = string.Empty ?? throw new Exception();
        public int CountOfTicket { get; set; }
        public int TypeOfPrice { get; set; }
        public DateTime DateTimeOfTicket { get; set; }
        public List<LocationPathEntity>? Direction { get; set; }




    }
}