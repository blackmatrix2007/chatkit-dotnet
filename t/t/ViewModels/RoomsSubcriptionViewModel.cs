using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;
using Xamarin.Forms;

namespace t.ViewModels
{
    public class RoomsSubcriptionViewModel : BaseViewModel
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

            if (array != null && array.Length == 4)
            {
                string a = array[3].ToString();
                BaseData baseData = JsonConvert.DeserializeObject<BaseData>(a);

                if (baseData.event_name == RoomEvent.initial_state.ToString())
                {
                    BaseContent<RoomData> baseContent = JsonConvert.DeserializeObject<BaseContent<RoomData>>(a);
                    Items = new ObservableCollection<Room>(baseContent.data.rooms);
                }
                else if (baseData.event_name == RoomEvent.added_to_room.ToString())
                {
                    BaseContent<RoomDetail> baseContent = JsonConvert.DeserializeObject<BaseContent<RoomDetail>>(a);
                    Room addingRoom = baseContent.data.room;
                    Items.Add(addingRoom);
                }
                else if (baseData.event_name == RoomEvent.room_updated.ToString())
                { }
                else if (baseData.event_name == RoomEvent.room_deleted.ToString())
                { }
                else if (baseData.event_name == RoomEvent.removed_from_room.ToString())
                { }
            }
        }
    }
}