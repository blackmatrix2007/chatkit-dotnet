using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;
using Xamarin.Forms;

namespace t.ViewModels
{
    public class RoomsSubcriptionViewModel
    : BaseViewModel
    {
        private ObservableCollection<Room> items;
        public ObservableCollection<Room> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public RoomsSubcriptionViewModel()
        {
            Items = new ObservableCollection<Room>();
            DependencyService.Get<ISubcriptionJib>().RoomsReceived += Handle_Fire;
        }

        void Handle_Fire(object sender, string e)
        {
            Console.WriteLine("RoomsSubcriptionPage {0}", e);

            object[] array = JsonConvert.DeserializeObject<object[]>(e);
            if (array.Length == 4)
            {

                string a = array[3].ToString();
                BaseContent<RoomData> room = JsonConvert.DeserializeObject<BaseContent<RoomData>>(a);
                Items.Clear();


                Items = new ObservableCollection<Room>(room.data.rooms);

            }

        }
    }
}