using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using t.MyChatkit.ModelChatkit;
using t.MyChatkit.ModelChatkit.ModelRelatedUsers.Request;
using t.ViewModels;
using Xamarin.Forms;

namespace t
{
    public partial class MembershipSubcriptionPage : ContentPage
    {

        public MembershipSubcriptionPage()
        {
            InitializeComponent();


            BindingContext = new MembershipSubcriptionViewModel();
        }

       
    }
}
