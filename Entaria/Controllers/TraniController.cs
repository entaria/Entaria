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
    public class TraniController : ApiController
    {
        private EntariaContext db = new EntariaContext();

        // GET api/Trani
        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            return db.TransactionTypes.AsEnumerable();
        }

        // GET api/Trani/5
        public TransactionType GetTransactionType(int id)
        {
            TransactionType transactiontype = db.TransactionTypes.Find(id);
            if (transactiontype == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return transactiontype;
        }

        // PUT api/Trani/5
        public HttpResponseMessage PutTransactionType(int id, TransactionType transactiontype)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != transactiontype.TransactionTypeId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(transactiontype).State = EntityState.Modified;

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

        // POST api/Trani
        public HttpResponseMessage PostTransactionType(TransactionType transactiontype)
        {
            if (ModelState.IsValid)
            {
                db.TransactionTypes.Add(transactiontype);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, transactiontype);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = transactiontype.TransactionTypeId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Trani/5
        public HttpResponseMessage DeleteTransactionType(int id)
        {
            TransactionType transactiontype = db.TransactionTypes.Find(id);
            if (transactiontype == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.TransactionTypes.Remove(transactiontype);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, transactiontype);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}