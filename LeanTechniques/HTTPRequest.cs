using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LeanTechniques
{
    public class HTTPRequest
    {
        public static string getJSON(string albumID)
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString($"https://jsonplaceholder.typicode.com/photos?albumId={albumID}");
                return json;
            }
        }
    }
}
