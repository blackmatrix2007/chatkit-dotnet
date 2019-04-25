using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage.Request;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionMessage;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;
using Xamarin.Forms;

namespace t.Pages
{
    public partial class ConversationPage : ContentPage
    {
        Random rd = new Random();
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(message.Text) || room == null || room.id == "")
            {
                return;
            }

            CreateMessageRequest request = new CreateMessageRequest();
            request.FormData["text"] = message.Text;
            request.FormData["user_id"] = DependencyService.Get<ISubcriptionJib>().GetChatkitId();
            request.Headers["Authorization"] = DependencyService.Get<ISubcriptionJib>().GetToken();
            request.roomId = room.id;
            var result =  await DependencyService.Get<IJibApi>().SendMessage(request);
            if (result != null )
            {
                message.Text = "";
            }
        }
        public Room room { get; set; }
        ObservableCollection<MessageData> items;
        public ConversationPage(Room item)
        {
            InitializeComponent();

            this.room = item;
            items = new ObservableCollection<MessageData>();

            listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
            listView.BindingContext = items;


            DependencyService.Get<ISubcriptionJib>().MessageReceived += Handle_Fire;
            DependencyService.Get<ISubcriptionJib>().JoinRoom(item);
        }
        void Handle_Fire(object sender, string e)
        {
            Console.WriteLine("ConversationPage {0}", e);

            List<object> array = JsonConvert.DeserializeObject<List<object>>(e);
            if (array.Count == 4)
            {
                string a = array[3].ToString();
                BaseContent<MessageData> message = JsonConvert.DeserializeObject<BaseContent<MessageData>>(a);
                items.Add(message.data);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DependencyService.Get<ISubcriptionJib>().LeaveRoom();
        }
    }
}
