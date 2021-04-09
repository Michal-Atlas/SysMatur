using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Objects
{
    public class SessionToken
    {
        [Key] public int Id { get; set; }
        public DateTime EndOfValidity { get; set; }
    }
}