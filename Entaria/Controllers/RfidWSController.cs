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
    public class RfidWSController : ApiController
    {
        private EntariaContext db = new EntariaContext();

        // GET api/RfidWS
        public IEnumerable<Rfid> GetRfids()
        {
            return db.Rfids.AsEnumerable();
        }

        // GET api/RfidWS/5
        public Rfid GetRfid(int id)
        {
            Rfid rfid = db.Rfids.Find(id);
            if (rfid == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return rfid;
        }

        // PUT api/RfidWS/5
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

        // POST api/RfidWS
        public HttpResponseMessage PostRfid(Rfid rfid)
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

        // DELETE api/RfidWS/5
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