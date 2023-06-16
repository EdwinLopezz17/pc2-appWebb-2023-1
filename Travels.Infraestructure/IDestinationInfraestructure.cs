using Travels.Infraestructure.Models;

namespace Travels.Infraestructure;

public interface IDestinationInfraestructure
{
    Task<List<Destination>> GetAllAsync();
    public Task<bool> SaveAsync(Destination destination);
}