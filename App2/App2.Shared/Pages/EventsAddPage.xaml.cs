using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Appointments;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using App1.Entities;
using App1.Pages;
using App2.Entities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsAddPage : NavBar
    {
        public EventsAddPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NameTextBox.Text = NameTextBoxDefaultString;
            DescriptionTextBox.Text = DescriptionTextBoxDefaultString;

            PriorityComboBox.Items.Insert(0, ScheduleActionPriority.Low.ToString());
            PriorityComboBox.Items.Insert(1, ScheduleActionPriority.Normal.ToString());
            PriorityComboBox.Items.Insert(2, ScheduleActionPriority.High.ToString());

            var Places = GenericRepo<PlaceEntity>.GetSome();

            for (var i = 0; i < Places.Count; i++)
            {
                PlaceComboBox.Items.Insert(i, Places[i]);
            }
        }

        private const string NameTextBoxDefaultString = "Name";
        private const string DescriptionTextBoxDefaultString = "Description";

        private void NameTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim() == NameTextBoxDefaultString)
                NameTextBox.Text = string.Empty;
        }

        private void NameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                NameTextBox.Text = NameTextBoxDefaultString;
        }

        private void DescriptionTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionTextBox.Text.Trim() == DescriptionTextBoxDefaultString)
                DescriptionTextBox.Text = string.Empty;
        }

        private void DescriptionTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
                DescriptionTextBox.Text = DescriptionTextBoxDefaultString;
        }

        private async void AddButtonTap(object sender, TappedRoutedEventArgs e)
        {
            if (StartDatePicker.Date > EndDatePicker.Date)
            {
                var errorMessageDialog = new MessageDialog("End date is behind the start date");

                await errorMessageDialog.ShowAsync();
                
                return;
            }

            var eventEntityToAdd = new EventEntity
            {
                Name = string.IsNullOrWhiteSpace(NameTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? default(string) : DescriptionTextBox.Text.Trim(),
                Priority = PriorityComboBox.SelectedItem == null ? ScheduleActionPriority.Low : (ScheduleActionPriority)Enum.ToObject(typeof(ScheduleActionPriority), PriorityComboBox.Items.IndexOf(PriorityComboBox.SelectedItem)),
                StartDate = StartDatePicker.Date,
                EndDate = EndDatePicker.Date
            };

            if (!(string.IsNullOrWhiteSpace(eventEntityToAdd.Name) && !(string.IsNullOrWhiteSpace(eventEntityToAdd.Description))))
                GenericRepo<EventEntity>.Insert(eventEntityToAdd);

            RootFrame.Navigate(typeof(EventsViewPage), e);
        }

        private void CancelButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(EventsViewPage), e);
        }
    }
}
