namespace AirlineFlight.Services.Interfaces;

public interface IFlightService
{
    public Task<List<LocationPathEntity>> getDirection();
    public Task<FlightEntity> PostFlight(FlightEntity flight, int flightId);
}
