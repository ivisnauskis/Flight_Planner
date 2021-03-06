﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Web.Attributes;
using Flight_Planner.Web.Models;

namespace Flight_Planner.Web.Controllers
{
    [BasicAuthentication]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AdminController : BaseController
    {
        public AdminController(IFlightService flightService, IMapper mapper) : base(flightService, mapper)
        {
        }

        [HttpGet]
        [Route("admin-api/flights/")]
        public async Task<IHttpActionResult> Get()
        {
            var flights = await FlightService.GetFlights();
            return Ok(flights.Select(f => Mapper.Map<FlightResponse>(f)).ToList());
        }

        [HttpGet]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var flight = await FlightService.GetById(id);
            if (flight == null) 
                return NotFound();

            return Ok(Mapper.Map<FlightResponse>(flight));
        }

        [HttpPut]
        [Route("admin-api/flights/")]
        public async Task<IHttpActionResult> Put(FlightRequest flightRequest)
        {
            var flight = Mapper.Map<Flight>(flightRequest);

            if (await FlightService.Exists(flight)) 
                return Conflict();

            var response = await FlightService.AddFlight(flight);

            if (response.Succeeded)
            {
                var flightUrl = $"{Request.RequestUri}/{response.Entity.Id}";
                var flightResponse = Mapper.Map<FlightResponse>(response.Entity);
                return Created(flightUrl, flightResponse);
            }

            return new BadRequest(response.Errors, Request);
        }

        [HttpDelete]
        [Route("admin-api/flights/{Id}")]
        public async Task<IHttpActionResult> DeleteFlight(int id)
        {
            await FlightService.DeleteFlight(id);
            return Ok();
        }
    }
}