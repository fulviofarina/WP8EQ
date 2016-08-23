using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
namespace This
{
    /// <summary>
    /// DISPATCHER SHELL
    /// </summary>
    public class DShell
    {
        public DShell(AsyncCallback Callback, string TagName)
        {

            callback = Callback;
            tagName = TagName;
        }
        private string tagName = string.Empty;
        public  void doSimple(IAsyncResult Ar)
        {
            ar = Ar;
            System.Threading.Thread thread = new System.Threading.Thread(doWorkSimple);
            thread.Name = "Thread" + tagName;
            thread.IsBackground = true;
            thread.Start(100);

        }
        private AsyncCallback callback = null;
        private  IAsyncResult ar = null;

        private  void doWorkSimple(object sleepMillisecond)
        {

            // System.Threading.Thread.Sleep((int)sleepMillisecond);
            ThreadStart threadStart = null;
            threadStart = delegate()
            {

                if (callback != null) callback(ar);

            };

            dispatcher.BeginInvoke(threadStart);

        }
    

        public static System.Windows.Threading.Dispatcher dispatcher = null;
      



    }
}
