using Microsoft.Phone.Scheduler;
using System;
using This;
using This.Net;
using This.Tools;
using This.ViewModels;

using System.Threading;

namespace EQ
{


    public static partial class Main
    {
        private static MainViewModel model = null;
        /// <summary>
        /// A static ViewModel used by the views to bind against.
        /// </summary>
        /// <returns>The MainViewModel object.</returns>
        public static MainViewModel ViewModel
        {
            get
            {
                // Delay creation of the view model until necessary
             //   if (model == null)
                 //   model = new MainViewModel();

                return model;
            }
        }

        private static Pkg pkg=null;

        public static Pkg Pkg
        {

            get { return pkg; }

        }

        public static Exception Exception
        {

            get { return exc; }

        }
  
         private static Exception exc = null;

       static string ReadError = "Read File Error";
       static string NetError = "Network problem";
       static string ConversionError = "Conversion to List of Items gave error";
       static string Itemkind = "Earthquakes";

    //   int counter = 0;

       private static Pkg toTilepkg = null;

       public static Pkg ToTilePkg
       {

           get { return toTilepkg; }

       }
       private static Pkg toToastpkg = null;

       public static Pkg ToToastPkg
       {

           get { return toToastpkg; }

       }

       public static AsyncCallback reportMethod;

       public static void TimerElapsed(Object stateInfo)
       {

           if (dMsg == null) dMsg = new DShell(reportMethod, "Msg");

           int timeAux = time;

           if (timer != null )
           {
               timer.Dispose();
               timer = null;


          
             
               Start(null, null );

           }
           else
           {

               if (stateInfo == null)
               {
                  // if (counter == 0)
                  
                       dMsg.doSimple(APkg.Create("Starting..."));

                       timeAux = timeFirst;
                 
                  // else timeAux = time;
               }
               else
               {

                 
                   Type stateType = stateInfo.GetType();
                   if (stateType.Equals(typeof(Exception)))
                   {
                       timeAux = timeRetry;
                       dMsg.doSimple(APkg.Create(((Exception)stateInfo).Message));

                       exc = null;
                   }
               }
             
               timer = new System.Threading.Timer(TimerElapsed,stateInfo, timeAux, time);
                

           }


       }

       private static int time = 300 * 1000;
       private static int timeRetry = 3 * 1000;
       private static int timeFirst = 500;
       private static System.Threading.Timer timer = null;


      

    //   private static AsyncCallback conexError;
     //  public static AsyncCallback ConexErrorCallback
     //  {

          // set { conexError = value; }
     //  }


       private static async void callBack(IAsyncResult ar)
        {

            dMsg.doSimple(APkg.Create("Fetching..."));

            string rssContent = await readOrWriteFile(ar);


            dMsg.doSimple(APkg.Create("Converting..."));

            convertToList(rssContent);

            dMsg.doSimple(APkg.Create("Updating..."));



         //   DShell dUI = new DShell(doUI, "UI");
       //     dUI.doSimple(ar);

            DShell dUI = new DShell(doUI, "UI");
            dUI.doSimple(ar);
      //     doUI(ar);

            if (ar != null)
            {
                DShell dPostUI = new DShell(doPostUI, "PostUI");

                dPostUI.doSimple(ar);
            }

          

        }

        /// <summary>
        /// If the info was found, write to file. Otherwise, read from file
        /// </summary>
        /// <param name="ar">null if force read</param>
        /// <returns>file content in xml</returns>
       private static async System.Threading.Tasks.Task<string> readOrWriteFile(IAsyncResult ar)
       {
           string rssContent = null;
           exc = null;
           try
           {

             

               if (ar != null)
               {
                   //if found info, write it
                   rssContent = ar.AsyncState as string;

                   if (rssContent != null && !rssContent.Equals(string.Empty))
                   {
                       await This.IO.WriteDataToFileAsync("data.txt", rssContent);


                   }
               }
               else
               {

                   rssContent = await This.IO.ReadFileContentsAsync("data.txt");

                   Tools.Throw(rssContent, ReadError);

               }

              
           }
           catch (Exception ex)
           {
               exc = ex;

           }
           return rssContent;
       }

       private static void convertToList(string rssContent)
       {
           exc = null;
           try
           {
             
               Tools.Throw(rssContent, NetError);

               pkg.ConvertToList(rssContent);

               Tools.Throw(pkg.List, ConversionError);


           }
           catch (Exception ex)
           {
               exc = ex;

           }
       }

       public static string basePageUri = "/Pages/ExplorerPage.xaml?";


     public static void Stop()
     {

         if (ViewModel == null) return;
         ItemViewModel a = ViewModel.Items[0];
         if (a == null) return;

            Notif.NotifData nf = new Notif.NotifData(basePageUri, "Main");
            nf.SetValues(a,  99);
            Notif.MakeSecondTile(nf);
         
     }

        public static MainViewModel Filter(ISetting setting)
        {



            if (setting != null) pkg.Setting = setting;

            try
            {
                ///FILTER
                pkg.Filter();

                if (model == null) model = new MainViewModel();
          //      else model.Items.Clear();
                model.ItemKind = Itemkind;

                pkg.FillModel(ref model);



                /// THE ONES TO TILE
                toTilepkg.List = pkg.List;
                ToTilePkg.Filter();
                /// THE ONES TO TILE
                toToastpkg.List = pkg.List;
                ToToastPkg.Filter();




            }
            catch (Exception ex)
            {
                exc = ex;

            }

            return model;
           
        }



        public static AsyncCallback doUI;
        public static AsyncCallback doPostUI;
        public static AsyncCallback doAfterLocation;


        static DShell dGeo = null;

        public static  async void Start(ScheduledTask task, AsyncCallback CallBack)
        {

            if (dGeo == null)
            {
              dGeo = new DShell(doAfterLocation, "Geo");

                Geodesy.CallBack = dGeo.doSimple;

             
                Geodesy.Start();

                dMsg.doSimple(APkg.Create("GPS Ok"));

            }

        
            string fileSettings = "Settings.txt";
            string fileLast = "Last.txt";
            Uri uri = EQ.BaseUri;
           
            if (pkg == null)
            {
               
                pkg = new Pkg(fileLast);
                pkg.BaseUri = uri;
                pkg.Setting = new EQSetting(fileSettings);

              


                await pkg.Setting.ReadOrWrite(true);
                await pkg.ReadOrWriteLastEvent(true);
//
            }

            dMsg.doSimple(APkg.Create("Loading settings"));

            if (toTilepkg == null)
            {
             
                fileSettings = "TileSettings.txt";
                fileLast = "TileLast.txt";
                toTilepkg = new Pkg(fileLast);
                toTilepkg.BaseUri = uri;
                toTilepkg.Setting = new EQSetting(fileSettings);
                await toTilepkg.Setting.ReadOrWrite(true);
                await toTilepkg.ReadOrWriteLastEvent(true);
                //
            }
            if (toToastpkg == null)
            {

                fileSettings = "ToastSettings.txt";
                fileLast = "ToastLast.txt";
                toToastpkg = new Pkg(fileLast);
                toToastpkg.BaseUri = uri;
                toToastpkg.Setting = new EQSetting(fileSettings);
                await toToastpkg.Setting.ReadOrWrite(true);
                await toToastpkg.ReadOrWriteLastEvent(true);
                //
            }

        //    AsyncPkg ap = new AsyncPkg(string.Empty);

            dMsg.doSimple(APkg.Create("Settings Ok"));

         
           callBack(null);

          
          //find in the web
           WebQuest wb = new WebQuest(callBack, pkg.BaseUri); //start webrequest

            dMsg.doSimple(APkg.Create("Connecting..."));

            //to call after finding the web
            //   AsyncCallback postprocessingCallBack = ; //second method

           
        }




        /// <summary>
        /// NOT USED
        /// </summary>
        /*
        public static void NotifyAll()
        {

            try
            {

                ///NOTIFY
                IList<ItemViewModel> views = model.Items;
                string baseNavUri = "/Pages/ExplorerPage.xaml";
                //  Notif.Notify(baseNavUri, m, model.Items.Count);
                // IList<ItemViewModel> itms = model.Items;
                Notif.Notify(baseNavUri, ref views);


                ///PRUEBAAAAAAAAAAAAAAA
                // Notif.NotifTileSched d = new Notif.NotifTileSched();

            }
            catch (Exception ex)
            {
                exc = ex;
            }
        }


         */


        private static DShell dMsg;
         

    }




          





}
