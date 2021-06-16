using System;
using System.ComponentModel.DataAnnotations;

namespace SysMatur.Data.Objects
{
    public class SessionToken
    {
        [Key] public int Id { get; set; }
        public User Owner { get; set; }
        public DateTime EndOfValidity { get; set; }
        public string Token { get; set; }
    }
}