using PS.LinkShortener.Services;
using PS.LinkShortener.Storage;



string filePath = "Data/links.json";
var storage = new JsonLinkStorage(filePath);
var service = new LinkShortenerService(storage);


while (true)
{
    Console.Clear();
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


Console.WriteLine("\nНажмите любую клавишу для продолжения...");
Console.ReadKey();

