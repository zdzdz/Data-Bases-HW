namespace _01.RSSFeedParser.VideoComponents
{
    using System;

    using Newtonsoft.Json;

    public class Link
    {
        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
