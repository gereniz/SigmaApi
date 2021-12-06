using System;
using System.Collections.Generic;

namespace SigmaAPI
{
    public class Item
    {
        public string Success { get; set; }
  
        public long Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public List<Dictionary<string,string>> Rates { get; set; }
    }
}
