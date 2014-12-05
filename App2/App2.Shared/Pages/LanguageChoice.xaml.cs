using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using App2.Entities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LanguageChoice : Page
    {
        private const string EnglishCultureString = "en-US";
        private const string UkrainianCultureString = "uk-UA";
        private const string RussianCultureString = "ru-RU";

        public LanguageChoice()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void EnglishLanguageButtonTap(object sender, TappedRoutedEventArgs e)
        {
            SetCulture(EnglishCultureString);

            GoToLogInPageIfNotLoggedIn();
        }

        private void UkrainianLanguageButtonTap(object sender, TappedRoutedEventArgs e)
        {
            SetCulture(UkrainianCultureString);

            GoToLogInPageIfNotLoggedIn();
        }

        private void RussianLanguageButtonTap(object sender, TappedRoutedEventArgs e)
        {
            SetCulture(RussianCultureString);

            GoToLogInPageIfNotLoggedIn();
        }

        private void SetCulture(string cultureInfoString)
        {
            if (GenericRepo<Language>.GetAll().Count != 0)
            {
                GenericRepo<Language>.DeleteAll();
            }

            var languageToAdd = new Language { SelectedCultureString = cultureInfoString};

            GenericRepo<Language>.Insert(languageToAdd);
        }

        private void GoToLogInPageIfNotLoggedIn()
        {
            Frame.Navigate(!GenericRepo<ServerCredentials>.GetAll().Any() ? typeof (LogInPage) : typeof (TasksViewPage));
        }
    }
}
