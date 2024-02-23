using System.ComponentModel.DataAnnotations;

namespace AirlineFlight;

public class LocationPathEntity
{
    //Location data
    [Key]
    public int PathId { get; set; }
    public string? FromWhere { get; set; }
    public string? ToWhere { get; set; }
    public Guid HotId { get; set; }
    
}
