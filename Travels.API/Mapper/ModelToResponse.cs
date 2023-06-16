using AutoMapper;
using Travels.API.Response;
using Travels.Infraestructure.Models;

namespace Travels.API.Mapper;

public class ModelToResponse: Profile
{
    public ModelToResponse()
    {
        CreateMap<Destination, DestinationResponse>();
    }
}