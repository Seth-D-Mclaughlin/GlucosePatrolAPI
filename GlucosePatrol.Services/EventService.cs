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
        private readonly int _userId;

        public EventService(int patientId)
        {
            _userId = patientId;
        }

        public bool CreateEvent(EventCreate model)
        {
            var entity =
                new Event()
                {
                    PatientId = _userId,//OwnerId = _userId, Hey we need to discuss how we get the OwnerId. 1) Grab it from foregin relation with Entry. 2)Add OwnerId prop to Event.cs (Which defeats the purpose?)
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
        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Events
                    .Where(e => e.PatientId == _userId)
                    .Select(
                        e =>
                        new EventListItem
                        {
                            PatientId = e.PatientId,
                            EventId = e.EventId,
                            TypeOfEvent = e.TypeOfEvent,
                            SubTypeOfEvent = e.SubTypeOfEvent,
                            Value = e.Value,
                            Unit = e.Unit,
                            CreatedUtc = e.CreatedUtc
                        }
                     );
                return query.ToArray();
            }
        }
        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == id);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        PatientId = entity.PatientId,
                        TypeOfEvent = entity.TypeOfEvent,
                        SubTypeOfEvent = entity.SubTypeOfEvent,
                        Unit = entity.Unit,
                        Value = entity.Value,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == model.EventId);
                entity.TypeOfEvent = model.TypeOfEvent;
                entity.SubTypeOfEvent = model.SubTypeOfEvent;
                entity.Unit = model.Unit;
                entity.Value = model.Value;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventId == eventId);
                ctx.Events.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
