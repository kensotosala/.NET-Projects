namespace Blog_App_ASP.NET_MVC_Entity_Framework.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }

        // A tag can have multiple blog posts
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
