using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoenixLogger.Utils
{
    internal class Binding
    {
        public string Event { get; set; }
        public Action<dynamic, string> Callback { get; set; }
    }
}
