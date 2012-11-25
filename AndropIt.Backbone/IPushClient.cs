using System;
using System.Collections.Generic;
using System.Linq;

namespace AndropIt.Backbone
{
    public interface IPushClient
    {
        string SendText(string clipboardText);
        string SendFile(string path);
    }
}
