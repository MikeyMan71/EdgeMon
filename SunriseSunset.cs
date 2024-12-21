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
        
        System.Device.Location.GeoCoordinateWatcher geoCoordinateWatcher = new GeoCoordinateWatcher();

        public bool isvalid 
        {
            get { return _isvalid; }
        }





        internal SunriseSunset(double lat, double lng, TimeZoneInfo timeZoneInfo)
        {
            geoCoordinateWatcher.Start();
            geoCoordinateWatcher.StatusChanged += new EventHandler<GeoPositionStatusChangedEventArgs>(watcher_statuschanged);

            _lat = lat;
            _lon = lng;

            if (Double.IsNaN(lat) || Double.IsNaN(lng))
            {
                getlocation();
            }
            else
            { _isvalid = true; }

            tz = timeZoneInfo;

        }


        public bool getlocation()
        {
       
            return _isvalid;
        }

        private void watcher_statuschanged(object sender, GeoPositionStatusChangedEventArgs e)
        {
            switch (e.Status)
            {
                case GeoPositionStatus.Initializing:
                    _isvalid = false;
                    break;

                case GeoPositionStatus.Ready:
                    GeoCoordinate geo = geoCoordinateWatcher.Position.Location;
                    _lat = geo.Latitude;
                    _lon = geo.Longitude;
                    _isvalid = true;
                    break;

                case GeoPositionStatus.NoData:
                    _isvalid = false;
                    break;

                case GeoPositionStatus.Disabled:
                    _isvalid = false;
                    break;
            }
        }

        public string getSunrise() 
        {
            string res = "??:??";
            Sunriset.SunriseSunset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _lat, _lon, out tsunrise, out tsunset);
            if (!double.IsNaN(tsunrise) && !double.IsNaN(tsunset))
            {
                sunrise = DateTime.Today + TimeSpan.FromHours(tsunrise);
                sunrise = DateTime.SpecifyKind(sunrise, DateTimeKind.Utc);
                sunset = DateTime.Today + TimeSpan.FromHours(tsunset);
                sunset = DateTime.SpecifyKind(sunset, DateTimeKind.Utc);
                res = TimeZoneInfo.ConvertTimeFromUtc(sunrise, tz).ToString(@"HH\:mm  ");
            }
            //TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);


            return res;
    }

        public string getSunset()
        {
            string res = "??:??";
            Sunriset.SunriseSunset(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, _lat, _lon, out tsunrise, out tsunset);
            if (!double.IsNaN(tsunrise) && !double.IsNaN(tsunset))
            {
                sunrise = DateTime.Today + TimeSpan.FromHours(tsunrise);
                sunrise = DateTime.SpecifyKind(sunrise, DateTimeKind.Utc);
                sunset = DateTime.Today + TimeSpan.FromHours(tsunset);
                sunset = DateTime.SpecifyKind(sunset, DateTimeKind.Utc);
                res = TimeZoneInfo.ConvertTimeFromUtc(sunset, tz).ToString(@"HH\:mm");
            }
            //TimeSpan sunriseTime = TimeSpan.FromHours(tsunrise);
            return res;
        }


     


        






    }
}
