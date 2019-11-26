using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/*
 * Json conversion for Lean Techniques
 * Changes: static json object, tryparse for number validation, break out into classes, unit test, logic change on the first loop
 * Date: 11/25/19
 * Tyler McFarland
 */

namespace LeanTechniques
{
    class Program
    {
        static void Main(string[] args)
        {
            string errMsg = null;
            string albumID = null;


            do
            {
                Console.Write("Enter Album ID: ");
                albumID = Console.ReadLine();

                errMsg = Validation.validateEntry(albumID);

                if (errMsg != null)
                {
                    Console.WriteLine($"{errMsg} {Environment.NewLine}");
                }
            } while (errMsg != null);


            var json = HTTPRequest.getJSON(albumID);
            List<Object> rootList = (List<Object>)JsonConvert.DeserializeObject<List<Object>>(json);
            foreach (var item in rootList)
            {
                Album album = JsonConvert.DeserializeObject<Album>(item.ToString());
                Console.WriteLine($"[{album.Id.ToString()}] {album.title.ToString()} {Environment.NewLine}");
            }

            Console.ReadLine();
        }
    }
}
