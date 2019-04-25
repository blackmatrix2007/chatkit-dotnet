using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;
using t.Pages;
using Xamarin.Forms;

namespace t
{
    public partial class RoomsSubcriptionPage : ContentPage
    {
        ObservableCollection<Room> items;
        public RoomsSubcriptionPage()
        {
            InitializeComponent();


            items = new ObservableCollection<Room>();

            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            listView.BindingContext = items;


            DependencyService.Get<ISubcriptionJib>().RoomsReceived += Handle_Fire;
        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ConversationPage((Room)e.Item));
        }

        void Handle_Fire(object sender, string e)
        {
            Console.WriteLine("RoomsSubcriptionPage {0}", e);

            List<object> array =  JsonConvert.DeserializeObject<List<object>>(e);
            if (array.Count == 4)
            {

                string a = array[3].ToString();
                BaseContent <RoomData> room = JsonConvert.DeserializeObject<BaseContent<RoomData>>(a);
                items.Clear();

                foreach (Room item in room.data.rooms)
                {
                    items.Add(item);
                }
            }

        }

    }
}
