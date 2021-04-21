using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class Post
    {
        public string Title { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Body { get; set; }
        public IEnumerable<Uri> Images { get; set; }
        public string Summary { get; set; }
        public Uri Anchor { get; set; }
    }
}