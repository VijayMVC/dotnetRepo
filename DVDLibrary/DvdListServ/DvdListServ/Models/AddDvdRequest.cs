using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DvdListServ.Models
{
    public class AddDvdRequest
    {
        [Required]
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public string Rating { get; set; }
        public string Notes { get; set; }
    }
}