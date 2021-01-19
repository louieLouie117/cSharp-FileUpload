using System;
using System.ComponentModel.DataAnnotations;

namespace FileUpload.Models
{

    public class Apprentice
    {
        [Key]
        public int ApprenticeId { get; set; }

        public string name { get; set; }
        public String file { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}