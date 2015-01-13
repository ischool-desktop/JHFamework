using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    public interface IExtraProcesser
    {
        ExtraInformation[] Process(object instance);
    }
}
