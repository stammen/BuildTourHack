using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Knowzy.Common.Helpers
{
    public class ExecutionMode
    {
        public static bool IsRunningAsUwp()
        {
            DesktopBridge.Helpers helpers = new DesktopBridge.Helpers();
            return helpers.IsRunningAsUwp();
        }
    }
}
