using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Security
{
    public interface IAceEditor
    {
        void ShowEditor();

        string PermissionString { get; set; }
    }
}
