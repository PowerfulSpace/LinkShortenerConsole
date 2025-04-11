
Dictionary<string, string> data = new Dictionary<string, string>();

var longLink = "https://www.google.com/search?q=%D0%BA%D1%83%D0%BF%D0%B8%D1%82%D1%8C+%D1%84%D0%BE%D1%82%D0%BE%D0%B0%D0%BF%D0%BF%D0%B0%D1%80%D0%B0%D1%82&sca_esv=9a6888ca637267bc&sxsrf=AHTn8zoP6UVlVGsVT72c3g-NWPuCGX0HOQ%3A1744406669320&ei=jYj5Z-mhE8mD9u8PwYSFiAU&ved=0ahUKEwipnPme9dCMAxXJgf0HHUFCAVEQ4dUDCBA&uact=5&oq=%D0%BA%D1%83%D0%BF%D0%B8%D1%82%D1%8C+%D1%84%D0%BE%D1%82%D0%BE%D0%B0%D0%BF%D0%BF%D0%B0%D1%80%D0%B0%D1%82&gs_lp=Egxnd3Mtd2l6LXNlcnAiI9C60YPQv9C40YLRjCDRhNC-0YLQvtCw0L_Qv9Cw0YDQsNGCMgoQIxiABBgnGIoFMgUQABiABDIFEAAYgAQyBRAAGIAEMgUQABiABDIFEAAYgAQyBRAAGIAEMgUQABiABDIKEAAYgAQYQxiKBTIFEAAYgARI2Q1Q2gRY9QtwAXgBkAEAmAGHAaAB-QWqAQMwLja4AQPIAQD4AQGYAgegAp4GwgIKEAAYsAMY1gQYR8ICDRAAGIAEGLADGEMYigWYAwCIBgGQBgqSBwMxLjagB8Q3sgcDMC42uAeZBg&sclient=gws-wiz-serp";
var shortLink = GenerateShorterLink(longLink);




Console.ReadLine();


string GenerateShorterLink(string longLink)
{
    string code = GenerateShortCode();
    string shortLink = $"http://sho.com/{code}";

    data.Add(shortLink, longLink);

    return shortLink;
}
string GenerateShortCode()
{
    string code;
    do
    {
        code = Guid.NewGuid().ToString("N").Substring(0, 8);
    }
    while (data.ContainsKey(code));

    return code;
}