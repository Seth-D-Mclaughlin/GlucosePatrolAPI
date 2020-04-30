using GlucosePatrol.Models;
using GlucosePatrol.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlucosePatrol.WebAPI.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(EventListItem model)
        {
            var eventService = new EventService(model.PatientId);
            var events = eventService.GetEvents();
            return Ok(events);
        }
        [HttpPost]
        public IHttpActionResult Post(EventCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new EventService(model.PatientId);

            if (!service.CreateEvent(model))
                return InternalServerError();

            return Ok();
        }
    }

}
