using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    public class DetailItemFeature : FeatureItem
    {
        public DetailItemFeature(Type featureType)
        {
            FeatureCodeAttribute feature = Attribute.GetCustomAttribute(featureType, typeof(FeatureCodeAttribute)) as FeatureCodeAttribute;

            Code = feature.Code;
            Title = feature.Title;
        }

        public DetailItemFeature(string code, string title)
        {
            Code = code;
            Title = title;
        }
    }
}
