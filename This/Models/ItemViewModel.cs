using System;
using System.ComponentModel;

namespace This.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string _id;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string ID
        {
            get
            {
                return _id;
            }
            set
            {
             //   if (value != _id)
                {
                    _id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }
        private string _name;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
            //    if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }
        private string selectedcolor = "Black";
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string SelectedColor
        {
            get
            {
                return selectedcolor;
            }
            set
            {
             //   if (value != selectedcolor)
                {
                    selectedcolor = value;
                    NotifyPropertyChanged("SelectedColor");
                }
            }
        }
        private object mapLayer;
        private object selectedmapLayer;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public object MapLayer
        {
            get
            {
                return mapLayer;
            }
            set
            {
              //  if (value != mapLayer)
                {
                    mapLayer = value;
                    NotifyPropertyChanged("MapLayer");
                }
            }
        }
        private bool? isChecked = false;
        public bool? IsChecked
        {
            get
            {
                return isChecked;
            }
            set
            {
               // if (value != isChecked)
                {
                    isChecked = value;
                    NotifyPropertyChanged("IsChecked");
                }
            }
        }
        public object SelectedMapLayer
        {
            get
            {
                return selectedmapLayer;
            }
            set
            {
            //    if (value != selectedmapLayer)
                {
                    selectedmapLayer = value;
                    NotifyPropertyChanged("SelectedMapLayer");
                }
            }
        }


      
      
        /*

        private System.Windows.Media.Color color = System.Windows.Media.Colors.White;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public  System.Windows.Media.Color Color 
        {
            get
            {
                return color;
            }
            set
            {
                if (value != color)
                {
                    color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }
        */
        private string color = "White";
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string Color
        {
            get
            {
                return color;
            }
            set
            {
             //   if (value != color)
                {
                    color = value;
                    NotifyPropertyChanged("Color");
                }
            }
        }
        private string visible = "Collapsed";
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string Visible 
        {
            get
            {
                return visible;
            }
            set
            {
             //   if (value != visible)
                {
                    visible = value;
                    NotifyPropertyChanged("Visible");
                }
            }
        }
        private object[] toLaunch = new object[4];
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public object[] ToLaunch
        {
            get
            { 
                return toLaunch;
            }
            set
            {
            //    if (value != toLaunch)
                {
                    toLaunch = value;
                    NotifyPropertyChanged("ToLaunch");
                }
            }
        }


        private string[] lines;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public string[] Lines
        {
            get
            {
                if (lines == null)
                {
                    lines = new string[6];
                }
                return lines;
            }
            set
            {
            //    if (value != lines)
                {
                    lines = value;
                    NotifyPropertyChanged("Lines");
                }
            }
        }
        private Uri _bkgImgUri = null;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public Uri BkgImgUri
        {
            get
            {
                return _bkgImgUri;
            }
            set
            {
             //   if (value != _bkgImgUri)
                {
                    _bkgImgUri = value;
                    NotifyPropertyChanged("BkgImgUri");
                }
            }
        }
        private Uri _backbkgImgUri=null;
        /// <summary>
        /// Sample ViewModel property; this property is used to identify the object.
        /// </summary>
        /// <returns></returns>
        public Uri BackBkgImgUri
        {
            get
            {
                return _backbkgImgUri;
            }
            set
            {
              //  if (value != _backbkgImgUri)
                {
                    _backbkgImgUri = value;
                    NotifyPropertyChanged("BackBkgImgUri");
                }
            }
        }
      
        private object tag;
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding.
        /// </summary>
        /// <returns></returns>
        public object Tag
        {
            get
            {
                return tag;
            }
            set
            {
             //   if (value != tag)
                {
                    tag = value;
                    NotifyPropertyChanged("Tag");
                }
            }
        }


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