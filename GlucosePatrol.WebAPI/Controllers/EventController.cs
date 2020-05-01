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

        [HttpGet]
        [Route("api/Event/{id}")]
        public IHttpActionResult Get(EventDetail events)
        {
            var service = new EventService(events.PatientId);
            var entry = service.GetEventById(events.EventId);
            return Ok(entry);
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

        [HttpPut]
        public IHttpActionResult Put(EventEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = new EventService(model.EventId);

            if (!service.UpdateEvent(model))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete (EventEdit model)
        {
            var service = new EventService(model.EventId);

            if (!service.DeleteEvent(model.EventId))
                return InternalServerError();

            return Ok();
        }
    }

}
