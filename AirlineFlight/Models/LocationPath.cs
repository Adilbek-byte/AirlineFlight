using System.ComponentModel.DataAnnotations;

namespace AirlineFlight;

public class LocationPath
{
    //Location data
    
    public int Id { get; set; }
    public string? FromWhere { get; set; }
    public string? ToWhere { get; set; }
    public int HotFlightId { get; set; }
    public List<HotFlight>? HotFlights { get; set; } = new();

}
