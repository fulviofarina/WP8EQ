using EQ;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using This;
using This.Ctrl;
using This.Tools;
using This.ViewModels;
using System.Threading;


namespace Tiler
{

    /// <summary>
    /// APP BAR
    /// </summary>
    public partial class ExplorerPage 
    {
        private  IApplicationBar bar = null;

      
        private void makeAppBar(int mode)
        {



            

            bar.IsMenuEnabled = true;
            bar.IsVisible = true;
            bar.Buttons.Clear();

            arrayOfNames = defaultItemNames(mode);
            createMethods(true, mode);
            createBarArgs();
            createButonIcons(iconpath, mode);

            createMethods(false, mode);
        

            AppBar.AddToAppBar(ref  bar, arrayOfNames, clickmethods, argus, appBarImgUris);
         
            AppBar.AddToAppBarMenu(ref  bar, defaultMenuItemNames(), clickMMs, argus, appBarImgUris);

        }
        private string iconpath = "Assets/Dark/";

       

        private void createMethods(bool ForAButton, int mode)
        {
            if (ForAButton)
            {
                clickmethods = new List<EventHandler>();
                //    uris.Add(new Uri(eq.Uri.ToString() + "#dyfi"));

               
             
                if (mode == 0)
                {

                    clickmethods.Add(switchList);
                    //   uris.Add(eq.Uri);
                  
                    clickmethods.Add(openSaved);
                 
                }
                else if (mode == 1)
                {
                    clickmethods.Add(pinItem);
                    //   uris.Add(eq.Uri);
                    clickmethods.Add(showInfo);

                }
                else if (mode >= 2)
                {
                    clickmethods.Add(pinItem);
                    //   uris.Add(eq.Uri);
                    clickmethods.Add(saveItems);

                }
                 //   uris.Add(eq.Uri);

                clickmethods.Add(showDetails);

                clickmethods.Add(showFilter);
                //   uris.Add(eq.Uri);
             

            }
            else
            {

              


                clickMMs = new List<EventHandler>();
                //    uris.Add(new Uri(eq.Uri.ToString() + "#dyfi"));

                if (mode == 0)
                {
                    clickMMs.Add(showSettings);
                    //   uris.Add(eq.Uri);
                    clickMMs.Add(showSettings);
                    //   uris.Add(eq.Uri);
                }
                else if (mode == 1)
                {
                    clickMMs.Add(showSettings);
                    //   uris.Add(eq.Uri);
                    clickMMs.Add(showSettings);
                }
                clickMMs.Add(showSettings);
                //   uris.Add(item);
                clickMMs.Add(showSettings);
         

            }
        }
        IList<object> argus = null;

        private void createBarArgs()
        {
            argus = new List<object>();
            argus.Add(1);
            argus.Add(1);
            argus.Add(1);
            argus.Add(1); //whathever
           
        }

        private void createButonIcons(string iconpath, int mode)
        {

            appBarImgUris = new List<Uri>();

            if (mode == 0)
            {

               
               appBarImgUris.Add(new Uri(iconpath + "switch.png", UriKind.Relative));

               appBarImgUris.Add(new Uri(iconpath + "favs.png", UriKind.Relative));
              

                      //
            }
            else if (mode == 1)
            {

             
                appBarImgUris.Add(new Uri(iconpath + "pin.png", UriKind.Relative));
                appBarImgUris.Add(new Uri(iconpath + "globe.png", UriKind.Relative));
             

            }
            else if (mode >= 2)
            {

             
                appBarImgUris.Add(new Uri(iconpath + "pin.png", UriKind.Relative));
                appBarImgUris.Add(new Uri(iconpath + "save.png", UriKind.Relative));
              

            }
            appBarImgUris.Add(new Uri(iconpath + "sum.png", UriKind.Relative));
            appBarImgUris.Add(new Uri(iconpath + "search.refine.png", UriKind.Relative));

        }
        private IList<string> defaultItemNames(int mode)
        {

            IList<string> defaultNames = new List<string>();
            if (mode == 0)
            {
                defaultNames.Add("Switch");

                defaultNames.Add("Open");
            
            }
            else if (mode == 1)
            {
                defaultNames.Add("Pin");
                defaultNames.Add("Globe");

            }
            else if (mode >=2)
            {
                defaultNames.Add("Pin");
                defaultNames.Add("Save");

            }    
            defaultNames.Add("Details");
            defaultNames.Add("Filter");
            //    defaultNames.Add("Fil");

            return defaultNames;
        }
        private IList<string> defaultMenuItemNames()
        {

            IList<string> defaultNames = new List<string>();

            defaultNames.Add("Settings");
            defaultNames.Add("Donate");
            defaultNames.Add("Tutorial");
            defaultNames.Add("Privacy Terms");
            //    defaultNames.Add("Fil");

            return defaultNames;
        }
        List<EventHandler> clickMMs = null;



        private IList<string> arrayOfNames;

        private  IList<EventHandler> clickmethods = null;
        private  IList<Uri> appBarImgUris = null;
    

        private void showFilter(object sender, System.EventArgs e)
        {

            //  ItemViewModel vmodel = (sender as AppBar.Btn).Tag as ItemViewModel;
            //    This.AsyncPkg pkg = new This.AsyncPkg(vmodel);
            // if (ar != null)
            {
                //  ItemViewModel vmodel = ar.AsyncState as ItemViewModel;
                //  if (vmodel != null)
                {
                    //this.MainLongListSelector.ScrollTo(vmodel);
                }
            }

            if (bar.IsVisible)
            {
                bar.IsVisible = false;
                this.filtControl.Visibility = System.Windows.Visibility.Visible;
                this.filtControl.FilterCallback = this.doUI;
               
            }
            else this.filtControl.FilterCallback = null;
            //   else ApplicationBar.IsVisible = true;



        }
      

        private void pinItem(object sender, System.EventArgs e)
        {



        //    AppBar.Btn btn = sender as AppBar.Btn;
          //  ItemViewModel i = btn.Tag as ItemViewModel;

            Notif.NotifData nf = new Notif.NotifData(Main.basePageUri, current.Name);
            nf.SetValues(current, null);
            Notif.MakeSecondTile(nf);



            //  this.MainLongListSelector.ItemTemplate = This.Templates.GetTemplateSubItem();
            //   setTemplates(ref MainLongListSelector);


        }
        private void saveItems(object sender, System.EventArgs e)
        {






            //  this.MainLongListSelector.ItemTemplate = This.Templates.GetTemplateSubItem();
            //   setTemplates(ref MainLongListSelector);


        }

        private void openSaved(object sender, System.EventArgs e)
        {






            //  this.MainLongListSelector.ItemTemplate = This.Templates.GetTemplateSubItem();
            //   setTemplates(ref MainLongListSelector);


        }
    
      
        
        private void showDetails(object sender, System.EventArgs e)
        {


            if (Main.ViewModel == null) return;

            ItemViewModel first = Main.ViewModel.Items.FirstOrDefault();
            if (first == null) return;

            bool isVis = first.Visible.Contains("Visible");

            foreach (ItemViewModel v in Main.ViewModel.Items)
            { 
                if (isVis)      v.Visible = "Collapsed";
                else v.Visible = "Visible";
            }
      

            //  this.MainLongListSelector.ItemTemplate = This.Templates.GetTemplateSubItem();
            //   setTemplates(ref MainLongListSelector);


        }
    
        
        private void refreshList(object sender, System.EventArgs e)
        {

            this.mainMapa.Layers.Clear();
            Main.TimerElapsed(null);



        }

        private  void showSettings(object sender, System.EventArgs e)
        {




            NavigationService.Navigate(new Uri("/Pages/Settings.xaml", UriKind.Relative));
       

       //     await Windows.System.Launcher.LaunchUriAsync(new Uri((string)current.ToLaunch[0], UriKind.Absolute));

            // await uriLaunch(uri.ElementAt(index));

        }


        private async void showInfo(object sender, System.EventArgs e)
        {


            if (current == null) return;

           
            //   int index = buttons.IndexOf(btn);
            AppBar.Btn btn = (sender as AppBar.Btn);

          
            await Windows.System.Launcher.LaunchUriAsync(new Uri( (string)current.ToLaunch[0], UriKind.Absolute));

            // await uriLaunch(uri.ElementAt(index));

        }


      
      

    //   public void checkBox_Checked(object sender, RoutedEventArgs e)
      //  {

      //  }


    }

   


    public partial class ExplorerPage : PhoneApplicationPage
    {
        public ExplorerPage()
        {

            InitializeComponent();

            Initiate();


            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }




        
        protected void Initiate()
        {




            // Set the data context of the LongListSelector control to the sample data
          //  DataContext = Main.ViewModel;


            //Register the events for this Long List Selector
            //   lctrl = new This.Ctrl.ListSel(ref this.MainLongListSelector);
       //     this.MainLongListSelector.ItemTemplate = This.Templates.GetTemplateSubItem();

            DShell.dispatcher = Dispatcher;
            Main.doPostUI = this.doPostUI;
            Main.doUI = this.doUI;
            Main.doAfterLocation = this.doAfterLocation;
            //    this.filtControl.FilterCallback = this.doUIRefresh;
            //this shit assigns the delegate that will re-load the ItemList of EQs after being filtered

    
                bar = new ApplicationBar();
                makeAppBar(0);

                ApplicationBar = bar;

            IList<UIElement> hideables = new List<UIElement>();
            hideables.Add(this.mainMapa);
            hideables.Add(this.LCtrl);
            hideables.Add(this.filtControl);
            hideables.Add(this.updateBox);

            hider = new UIHider(ref hideables, ref this.msgBox);

            this.filtControl.Visibility = System.Windows.Visibility.Collapsed;

            Main.reportMethod = this.doMsg;

            this.mainMapa.CartographicMode = MapCartographicMode.Road;
         

            Main.TimerElapsed(null);


        }

     



        private bool trackMe = false;
       private MapLayer currentPos = null;
       private void doAfterLocation(IAsyncResult ar)
        {
            ICollection<MapLayer> maplayers = this.mainMapa.Layers;
            GeoCoordinate cur = new GeoCoordinate(Geodesy.CurrentLatitude, Geodesy.CurrentLongitude);
            MapLayer here = Geodesy.GetMapLayer(cur, 100);
            if (currentPos != null && !trackMe) maplayers.Remove(currentPos);
            maplayers.Add(here);
            currentPos = here;
        }



        private void doPostUI(IAsyncResult ar)
        {



            if (counter == 0)
            {
                Main.Pkg.BaseUri = new Uri("http://earthquake.usgs.gov/earthquakes/feed/atom/all/hour");
            }
            Main.Pkg.CheckIfNew();

            counter++;

       //     Main.Hider.Visibility(true);

          //  this.msgBox.Text = "Loading settings...";

         

            Main.TimerElapsed(0);

        }

        //  private System.Threading.Timer timerShow = null;
      
        private  UIHider hider = null;
    
        private void doMsg(IAsyncResult ar)
        {

            hider.Report((string)ar.AsyncState);
          //  hider.Report("Starting in " + (timeAux * 0.001).ToString() + "s");
           
        }

        private void doUI(IAsyncResult ar)
        {


            //    if (model.Items.Count
            this.LCtrl.CheckBoxChanged = null;
            this.LCtrl.SelectionChanged -= selectionChanged;
            this.LCtrl.Hold -= selectorHold;
            ISetting setdefault = Main.Pkg.Setting;
            if (this.filtControl.Setting == null)
            {
                this.filtControl.Setting = setdefault;
            }

               Main.Filter(this.filtControl.Setting);

               this.updateBox.Text = Main.Pkg.Updated.ToString();

        
                MainViewModel model = Main.ViewModel;

             
       
                IList<ItemViewModel> views = null;
            if (model != null)
            {

                views = model.Items;
                string typeOfElements = model.ItemKind;

                this.LCtrl.DataContext = model;
                this.LCtrl.Source = (IList)views;

                hider.Report("Displaying " + views.Count + " " + typeOfElements);

            }

         

                this.LCtrl.CheckBoxChanged = this.checkBoxChecked;

                this.LCtrl.SelectionChanged += selectionChanged;
                this.LCtrl.Hold += selectorHold;
      

             //   if (ar == null) return; // so it does not map twice...


                if (views == null) return;

           
                mapPainting(ref views);


              

      


        }

        private void mapPainting(ref IList<ItemViewModel> views)
        {


            this.mainMapa.Layers.Clear();

         
            foreach (ItemViewModel v in views) Fx.GetMapLayers(v);


            IList<ItemViewModel> selected = views.Where(o => (bool)o.IsChecked).ToList();
            int count = selected.Count();

            if (count >= 1) mapEQs(ref selected, true);
            mapEQs(ref views, false);


            doAfterLocation(null);
        
       

        }

        private void mapEQs(ref IList<ItemViewModel> views, bool selected)
        {
            ICollection<MapLayer> maplayers = this.mainMapa.Layers;

            Func<ItemViewModel, object> selector = null;
           


            if (selected) selector = x => x.SelectedMapLayer;
            else selector =  x => x.MapLayer;

            IEnumerable<MapLayer> layers = views.Select(selector).OfType<MapLayer>().Where(o=> o!=null).ToList();
            if (layers != null)
            {
                // maplayers.Clear();
                foreach (MapLayer m in layers)
                {
                    if (!maplayers.Contains(m))
                    {
                        maplayers.Add(m);

                    }
                }
            }
          //  this.mainMapa.OnApplyTemplate();
         //  Microsoft.Maps.MapControl.WPF

           
        }

  

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
  

          counter = 0;

          
         //  activateTimers(null);
           // Main.Initialize(); //start loading

    
        }

        int counter = 0;
   
   

      
        private ItemViewModel current = null;
      
        private void selectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector sel = sender as LongListSelector;

    
           
          //  current = sel.SelectedItem as ItemViewModel;
            if (sel.SelectedItem == null) return;
            ItemViewModel old = current;
            if (old != null) old.SelectedColor = "Magenta";
       
            current = sel.SelectedItem as ItemViewModel;
            current.SelectedColor = "Yellow";
          
         //   ICollection<MapLayer> maplayers = this.mainMapa.Layers;

            IList<ItemViewModel> items = this.LCtrl.Source as IList<ItemViewModel>;

            //  current = (ItemViewModel)MainLongListSelector.SelectedItem;
            if (currentBox != null)
            {
                bool chk = (bool)currentBox.IsChecked;
                currentBox = null;
                current.IsChecked = chk;
            }

          //  IList<ItemViewModel> items = this.LCtrl.Source as IList<ItemViewModel>;
            mapPainting(ref items);
         
          //  bool dorest = true;
            /*
                        if (item == current) //so it can show details again
                        {
               
                            if (item.SelectedMapLayer != null)
                            {
                                maplayers.Remove(item.SelectedMapLayer as MapLayer);
                                item.SelectedMapLayer = null;
                            }
                          //  current.Visible = "Collapsed";
                         //   current = null;
                          //  dorest = false;
               
          
                
                        }
                        else
                        {
                        //    if (current != null) current.IsChecked = false;
                            current = item;
                        //    current.IsChecked = true;
                      //      item.Visible = "Visible";
                            if (item.SelectedMapLayer == null)
                            {
                                item.SelectedMapLayer = This.Geodesy.GetMapLayer(geoCoord, 0);
                                maplayers.Add(item.SelectedMapLayer as MapLayer);
                            }
                        }
                        */


        

          

            IEnumerable<ItemViewModel> selected = items.OfType<ItemViewModel>().Where(o => (bool)o.IsChecked);
            int count =selected.Count();
            this.makeAppBar(count);

            int zoom = 3;
         
         //   if (count > 1)
           // {
           //     IEnumerable<EQ.EQ> selectedEQs = items.OfType<ItemViewModel>().Select(o => o.Tag).OfType<EQ.EQ>();
               // lat = selectedEQs.Average(o => o.Latitude);
             //   lon = selectedEQs.Average(o => o.Longitude);
              //  zoom = 3;
             //   alt = 100;
          //  }
           // else
          //  {

               // EQ.EQ eq = current.Tag as EQ.EQ;
              

           // }

            EQ.EQ eq = current.Tag as EQ.EQ;



            this.mainMapa.SetView(eq.GeoCoord, zoom, Microsoft.Phone.Maps.Controls.MapAnimationKind.Parabolic);

           
      //      sel.SelectedItem = null;
       
        //    this.MainLongListSelector.ItemTemplate = This.Templates.GetTemplateSubItem();
          
            /*
            current.MapLayer = Fx.MapLayer(eq);
            current.SelectedMapLayer = This.Geodesy.GetMapLayer(eq.GeoCoord, 0);

              MapLayer l = current.SelectedMapLayer as MapLayer;

                if (!(bool)current.IsChecked) //so it can show details again
                {

                  //  if (current.SelectedMapLayer != null)
                    {

                       
                   //     if (maplayers.Contains(l))
                        {
                            maplayers.Remove(l);
                            current.SelectedMapLayer = null;
                        }
                            //  current.SelectedMapLayer = null;
                    }
                    //  current.Visible = "Collapsed";
                    //   current = null;
                    //  dorest = false;


                }
                else
                {
                    //    if (current != null) current.IsChecked = false;
                    //  current = item;
                    //    current.IsChecked = true;
                    //      item.Visible = "Visible";
                  //  if (current.SelectedMapLayer == null)
                    {
                       
                        if (!maplayers.Contains(l))
                        {
                            current.SelectedMapLayer = This.Geodesy.GetMapLayer(eq.GeoCoord, 0);

                            maplayers.Add((MapLayer)current.SelectedMapLayer);
                        }
                    }
                }

                this.mainMapa.InvalidateArrange();

           //     string prueba = "yo";
                //   currentBox = null;

             * 
             * 
             */


          

                LCtrl.SelectionChanged=null;
            sel.SelectedItem = null; //important to keep to reset
            LCtrl.SelectionChanged = selectionChanged;
         

            if (!bar.IsVisible)
            {
                bar.IsVisible = true;
                this.filtControl.Visibility = System.Windows.Visibility.Collapsed;

            }


           

          //  makeAppBar(0);
          //  IList<object> argus = item.ToLaunch;
          //  AppBar.AddToAppBar(ref bar, arrayOfNames, clickmethods, argus, appBarImgUris);



        //    if (dorest)
         //   {
                //  this.mainMapa.SetView(new LocationRectangle(geoCoord,10,10), MapAnimationKind.Parabolic);
               
               
          //  }
      
        }


      
/*
        private void setAppBarButons(int count)
        {
            AppBar.Btn btn = bar.Buttons.OfType<AppBar.Btn>().ElementAt(1);
            //    btn.IconUri = new Uri(iconpath + "pin.png", UriKind.Relative);
             AppBar.Btn pinbtn =  bar.Buttons.OfType<AppBar.Btn>().ElementAt(0);
            if (count == 1)
            {
                //usar estrellita
                btn.IconUri = new Uri(iconpath + "globe.png", UriKind.Relative);
           
                btn.Click -= refreshList;
                btn.Click += showInfo;

                pinbtn.IconUri = new Uri(iconpath + "pin.png", UriKind.Relative);
                pinbtn.Click -= switchList;
                pinbtn.Click += pinItem;
             //   pinbtn.IsEnabled = true;
                //cambiar methodo tambien
            }
            else if (count == 0)
            {
                btn.IconUri = new Uri(iconpath + "refresh.png", UriKind.Relative);

                btn.Click -= showInfo;
                btn.Click += refreshList;
                pinbtn.Click -= switchList;
                    //   btn.Click -= pinItem;
                    //  btn.Click += saveItems;
                pinbtn.IconUri = new Uri(iconpath + "wallet.png", UriKind.Relative);
               // pinbtn.IsEnabled = false;
            }
            else
            {
                btn.IconUri = new Uri(iconpath + "save.png", UriKind.Relative);
                btn.Click -= showInfo;
                btn.Click += saveItems;
             //   pinbtn.Click -= switchList;
             //   pinbtn.Click += pinItem;
            //    pinbtn.IsEnabled = true;

            }
        }

        */
        private CheckBox currentBox = null;


        int btnCtr = 1;
  
        private void mainBtn_Click(object sender, RoutedEventArgs e)
        {

            switchList(sender, EventArgs.Empty);

        }

        private void switchList(object sender, System.EventArgs e)
        {
            if (btnCtr == 0)
            {
                this.filtControl.Setting = EQ.Main.Pkg.Setting;
            }
            else if (btnCtr == 1)
            {
                this.filtControl.Setting = EQ.Main.ToToastPkg.Setting;
            }
            else if (btnCtr == 2)
            {
                this.filtControl.Setting = EQ.Main.ToTilePkg.Setting;
            }
            doUI(null);

            btnCtr++;
            if (btnCtr > 2) btnCtr = 0;
        }



        private void PhoneApplicationPage_BackKeyPress(object sender, System.ComponentModel.CancelEventArgs e)
        {
            EQ.Main.Stop();
        }

        private void selectorHold(object sender, System.Windows.Input.GestureEventArgs e)
        {

            makeAppBar(1);
        }
        private void checkBoxChecked(object sender, RoutedEventArgs e)
        {

            //  LongListSelector sel = sender as LongListSelector;
            currentBox = e.OriginalSource as CheckBox;

           
           


        }
   
       
     

    }
}