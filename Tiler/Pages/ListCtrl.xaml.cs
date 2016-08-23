using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace Tiler
{
    public partial class ListCtrl : UserControl
    {

        private List<childItem> FindVisualChild<childItem>(DependencyObject obj)
where childItem : DependencyObject
        {

            List<DependencyObject> items = new List<DependencyObject>();

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);

                if (child != null && child is childItem)
                {
                    items.Add(child);
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child).FirstOrDefault();
                    if (childOfChild != null)
                    {
                        items.Add(childOfChild);

                    }
                }
            }
            return items.OfType<childItem>().ToList();
        }
        /*
        private List<childItem> FindVisualChild<childItem>(DependencyObject[] obj)
where childItem : DependencyObject
        {

            List<childItem> items = new List<childItem>();

            foreach (DependencyObject a in obj)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(a); i++)
                {
                    childItem child = (childItem)VisualTreeHelper.GetChild(a, i);

                    if (child != null && child is childItem)
                    {
                        items.Add(child);
                    }
                    else
                    {
                        childItem childOfChild = FindVisualChild<childItem>(child).FirstOrDefault();
                        if (childOfChild != null)
                        {
                            items.Add(childOfChild);

                        }
                    }
                }

            }
            return items;
        }
        */

      

        public ListCtrl()
        {
            InitializeComponent();
         
       //     template = Resources["grid1"];
            
           //      UIElement element =   template.LoadContent() as UIElement;

          //  DataTemplate dataTemp = this.ListSelector.ItemTemplate;


      

            

       //     CheckBox chk = FindVisualChild<CheckBox>(grid).FirstOrDefault();
      //      string a = string.Empty;
         // this.ListSelector.h

         //   this.ListSelector.Resources
        }

     

        private SelectionChangedEventHandler _selectionChanged = null;

        public SelectionChangedEventHandler SelectionChanged
        {

            get { return _selectionChanged; }
            set
            {
             
             
               if (value==null) this.ListSelector.SelectionChanged -= _selectionChanged;
               else   this.ListSelector.SelectionChanged += value;
               _selectionChanged = value;
            }
        }
      
        private EventHandler<System.Windows.Input.GestureEventArgs> _selectorHold =null;

        public EventHandler<System.Windows.Input.GestureEventArgs> SelectorHold
        {

            get { return _selectorHold; }

            set {

            
                if (value == null) this.ListSelector.Hold -= _selectorHold;
                else this.ListSelector.Hold += value;
                _selectorHold = value;
           
               
            
            }
        }


        private RoutedEventHandler _checkBoxChecked =null;

        public RoutedEventHandler CheckBoxChanged
        {

           get { return _checkBoxChecked; }
            set {
             //   DataTemplate template = this.ListSelector.ItemTemplate;
             //   CheckBox chkBox = null;
               
           //     DependencyObject element = template.LoadContent();
             //   UIElement element = this.ListSelector.ItemTemplate.LoadContent() as UIElement;

                _checkBoxChecked = value;
            
                //    Grid grid = ((StackPanel)element).Children.First() as Grid;
         //       this.ListSelector.ItemTemplate.LoadContent().
              //  Grid grid = FindVisualChild<Grid>(element).FirstOrDefault();
             //   chkBox = FindVisualChild<CheckBox>(grid).FirstOrDefault();
               //     chkBox = (CheckBox)grid.FindName("chkBox");
             //   chkBox = (CheckBox)this.FindName("chkBox");
            //        chkBox.IsEnabled = true;
                
             //   chkBox.Checked += value;
            //    chkBox.Unchecked += value;
                
             }
        }

      
     
        public System.Collections.IList Source
        {

            get
            {

                return this.ListSelector.ItemsSource;
            }
            set
            {

                this.ListSelector.ItemsSource = value;
            }

        }

        private void chkBox_Checked(object sender, RoutedEventArgs e)
        {
            _checkBoxChecked(sender, e);
               
        }
     

    }
}
