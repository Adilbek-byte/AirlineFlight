using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace AirlineFlight.Models;

public class BonusEntity
{
    //Bonus data

    [Key]
    public int BonusId { get; set; }
    public bool FreeTaxi { get; set; }
   
}
