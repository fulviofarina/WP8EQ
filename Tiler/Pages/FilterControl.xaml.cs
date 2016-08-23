using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using This;

namespace Tiler
{
    public partial class FilterControl : UserControl
    {



        private const string A = "A";
        private const string D = "D";
        private const string C = "x";

        private  FontFamily FSegoe = new FontFamily(Segoe); //save
        private  FontFamily FWindings = new FontFamily(Windings); //save

        private SolidColorBrush transparent = new SolidColorBrush(Colors.Transparent);
        private SolidColorBrush black = new SolidColorBrush(Colors.Transparent);

        private const string save = "Save";
        private List<Border> borders = null;

        private string oldfieldbox = string.Empty;

        private const string Windings = "Wingdings";
        private const string Segoe = "Segoe UI";



        private void setFields(object value)
        {

            this.fieldBtn.Content = setting.TableName.ElementAt(setting.CurrIndex).ToString();
            this.valueBox.Text = value.ToString();

            this.oldfieldbox = this.fieldBtn.Content.ToString();
        }

        private void setAD()
        {

            if (!setting.Asc) this.Rbtn.Content = D;
            else this.Rbtn.Content = A;
        }


        private ISetting setting;
        public ISetting Setting
        {
            get { return setting; }
            set {
                
                
                setting = value;
              //  setting.CurrIndex = -1;
              
            
            }

        }

        private AsyncCallback callback;
        public AsyncCallback FilterCallback
        {

            get { return callback; }

            set
            {

                callback = value;

                if (callback!=null) fieldBtn_Click(null, null);
                //  

            }


        }
   
     
        public FilterControl( )
        {
            InitializeComponent();

          //  this.Rbtn.Content = "D";
         //   this.fieldBtn.Content = "";
         //   this.fieldBtn.Content = "";
            this.valueBox.TextChanged -= this.valueBox_TextChanged;
            this.valueBox.TextChanged += this.valueBox_TextChanged;
            this.Rbtn.Click -= this.Rbtn_Click;
            this.Rbtn.Click += this.Rbtn_Click;
            this.fieldBtn.Click -= fieldBtn_Click;
            this.fieldBtn.Click+=fieldBtn_Click;


         //   System.Collections.IList list = new List<string>();

            this.valueBox.InputScope = new System.Windows.Input.InputScope();
            System.Windows.Input.InputScopeName n = new System.Windows.Input.InputScopeName();
            n.NameValue = System.Windows.Input.InputScopeNameValue.Number;
            this.valueBox.InputScope.Names.Add(n);


            this.Rbtn.FontFamily = new System.Windows.Media.FontFamily(Segoe); //save

        //    this.fieldBtn.Tag = 0; //put first variable of setting
            //    filterField = FilterField; //assign filter Field Names
            //     filterValue = FilterValue; // assign filter Field values
            borders = new List<Border>();
            borders.Add(r1);
            borders.Add(r2);
            borders.Add(r3);

        }

    
        private void fieldBtn_Click(object sender, RoutedEventArgs e)
        {


                foreach (Border b in borders)
                {
                    b.Background = transparent;
                }
                    Border br = borders.ElementAt(setting.CurrIndex);
                    br.Background = black;


                if (setting.CurrIndex >= setting.TableName.Count - 1) setting.CurrIndex = 0;
                else setting.CurrIndex++;

                setAD();

                setFields(setting.Table.ElementAt(setting.CurrIndex));

        }
      
    
        private void valueBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox box = sender as TextBox;
            string text = box.Text.Trim();

          //  int index = (int)box.Tag;

      

            string o = setting.Table.ElementAt(setting.CurrIndex).ToString();

          

            if (text.Equals(string.Empty))
            {
                //input is empty
                this.fieldBtn.Content = oldfieldbox;
            }
            else if (!o.Equals(text))
            {

             //   this.fieldBtn.Content = save;
                this.maxmin.FontFamily = FWindings; //save
                this.maxmin.Tag = 0;


            }
            else
            {
                
                this.fieldBtn.Content = oldfieldbox;
            }
        }


        private void Rbtn_Click(object sender, RoutedEventArgs e)
        {
            string type = this.Rbtn.Content.ToString();
           
          
           bool toPut = false;
         

           if (type.Contains(C))
           {
               toPut = !toPut; //tweak asc,desc
               setAD();
               return;
           }
           else if (type.Contains(A))
           {
               // this.Rbtn.Content = D;
               setting.Asc = toPut;
               setAD();
           }
           else if (type.Contains(D))
           {
               // this.Rbtn.Content = A;
               setting.Asc = !toPut;
               setAD();

           }
         //  

           doACallBack();
        }

        private void doACallBack()
        {

            if (callback != null)
            {
                DShell ds = new DShell(callback, "UFiltered");
                ds.doSimple(APkg.Empty);

            }
        }
   
        private void valueBox_LostFocus(object sender, RoutedEventArgs e)
        {
             this.valueBox.TextChanged -= this.valueBox_TextChanged;
          
            string type = this.Rbtn.Content.ToString();
            object old = setting.Table.ElementAt(setting.CurrIndex);
            if (this.valueBox.Text.CompareTo(old.ToString()) != 0)
            {
                //    if (!type.Contains(C)) 
              
            if (!this.Rbtn.IsMouseOver) setFields(this.valueBox.Text); //cacel was not pressed, therefore SAVE
            else valueBox.Text = old.ToString();
     
            }
            else if (!this.Rbtn.IsMouseOver) setAD();
         
       //     setAD();
            
            this.maxmin.FontFamily = FSegoe; //save
            this.Rbtn.FontFamily = FSegoe;
            this.valueBox.TextChanged += this.valueBox_TextChanged;
        }

        private void valueBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Rbtn.Content = C;
            this.Rbtn.FontFamily = FWindings;

           
        }

        private async void maxmin_Click(object sender, RoutedEventArgs e)
        {
           // object cont = this.fieldBtn.Content;
        
            if (maxmin.Tag!=null)
            {

               
                List<object> set = new List<object>();
                for (int i = 0; i < setting.Table.Count; i++)
                {

                    if (setting.CurrIndex != i) set.Add(setting.Table.ElementAt(i));
                    else set.Add(this.valueBox.Text);

                }
                maxmin.Tag = null;

                setting.Table = set; //refreshes
               
                await setting.ReadOrWrite(false);
               
                Rbtn_Click(sender, e);

                doACallBack();

            }
        }

      
    }
}
