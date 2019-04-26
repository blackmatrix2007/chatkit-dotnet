using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionStateOnlineOffline;
using Xamarin.Forms;

namespace t
{
    public partial class PresenceSubcriptionPage : ContentPage
    {
        ObservableCollection<PresenceData> items;
        public PresenceSubcriptionPage()
        {
            InitializeComponent();

            items = new ObservableCollection<PresenceData>();

            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            listView.BindingContext = items;

            DependencyService.Get<ISubcriptionJib>().OnOffHandle += Handle_OnOffHandle;


            PopulateData();
        }

        void PopulateData()
        {
            //get list user from api or your backend
            items.Add(new PresenceData()
            {
                user_id = "neo2_at_gmailcom",
                state = "offline"
            });


            items.Add(new PresenceData()
            {
                user_id = "one_at_hotelsng",
                state = "offline"
            });


            items.Add(new PresenceData()
            {
                user_id = "neo_at_hotelsng",
                state = "offline"
            });


            items.Add(new PresenceData()
            {
                user_id = "sondh",
                state = "offline"
            });


        }

        void Handle_OnOffHandle(object sender, string e)
        {
            List<object> array = JsonConvert.DeserializeObject<List<object>>(e);
            if (array.Count == 4)
            {

                Console.WriteLine("PresenceSubcriptionPage {0}", e);
                string a = array[3].ToString();
                BaseContent<PresenceData> room = JsonConvert.DeserializeObject<BaseContent<PresenceData>>(a);

                string partnerid = sender as string;
                string newstate = room.data.state;
                int count = items.Count;
                int i = 0;
                //bool isOnline = false;
                for (; i < count; i++)
                {
                    if (items[i].user_id == partnerid)
                    {

                        //isOnline = newstate == "offline" ? false : true;
                        break;
                    }
                }

                items.RemoveAt(i);

                items.Add(new PresenceData()
                {
                    state = newstate,
                    user_id = partnerid
                });
            }
        }
    }
}
