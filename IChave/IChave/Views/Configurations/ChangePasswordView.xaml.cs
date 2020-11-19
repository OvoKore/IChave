﻿using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace IChave.Views.Configurations
{
    public partial class ChangePasswordView : ContentPage
    {
        public ChangePasswordView()
        {
            InitializeComponent();
            Title = "Change Password";
            NavigationPage.SetHasNavigationBar(this, true);
            On<iOS>().SetUseSafeArea(true);
        }
    }
}