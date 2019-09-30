using System;
using System.Collections.Generic;
using Models;
using Newtonsoft.Json;

namespace HNWrapper
{
    public class HNConverterService : IHNConverterService
    {
        public HNConverterService()
        {

        }

        public List<int> MapToIds(string content)
        {
            return new List<int>(JsonConvert.DeserializeObject<int[]>(content));
        }

        public Item MapToItem(string content)
        {
            var itemHN = JsonConvert.DeserializeObject<ItemHN>(content);

            return new Item
            {
                Author = itemHN.By,
                Content = itemHN.Text,
                Date = new DateTime(1970, 1, 1, 0, 0, 0).AddSeconds(itemHN.Time),
                Score = itemHN.Score,
                Title = itemHN.Title,
                Type = (ItemType)Enum.Parse(typeof(ItemType), itemHN.Type),
                Url = itemHN.Url
            };
        }
    }
}
