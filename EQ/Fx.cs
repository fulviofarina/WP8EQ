using Microsoft.Phone.Maps.Controls;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using This;
using This.ViewModels;

namespace EQ
{
    public class Fx
    {
        public static Func<EQ, MapLayer> MapLayer = aux =>
        {
            GeoCoordinate g = new GeoCoordinate(aux.Latitude, aux.Longitude, 1000);

            return Geodesy.GetMapLayer(g, aux.Magnitude);


        };
     

        public static Func<IList<string>, EQ> MainConverter = o =>
        {
            EQ output = new EQ();
            //output.SetData<string>(o); ANOTHER VERSION OF READING IT
            output.SetDataExt<string>(o);
            return output;
        };


        public static Func<IList<object>, string> GetFirstID = eqs =>
       {

           
           if (eqs== null) return string.Empty;

           EQ last = (EQ)eqs.FirstOrDefault();

           if (last == null) return string.Empty;

          
           return last.ID;
           
       };
    
        public static Func<EQ, int, ItemViewModel> VMConverter = (eq, i) =>
        {
          
            ItemViewModel vm = new ItemViewModel();

          

                vm.Tag = eq;
                vm.Name = eq.ID;
                vm.ID = i.ToString();
                vm.Lines[0] = eq.Magnitude.ToString();
           
                string[] aux = eq.Location.Split(new string[]{"of"}, StringSplitOptions.RemoveEmptyEntries);
                vm.Lines[1] = aux[1].Trim();
                vm.Lines[5] = aux[0].Trim() + " of";
            //    vm.LineDetail = "Magnitude " + eq.Magnitude;
                vm.Lines[2] = "Depth = " + eq.Depth + "\n( Lat ; Lon ) = ( " + eq.Latitude.ToString();
                vm.Lines[2] += " ; " + eq.Longitude.ToString() + " )";
              
                vm.Lines[2] += "\nID = " + eq.ID + " --> " + eq.EventDate.UtcDateTime + " UTC";
                vm.Lines[3] = eq.SinceString;

                vm.Lines[3] += ", " + Convert.ToInt32(eq.Distance).ToString() + " km away";
                vm.Lines[4] = eq.Summary;

                vm.ToLaunch[0] = eq.Uri;
                vm.ToLaunch[1] = eq.Uri;
                vm.ToLaunch[2] = eq.Uri;
                vm.ToLaunch[3] = eq.Uri + "#dyfi";
                vm.IsChecked = false;
                vm.BkgImgUri =eq.ImgUri;
                vm.Visible = "Collapsed";
                vm.Color = This.Templates.GetColorNameByNumber(eq.Magnitude);
              
                i++;
                vm.SelectedColor = "Magenta";

           
           
            return vm;
        };

        public static Func<ItemViewModel, bool> GetMapLayers = v =>
     {
         EQ eq = v.Tag as EQ;
         v.MapLayer = null;
         v.SelectedMapLayer = null;
         v.MapLayer = Fx.MapLayer(eq);
         v.SelectedMapLayer = This.Geodesy.GetMapLayer(eq.GeoCoord, 0);
         return true;
     };
      


        public static Func<ISetting, object > Order = set =>
        {

            Func<EQ, object> func = null;

         //   double value = (double)set.Table.ElementAt(set.CurrIndex);

            if (set.CurrIndex == 0) func = x => x.Magnitude;
            else if (set.CurrIndex == 1) func = x => x.SinceMin;
            else  if (set.CurrIndex == 2) func = x => x.Distance;
            return func;
         
        };



        public static Func<EQ, double> DistanceFinder = x =>
        {
            double distance = 0;
         //   if (Geodesy.CurrentPosition != null)
           // {
           //     Geocoordinate gc = Geodesy.CurrentPosition.Coordinate;
               distance = Geodesy.DistanceBetweenCoords(x.Latitude, x.Longitude, Geodesy.CurrentLatitude, Geodesy.CurrentLongitude);
               x.Distance = distance;
          //  }
            return distance;
        };

        public static Func<int, ISetting,Func<EQ, bool>> FilterPerSettingIndx = (ind, set) =>
        {

            Func<EQ, bool> func = null;

            double value = (double)set.Table.ElementAt(ind);
          
            if (ind == 0) func = x => (x.Magnitude >= value);
            //     else if (ind == 1) 
            else if (ind == 1) func= x => (x.SinceMin.TotalMinutes <= value );
            else if (ind ==2) 
            {
               func = x => ( DistanceFinder(x) <= value);
            }
            return func;
            //    else return  FilterDistance; //fix this!!!
        };

       
     
       

        public static IList<object> GetEQFilters(ISetting setting  )
        {
            IList<Func<EQ, bool>> filters;
            filters = new List<Func<EQ, bool>>();
            for (int y = 0; y < setting.Table.Count; y++)
            {
                filters.Add((Func<EQ, bool>)FilterPerSettingIndx(y,setting));
            }
            return filters.AsEnumerable<object>().ToList();
        }

    }
  

}
