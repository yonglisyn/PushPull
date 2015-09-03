using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PushPull.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string AccountId { get; set; }
        public string Password { get; set; }
        public DateTime PasswordExpiryTime { get; set; }
        public DateTime LockExpiryTime { get; set; }
        public int LoginFailCount { get; set; }
        public DateTime LoginTime { get; set; }
        public string LoginIp { get; set; }
        public string LoginCountry { get; set; }
        public string ModifiedOn { get; set; }
        public string ModifeidBy { get; set; }
    }

}