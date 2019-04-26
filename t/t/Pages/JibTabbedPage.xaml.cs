using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace t.Pages
{
    public partial class JibTabbedPage : TabbedPage
    {
        public JibTabbedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasBackButton(this, false);
        }
    }
}
