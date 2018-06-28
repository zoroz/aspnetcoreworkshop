using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Book
    {
        [Required]
        [DisplayName("I DI")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Naslov")]
        public string Title { get; set; }
        public string Publisher { get; set; }

        public string Data { get; set; }
    }
}
