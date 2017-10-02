using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeNews.Models
{
    public class NewsRepo
    {
        public static List<NewsArticle> _allArticles = new List<NewsArticle>
        {
            new NewsArticle
            {
                Headline = "Hamburger Shortage!",
                PublishDate = new DateTime (2017,4,1),
                Author = "Hamburglar",
                IsPublished = true,
                BodyText = "Heres is a story about the shortage of hamburgers across the world",
                Id = 1,

            },
            new NewsArticle
            {
                Headline = "McDonalds Goes out of Business",
                PublishDate = new DateTime (2017,8,1),
                Author = "Bill Johnson",
                IsPublished = true,
                BodyText = "Heres is a story about McDonalds going out of business",
                Id = 2,
            },
            new NewsArticle
            {
                Headline = "Life expectancy at an all time high!",
                PublishDate = new DateTime (2017,9,1),
                Author = "Bob Bobson",
                IsPublished = true,
                BodyText = "The average life expectancy is at an all time high. People are living til 120 years old on average",
                Id = 3,
            },
            new NewsArticle
            {
                Headline = "Jake is Hungry for a Hamburger!",
                PublishDate = new DateTime (2017,9,27),
                Author = "Jake Ganser",
                IsPublished = false,
                BodyText = "Writing these articles has made Jake hungry for hamburgers",
                Id = 4,
            }
        };

        public List<NewsArticle> GetAllArticles()
        {
            return _allArticles;
        }
    }
}