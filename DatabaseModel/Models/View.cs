using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class View
    {
        public View()
        {
            Feeds = new List<Feed>();
        }

        [Key] public int Id { get; set; }
        public IEnumerable<Feed> Feeds { get; set; }
    }
}