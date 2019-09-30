using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Models;

namespace HNWrapper
{
    public class HNWrapperService : IHNWrapperService
    {
        private readonly string baseUrl;
        private readonly IHNConverterService hnConverterService;

        private const string TOPURL = "topstories.json";
        private const string NEWURL = "newstories.json";
        private const string BESTURL = "beststories.json";
        private const string ITEMURL = "item/{0}.json";

        public HNWrapperService(string baseUrl)
        {
            this.baseUrl = baseUrl;
            this.hnConverterService = new HNConverterService();
        }

        public Items GetBestStories()
        {
            var items = GetItems(BESTURL);
            return items;
        }

        public Items GetNewStories()
        {
            var items = GetItems(NEWURL);
            return items;
        }

        public Items GetTopStories()
        {
            var items = GetItems(TOPURL);
            return items;
        }

        public Item GetItemById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException(nameof(id));
            }

            string url = string.Concat(baseUrl, string.Format(ITEMURL, id));
            string response = GetRequest(url);

            return hnConverterService.MapToItem(response);
        }

        private Items GetItems(string urlParam)
        {
            List<int> ids = GetIds(urlParam);

            if (ids == null)
            {
                throw new ArgumentNullException(nameof(ids));
            }

            var items = new Items();

            foreach(var id in ids.GetRange(0, 10))
            {
                items.Add(GetItemById(id));
            }

            return items;
        }

        private List<int> GetIds(string urlParam)
        {
            string url = baseUrl + urlParam;
            string response = GetRequest(url);

            return hnConverterService.MapToIds(response);
        }

        private string GetRequest(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
