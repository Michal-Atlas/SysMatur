using System;
using System.Collections.Generic;

namespace SysMatur.Api.Models
{
    public class Post
    {
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Body { get; set; }
        public Uri? Image { get; set; }
        public string Summary { get; set; }
        public Uri Anchor { get; set; }
    }
}