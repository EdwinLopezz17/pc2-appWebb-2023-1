using Travels.Infraestructure.Models;

namespace Travels.Domain;

public interface IDestinationDomain
{
    public Task<bool> SaveAsync(Destination destination);
}