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
    [RoutePrefix("Entry")]

    public class EntryController : ApiController
    {
        [HttpGet]
        [Route("Get")]
        public IHttpActionResult Get(EntryListItem entry)
        {
            var entryService = new EntryService(entry.PatientId);
            var entries = entryService.GetEntries();
            return Ok(entries);
        }

        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post(EntryCreate entry)
        {
            if (!ModelState.IsValid)        //If EntryCreate Required Properties are not met
                return BadRequest(ModelState); // Return BadRequest

            var service = new EntryService(entry.PatientId);

            if (!service.CreateEntry(entry))    //Checking CreateEntry() in EntryCreate class
                return InternalServerError(); //Return 500 (Either didnt save to DB or info was put in correctly)

            return Ok(); //Return 200
        }
        [HttpGet]
        [Route("{id}")]
        [ActionName("GetEntryByID")]
        public IHttpActionResult Get(EntryDetail entries)
        {
            var service = new EntryService(entries.PatientId);
            var entry = service.GetEntryById(entries.EntryId);
            return Ok(entry);
        }
        [HttpGet]
        [Route("Start={Start}/End={End}")]
        [ActionName("GetEntryByTimeSpan")]
        public IHttpActionResult Get(EntryStatistics model)  // We need to create a method that gets entries beteween a start and end date.
        {

            var entryService = new EntryService(model.PatientId);
            var MinMaxAvg = entryService.GetListOfBloodSugarByDate(model.Start.Date, model.End.Date);
            var MMA = entryService.GetMinMaxAvg(MinMaxAvg);
            return Ok(MMA);
        }
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(EntryEdit entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new EntryService(entry.EntryId);

            if (!service.UpdateEntry(entry))
                return InternalServerError();
            return Ok();
        }
        [HttpDelete]
        [Route("Delete")]
        public IHttpActionResult Delete(EntryEdit entry)
        {
            var service = new EntryService(entry.EntryId);

            if (!service.DeleteEntry(entry.EntryId))
                return InternalServerError();
            return Ok();
        }
        //private EntryService CreateEntryService()
        //{

        //    EntryService entryService = new EntryService();
        //    return entryService;
        //}
    }
}
