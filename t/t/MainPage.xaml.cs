using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xamarin.Forms;

namespace t
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();


        }

        void Handle_Fire(object sender, string e)
        {
            Console.WriteLine(e);
            Device.BeginInvokeOnMainThread(()=> {
                //content.Text = content.Text + e;
            });
        }


         void Handle_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<ISubcriptionJib>().Connect();
        }
    }
}
