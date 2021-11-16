using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsAndCollections.Classes
{
    class Furniture: FormatBase
    {
        public string Type { get; set; }
        public int Count { get; set; }

        public Furniture(string type, int count)
        {
            Type = type;
            Count = count;
        }

        public override string ToString()
        {
            return string.Format("Type is {0}, count is {1}", Type, Count);
        }
    }
}
