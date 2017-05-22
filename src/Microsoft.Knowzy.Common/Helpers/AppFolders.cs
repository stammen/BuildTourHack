using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Knowzy.Common.Helpers
{
    public class AppFolders
    {
        public static string Current
        {
            get
            {
                string path = null;
                if (ExecutionMode.IsRunningAsUwp())
                {
                    path = GetSafeAppxFolder();
                }
                return path;
            }
        }

        public static string Local
        {
            get
            {
                string path = null;
                if (ExecutionMode.IsRunningAsUwp())
                {
                    path = GetSafeLocalFolder();
                }
                return path;
            }
        }

        internal static string GetSafeAppxFolder()
        {
            try
            {
                return Windows.ApplicationModel.Package.Current.InstalledLocation.Path;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        internal static string GetSafeLocalFolder()
        {
            try
            {
                return Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }
    }
}