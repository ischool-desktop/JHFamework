using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    public class @Int
    {
        static public int Parse(string Value)
        {
            int i;

            if (int.TryParse(Value, out i))
                return i;
            else
                return 0;
        }

        static public int? ParseAllowNull(string Value)
        {
            int i;

            if (int.TryParse(Value, out i))
                return i;
            else
                return null;
        }

        static public string GetString(int Value)
        {
            return Value.ToString();
        }

        static public string GetString(int? Value)
        {
            if (Value == null)
                return "";
            else
                return Value.ToString();
        }
    }
}