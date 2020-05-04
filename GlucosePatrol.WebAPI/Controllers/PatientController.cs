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
    //[RoutePrefix("Patient")]

    public class PatientController : ApiController
    {
        //[Route("Get")]
        public IHttpActionResult Get()
        {
            PatientService patientService = CreatePatientService();
            var patient = patientService.GetPatients();
            return Ok(patient);
        }
        [HttpPost]
        //[Route("Post")]
        public IHttpActionResult Post(PatientCreate patient)
        {
            if (!ModelState.IsValid)        //If EntryCreate Required Properties are not met
                return BadRequest(ModelState); // Return BadRequest

            var service = CreatePatientService();

            if (!service.CreatePatient(patient))    //Checking CreateEntry() in EntryCreate class
                return InternalServerError(); //Return 500 (Either didnt save to DB or info was put in correctly)

            return Ok(); //Return 200
        }
        [HttpPut]
        //[Route("Put")]
        public IHttpActionResult Put(PatientEdit patient)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreatePatientService();

            if (!service.UpdatePatient(patient))
                return InternalServerError();
            return Ok();
        }

        [HttpDelete]
        //[Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var service = CreatePatientService();

            if (!service.DeletePatient(id))
                return InternalServerError();
            return Ok();
        }

        private PatientService CreatePatientService() //Helper method
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var patientService = new PatientService(userId);
            return patientService;
        }
    }
}
