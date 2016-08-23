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
    public partial class MenuBtn : UserControl
    {
        public MenuBtn(IAsyncResult ar, bool isNames,  AsyncCallback cb, string content)
        {
            
            InitializeComponent();
            if (isNames) A.Content = content;
            else
            {
                A.Content = string.Empty;
                //OTHER FOR ICONS
            }
            callback = cb;
              
            A.Click+=a_Click;
            A.Tag = ar;


        }

        private AsyncCallback callback;


        private  void a_Click(object sender, RoutedEventArgs e)
        {

            Control btn = sender as Control;

            if (callback != null)
            {
                callback.Invoke(btn.Tag as IAsyncResult); //call back method to show the filtered list
            }
        }

    }
}
