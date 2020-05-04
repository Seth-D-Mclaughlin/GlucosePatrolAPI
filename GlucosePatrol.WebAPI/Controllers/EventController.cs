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
    [RoutePrefix("Event")]
    public class EventController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(EventListItem model)
        {
            var eventService = new EventService(model.PatientId);
            var events = eventService.GetEvents();
            return Ok(events);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult Get(EventDetail events)
        {
            var service = new EventService(events.PatientId);
            var entry = service.GetEventById(events.EventId);
            return Ok(entry);
        }

        [HttpPost]
        [Route("Post")]
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
        [Route("Put")]
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
        [Route("Delete")]
        public IHttpActionResult Delete (EventEdit model)
        {
            var service = new EventService(model.EventId);

            if (!service.DeleteEvent(model.EventId))
                return InternalServerError();

            return Ok();
        }
    }

}
