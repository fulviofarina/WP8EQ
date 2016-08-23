using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Tiler
{
    public partial class Settings : PhoneApplicationPage
    {

        object pa = null;

        public Settings()
        {
            InitializeComponent();

            this.filterCtrl.FilterCallback = updateFilter;

           //  pa = pano1.DataContext;


        }


        private void updateFilter(IAsyncResult ar)
        {



        }

      

    

        private void pano_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            PanoramaItem item = (PanoramaItem)pano.SelectedItem;

            if (item.Equals(pano1))
            {

              //  pano1.DataContext = pa;
             //   item.Header = "toaster";
              
                this.filterCtrl.Setting = EQ.Main.ToToastPkg.Setting;
                pano2.Content = null;
                pano1.Content = grid;
             
            }
            else
            {

            //    item.Content = pano1.Content;
              //  pano2.DataContext = pa;
               // item.Header = "toaster";
                pano1.Content = null;
                pano2.Content = grid;
                this.filterCtrl.Setting = EQ.Main.ToTilePkg.Setting;
         
            }

           

        }

    }
}