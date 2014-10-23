using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
using App1.Entities;
using App2.Entities;
using App2.Pages;

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsViewPage : NavBar
    {
        public EventsViewPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var items = GenericRepo<EventEntity>.GetSome();

            EventsGridView.ItemsSource = items.Select(x => string.Format("{0,-15}{1,-15}{2,-10}{3}{4,-10}", /*items.IndexOf(x).ToString(), */x.Name, x.Description, x.StartDate.ToString("d"),"--",x.EndDate.ToString("d")));

            EditEventButton.IsEnabled = false;
            AddEventButton.IsEnabled = true;
        }

        private void EventsGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditEventButton.IsEnabled = true;
        }

        private void AddEventButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(EventsAddPage), e);
        }

        private void EditEventButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(EventsAddPage), EventsGridView.SelectedItem);
        }
    }
}
