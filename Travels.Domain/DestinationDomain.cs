using Travels.Infraestructure;
using Travels.Infraestructure.Models;

namespace Travels.Domain;

public class DestinationDomain :IDestinationDomain
{
    public IDestinationInfraestructure DestinationInfraestructure;

    public DestinationDomain (IDestinationInfraestructure destinationInfraestructure)
    {
        DestinationInfraestructure = destinationInfraestructure;
    }
    
    public async Task<bool> SaveAsync(Destination destination)
    {;
        return await DestinationInfraestructure.SaveAsync(destination);
    }
}