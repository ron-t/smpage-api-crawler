using AirlineFacebookDataCollection.Properties;
using Facebook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineFacebookDataCollection
{
    class AuthTasks
    {
        internal static string GetAppAccessToken()
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = App.AppId,
                client_secret = App.AppSecret,
                grant_type = "client_credentials"
            });

            Settings.Default.AppAccessToken = result[0];
            Settings.Default.Save();

            return result[0];
        }

        internal static string GetLongTermUserAccessToken(string UserAccessToken)
        {
            var fb = new FacebookClient(UserAccessToken);
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = App.AppId,
                client_secret = App.AppSecret,
                grant_type = "fb_exchange_token",
                fb_exchange_token = UserAccessToken
            });

            var token = result[0];

            if(token != null)
            {
                Settings.Default.UserAccessToken = token;
                Settings.Default.Save();
            }
            else { token = UserAccessToken; }

            return token;
        }

        internal static dynamic DebugTokenAsync(string appAccessToken, string userAccessToken)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Get("debug_token", new
            {
                access_token = appAccessToken,
                input_token = userAccessToken
            });

            return result.data;


        }

        internal static string GetUserAccessToken(string url)
        {
            //https://www.facebook.com/connect/login_success.html

            string url2 = url.Substring(url.IndexOf("access_token") + 13);
            var token =  url2.Substring(0, url2.IndexOf("&"));

            Settings.Default.UserAccessToken = token;
            Settings.Default.Save();

            return token;
        }
        
    }
}
