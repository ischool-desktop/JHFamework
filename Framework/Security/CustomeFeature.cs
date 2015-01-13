using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    public class CustomeFeature : FeatureItem
    {
        public CustomeFeature(string code, string title, IAceEditor editor)
        {
            Code = code;
            Title = title;
            Editor = editor;
        }
    }
}
