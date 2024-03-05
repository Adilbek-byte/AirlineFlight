namespace AirlineFlight.Services.Interfaces;

public interface IFlightService
{
    public Task<List<LocationPath>> getDirection();
    public Task<Flight> PostFlight(Flight flight, int flightId);
    public Task<List<Flight>> GetPassengerTicket(int numOfPassenger,
       string typeOfPassenger,
       string direction);
    public Task<List<Flight>> GetNumberOfFlights(int number);
    public Task<Flight> UpdateFlight(string aviaName, int Id, int passId, string type);
    public Task DeleteFlight(int Id);
    public Task<List<Passenger>> GetBonus();


}
