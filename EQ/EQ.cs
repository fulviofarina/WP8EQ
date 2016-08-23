using System;
using System.Collections.Generic;
using System.Linq;




namespace EQ 
{


    public class EQComparer : IEqualityComparer<object>
    {
        public bool Equals(object x, object y)
        {

            EQ x1 = x as EQ;
            EQ y1 = y as EQ;

            return x1.ID.CompareTo(y1.ID) == 0;
          
        }
        public int GetHashCode(object c)
        {
            EQ c1 = c as EQ;
            return c1.ID.GetHashCode();
        }

    }

    /// <summary>
    /// ta fina por ahora
    /// </summary>
    public class EQ 
    {




        private System.Device.Location.GeoCoordinate geoCoord;

        public System.Device.Location.GeoCoordinate GeoCoord
        {
            get
            { 
           
            return geoCoord;
            }
        }
        //    private static Geoposition position = null;
       // private Methods methods;

    //    private static Uri baseUri =   new Uri("http://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.atom");
       // private static Uri baseUri = new Uri("http://earthquake.usgs.gov/earthquakes/feed/atom/all/day");
        private static Uri baseUri = new Uri("http://earthquake.usgs.gov/earthquakes/feed/atom/all/day");
        public static Uri BaseUri
        {

            get { return baseUri; }

        }
        public EQ()
        {


         

          
        }

        public void SetDataExt<T>(IList<T> input)
        {

            IList<string> inputItem = input.OfType<string>().ToList();
            //  

            this.iD = inputItem.ElementAt(0).Trim();
            //"<img src=\"/images/globes/35_-115.jpg\" align=\"left\""

            this.depth = inputItem.ElementAt(7).Replace(":",null).Trim();
            this.elevation = -1*Convert.ToDouble(inputItem.ElementAt(9));
            this.eventDate = Convert.ToDateTime(inputItem.ElementAt(2).Trim());
        //    this.eventDate = this.eventDate.Add(this.eventDate.Offset);
            //DateTimeOffset now = DateTime.Now;
            string[] latlon;
            latlon = inputItem.ElementAt(8).Split(' ');
            this.latitude = Convert.ToDouble(latlon[0]);
            this.longitude = Convert.ToDouble(latlon[1]);
            this.summary = inputItem.ElementAt(1).Trim();
            this.si = true;
            string[] sum = this.summary.Split(' ');
            this.magnitude = Convert.ToDouble(sum[1].Replace(",",null).Trim());
            for (int i = 2; i < sum.Count(); i++) this.location += sum[i].Trim() + " ";
            this.location = location.Trim();
            this.iD = this.iD.Replace("urn:earthquake-usgs-gov:", null).Replace(":", null);
            this.uri = new Uri("http://earthquake.usgs.gov/earthquakes/eventpage/" + this.iD, UriKind.Absolute);
            sum = inputItem.ElementAt(4).Split('\"');
            // this.summary = "Last EQ was " + Convert.ToInt16(this.SinceMin) + " min ago";
        //    string aux = input.ElementAt(4);
            this.imgUri = new Uri("http://earthquake.usgs.gov" + sum[1], UriKind.Absolute );
            geoCoord = new System.Device.Location.GeoCoordinate(this.latitude, this.longitude, elevation);
            
            /*
           string[] magLoc = item.Title.Text.Substring(2).Split(',');
           string webimg = item.Summary.Text.Trim();
            int ind = webimg.IndexOf('"');
            webimg = webimg.Substring(ind + 1);
            ind = webimg.IndexOf('"');
            webimg = webimg.Substring(0, ind);
         coord = item.ElementExtensions[1].NodeValue.ToString();
            string[] geo = coord.Split(' ');



            this.iD = item.Id.ToString().Trim();
           this.eventDate = item.LastUpdatedTime.ToUniversalTime();

            this.latitude = Convert.ToDouble(geo[0]);
            this.longitude = Convert.ToDouble(geo[1]);
            this.imgUri = "http://earthquake.usgs.gov" + webimg.Trim();
            this.elevation = Convert.ToDouble(item.ElementExtensions[2].NodeValue);
            this.magnitude = Convert.ToDouble(magLoc[0]);
            this.location = magLoc[1].Trim() + ", " + magLoc[2].Trim();

            string aux = item.Links.FirstOrDefault().Uri.ToString();
            int a = aux.LastIndexOf('/');
            this.uri = new Uri("http://earthquake.usgs.gov/earthquakes/eventpage" + aux.Substring(a).Replace(".php", "#summary"));

            this.nr = 0;
            */
        }
        public void SetData<T>(IList<T> input)
        {

            IList<string> inputItem = input.OfType<string>().ToList();
      //  

            this.iD = inputItem.ElementAt(0).Trim();
            this.elevation = Convert.ToDouble(inputItem.ElementAt(11).Trim());
            this.eventDate = Convert.ToDateTime(inputItem.ElementAt(4).Replace("UTC", "").Trim());
            this.eventDate = this.eventDate.Add(this.eventDate.Offset);
            //DateTimeOffset now = DateTime.Now;
            string[] latlon;
            latlon = inputItem.ElementAt(10).Split(' ');
            this.latitude = Convert.ToDouble(latlon[0]);
            this.longitude = Convert.ToDouble(latlon[1]);
            this.summary = inputItem.ElementAt(1).Trim();
            this.si = true;
            string[] sum = this.summary.Split(' ');
            this.magnitude = Convert.ToDouble(sum[1].Trim());
            for (int i = 3; i < sum.Count(); i++) this.location += sum[i].Trim() + " ";
            this.location = location.Trim();
            this.iD = this.iD.Replace("urn:earthquake-usgs-gov:", null).Replace(":", null);
            this.uri = new Uri("http://earthquake.usgs.gov/earthquakes/eventpage/" + this.iD);
            // this.summary = "Last EQ was " + Convert.ToInt16(this.SinceMin) + " min ago";

            this.imgUri = new Uri("http://earthquake.usgs.gov/earthquakes/map/#thumb=/images/globes/60_-140.jpg");
            /*
           string[] magLoc = item.Title.Text.Substring(2).Split(',');
           string webimg = item.Summary.Text.Trim();
            int ind = webimg.IndexOf('"');
            webimg = webimg.Substring(ind + 1);
            ind = webimg.IndexOf('"');
            webimg = webimg.Substring(0, ind);
         coord = item.ElementExtensions[1].NodeValue.ToString();
            string[] geo = coord.Split(' ');



            this.iD = item.Id.ToString().Trim();
           this.eventDate = item.LastUpdatedTime.ToUniversalTime();

            this.latitude = Convert.ToDouble(geo[0]);
            this.longitude = Convert.ToDouble(geo[1]);
            this.imgUri = "http://earthquake.usgs.gov" + webimg.Trim();
            this.elevation = Convert.ToDouble(item.ElementExtensions[2].NodeValue);
            this.magnitude = Convert.ToDouble(magLoc[0]);
            this.location = magLoc[1].Trim() + ", " + magLoc[2].Trim();

            string aux = item.Links.FirstOrDefault().Uri.ToString();
            int a = aux.LastIndexOf('/');
            this.uri = new Uri("http://earthquake.usgs.gov/earthquakes/eventpage" + aux.Substring(a).Replace(".php", "#summary"));

            this.nr = 0;
            */
        }
        private int nr = 0;
        public int Nr
        {
            get { return nr; }
            set { nr = value; }
        }

        private Uri uri = null;
        private Uri imgUri;
        private string summary;
        private string location;
        private double latitude;
        private double longitude;
        private double magnitude;
        private DateTimeOffset eventDate;
        public TimeSpan SinceMin
        {
            get
            {
                return DateTime.UtcNow.Subtract(this.EventDate.UtcDateTime);
            }

        }
        private double distance;
        private double elevation;
        private string depth;
        private string iD;

        private bool si = false;
        public bool SI
        {
            get { return si; }
            set { si = value; }
        }

        public DateTimeOffset EventDate
        {
            get { return eventDate; }
            set
            {
                eventDate = value;
            }

        }

        public Uri Uri
        {
            get { return uri; }
            set
            {
                uri = value;
            }

        }
        public Uri ImgUri
        {
            get { return imgUri; }
            set
            {
                imgUri = value;
            }

        }
        public string Summary
        {
            get {

           
                this.summary = "M " + this.magnitude + " - " + SinceString;
      
                
                return summary; }
            set
            {
                summary = value;
            }

        }


        public string SinceString
        {
            get
            {

                int h = this.SinceMin.Hours;
                int m = this.SinceMin.Minutes;
                int d= this.SinceMin.Days;
              

                string aux = string.Empty;

                if (d > 0) aux += d + "d";
                if (h > 0) aux += h + "h";
                if (m > 0) aux += m + "m";

                return aux + " ago";
               
            }

        }

        public string Location
        {
            get { return location; }
            set
            {
                location = value;
            }

        }
        public double Magnitude
        {
            get { return magnitude; }
            set
            {
                magnitude = value;
            }

        }
        public double Distance
        {
            get { return distance; }
            set
            {
                distance = value;
            }

        }
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
            }

        }
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
            }

        }

        public double Elevation
        {
            get { return elevation; }
            set
            {
                elevation = value;
            }

        }
        public string Depth
        {
            get { return depth; }
            set
            {
                depth = value;
            }

        }

        public string ID
        {
            get { return iD; }
            set
            {
                iD = value;
            }

        }

        private object notification;
        public object Notification
        {
            get { return notification; }
            set
            {
                notification = value;
            }

        }



    }


}
