using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    [AttributeUsage(AttributeTargets.Class)]
    public class FeatureCodeAttribute : Attribute
    {
        public FeatureCodeAttribute()
        {
        }

        public FeatureCodeAttribute(string code, string title)
        {
            Code = code;
            Title = title;
        }

        public string Code { get; set; }

        public string Title { get; set; }

        public static string GetCode(Type featureType)
        {
            FeatureCodeAttribute fcode = Attribute.GetCustomAttribute(featureType, typeof(FeatureCodeAttribute)) as FeatureCodeAttribute;

            if (fcode == null)
                return string.Empty;
            else
                return fcode.Code;
        }
    }
}
