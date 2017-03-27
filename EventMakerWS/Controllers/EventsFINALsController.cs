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
    public class EventsFINALsController : ApiController
    {
        private EventFinalContext db = new EventFinalContext();

        // GET: api/EventsFINALs
        public IQueryable<EventsFINAL> GetEventsFINAL()
        {
            return db.EventsFINAL;
        }

        // GET: api/EventsFINALs/5
        [ResponseType(typeof(EventsFINAL))]
        public async Task<IHttpActionResult> GetEventsFINAL(int id)
        {
            EventsFINAL eventsFINAL = await db.EventsFINAL.FindAsync(id);
            if (eventsFINAL == null)
            {
                return NotFound();
            }

            return Ok(eventsFINAL);
        }


        // PUT: api/EventsFINALs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventsFINAL(int id, EventsFINAL eventsFINAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventsFINAL.Id)
            {
                return BadRequest();
            }

            db.Entry(eventsFINAL).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsFINALExists(id))
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

        // POST: api/EventsFINALs
        [ResponseType(typeof(EventsFINAL))]
        public async Task<IHttpActionResult> PostEventsFINAL(EventsFINAL eventsFINAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventsFINAL.Add(eventsFINAL);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventsFINAL.Id }, eventsFINAL);
        }

        // DELETE: api/EventsFINALs/5
        [ResponseType(typeof(EventsFINAL))]
        public async Task<IHttpActionResult> DeleteEventsFINAL(int id)
        {
            EventsFINAL eventsFINAL = await db.EventsFINAL.FindAsync(id);
            if (eventsFINAL == null)
            {
                return NotFound();
            }

            db.EventsFINAL.Remove(eventsFINAL);
            await db.SaveChangesAsync();

            return Ok(eventsFINAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventsFINALExists(int id)
        {
            return db.EventsFINAL.Count(e => e.Id == id) > 0;
        }
    }
}