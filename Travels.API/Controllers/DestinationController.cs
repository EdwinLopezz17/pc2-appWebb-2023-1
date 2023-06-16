using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travels.API.Input;
using Travels.API.Response;
using Travels.Domain;
using Travels.Infraestructure;
using Travels.Infraestructure.Models;

namespace Travels.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {

        private IDestinationInfraestructure _destinationInfraestructure;
        private IDestinationDomain _destinationDomain;
        private IMapper _mapper;

        public DestinationController(IDestinationInfraestructure destinationInfraestructure,
            IDestinationDomain destinationDomain, IMapper mapper)
        {
            _destinationInfraestructure = destinationInfraestructure;
            _destinationDomain = destinationDomain;
            _mapper = mapper;
        }
        
        
        // GET: api/Destination
        [HttpGet]
        public async Task<List<DestinationResponse>> Get()
        {
            var destinations= await _destinationInfraestructure.GetAllAsync();
            return _mapper.Map<List<Destination>, List<DestinationResponse>>(destinations);
        }

        // GET: api/Destination/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Destination
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] DestinationInput destinationInput)
        {
            if (ModelState.IsValid)
            {
                var destination = _mapper.Map<DestinationInput, Destination>(destinationInput);
                await _destinationDomain.SaveAsync(destination);
                return Ok();
            }
            else
            {
                return StatusCode(400);
            }
        }

        // PUT: api/Destination/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Destination/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
