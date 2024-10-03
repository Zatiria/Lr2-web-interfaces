using AngleSharp.Io;
using AngleSharp;

namespace Lr2_web_interfaces
{
    internal class WebScraper
    {
        private readonly IBrowsingContext _context;

        public WebScraper()
        {
            var config = Configuration.Default.WithDefaultLoader(new LoaderOptions { IsResourceLoadingEnabled = false });
            _context = BrowsingContext.New(config);
        }

        public async Task<string> GetPageTitleAsync(string url)
        {
            try
            {
                var document = await _context.OpenAsync(url);
                var titleElement = document.QuerySelector("title");

                if (titleElement != null)
                {
                    return titleElement.TextContent;
                }
                else
                {
                    return "Заголовок не знайдено.";
                }
            }
            catch (Exception ex)
            {
                return $"Помилка під час завантаження сторінки: {ex.Message}";
            }
        }
    }
}