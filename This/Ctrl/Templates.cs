using System.Windows;
using System.Windows.Media;

namespace This
{





    public static class Templates
    {



        public static SolidColorBrush GetColorByNumber(double color)
        {
            SolidColorBrush col = new SolidColorBrush();

            if (color < 3) col.Color = Colors.Green;
            else if (color >= 3 && color < 4) col.Color = Colors.Cyan;
            else if (color >= 4 && color < 5) col.Color = Colors.Yellow;
            else if (color >= 5 && color < 6) col.Color = Colors.Orange;
            else if (color >= 6) col.Color = Colors.Red;
            return col;
        }
        public static string GetColorNameByNumber(double color)
        {
            return GetColorByNumber(color).Color.ToString();
        }


        static string basicHeader = "<DataTemplate xmlns='http://schemas.microsoft.com/client/2007' xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' xmlns:local='clr-namespace:Tiler'>" +
           "<StackPanel Margin='0,0,0,17'>";
      
        
        // '12,-6,12,0'


        static string basicFooter = "</StackPanel></DataTemplate>";
     

        static string textblock0 = "<TextBlock Text='{Binding Lines[0]}' TextWrapping='Wrap' Style='{StaticResource PhoneTextStyle}'/>";

        static string textblock1 = "<TextBlock Text='{Binding Lines[0]}' Foreground='{Binding Color}' ToolTipService.ToolTip='Tap for more details' TextWrapping='Wrap' Style='{StaticResource PhoneTextLargeStyle}'/>";
        static string textblock2 = "<TextBlock Text='{Binding Lines[3]}' Foreground='Magenta' TextWrapping='Wrap' Style='{StaticResource PhoneTextSubtleStyle}'/>";

        static string textblock3 = "<TextBlock Text='{Binding Lines[1]}' TextAlignment='Right' FontWeight='Bold' TextWrapping='Wrap'  Margin='0,0,0,0' Style='{StaticResource PhoneTextNormalStyle}'/>";
        static string textblock4 = "<TextBlock Text='{Binding Lines[2]}' Visibility='{Binding Visible}' TextAlignment='Right' TextWrapping='Wrap'  Margin='0,0,0,0' Style='{StaticResource PhoneTextSmallStyle}'/>";
        //IsChecked='{Binding IsChecked}' 
        static string radiobtn = "<CheckBox Margin='0,0,0,0'   Background='Black'/>";
    //  Checked='This.Templates.checkBox_Checked'      
        static string menuBtn = "<TextBlock Text='{Binding Lines[2]}' TextAlignment='Right' FontWeight='Bold' TextWrapping='Wrap'  Margin='0,0,0,0' Style='{StaticResource PhoneTextSubtleStyle}'/>";


 //      static string checkedMethod = "checkBox_Checked";

        public static string Textblock1
        {
            get { return textblock1; }

        }
        public static string BasicHeader
        {
            get { return basicHeader; }

        }
        public static string BasicFooter
        {
            get { return basicFooter; }

        }
        public static string Textblock2
        {
            get { return textblock2; }

        }
        public static string Textblock3
        {
            get { return textblock3; }

        }
        public static string Textblock4
        {
            get { return textblock4; }

        }
     //   public static void checkBox_Checked(object sender, RoutedEventArgs e)
      //  {

      //  }

        public static DataTemplate GetTemplateItem()
        {

            /*
             DataTemplate  d = new  DataTemplate ();
           
          
            StackPanel p = new StackPanel();
         

            p.Margin = new Thickness(0,0,0,17);
            TextBlock b1 = new TextBlock();
           
            b1.Text ="{Binding LineThree}";
            b1.TextWrapping = TextWrapping.Wrap;
            Style XLstyle = this.Resources["PhoneTextExtraLargeStyle"] as Style;
            b1.Style=XLstyle;

            TextBlock b2 = new TextBlock();
           
            b2.Text ="{Binding LineTwo}";
            b2.TextWrapping = TextWrapping.Wrap;
            b2.Margin = new Thickness(12,-6,12,0);
            Style Substyle = this.Resources["PhoneTextSubtleStyle"] as Style;
            b2.Style=Substyle;

            p.Children.Add(b1);
            p.Children.Add(b2);
            */





            string full = basicHeader + radiobtn+ textblock1 + textblock2 + textblock3 + basicFooter;

            return GetTemplateFrom(full);

        }

        public static DataTemplate GetTemplateFrom(string full)
        {
            object myDt = null;
            try
            {

                myDt = System.Windows.Markup.XamlReader.Load(full);

            }
            catch (System.Windows.Markup.XamlParseException ex)
            {

            }

            return (myDt as DataTemplate);
        }

        public static DataTemplate GetTemplateSubItem()
        {



            string full = basicHeader + radiobtn + textblock1 + textblock2 + textblock3 + textblock4 + basicFooter;

            return GetTemplateFrom(full);




        }



    }

}
