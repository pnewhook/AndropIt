using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndropIt.Core
{
    public interface IPushClient
    {
        string SendText(string clipboardText);
    }
}
