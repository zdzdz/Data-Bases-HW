namespace _01.RSSFeedParser.VideoComponents
{
    using System;

    using Newtonsoft.Json;

    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("yt:channelId")]
        public string Id { get; set; }
    }
}
