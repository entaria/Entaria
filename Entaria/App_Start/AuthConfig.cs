using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using Entaria.Models;

namespace Entaria
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "0000000048118649",
                clientSecret: "epcb2QID4x-ayged5S4Ygf7GYubpOTbS");

            //OAuthWebSecurity.RegisterTwitterClient(
            //    consumerKey: "",
            //    consumerSecret: "");

            //OAuthWebSecurity.RegisterFacebookClient(
            //    appId: "595751640520969",
            //    appSecret: "4b39718d35b6050076d7a21b0f565707");

            OAuthWebSecurity.RegisterGoogleClient();

            OAuthWebSecurity.RegisterYahooClient();
        }
    }
}
