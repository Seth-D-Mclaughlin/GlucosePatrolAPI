using GlucosePatrol.Data;
using GlucosePatrol.Models;
using GlucosePatrol.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GlucosePatrol.WebAPI.Controllers
{
    [Authorize]
    public class EntryController : ApiController
    {
        public IHttpActionResult Get()
        {
            EntryService entryService = CreateEntryService();
            var entries = entryService.GetEntries();
            return Ok(entries);
        }

        [HttpPost]
        public IHttpActionResult Post(EntryCreate entry)
        {
            if (!ModelState.IsValid)        //If EntryCreate Required Properties are not met
                return BadRequest(ModelState); // Return BadRequest

            var service = CreateEntryService();

            if (!service.CreateEntry(entry))    //Checking CreateEntry() in EntryCreate class
                return InternalServerError(); //Return 500 (Either didnt save to DB or info was put in correctly)

            return Ok(); //Return 200
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            EntryService entryService = CreateEntryService();
            var entry = entryService.GetEntryById(id);
            return Ok(entry);
        }
        private EntryService CreateEntryService() //Helper method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var entryService = new EntryService(userId);
            return entryService;
        }
        [HttpGet]
        public IHttpActionResult Get(DateTime Start, DateTime End)  // We need to create a method that gets entries beteween a start and end date.
        {
            EntryService entryService = CreateEntryService();
            var MinMaxAvg = entryService.GetMinMaxAvg();
            return Ok(MinMaxAvg);
        }
        [HttpPut]
        public IHttpActionResult Put(EntryEdit entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateEntryService();

            if (!service.UpdateEntry(entry))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEntryService();

            if (!service.DeleteEntry(id))
                return InternalServerError();
            return Ok();
        }
    }
}
