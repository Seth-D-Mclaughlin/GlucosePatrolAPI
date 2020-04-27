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
        private EntryService CreateEntryService() //Helper method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var entryService = new EntryService(userId);
            return entryService;
        }
    }
}
