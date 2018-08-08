using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCloud.Core
{
    public class WebParserService
    {
        private readonly List<string> artsAndPreps = new List<string>()
            { "about","all","also","are","above","across","after","against","among","around",
                "and", "any", "before", "behind","below","beside","between",
                "down","during","except","for","inside","into","near","off","out","over","from",
                "through","toward","under","with","into","some", "the","his","this","that", "was"};

        public WebParserService() { }

        public List<Word> Parse(string websiteURL)
        {
            try
            {
                List<Word> wcData = new List<Word>();

                if (string.IsNullOrEmpty(websiteURL))
                    return null;

                var websiteRawText = FetchWebsiteBodyRawText(websiteURL);

                wcData = Regex.Matches(websiteRawText.ToLower(), "\\w+")
                .OfType<Match>()
                .Where(m => (m.Value.Length > 2 && !artsAndPreps.Contains(m.Value)))
                .GroupBy(m => m.Value)
                .Select(m => new Word { WordText = m.Key, Count = m.Count() })
                .OrderByDescending(wc => wc.Count)
                .Take(100)
                .ToList();

                return wcData;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string FetchWebsiteBodyRawText(string websiteURL)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();

                var htmlDoc = web.Load(websiteURL);
                var node = htmlDoc.DocumentNode.SelectSingleNode("//body");

                return StripHtmlTags(node.InnerHtml);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private string StripHtmlTags(string source)
        {
            try
            {
                var jsRemoved = Regex.Replace(source, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);

                var htmlRemoved = Regex.Replace(jsRemoved, "<.*?>|&.*?;", string.Empty);

                return htmlRemoved.Replace("\n", "");
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
