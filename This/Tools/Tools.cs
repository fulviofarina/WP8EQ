using System;
using System.Collections.Generic;
using System.Linq;



namespace This.Tools
{
    public static class Tools
    {

    


        public static void Throw(object o, string msg)
        {
            if (o == null) throw new Exception(msg);

        }


      
        public static IList<T> FilterList<T>(ref IList<object> input, bool asc, IList<object> filtersList, object Orderer)
        {

            IEnumerable<T> ordered = null;


            if (input == null) throw new Exception("input list is null, cannot filter it");
            ordered = null;
            ordered = input.OfType<T>().ToList();

            //   IList<Func<T, bool>> filters = filtersList.OfType<Func<T, bool>>().ToList();

            foreach (object o in filtersList)
            {
                Func<T, bool> f = o as Func<T, bool>;
                ordered = ordered.Where(f).ToList();
            }
            //  Func<T, object> orderAux = ;
            Func<T, object> orderer = Orderer as Func<T, object>;

            ordered = ordered.OrderBy(orderer);

            if (!asc) ordered = ordered.Reverse();
            if (ordered != null) ordered = ordered.ToList().AsEnumerable();

            return ordered.ToList();

        }

      
      

        public static IList<IList<T>> ConvertToListOfItems<T>(ref IList<string> list, string headerKey, int maxCountItem, int indexToRemoveExcessAt)
        {




            IList<IList<T>> listBig = null;

            IList<T> list2 = null;

            if (listBig == null) listBig = new List<IList<T>>();
            else listBig.Clear();

            for (int x = 0; x < list.Count; x++)
            {
                string ele = list.ElementAt(x).Trim();
                if (ele.Contains(headerKey))
                {
                    
                    list2 = new List<T>();
                }
                
                if (!ele[0].Equals('<') || ele.Contains("img src="))
                {
                    T toInsert = (T)Convert.ChangeType(ele, typeof(T));
                    list2.Add(toInsert);

                   // if (list2 != null)
                  //  {
                        while (list2.Count > maxCountItem)
                        {
                            list2.RemoveAt(indexToRemoveExcessAt);
                        }
                        if (list2.Count==maxCountItem)  listBig.Add(list2);
                   // }


                }
             

            }


            return listBig;


        }

        public static IList<T2> ConvertToListOf<T, T2>(ref IList<IList<T>> listBig, Func<IList<T>, T2> converter)
        {

            IList<T2> outList = null;

            outList = listBig.Select(converter).OfType<T2>().ToList();


            return outList;

        }

        public static IList<string> TrimToList(ref string rssCont)
        {
            rssCont = rssCont.Replace(">", ">\n").Replace("</", "\n<").Replace("<dd>", "\n").Replace("<dt>", " \n");
            IEnumerable<string> list = null;

            list = rssCont.Split('\n');
            list = list.Where(x => !x.Trim().Equals(""));
            list = list.Where(x => !x.Contains(">"));
            return list.ToList();
        }




    }
}
