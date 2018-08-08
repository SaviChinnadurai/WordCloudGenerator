using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WordCloud.Web.Models
{
    public class WordDM
    {

        public int id { get; set; }
        public string WordText { get; set; }
        public int Count { get; set; }
    }
}