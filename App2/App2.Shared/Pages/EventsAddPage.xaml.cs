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
using App2.Entities;
using App2.Extensions;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EventsAddPage : NavBar
    {
        private const string NameTextBoxResourceName = "NameTextBox";
        private const string DescriptionTextBoxResourceName = "DescriptionTextBox";
        private const string StartTextBoxResourceName = "StartString";
        private const string EndTextBoxResourceName = "EndString";
        private const string PlaceComboboxPlaceholderResourceName = "PlaceString";
        private const string PriorityComboboxPlaceholderResourceName = "PriorityString";
        private const string AddButtonTextResourceName = "AddButtonText";
        private const string CancelButtonTextResourceName = "CancelButtonText";
        private const string EditButtonResourceName = "EditButtonText";

        private readonly string _nameTextBoxDefaultString = GlobalResourceLoader.GetString(NameTextBoxResourceName);
        private readonly string _descriptionTextBoxDefaultString = GlobalResourceLoader.GetString(DescriptionTextBoxResourceName);
        private readonly string _placeComboBoxDefaultPlaceholder = GlobalResourceLoader.GetString(PlaceComboboxPlaceholderResourceName);
        private readonly string _priorityComboBoxDefaultPlaceholder = GlobalResourceLoader.GetString(PriorityComboboxPlaceholderResourceName);
        
        private bool _isEditMode = false;
        private EventEntity _editingEventEntity;

        public EventsAddPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetButtonNames(TasksButton, EventsButton, LecturersButton, SubjectsButton);

            if (e.Parameter is string)
            {
                _isEditMode = true;
                var rawIdForAnItemToEdit = e.Parameter as string;

                _editingEventEntity =
                    GenericRepo<EventEntity>.Get(
                        Guid.Parse(rawIdForAnItemToEdit.Substring(rawIdForAnItemToEdit.Length - GuidLength, GuidLength)));

                NameTextBox.Text = string.IsNullOrEmpty(_editingEventEntity.Name)
                    ? _nameTextBoxDefaultString
                    : _editingEventEntity.Name;

                StartDatePicker.Date = _editingEventEntity.StartDate;
                EndDatePicker.Date = _editingEventEntity.EndDate;

                PlaceComboBox.PlaceholderText = string.IsNullOrEmpty(_editingEventEntity.Place)
                    ? _placeComboBoxDefaultPlaceholder
                    : _editingEventEntity.Place;

                PriorityComboBox.PlaceholderText = string.IsNullOrEmpty(_editingEventEntity.Priority.ToString())
                    ? _priorityComboBoxDefaultPlaceholder
                    : _editingEventEntity.Priority.ToString().Localize();

                DescriptionTextBox.Text = string.IsNullOrEmpty(_editingEventEntity.Description)
                    ? _descriptionTextBoxDefaultString
                    : _editingEventEntity.Description;
            }
            else
            {
                NameTextBox.Text = _nameTextBoxDefaultString;
                DescriptionTextBox.Text = _descriptionTextBoxDefaultString;
                PlaceComboBox.PlaceholderText = _placeComboBoxDefaultPlaceholder;
                PriorityComboBox.PlaceholderText = _priorityComboBoxDefaultPlaceholder;
            }

            StartTextBox.Text = GlobalResourceLoader.GetString(StartTextBoxResourceName);
            EndTextBox.Text = GlobalResourceLoader.GetString(EndTextBoxResourceName);
            AddButton.Content = _isEditMode ? GlobalResourceLoader.GetString(EditButtonResourceName) : GlobalResourceLoader.GetString(AddButtonTextResourceName);
            CancelButton.Content = GlobalResourceLoader.GetString(CancelButtonTextResourceName);

            PriorityComboBox.Items.Insert(0, ScheduleActionPriority.Low.ToString().Localize());
            PriorityComboBox.Items.Insert(1, ScheduleActionPriority.Normal.ToString().Localize());
            PriorityComboBox.Items.Insert(2, ScheduleActionPriority.High.ToString().Localize());

            var Places = GenericRepo<PlaceEntity>.GetAll();

            for (var i = 0; i < Places.Count; i++)
            {
                PlaceComboBox.Items.Insert(i, Places[i]);
            }
        }

        private void NameTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim() == _nameTextBoxDefaultString)
                NameTextBox.Text = string.Empty;
        }

        private void NameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                NameTextBox.Text = _nameTextBoxDefaultString;
        }

        private void DescriptionTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionTextBox.Text.Trim() == _descriptionTextBoxDefaultString)
                DescriptionTextBox.Text = string.Empty;
        }

        private void DescriptionTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
                DescriptionTextBox.Text = _descriptionTextBoxDefaultString;
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
            {
                if (_isEditMode)
                {
                    GenericRepo<EventEntity>.Delete(_editingEventEntity.Id);
                }
                GenericRepo<EventEntity>.Insert(eventEntityToAdd);
            }

            RootFrame.Navigate(typeof(EventsViewPage), e);
        }

        private void CancelButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(EventsViewPage), e);
        }
    }
}
