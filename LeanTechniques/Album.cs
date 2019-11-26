using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanTechniques
{
    public class Album
    {
        [JsonProperty("albumID")]
        public int albumId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string title { get; set; }

        [JsonProperty("url")]
        public string url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public string thumbnailUrl { get; set; }

        //[JsonProperty("photos")]
        //public List<Rows> Albums { get; set; }
    }

    public class Rows
    {

        //[JsonProperty("albumID")]
        //public int albumId { get; set; }

        //[JsonProperty("id")]
        //public int Id { get; set; }

        //[JsonProperty("title")]
        //public string title { get; set; }

        //[JsonProperty("url")]
        //public string url { get; set; }

        //[JsonProperty("thumbnailUrl")]
        //public string thumbnailUrl { get; set; }

    }
}
