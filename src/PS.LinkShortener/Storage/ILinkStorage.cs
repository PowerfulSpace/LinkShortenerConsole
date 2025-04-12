namespace PS.LinkShortener.Storage
{
    public interface ILinkStorage
    {
        void Save(string shortUrl, string longUrl);
        bool TryGet(string shortUrl, out string longUrl);
        Dictionary<string, string> GetAll();
    }
}
