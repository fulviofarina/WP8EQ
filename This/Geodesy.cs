using Microsoft.Phone.Maps.Controls;
using System;
using System.Device.Location;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace This
{

       
    public  class Geodesy
    {




         private static GeoCoordinateWatcher _watcher = null;

         private static AsyncCallback callBack;
         public static AsyncCallback CallBack
         {

             get { return callBack;}
             set { callBack = value; }
         }

        public static void Start()
        {
            if (_watcher == null)
            {
                _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
                _watcher.MovementThreshold = 10;
                _watcher.PositionChanged +=
                  new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(watcher_PositionChanged);
                _watcher.StatusChanged +=
                  new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_StatusChanged);
            }
            _watcher.Start();
            if (_watcher.Permission == GeoPositionPermission.Denied)
            {
                //Location services is disable on the phone. Show a message to the user.
            }
        }
        static void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
           
            curPosition = e.Position.Location;
            if (callBack != null) callBack.Invoke(null);

        }
        static  void watcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            if (e.Status == GeoPositionStatus.Ready)
            {
              
              
               
            }
        }



   //     private static Geolocator g=null;
        private static GeoCoordinate curPosition = null;
      
        public static double CurrentLatitude
        {

            get
            {

                if (curPosition != null)
                {
                    return curPosition.Latitude;
                }
                else return 0;
            }
        }
        public static double CurrentLongitude
        {

            get
            {
                if (curPosition != null)
                {
                    return curPosition.Longitude;
                }
                else return 0;
               
            }
        }

      

   




        public  static MapLayer GetMapLayer(GeoCoordinate geoCoord,  double color)
        {
           
         

            Shape s = null;

            int wh = 10;
            int opacity = 50;

          
            SolidColorBrush col = This.Templates.GetColorByNumber(color);
            if (color == 0)
            {
                s = new Rectangle();
                wh = 20;
                col.Color = System.Windows.Media.Colors.Black;
                opacity = 10;
                //    s.StrokeLineJoin = PenLineJoin.Miter;
                //  s.StrokeDashCap = PenLineCap.Triangle;
                s.StrokeThickness = 2;
                s.Stroke = col;
               
              
            }
          
            else if (color == 100)
            {
                s = new Ellipse();
                wh = 20;
                col.Color = System.Windows.Media.Colors.Brown;
                opacity = 50;
                //    s.StrokeLineJoin = PenLineJoin.Miter;
                //  s.StrokeDashCap = PenLineCap.Triangle;
                s.StrokeThickness = 3;
                s.Stroke = col;


            }
            else 
            {
                s = new Ellipse();
                s.Fill = col;
            }
            s.Height = wh;
            s.Width = wh;
            s.Opacity = opacity;

            MapOverlay myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = s;
            myLocationOverlay.PositionOrigin = new Point(1, 1);
            myLocationOverlay.GeoCoordinate = geoCoord;
         
          
           MapLayer myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);
       //  myLocationOverlay.ad
          
            return myLocationLayer;
        }

     




        public static double RadToDeg(double radians)
        {
            return radians * (180 / Math.PI);
        }

        public static double DegToRad(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        //Calculate distance between two coordinates useing the Haversine formula  
        public static double DistanceBetweenCoords(double lat1, double long1, double lat2, double long2)
        {
            //Convert input values to radians  
            lat1 = Geodesy.DegToRad(lat1);
            long1 = Geodesy.DegToRad(long1);
            lat2 = Geodesy.DegToRad(lat2);
            long2 = Geodesy.DegToRad(long2);

            double earthRadius = 6371; // km  
            double deltaLat = lat2 - lat1;
            double deltaLong = long2 - long1;
            double a = Math.Sin(deltaLat / 2.0) * Math.Sin(deltaLat / 2.0) +
                    Math.Cos(lat1) * Math.Cos(lat2) *
                    Math.Sin(deltaLong / 2.0) * Math.Sin(deltaLong / 2.0);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;

            return distance;
        }
    }

}
