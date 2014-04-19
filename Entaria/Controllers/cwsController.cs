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
 /// <summary>
 /// 
 /// </summary>
 //  [Authorize (Roles ="RegisteredTills")]
    public class cwsController : ApiController
    {
        public class TransactionII
        {
            public int TransactionId { get; set; }
            public int ClientId { get; set; }
            public int LocationId { get; set; }
            public int ReaderId { get; set; }
            public int CardId { get; set; }
            public string ReceiptNumber { get; set; }
            public int TransactionTypeId { get; set; }
            public DateTime TransactionTime { get; set; }
        }
        public class RData
        {
            // all of the data that comes from the cash regiter
            public int CardId { get; set; }
            public string Number { get; set; }
            public int ClientId { get; set; }
            public int LocID { get; set; }
            public int Points { get; set; }
            public string TransactionRef { get; set; }
            public int ReaderID { get; set; }
        }
        private EntariaContext db = new EntariaContext();

        // GET api/TransAct
        public IEnumerable<Transaction> GetTransactions()
        {
            return db.Transactions.AsEnumerable();
        }

        // GET api/cws
        public IEnumerable<Card> GetCards()
        {
            return db.Cards.AsEnumerable();
        }


        public Card GetRfidNo(string LCid)
        {
            var card = db.Cards.FirstOrDefault(r => r.Number == LCid);

            if (card == null)
            {
                Card newCard = new Card() { Number = LCid, LoyaltyCardHolderId = 0 };

                var returned = PostNewCard(newCard);

                if (returned.CardId != -1)
                {
                    Card returnRfidCard = new Card() { Number = returned.Number, LoyaltyCardHolderId = returned.LoyaltyCardHolderId, CardId = returned.CardId };
                    card = returnRfidCard;
                }
                else
                {

                    Card returnRfidCard = new Card() { Number = LCid, LoyaltyCardHolderId = 54321, CardId = 111111111 };
                    card = returnRfidCard;
                }



            //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            }

            return card;

          
            ;
        }
        [HttpGet]
        [ActionName("ApigetCCB")]
        public ClientCardBalance getCCB(int client, int card)           // find client card balance 
            // this method find the card balance for this partiular client for this particular loyalty cardholder
        {

         var ccb = db.ClientCardBalances.FirstOrDefault(r => r.CardId == card && r.ClientId == client);
           if (ccb == null)
            {
                ClientCardBalance newCCB = new ClientCardBalance() { CardId = card, PointsBalance = 0, ClientId = client };

               ccb = PostNewCCB(newCCB);

            } 

         return ccb;

          //  return "Hello " + client + " got here" + " " + card;

        }  // end of findCCB


        private ClientCardBalance PostNewCCB(ClientCardBalance ccb)
        {
            if (ModelState.IsValid)
            {
                var retID = 0;
                try
                {
                    db.ClientCardBalances.Add(ccb);
                    db.SaveChanges();
                    retID = ccb.ClientCardBalanceId;

                }
                catch (Exception)
                {
                    retID = -1;

                }
                return ccb;                       // return new record id or a failure value of -1

            }
            else
            {

                // return an error card with -1'sin the integers to indicate there was some sordt of a problem
                ClientCardBalance errorcard = new ClientCardBalance { CardId = ccb.CardId   ,ClientId = ccb.ClientId,  PointsBalance = -1 , ClientCardBalanceId = -1 };
                return errorcard;
            }
        }
        // POST api/FindRfid
        private Card  PostNewCard(Card card)
        {
            if (ModelState.IsValid)
            {
                var retID = 0;
                try
                {
                    db.Cards.Add(card);
                    db.SaveChanges();
                    retID = card.CardId;
                   
                }
                catch (Exception)
                {
                    retID = -1;
                    
                }
                return card;                       // return new record id or a failure value of -1

            }
            else
            {

               Card  errorcard = new Card{ Number = card.Number   , LoyaltyCardHolderId = 54321, CardId = -1 };
               return errorcard;
            }
        }


        /*
         * 
         * 
         * 
         *  public int ReaderId { get; set; }
            public int CardId { get; set; }
            public string ReceiptNumber { get; set; }
            public int TransactionTypeId { get; set; }
            public DateTime TransactionTime { get; set; }
         */

        // POST api/TransAct
        public HttpResponseMessage PostTransaction(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, transaction);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = transaction.TransactionId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        [ActionName("ApiputCCB")]

        public HttpResponseMessage PutClientCardBalance(int id, ClientCardBalance clientcardbalance)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != clientcardbalance.ClientCardBalanceId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(clientcardbalance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
              //  return Request.CreateErrorResponse(HttpStatusCode.Ambiguous, ex);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
           
        // PUT api/cws/5
        public HttpResponseMessage PutCard(int id, Card card)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != card.CardId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(card).State = EntityState.Modified;

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

        // POST api/cws
        public HttpResponseMessage PostCard(Card card)
        {
            if (ModelState.IsValid)
            {
                db.Cards.Add(card);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, card);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = card.CardId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/cws/5
        public HttpResponseMessage DeleteCard(int id)
        {
            Card card = db.Cards.Find(id);
            if (card == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Cards.Remove(card);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, card);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}