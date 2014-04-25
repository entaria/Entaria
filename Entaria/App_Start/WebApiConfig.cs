using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Entaria
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {


            // int client, int card, int locationId, int readerid, string receiptNo, int transactionTypeId, DateTime transactionTime 
      /*     config.Routes.MapHttpRoute(
              name: "ApiputCCB",
              routeTemplate: "api/{controller}/{action}/{id}/{value}",
              defaults: new { controller = "cws", action = "PutClientCardBalance"}
          ); */
          config.Routes.MapHttpRoute(
               name: "ApipostTRANSACTION",
               routeTemplate: "api/{controller}/{action}/{client}/{card}/{locationId}/{readerid}/{receiptNo}/{transactionTypeId}/{transactionTime}",
               defaults: new { controller = "cws", action = "PostTRANSACTION", client = 0, card = 0, locationId =  0, readerid = 0, receiptNo = "1234567890", transactionTypeId = 0, transactionTime = System.DateTime.Now}
           );  
            config.Routes.MapHttpRoute(
                name: "ApiFindRfid",
                routeTemplate: "api/{controller}/{action}/{value}",
                defaults: null
            );
            config.Routes.MapHttpRoute(
               name: "ApigetCCB",
               routeTemplate: "api/{controller}/{action}/{client}/{card}",
               defaults: new { controller = "cws", client = 0, card = 0 }
           );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}