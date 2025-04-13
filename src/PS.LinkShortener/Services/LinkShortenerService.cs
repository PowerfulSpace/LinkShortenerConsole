using PS.LinkShortener.Storage.Interfaces;

namespace PS.LinkShortener.Services
{
    public class LinkShortenerService
    {
        private readonly ILinkStorage _storage;
        const string BaseUrl = "http://sho.com/";

        public LinkShortenerService(ILinkStorage storage)
        {
            _storage = storage;
        }

        public string Shorten(string longUrl)
        {
            string code;
            string shortLink;

            do
            {
                code = GenerateShortCode();
                shortLink = $"{BaseUrl}{code}";
            }
            while (_storage.TryGet(shortLink, out _));

            _storage.Save(shortLink, longUrl);

            return shortLink;
        }

        public string? Expand(string shortUrl)
        {
            _storage.TryGet(shortUrl, out var longUrl);
            return longUrl;
        }

        public string GenerateShortCode()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 8);
        }
    }
}
