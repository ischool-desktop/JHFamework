using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework
{
    public enum ValueStatus { Clean, Dirty }

    public class ChangeEventArgs : EventArgs
    {
        public ChangeEventArgs(ValueStatus status)
        {
            Status = status;
        }

        public ValueStatus Status { get; private set; }
    }
}
