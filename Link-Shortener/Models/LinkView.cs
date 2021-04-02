using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Link_Shortener.Models
{
    public class LinkView
    {
        public int linkFrom { get; set; }
        public string linkTo { get; set; }
        public List<Link> list { get; set; }
    }
}