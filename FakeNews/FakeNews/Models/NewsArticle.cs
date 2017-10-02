using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeNews.Models
{
    public class NewsArticle
    {
        public string Headline { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string BodyText { get; set; }
        public bool IsPublished { get; set; }
        public int Id { get; set; }
    }
}