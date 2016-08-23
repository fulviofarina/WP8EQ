using Microsoft.Phone.Shell;
using System;
using System.Linq;
using System.Threading;
using This.ViewModels;


namespace This.Tools
{


       
            
    public static class Notif
    {

        private static Timer timer;
       

        /// <summary>
        /// NOT USED YET
        /// </summary>
        /*
        public class NotifTileSched : ShellTileSchedule
        {
            private bool tileScheduleRunning = false;


            public NotifTileSched()
                : base()
            {

              

            }
            public void  Setter()
            {

                Interval = UpdateInterval.EveryHour;
                Recurrence = UpdateRecurrence.Interval;
                RemoteImageUri = new Uri(@"http://www.weather.gov/forecasts/graphical/images/conus/MaxT1_conus.png");
                Start();
                tileScheduleRunning = true;

            }


        }

        */
        public class NotifData : StandardTileData
        {

/*
             public string tileTile = "Secondary Tile";
            public string backTitle = "Back Tile";
            public string backContent = "Back Content";
            public int count = 12;
            public string uriBkgImg = "Red.jpg";
            public string uriBackBkgImg = "Red.jpg";

            */
            public string baseNavUri = "/Pages/ExplorerPage.xaml?";
            public string navUri = "DefaultTitle=FromTile";


            public NotifData(string BaseNavUri, string NavUri)
                :base()
            {
               
                baseNavUri = BaseNavUri;
                navUri = NavUri;
            }

            public void SetValues(string TileTile, string backTitle, string backContent, Uri UriBkgImg, Uri UriBackBkgImg,  int? count)
            {
               
                Count = count;
                setBasicValues(TileTile, backTitle, backContent);
                setImgValues(UriBkgImg, UriBackBkgImg);
              
            }

            private void setBasicValues(string TileTile, string backTitle, string backContent)
            {
                BackTitle = backTitle;

                BackContent = backContent;
                Title = TileTile;
            }

            private void setImgValues(Uri UriBkgImg, Uri UriBackBkgImg)
            {
                if (UriBackBkgImg!=null) BackBackgroundImage = UriBackBkgImg;
                if (UriBkgImg != null) BackgroundImage = UriBkgImg;
            }
          

            public void SetValues(ItemViewModel view, int? count)
            {

                SetValues(string.Empty, view.Lines[4], view.Lines[1], view.BkgImgUri,view.BackBkgImgUri, count);
              
        
            }

        }

     
        private static int? count = 0;

        static string baseNavUri = null;
        
     
      
   

      public static ShellTile MakeSecondTile(NotifData totile)
        {
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(totile.navUri));

         
         
   

            // Create the tile if we didn't find it already exists.
            if (TileToFind == null)
            {
                // Create the tile object and set some initial properties for the tile.
                // The Count value of 12 will show the number 12 on the front of the Tile. Valid values are 1-99.
                // A Count value of 0 will indicate that the Count should not be displayed.

                // Create the tile and pin it to Start. This will cause a navigation to Start and a deactivation of our application.
                ShellTile.Create(new Uri(totile.baseNavUri + "?" + totile.navUri, UriKind.Relative), totile);
            }
            else
            {
              
                TileToFind.Update(totile);

            }
            return TileToFind;
        }



        public static void DeleteSecondTile(string navUri)
        {

            // Find the tile we want to delete.
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains(navUri));

            // If tile was found, then delete it.
            if (TileToFind != null)
            {
                TileToFind.Delete();
            }
        }

    }

}
