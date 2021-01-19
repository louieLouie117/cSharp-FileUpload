using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// system need for File upload

namespace FileUpload.Models
{

    public class Apprentice
    {
        [Key]
        public int ApprenticeId { get; set; }

        public string name { get; set; }
        public List<IFormFile> files { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }


}

