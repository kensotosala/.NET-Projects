using Blog_App_ASP.NET_MVC_Entity_Framework.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blog_App_ASP.NET_MVC_Entity_Framework.Data
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions options) : base(options)
        {

        }

        // Creating a tables
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
