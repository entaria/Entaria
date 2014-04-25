using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Entaria.Models;

namespace Entaria.Controllers
{
    public class FindRfidController : ApiController
    {
        private EntariaContext db = new EntariaContext();

        // GET api/FindRfid

        



        class RfidCard
        {
            public int RfidID { get; set; }
            public string Number { get; set; }

        }
        public IEnumerable<Rfid> GetRfids()
        {
            return db.Rfids.AsEnumerable();
        }
        public class RData
        {
            // all of the data that comes from the cash regiter
            public int RfidID { get; set; }
            public string Number { get; set; }
            public int LocID { get; set; }
            public int points { get; set; }
            public int TransactionRef { get; set; }
            public int ReaderID { get; set; }
        }

        // GET api/FindRfid/5
        //[Authorize]
        public Rfid GetRfidNo(string  LCid)
        {
            var rfid = db.Rfids.FirstOrDefault(r => r.Number == LCid);
        
            if (rfid == null)
            {
                Rfid newRfidCard = new Rfid() { Number = LCid, LoyaltyCardHolderId = 0 };
                 PostRfid(newRfidCard);


               //  for (var x = 0; x < 5000000; x++)
              //   {
                     // short delay to get the record inserted
               //  }
                 
               
                     throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                 
                   }

            return rfid;

          //  return "hello got here";
            ;
        }

        // PUT api/FindRfid/5
        public HttpResponseMessage PutRfid(int id, Rfid rfid)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != rfid.RfidId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(rfid).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/FindRfid
        private HttpResponseMessage PostRfid(Rfid rfid)
        {
            if (ModelState.IsValid)
            {
                db.Rfids.Add(rfid);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, rfid);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = rfid.RfidId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/FindRfid/5
        public HttpResponseMessage DeleteRfid(int id)
        {
            Rfid rfid = db.Rfids.Find(id);
            if (rfid == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Rfids.Remove(rfid);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, rfid);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}