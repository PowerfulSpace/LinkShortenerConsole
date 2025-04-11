namespace PS.LinkShortener.Services
{
    public class LinkShortenerService
    {
        private readonly Dictionary<string, string> data = new Dictionary<string, string>();
        const string BaseUrl = "http://sho.com/";

        public string Shorten(string longUrl)
        {
            string code = GenerateShortCode();
            string shortLink = $"{BaseUrl}{code}";

            data.Add(shortLink, longUrl);

            return shortLink;
        }

        public string? Expand(string shortUrl)
        {
            data.TryGetValue(shortUrl, out var shortLink);
            return shortLink;
        }

        public string GenerateShortCode()
        {
            string code;
            do
            {
                code = Guid.NewGuid().ToString("N").Substring(0, 8);
            }
            while (data.ContainsKey($"{BaseUrl}{code}"));

            return code;
        }
    }
}
