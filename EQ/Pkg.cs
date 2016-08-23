using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using This;
using This.Tools;
using This.ViewModels;

namespace EQ
{

    public class Pkg
    {


        private string lastFile = string.Empty;

        public Pkg(string LastFile)
        {

            lastFile = LastFile;


        }

       
        public Uri BaseUri
        {
            get { return baseUri; }
            set { baseUri = value; }
        }



        public IList<object> List
        {
            get { return eqs as IList<object>; }
            set { eqs = value; }
        }
        public IList<object> FilteredList
        {
            get { return eqsFiltered as IList<object>; }
            set { eqsFiltered = value; }
        }
        public ISetting Setting
        {
            get {

              
                return eqset; }
            set { eqset = value; }
        }

        private ISetting eqset = null;


        private Uri baseUri;
      

        private string basicIdentifier = "urn:";
        private int maxItemCountOnList = 10;
        private int indexToRemoveExcess = 4;

        private  DateTime lastUpdate;
        public  DateTime Updated
        {
            get
            {
                return lastUpdate;
            }
            //    set { lastUpdate = value; }

        }
     

        public void ConvertToList(string rssContent)
        {

            IList<string> list = Tools.TrimToList(ref rssContent);


            this.lastUpdate = Convert.ToDateTime(list.ElementAt(0));
            list = list.Skip(6).ToList();

            IList<IList<string>> listofItems = Tools.ConvertToListOfItems<string>(ref list, basicIdentifier, maxItemCountOnList, indexToRemoveExcess);

          

            IEnumerable<object> aux = Tools.ConvertToListOf<string, object>(ref listofItems, Fx.MainConverter);

            if (eqs == null) eqs = new List<object>();
            int oldCount = eqs.Count;

            aux = eqs.Union(aux, new EQComparer() ); //make union for the second loop where the source has changed

            eqs = aux.ToList();

            if (eqs.Count != oldCount)/// DO SOMETHING HERE
            {

            }

            list = null;
            listofItems = null;
            aux = null;






           
        }



        private IList<object> eqs = null;
        private IList<object> eqsFiltered = null;



        private string lastEventID = string.Empty;



        public async void CheckIfNew()
        {


                string firstID = Fx.GetFirstID(eqsFiltered);


                if (lastEventID.Equals(string.Empty)) lastEventID = firstID;
                else if (!lastEventID.Equals(firstID)) lastEventID = firstID;
                else return;

                //if it does not return, then lstEvent has changed therefore update the file data.
                await ReadOrWriteLastEvent(false);
          
        }
        public async Task ReadOrWriteLastEvent(bool read)
        {


           
           string content = string.Empty;

            if (read)
            {

               content = await IO.ReadFileContentsAsync(  lastFile);
               if (!content.Equals(string.Empty))
               {
                   string[] aux =content.Split('\n');
                   lastEventID = aux[0].Replace("\0", "");

               }
              

            }
            else
            {
                content = lastEventID + "\n" + DateTime.UtcNow;
              
                await IO.WriteDataToFileAsync(lastFile, content);

            }

        }


        public void Filter()
        {

            // IEnumerable<object> input = pkg.List;
            //  bool asc = ;
            //  IEnumerable<EQ> input = eqs.OfType<EQ>();
            //  IEnumerable<object> input = eqs.OfType<EQ>();

            eqsFiltered = Tools.FilterList<EQ>(ref eqs, eqset.Asc, Fx.GetEQFilters(eqset), Fx.Order(eqset)).AsEnumerable<object>().ToList();

        }
        public void FillModel(ref MainViewModel model)
        {
            //FILL VIEWMODEL
            //  Func<object, int, ItemViewModel> VMcoverter = as Func<object, int, ItemViewModel>;
            model.FillModel<EQ>(eqsFiltered, Fx.VMConverter);


        }

    }

}
