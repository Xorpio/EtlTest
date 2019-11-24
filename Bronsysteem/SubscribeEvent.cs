using System;
using System.Collections.Generic;
using System.Text;

namespace Bronsysteem.Events
{
    public class SubscribeEvent<T>
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        public string id { get; set; }
        public string source { get; set; }
        public string type { get; set; }
        public string specversion { get; set; }
        public string datacontenttype { get; set; }
        public T data { get; set; }
    }
}
