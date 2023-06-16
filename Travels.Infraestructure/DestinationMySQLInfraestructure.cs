using Microsoft.EntityFrameworkCore;

using Travels.Infraestructure.Models;
using TravelsInfraestructure.Context;

namespace Travels.Infraestructure;

public class DestinationMySQLInfraestructure: IDestinationInfraestructure
{
    
    private TravelsInfraestructureDBContext _travelsInfraestructureDbContext;

    public DestinationMySQLInfraestructure(TravelsInfraestructureDBContext travelsInfraestructureDbContext)
    {
        _travelsInfraestructureDbContext = travelsInfraestructureDbContext;
    }
    
    public async Task<List<Destination>> GetAllAsync()
    {
        return await _travelsInfraestructureDbContext.Destinations.ToListAsync();
    }

    public async Task<bool> SaveAsync(Destination destination)
    {
        await _travelsInfraestructureDbContext.Destinations.AddAsync(destination);
        await _travelsInfraestructureDbContext.SaveChangesAsync();
        return true;
    }
}