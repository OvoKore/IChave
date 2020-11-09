﻿using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace IChave.Views.LoginSignUp
{
    public partial class SignUpView : ContentPage
    {
        public SignUpView()
        {
            InitializeComponent();
            this.BackgroundImageSource = FileImageSource.FromFile("icon_splash.png");
            this.Title = "Sign Up";
            NavigationPage.SetHasNavigationBar(this, true);
            On<iOS>().SetUseSafeArea(true);
        }
    }
}