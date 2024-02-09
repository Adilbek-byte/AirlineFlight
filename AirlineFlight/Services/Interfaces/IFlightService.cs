namespace AirlineFlight.Services.Interfaces;

public interface IFlightService
{
    public Task<List<Flight>> GetFligthsAsync();
}
