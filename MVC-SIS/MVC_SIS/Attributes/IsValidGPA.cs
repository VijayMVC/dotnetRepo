using Exercises.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Attributes
{
    public class IsValidGPA : ValidationAttribute
    {
        public override bool IsValid(Object value)
        {
            if (value == null)
            {
                return false;
            }
            decimal gpa = (decimal)value;
            if (gpa < 0.0M || gpa > 4.0M)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}