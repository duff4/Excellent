// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App2.Entities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsViewPage : NavBar
    {
        private const string AddEventResourceName = "AddEventButtonText";
        private const string EditEventResourceName = "EditEventButtonText";

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
            SetButtonNames(TasksButton, EventsButton, LecturersButton, SubjectsButton);

            AddEventButton.Content = GlobalResourceLoader.GetString(AddEventResourceName);
            EditEventButton.Content = GlobalResourceLoader.GetString(EditEventResourceName);

            var items = GenericRepo<EventEntity>.GetAll();

            EventsGridView.ItemsSource = items.Select(x => string.Format("{0,-15}{1,-10}{2}{3, -10}{4, 100}", /*items.IndexOf(x).ToString(), */x.Name, x.StartDate.ToString("d"),"--",x.EndDate.ToString("d"), x.Id.ToString()));

            DeleteEventButton.IsEnabled = false;
            EditEventButton.IsEnabled = false;
            AddEventButton.IsEnabled = true;
        }

        private void EventsGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditEventButton.IsEnabled = true;
            DeleteEventButton.IsEnabled = true;
        }

        private void DeleteEventButtonTap(object sender, TappedRoutedEventArgs e)
        {
            var selectedItemString = EventsGridView.SelectedItem.ToString();

            GenericRepo<EventEntity>.Delete(Guid.Parse(selectedItemString.Substring(selectedItemString.Length - GuidLength, GuidLength)));

            RootFrame.Navigate(typeof(EventsViewPage));
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
