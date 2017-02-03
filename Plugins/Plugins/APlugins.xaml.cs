using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Plugins
{
    public partial class APlugins : ContentPage
    {

        public APlugins()
        {
            InitializeComponent();


            //DeviceInfo

            deviceOS.Text = "Device Os:" + Device.OS.ToString() + Device.Idiom.ToString();
            platform.Text = "Platform :" + Plugin.DeviceInfo.CrossDeviceInfo.Current.Platform.ToString();
            model.Text = "Model :" + Plugin.DeviceInfo.CrossDeviceInfo.Current.Model;
            version.Text = "Version:" + Plugin.DeviceInfo.CrossDeviceInfo.Current.Version;

            //Connectivity

            connection.Text = "IsConnected:" + Plugin.Connectivity.CrossConnectivity.Current.IsConnected.ToString();
            cnn.Text = "" + Plugin.Connectivity.CrossConnectivity.Current.Bandwidths.ToString();


            //GeoLocator

            btn.Clicked +=  (s, e) =>
            {
                latitude.Text = "Getting GPS";
                Device.BeginInvokeOnMainThread(async() => {
                    try
                    {
                        var locator = CrossGeolocator.Current;
                        locator.DesiredAccuracy = 50;
                        var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

                        if (position == null)
                        {
                            latitude.Text = "null GPS :(";
                            return;
                        }
                        latitude.Text = string.Format("Time: {0} \nLat: {1} \nLong: {2} ",
                        position.Timestamp, position.Latitude, position.Longitude);
                    }
                    catch (Exception asd)
                    {
                        await DisplayAlert("Alert", asd.Message, "hudd");
                    }

                });                
            };
        }






    }
}
