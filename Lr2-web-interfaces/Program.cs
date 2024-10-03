using Lr2_web_interfaces;
using System.Text;
using Newtonsoft.Json;
using ICSharpCode.SharpZipLib.Zip;

Console.OutputEncoding = UTF8Encoding.UTF8;
Program.Main(args);

partial class Program
{
    static async Task Main(string[] args)
    {
        // FluentValidation (Валідація)
        var user1 = new User { Name = "", Age = 19 };
        var validator = new UserValidator();
        var results = validator.Validate(user1);
        Console.WriteLine("FluentValidation");
        if (!results.IsValid)
        {
            foreach (var failure in results.Errors)
            {
                Console.WriteLine($"Помилка : {failure.ErrorMessage}");
            }
        }
        else
        {
            Console.WriteLine("Валідація успішна");
        }

        // Newtonsoft.Json (Робота з JSON)
        var user2 = new { Name = "John", Age = 30 };

        // Серіалізація об'єкта в JSON
        string json = JsonConvert.SerializeObject(user2);
        Console.WriteLine("\nICNewtonsoft.Json");
        Console.WriteLine($"Серіалізований JSON: {json}");

        // Десеріалізація JSON в об'єкт
        var deserializedUser = JsonConvert.DeserializeObject<dynamic>(json);
        Console.WriteLine($"Ім'я: {deserializedUser.Name}, Вік: {deserializedUser.Age}");


        // ICSharpCode.SharpZipLib (Архівація файлів)
        string fileToZip = "example.txt";
        string zipFileName = "archive.zip";

        using (FileStream fs = File.Create(zipFileName))
        using (ZipOutputStream zipStream = new ZipOutputStream(fs))
        {
            var entry = new ZipEntry(Path.GetFileName(fileToZip))
            {
                IsUnicodeText = true
            };
            zipStream.PutNextEntry(entry);

            using (FileStream fileStream = File.OpenRead(fileToZip))
            {
                fileStream.CopyTo(zipStream);
            }
        }
        Console.WriteLine("\nICSharpCode.SharpZipLib");
        Console.WriteLine($"Файл {fileToZip} заархівовано");


        // AngleSharp (Парсинг HTML)
        var scraper = new WebScraper();

        string url = "https://www.example.com";
        var pageTitle = scraper.GetPageTitleAsync(url).GetAwaiter().GetResult();

        Console.WriteLine("\nAngleSharp:");
        Console.WriteLine($"Назва сторінки: {pageTitle}");

        // Quartz (Планувальник)
        Console.WriteLine("\nQuartz: ");
        await TimeJob.QuartzExample();
    }
}