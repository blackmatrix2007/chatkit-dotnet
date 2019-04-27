using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedSubcriptionRoom;
using t.Pages;
using t.ViewModels;
using Xamarin.Forms;

namespace t
{
    public partial class RoomsSubcriptionPage : ContentPage
    {

        public RoomsSubcriptionPage()
        {
            InitializeComponent();

            BindingContext = new RoomsSubcriptionViewModel();


        }

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ConversationPage((Room)e.Item));
        }


    }
}
