namespace Blog_App_ASP.NET_MVC_Entity_Framework.Models.Domain
{
    public class BlogPost
    {
        public Guid Id { get; set; }

        public string Heading { get; set; }

        public string PageTitle { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }
        public string FeaturedImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public bool Visible { get; set; }

        // A BlogPost can have multiple tags posts
        public ICollection<Tag> Tags { get; set; }
    }
}