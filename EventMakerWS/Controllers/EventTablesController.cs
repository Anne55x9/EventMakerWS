using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using EventMakerWS;

namespace EventMakerWS.Controllers
{
    public class EventTablesController : ApiController
    {
        private EventContext db = new EventContext();

        // GET: api/EventTables
        public IQueryable<EventTable> GetEventTable()
        {
            return db.EventTable;
        }

        // GET: api/EventTables/5
        [ResponseType(typeof(EventTable))]
        public async Task<IHttpActionResult> GetEventTable(int id)
        {
            EventTable eventTable = await db.EventTable.FindAsync(id);
            if (eventTable == null)
            {
                return NotFound();
            }

            return Ok(eventTable);
        }

        // PUT: api/EventTables/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventTable(int id, EventTable eventTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventTable.Id)
            {
                return BadRequest();
            }

            db.Entry(eventTable).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EventTables
        [ResponseType(typeof(EventTable))]
        public async Task<IHttpActionResult> PostEventTable(EventTable eventTable)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventTable.Add(eventTable);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EventTableExists(eventTable.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eventTable.Id }, eventTable);
        }

        // DELETE: api/EventTables/5
        [ResponseType(typeof(EventTable))]
        public async Task<IHttpActionResult> DeleteEventTable(int id)
        {
            EventTable eventTable = await db.EventTable.FindAsync(id);
            if (eventTable == null)
            {
                return NotFound();
            }

            db.EventTable.Remove(eventTable);
            await db.SaveChangesAsync();

            return Ok(eventTable);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventTableExists(int id)
        {
            return db.EventTable.Count(e => e.Id == id) > 0;
        }
    }
}