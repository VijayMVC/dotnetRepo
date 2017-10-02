using Exercises.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage ="Please enter a first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a Last name")]
        public string LastName { get; set; }
        [IsValidGPA(ErrorMessage = "Must be a valid GPA between 0.0 and 4.0")]
        public decimal GPA { get; set; }
        public Address Address { get; set; }
        public Major Major { get; set; }
        public List<Course> Courses { get; set; }
    }
}