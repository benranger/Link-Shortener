using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Link_Shortener.Models
{
    public class Link
    {
        public int linkFrom { get; set; }
        [Required]
        [DataType(DataType.Url, ErrorMessage ="Must be a Valid URL")]
        public string linkTo { get; set; }
    }
}