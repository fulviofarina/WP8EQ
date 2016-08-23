using System;
using System.IO;
using System.Net;
using System.Text;


namespace This.Net
{
   
    public class WebQuest : WebClient
    {
        private String rssContent;
        private Exception exc;

        private void webQuest_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {


            try
            {


                Stream stream = e.Result;
                WebClient wcRSSFeeds = sender as WebClient;
                Encoding encoding = wcRSSFeeds.Encoding;
                if (encoding != null)
                {
                    encoding = Encoding.GetEncoding(encoding.WebName);
                }
                else
                {
                    encoding = Encoding.UTF8;  // set to standard if none given 
                }
                StreamReader srRSSFeeds = new StreamReader(stream, encoding, false);
                rssContent = srRSSFeeds.ReadToEnd();
                srRSSFeeds.Close();
                srRSSFeeds.DiscardBufferedData();
                srRSSFeeds.Dispose();

            }

            catch (Exception ex)
            {
                exc = ex;
            }
            finally
            {

                if (callback != null)
                {
                    IAsyncResult ar = new APkg(rssContent);
                    callback.Invoke(ar);

                }
            }
        }

        private AsyncCallback callback;
      
      
        /// <summary>
        /// Makes a web request  to the given uri and returns to the provided method
        /// </summary>
        /// <param name="callB">provided method</param>
        /// <param name="uir"></param>
        public WebQuest(AsyncCallback callB, Uri uir)
            :base()
        {

            callback = callB;

            this.OpenReadCompleted+=webQuest_OpenReadCompleted;
          
             OpenReadAsync(uir); // feedURL is a string eg, "http://blah.com"
      
      

        }

     

    }


}
