using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;


using System;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;


namespace Tiler
{
    public partial class Menu : UserControl
    {

     //   private IList<string> filterField;
      //  private IList<object> filterValue;

        private int count = 0;

        public int Current
        {

            get { return count-1;}

        }

        private IList<object> buttons;
        private IList<IAsyncResult> tasks;

        public Menu()
        {
            InitializeComponent();

           




        }
       
      




      

      
      
       




        public void SetMenu(IList<string> arrayOfNames, IList<Icon> arrayOfIcons,  IList<EventHandler> callbacks, IList<object> callbacksArgs)
        {


      
              // buttons = new List<object>();


    
          



        }

    


       private AsyncCallback callback;

       public AsyncCallback FilterCallback
       {
           set
           {
           //    bool wasnull = (callback==null);
               callback = value;
          
           }

       }

        /*
       private AsyncCallback sqrcallback;

        //for square button click call back
       public AsyncCallback SqrCallback
       {
           set
           {
               sqrcallback = value;



           }

       }
        */

    

     
       

      

      
    }
}
