using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HNWrapper.Tests
{
    public class HNWrapperServiceTestContext
    {
        public List<int> GetIds()
        {
            return Enumerable.Range(0, 20).ToList();
        }

        public Item GetStoryItem()
        {
            return new Item
            {
                Author = "Tester",
                Content = "this is the test content",
                Date = DateTime.Now,
                Score = 0,
                Title = "Test",
                Type = ItemType.story,
                Url = ""
            };
        }
    }
}
