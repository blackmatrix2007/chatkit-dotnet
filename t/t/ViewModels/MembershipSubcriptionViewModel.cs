using System;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedRooms.Request;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionStateOnlineOffline;
using t.MyChatkit.ModelChatkit.ModelRelatedUsers.Request;
using t.Pages;
using Xamarin.Forms;

namespace t.ViewModels
{
    public class MembershipSubcriptionViewModel : BaseViewModel
    {

        private ObservableCollection<User> items;
        public ObservableCollection<User> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        public MembershipSubcriptionViewModel()
        {
            Items = new ObservableCollection<User>();
            Connect();
        }

        private Command<User> itemSelectedCommand;
        public Command<User> ItemSelectedCommand
        {
            get
            {
                return itemSelectedCommand ?? new Command<User>(CreateNewOrCheckExistDialog);
            }
        }


        private async void CreateNewOrCheckExistDialog(User partner) {
            CreateRoomRequest request = new CreateRoomRequest()
            {
                isPrivate = true,
                user_ids = new string[2] { SubcriptionJib.user_id, partner.id },
                name = partner.name,
            };
            request.Headers["Authorization"] = DependencyService.Get<ISubcriptionJib>().GetToken();
            var result = await DependencyService.Get<IJibApi>().CreateRoom(request);
            if (result!=null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new IndivisualConversationPage());
            }
        }

        void Handle_OnOffHandle(object sender, string e)
        {

            object[] array = JsonConvert.DeserializeObject<object[]>(e);
            if (array != null && array.Length == 4)
            {

                Console.WriteLine("PresenceSubcriptionPage {0}", e);
                string a = array[3].ToString();
                BaseContent<PresenceData> room = JsonConvert.DeserializeObject<BaseContent<PresenceData>>(a);

                string partnerid = sender as string;
                string newstate = room.data.state;

                if (Items.Count == 0 )
                {
                    return;
                }
                try
                {
                    int count = Items.Count;
                    int i = 0;
                    for (; i < count; i++)
                    {
                        if (Items[i].id == partnerid && Items[i].state != newstate)
                        {
                            User u = Items[i];
                           
                            Console.WriteLine("PresenceSubcriptionPage Change{0} {1}", partnerid, newstate);

                            Items[i] = new User() { 
                                id = partnerid,
                                name = u.name,
                                state = newstate,
                                
                            };

                            break;
                        }

                    }
                }
                catch (Exception ex)
                {

                }
            }
        }


        private async void Connect() {

            var tokenResponse = await DependencyService.Get<ISubcriptionJib>().RequestToken();
            if (tokenResponse != null)
            {
                LoadData();
                DependencyService.Get<ISubcriptionJib>().OnOffHandle += Handle_OnOffHandle;
            }
        }

        private async void LoadData() {
            GetUsersRequest request = new GetUsersRequest();
            request.Headers["Authorization"] =  DependencyService.Get<ISubcriptionJib>().GetToken();
            var result = await DependencyService.Get<IJibApi>().GetUsers(request);
            if (result != null)
            {

                Items = new ObservableCollection<User>(result);

                foreach (var item in Items)
                {
                    DependencyService.Get<ISubcriptionJib>().SubcribeUserStateOnOff(item.id);
                }
            }
        }

        private Command refreshCommand;
        public Command RefreshCommand
        {
            get
            {
                return refreshCommand ?? new Command(() =>
                {

                });
            }
        }
    }
}
