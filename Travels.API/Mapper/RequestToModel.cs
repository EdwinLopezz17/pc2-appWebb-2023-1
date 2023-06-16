using AutoMapper;
using Travels.API.Input;
using Travels.API.Response;
using Travels.Infraestructure.Models;

namespace Travels.API.Mapper;

public class RequestToModel: Profile
{
    public RequestToModel()
    {
        CreateMap<DestinationInput, Destination>();
    }
}