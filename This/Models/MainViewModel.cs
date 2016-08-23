using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;


namespace This.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {


        public  void FillModel<T>(IList<object> ls, object converter )
        {
            this.IsDataLoaded = false;
            //  Func<T, int, ItemViewModel> vmconverter = Fx.VMConverter as Func<T, int, ItemViewModel>;
            Func<T, int, ItemViewModel> vmconverter = converter as Func<T,int,ItemViewModel>;
             IList<ItemViewModel> vms = ls.OfType<T>().Select(vmconverter).ToList();
      //       this.Items.Clear();
             IList<ItemViewModel> oldies = this.Items.OfType<ItemViewModel>().ToList();

             if (oldies != null && oldies.Count!=0)
             {
                 foreach (ItemViewModel v in vms)
                 {

                     ItemViewModel old = oldies.FirstOrDefault(o => o.Name.CompareTo(v.Name)==0);
                     if (old != null)
                     {
                       //  v.SelectedMapLayer = old.SelectedMapLayer;
                     //    v.MapLayer = old.MapLayer;
                         v.IsChecked = old.IsChecked;
                     }

                 }
             }
             this.Items.Clear();
             foreach (ItemViewModel v in vms) this.Items.Add(v);
               
         //    this.Items = vms as ObservableCollection<ItemViewModel>; //.Add(v);
             oldies = null;
            this.IsDataLoaded = true;
        }


      
        private string _ItemKind;
        public string ItemKind
        {
            get
            {
                return _ItemKind;
            }
            set
            {
                if (value != _ItemKind)
                {
                    _ItemKind = value;
                    NotifyPropertyChanged("ItemKind");
                }
            }
        }
        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (value != _description)
                {
                    _description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }



        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        /// <summary>
        /// Sample property that returns a localized string
        /// </summary>

        private bool dataLoaded = false;
        public bool IsDataLoaded
        {
            get { return dataLoaded; } 
         set{ dataLoaded =value ; }
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
     
       

       
       

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}