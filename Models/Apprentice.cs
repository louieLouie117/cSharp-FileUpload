using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FileUpload.Models
{
    public class Apprentice
    {
        [Key]
        public int ApprenticeId { get; set; }

        public string name { get; set; }
        // public List<IFormFile> files { get; set; }

        public string UploadName { get; set; }

        public string aboutMe { get; set; }

        [NotMapped]
        public IFormFile files { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }


}

