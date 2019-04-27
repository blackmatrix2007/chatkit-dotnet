using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionStateOnlineOffline;
using Xamarin.Forms;

namespace t.ViewModels
{
    public class PresenceSubcriptionViewModel : BaseViewModel
    {
        private ObservableCollection<PresenceData> items;
        public ObservableCollection<PresenceData> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
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



                try
                {
                    int count = Items.Count;
                    int i = 0;
                    //bool isOnline = false;
                    for (; i < count; i++)
                    {
                        if (Items[i].user_id == partnerid && Items[i].state != newstate)
                        {
                            Items[i] = new PresenceData() { 
                                state = newstate,
                                user_id = partnerid
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
        public PresenceSubcriptionViewModel() {
            DependencyService.Get<ISubcriptionJib>().OnOffHandle += Handle_OnOffHandle;

            Items = new ObservableCollection<PresenceData>() {
                new PresenceData()
                {
                    user_id = "neo2_at_gmailcom",
                    state = "offline"
                },
                new PresenceData()
                {
                    user_id = "one_at_hotelsng",
                    state = "offline"
                },
                new PresenceData()
                {
                    user_id = "neo_at_hotelsng",
                    state = "offline"
                }
            };
        }
    }
}