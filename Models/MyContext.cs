using Microsoft.EntityFrameworkCore;

namespace FileUpload.Models
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions options) : base(options) { }


        public DbSet<NewAppretice> NewAppretices { get; set; }
    }

}