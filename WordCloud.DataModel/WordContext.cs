using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WordCloud.DataModel.Models;

namespace WordCloud.DataModel
{
    class WordContext : DbContext
    {
        public WordContext() : base()
        {

        }

        public DbSet<WordDM> Words { get; set; }

    }
}