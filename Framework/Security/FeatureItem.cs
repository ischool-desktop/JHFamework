using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Framework.Security
{
    public abstract class FeatureItem
    {
        public FeatureItem()
        {
            Code = string.Empty;
            Editor = null;

            StackTrace st = new StackTrace();
            StackFrame sf = st.GetFrame(0);
            InstallAssembly = sf.GetMethod().ReflectedType.Assembly.CodeBase;
        }

        public string Title { get; set; }

        public string Code { get; set; }

        public IAceEditor Editor { get; set; }

        public string InstallAssembly { get; private set; }
    }
}
