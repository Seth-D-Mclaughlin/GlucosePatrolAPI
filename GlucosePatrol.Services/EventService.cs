using GlucosePatrol.Data;
using GlucosePatrol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucosePatrol.Services
{
    public class EventService
    {
        private readonly Guid _userId;
        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    OwnerId = _userId, //Hey we need to discuss how we get the OwnerId. 1) Grab it from foregin relation with Entry. 2)Add OwnerId prop to Event.cs (Which defeats the purpose?)
                    TypeOfEvent = model.TypeOfEvent,
                    SubTypeOfEvent = model.SubTypeOfEvent,
                    Value = model.Value,
                    Unit = model.Unit,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

    }
}
