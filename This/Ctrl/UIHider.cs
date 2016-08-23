using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace This
{
    public class UIHider
    {
        /*
        public static  class NetMsg
        {

            public static string NotConnected = "Could not connect to network...";
            public static string Connecting = "Connecting to network...";

            public static string Connected = "Connected successfully...";
      

        }
       */
        private IList<UIElement> uis;
        private System.Windows.Controls.TextBlock msgUI ;
        public UIHider( ref IList<UIElement> UIHideableElements, ref TextBlock msgUIElement)
        {

            uis = UIHideableElements;
            msgUI =  msgUIElement;

        }

    
        public void Report(string ar)
        {
          
            msgUI.Text = ar.ToString();

        }
        public  void Visibility(bool visibility)
        {
            Visibility(visibility, string.Empty);
          
        }
        public void Visibility(bool visibility, string msg)
        {
            Visibility vis = System.Windows.Visibility.Collapsed;
            if (visibility) vis = System.Windows.Visibility.Visible;

            if (visibility == false)
            {
                msgUI.Text = (msg);

            }
            else msgUI.Text = (msg);

            foreach (UIElement ui in uis)
            {
                ui.Visibility = vis;
            }

        }

    }
}
