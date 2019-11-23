using System;
using System.Collections.Generic;
using System.Text;

namespace Bronsysteem
{
    public class SubscribeEvent<T>
    {
        public string id { get; set; }
        public string source { get; set; }
        public string type { get; set; }
        public string specversion { get; set; }
        public string datacontenttype { get; set; }
        public T data { get; set; }
    }
}
