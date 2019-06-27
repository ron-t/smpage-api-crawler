using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineFacebookDataCollection
{
    class App
    {
        private const string appid = "";
        internal static string AppId
        {
            get { return appid; }
        }

        private const string appsecret = "";

        internal static string AppSecret
        {
            get { return appsecret; }
        }

        internal static string AppToken { get; set; }

        //internal void ass()
        //{
        //    System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
        //    Console.Out.WriteLine(myAssembly.FullName);
        //}

    }
}
