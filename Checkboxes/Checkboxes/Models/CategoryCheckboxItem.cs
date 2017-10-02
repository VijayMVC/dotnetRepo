using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkboxes.Models
{
    public class CategoryCheckBoxItem
    {
        public Category Category { get; set; }
        public bool IsSelected { get; set; }
    }
}