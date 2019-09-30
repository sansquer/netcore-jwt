using System;
using System.Collections.Generic;

namespace Models
{
    public class Items: List<Item>
    {

    }
    public class Item
    {
        public string Author { get; set; }
        public int Score { get; set; }
        public DateTime Date { get; set; }
        public ItemType Type { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
    }
}
