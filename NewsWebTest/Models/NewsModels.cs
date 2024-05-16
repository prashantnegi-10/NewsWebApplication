namespace NewsWebTest.NewsModels
{
    public class NewsApiResponse
    {
        public string? Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article>? Articles { get; set; }
    }

    public class Article
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? UrlToImage { get; set; }
        public string? PublishedAt { get; set; }
        // Other relevant properties
        public string? Url { get; set; }
    }
}