using System;



namespace This
{
 
    /// <summary>
    /// AYSNC Package
    /// </summary>
    public class APkg : IAsyncResult
    {
        public static APkg Create(Object state)
        {
           return new APkg(state);

        }
        public static APkg Empty
        {
            get
            {
                return new APkg(0);
            }
        }
      

        public APkg(Object state)
        {
            asyncState = state;

        }
        private Object asyncState;
        public Object AsyncState { get { return asyncState; }
            set { asyncState = value; }
        }
        public System.Threading.WaitHandle AsyncWaitHandle { get { return null; } }
        private bool isCompleted = false;
        private bool completedSynch = false;

        public bool CompletedSynchronously { get { return completedSynch; } }
        public bool IsCompleted { get { return isCompleted; } }


    }

 
}
