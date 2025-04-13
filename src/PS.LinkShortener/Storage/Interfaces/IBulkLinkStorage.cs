namespace PS.LinkShortener.Storage.Interfaces
{
    public interface IBulkLinkStorage : ILinkStorage
    {
        Dictionary<string, string> GetAll();
    }
}
