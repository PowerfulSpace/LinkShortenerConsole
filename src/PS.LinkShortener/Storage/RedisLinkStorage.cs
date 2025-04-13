
namespace PS.LinkShortener.Storage
{
    public class RedisLinkStorage : ILinkStorage
    {
        public Dictionary<string, string> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Save(string shortUrl, string longUrl)
        {
            throw new NotImplementedException();
        }

        public bool TryGet(string shortUrl, out string longUrl)
        {
            throw new NotImplementedException();
        }
    }
}
