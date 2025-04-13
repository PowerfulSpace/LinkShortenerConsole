using PS.LinkShortener.Services.Interfaces;

namespace PS.LinkShortener.Services
{
    public class PathService : IPathService
    {
        public string GetDataFilePath(string fileName)
        {
            string basePath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\.."));
            return Path.Combine(basePath, "Data", fileName);
        }
    }
}
