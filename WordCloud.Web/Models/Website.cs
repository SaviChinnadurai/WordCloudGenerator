using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WordCloud.Web.Models
{
    public class Website
    {
        [Required(ErrorMessage = "Website URL cannot be empty")]
        public string URL { get; set; }
    }
}