using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace t
{
    public partial class MembershipSubcriptionPage : ContentPage
    {
        ObservableCollection<string> items;
        public MembershipSubcriptionPage()
        {
            InitializeComponent();

//2019 - 04 - 08 15:16:07.669081 + 0700 t.iOS[77717:1145923][1, "100000108",{ },{ "event_name":"new_message","data":{ "created_at":"2019-04-08T06:38:28Z","id":100071811,"room_id":"19564764","text":" 693","updated_at":"2019-04-08T06:38:28Z","user_id":"neo_at_hotelsng"},"timestamp":"2019-04-08T08:16:07Z"}]
//2019 - 04 - 08 15:16:21.828307 + 0700 t.iOS[77717:1145923][1, "100000109",{ },{ "event_name":"new_message","timestamp":"2019-04-08T08:16:21Z","data":{ "created_at":"2019-04-08T08:16:21Z","id":100071943,"room_id":"19564764","text":" 380","updated_at":"2019-04-08T08:16:21Z","user_id":"neo_at_hotelsng"} }]
//2019 - 04 - 08 15:16:31.006871 + 0700 t.iOS[77717:1145923][1, "100000110",{ },{ "event_name":"new_message","timestamp":"2019-04-08T08:16:30Z","data":{ "created_at":"2019-04-08T08:16:30Z","id":100071944,"room_id":"19564764","text":" 330","updated_at":"2019-04-08T08:16:30Z","user_id":"neo_at_hotelsng"} }]

            //DependencyService.Get<ISubcriptionJib>().Connect();
            //items = new ObservableCollection<string>();

            //listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            //listView.BindingContext = items;

            //DependencyService.Get<ISubcriptionJib>().MessageReceived += Handle_Fire;
        }

        //void Handle_Fire(object sender, string e)
        //{
        //    Console.WriteLine("MembershipSubcriptionPage {0}", e);
        //    Device.BeginInvokeOnMainThread(() => {
        //        items.Add(e);
        //    });
        //}


        //void Handle_Clicked(object sender, System.EventArgs e)
        //{
        //    DependencyService.Get<ISubcriptionJib>().Connect();
        //}
    }
}
