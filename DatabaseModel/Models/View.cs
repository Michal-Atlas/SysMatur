using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class View
    {
        [Key] public int Id { get; set; }
        public List<Feed> Feeds { get; set; }
    }
}