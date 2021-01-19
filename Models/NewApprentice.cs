using System;
using System.ComponentModel.DataAnnotations;

namespace FileUpload
{

    public class NewAppretice
    {

        public string Name { get; set; }
        public string File { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}