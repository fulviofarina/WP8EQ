using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;

namespace This.Ctrl
{

    public static class AppBar
    {

        public static void AddToAppBar(ref IApplicationBar bar, IList<string> arrayOfNames, IList<EventHandler> clickmethods,  IList<object> arrayOfArgs, IList<Uri> iconPaths)
        {
            IList<AppBar.Btn> btns = bar.Buttons.Cast<AppBar.Btn>().ToList();
            IList<AppBar.MenuItm> menus = bar.MenuItems.Cast<AppBar.MenuItm>().ToList();


            for (int i = 0; i < clickmethods.Count; i++)
            {

                object tag = null;
                if (arrayOfArgs != null) tag = arrayOfArgs.ElementAt(i);
                EventHandler cb = clickmethods.ElementAt(i);
            //    EventHandler cbm = clickMenuMethods.ElementAt(i);
                string content = arrayOfNames.ElementAt(i);

             

                Uri imgUri = iconPaths.ElementAt(i);

                AppBar.Btn b = btns.FirstOrDefault(x => x.ID == i) as AppBar.Btn;
                if (b == null)
                {
                    b = AppBar.MakeBtn(tag, cb, content, imgUri, i);

                    bar.Buttons.Add(b);
                }
                else b.Set(tag, cb, content, imgUri, i);

            


            }
        }
        public static void AddToAppBarMenu(ref IApplicationBar bar, IList<string> arrayOfNames, IList<EventHandler> clickmethods, IList<object> arrayOfArgs, IList<Uri> iconPaths)
        {


            for (int i = 0; i < clickmethods.Count; i++)
            {

                object tag = null;
                if (arrayOfArgs != null) tag = arrayOfArgs.ElementAt(i);
                EventHandler cb = clickmethods.ElementAt(i);
                //    EventHandler cbm = clickMenuMethods.ElementAt(i);
                string content = arrayOfNames.ElementAt(i);

           
                IList<AppBar.MenuItm> menus = bar.MenuItems.Cast<AppBar.MenuItm>().ToList();

                Uri imgUri = iconPaths.ElementAt(i);

      
                AppBar.MenuItm m = menus.FirstOrDefault(x => x.Text.CompareTo(content) == 0) as AppBar.MenuItm;
                if (m == null)
                {
                    m = AppBar.MakeMenuItm(tag, cb, content, imgUri, i);

                    bar.MenuItems.Add(m);
                }
                else m.Set(tag, cb, content, imgUri, i);


            }
        }



        public class Btn : ApplicationBarIconButton
        {


            public void Set(object tag, EventHandler cb, string content, Uri imgUri, int id)
            {

                Text = content;
                Click -= cb;
                Click += cb;
                Tag = tag;
                ID = id;
                if (tag == null) this.IsEnabled = false;

                // Create a new menu item with the localized string from AppResources.
                //   ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(content);
                //  ApplicationBar.MenuItems.Add(appBarMenuItem);
            }

            public Btn(Uri uri)
                : base(uri)
            {

            }
            public object Tag;
            public int ID;


        }
        public class MenuItm : ApplicationBarMenuItem
        {
            public MenuItm(string content)
                : base(content)
            {

            }
            public object Tag;
            public int ID;

            public void Set(object tag, EventHandler cb, string content, Uri imgUri, int id)
            {

                Text = content;
                Click -= cb;
                Click += cb;
                Tag = tag;
                ID = id;

                // Create a new menu item with the localized string from AppResources.
                //   ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(content);
                //  ApplicationBar.MenuItems.Add(appBarMenuItem);
            }



        }

        public static Btn MakeBtn(object tag, EventHandler cb, string content, Uri imgUri, int id)
        {
            AppBar.Btn appBarButton = new AppBar.Btn(imgUri);
           

            appBarButton.Set(tag, cb, content, imgUri,id);
        

            return appBarButton;
            // Create a new menu item with the localized string from AppResources.
         //   ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(content);
          //  ApplicationBar.MenuItems.Add(appBarMenuItem);
        }



        public static MenuItm MakeMenuItm(object tag, EventHandler cb, string content, Uri imgUri, int id)
        {
           
            // Create a new menu item with the localized string from AppResources.
            MenuItm appBarMenuItem = new MenuItm(content);
            appBarMenuItem.Set(tag, cb, content, imgUri,id);
         
        
            return appBarMenuItem;
           // ApplicationBar.MenuItems.Add(appBarMenuItem);
        }

      
    }

  }
