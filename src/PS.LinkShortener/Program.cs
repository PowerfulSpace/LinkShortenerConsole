using PS.LinkShortener.Services;
using PS.LinkShortener.Services.Interfaces;
using PS.LinkShortener.Storage;



IPathService pathService = new PathService();
string filePath = pathService.GetDataFilePath("links.json");


//var storage = new JsonLinkStorage(filePath);
//var service = new LinkShortenerService(storage);

string redisConnection = "localhost:6379";
var storage = new RedisLinkStorage(redisConnection);
var service = new LinkShortenerService(storage);

while (true)
{
    //Console.Clear();
    Console.WriteLine();
    Console.WriteLine("==== Link Shortener ====");
    Console.WriteLine("1. Сократить ссылку");
    Console.WriteLine("2. Развернуть короткую ссылку");
    Console.WriteLine("0. Выйти");
    Console.Write("Выбор: ");

    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Console.Write("Введите длинную ссылку: ");
            var longUrl = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(longUrl))
            {
                Console.WriteLine("Ссылка не может быть пустой.");
                break;
            }

            var shortUrl = service.Shorten(longUrl);
            Console.WriteLine($"Короткая ссылка: {shortUrl}");
            break;

        case "2":
            Console.Write("Введите короткую ссылку: ");
            var inputShort = Console.ReadLine();
            var original = service.Expand(inputShort);

            if (original == null)
            {
                Console.WriteLine("Ссылка не найдена.");
            }
            else
            {
                Console.WriteLine($"Оригинальная ссылка: {original}");
            }
            break;

        case "0":
            return;

        default:
            Console.WriteLine("Некорректный выбор.");
            break;
    }

}