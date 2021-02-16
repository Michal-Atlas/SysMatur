using System.ComponentModel.DataAnnotations;

namespace DatabaseModel.Models
{
    public class Domain
    {
        [Key] public int Id { get; set; }

        public string Address { get; set; }
    }
}