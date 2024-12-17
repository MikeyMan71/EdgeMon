using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using System.Threading;

namespace EdgeMon
{
    internal class SunriseSunset
    {
        double tsunrise, tsunset;
        DateTime sunrise;
        DateTime sunset;
        double _lat;
        double _lon;
        TimeZoneInfo tz;
        bool _isvalid;

        public bool isvalid 
        {
            get { return _isvalid; }
        }





        internal SunriseSunset(double lat, double lng, TimeZoneInfo timeZoneInfo)
        {
           


            _lat = lat;
            _lon = lng;

            if (Double.IsNaN(lat) || Double.IsNaN(lng))
            {
                getlocation();
            }
            else
            { _isvalid = true; }
            //System.Device.Location.GeoCoordinateWatcher geoCoordinateWatcher = new GeoCoordinateWatcher();
            //ret = geoCoordinateWatcher.TryStart(false, TimeSpan.FromMilliseconds(10000));
            //Thread.Sleep(1000);

            //if (geoCoordinateWatcher.Status == GeoPositionStatus.Ready)
            //{
            //    GeoCoordinate geo = geoCoordinateWatcher.Position.Location;
            //    _lat = geo.Latitude;
            //    _lon = geo.Longitude;
            //    _isvalid = true;
            //}
            //else
            //{ _isvalid = false; }



            //  _lat = lat;
            //  _lon = lng;
            tz = timeZoneInfo;

        }


        public bool getlocation()
        {
   
            System.Device.Location.GeoCoordinateWatcher geoCoordinateWatcher = new GeoCoordinateWatcher();
            geoCoordinateWatcher.TryStart(false, TimeSpan.FromMilliseconds(100));
            //  Thread.Sleep(1000);
           
            if (geoCoordinateWatcher.Status == GeoPositionStatus.Ready)
            {
                GeoCoordinate geo = geoCoordinateWatcher.Position.Location;
                _lat = geo.Latitude;
                _lon = geo.Longitude;
                _isvalid = true;
            }
            else
            { _isvalid = false; }

            return _isvalid;

        }

        public string getSunrise() 
        {

            Sunriset.SunriseSunset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _lat, _lon, out tsunrise, out tsunset);
            sunrise = DateTime.Today + TimeSpan.FromHours(tsunrise);
            sunrise = DateTime.SpecifyKind(sunrise, DateTimeKind.Utc);
            sunset = DateTime.Today + TimeSpan.FromHours(tsunset);
            sunset = DateTime.SpecifyKind(sunset, DateTimeKind.Utc);

            //TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);
            return TimeZoneInfo.ConvertTimeFromUtc(sunrise, tz).ToString(@"HH\:mm  ");
    }

        public string getSunset()
        {

            Sunriset.SunriseSunset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _lat, _lon, out tsunrise, out tsunset);
            sunrise = DateTime.Today + TimeSpan.FromHours(tsunrise);
            sunrise = DateTime.SpecifyKind(sunrise, DateTimeKind.Utc);
            sunset = DateTime.Today + TimeSpan.FromHours(tsunset);
            sunset = DateTime.SpecifyKind(sunset, DateTimeKind.Utc);

            //TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);
            return TimeZoneInfo.ConvertTimeFromUtc(sunset,tz).ToString(@"HH\:mm");
        }


     


        






    }
}
