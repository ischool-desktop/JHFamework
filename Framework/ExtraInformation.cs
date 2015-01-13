using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public class ExtraInformation
    {
        public ExtraInformation(string name, string data)
        {
            Name = name;
            Data = data;
        }

        public string Name { get; private set; }

        public string Data { get; private set; }
    }
}
