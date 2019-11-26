using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeanTechniquesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string albumID = "1";
            var json = LeanTechniques.HTTPRequest.getJSON(albumID);
            List<Object> rootList = (List<Object>)JsonConvert.DeserializeObject<List<Object>>(json);
            foreach (var item in rootList)
            {
                LeanTechniques.Album album = JsonConvert.DeserializeObject<LeanTechniques.Album>(item.ToString());
                Console.WriteLine($"[{album.Id.ToString()}] {album.title.ToString()} {Environment.NewLine}");
            }
        }
    }
}
