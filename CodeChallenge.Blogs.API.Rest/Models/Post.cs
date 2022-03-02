namespace CodeChallenge.Blogs.API.Rest.Models
{
    public class Post
    {
        public int totalArticles { get; set; }
        public Article[]? articles { get; set; }
    }

    public class Article
    {
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public DateTime publishedAt { get; set; }
        public Source source { get; set; }
    }

    public class Source
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}
