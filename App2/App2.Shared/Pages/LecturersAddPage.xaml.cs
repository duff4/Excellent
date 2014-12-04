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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using App2.Entities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LecturersAddPage :NavBar
    {
        private const string NameTextBoxResourceName = "NameTextBox";
        private const string AdditionalInformationTextBoxResourceName = "AdditionalInformationTextBox";
        private const string PositionTextBoxResourceName = "PositionTextBox";
        private const string EmailTextBoxResourceName = "EmailTextBox";
        private const string PhoneTextBoxResourceName = "PhoneTextBox";

        private readonly string _nameTextBoxDefaultString = GlobalResourceLoader.GetString(NameTextBoxResourceName);
        private readonly string _additionalInforamtionTextBoxDefaultString = GlobalResourceLoader.GetString(AdditionalInformationTextBoxResourceName);
        private readonly string _positionTextBoxDefaultString = GlobalResourceLoader.GetString(PositionTextBoxResourceName);
        private readonly string _emailTextBoxDefaultString = GlobalResourceLoader.GetString(EmailTextBoxResourceName);
        private readonly string _phoneTextBoxDefaultString = GlobalResourceLoader.GetString(PhoneTextBoxResourceName);

        private bool _isEditMode = false;
        private TaskEntity editingTaskEntity;

        public LecturersAddPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetButtonNames(TasksButton, EventsButton, LecturersButton, SubjectsButton);
            NameTextBox.Text = _nameTextBoxDefaultString;
            AdditionalInformationTextBox.Text = _additionalInforamtionTextBoxDefaultString;
            PositionTextBox.Text = _positionTextBoxDefaultString;
            EmailTextBox.Text = _emailTextBoxDefaultString;
            PhoneTextBox.Text = _phoneTextBoxDefaultString;
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

        private void AdditionalInformationTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (AdditionalInformationTextBox.Text.Trim() == _additionalInforamtionTextBoxDefaultString)
                AdditionalInformationTextBox.Text = string.Empty;
        }

        private void AdditionalInformationTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AdditionalInformationTextBox.Text))
                AdditionalInformationTextBox.Text = _additionalInforamtionTextBoxDefaultString;
        }

        private void PositionTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (PositionTextBox.Text.Trim() == _positionTextBoxDefaultString)
                PositionTextBox.Text = string.Empty;
        }

        private void PositionTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PositionTextBox.Text))
                PositionTextBox.Text = _positionTextBoxDefaultString;
        }

        private void EmailTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text.Trim() == _emailTextBoxDefaultString)
                EmailTextBox.Text = string.Empty;
        }

        private void EmailTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
                EmailTextBox.Text = _emailTextBoxDefaultString;
        }

        private void PhoneTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (PhoneTextBox.Text.Trim() == _phoneTextBoxDefaultString)
                PhoneTextBox.Text = string.Empty;
        }

        private void PhoneTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneTextBox.Text))
                PhoneTextBox.Text = _phoneTextBoxDefaultString;
        }

        private async void AddButtonTap(object sender, TappedRoutedEventArgs e)
        {
            var eventEntityToAdd = new LecturerEntity
            {
                Name = string.IsNullOrWhiteSpace(NameTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                AdditionalInformation = string.IsNullOrWhiteSpace(AdditionalInformationTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(EmailTextBox.Text) ? default(string) : EmailTextBox.Text.Trim(),
                Phone = string.IsNullOrWhiteSpace(PhoneTextBox.Text) ? default(string) : PhoneTextBox.Text.Trim(),
                Position = string.IsNullOrWhiteSpace(PositionTextBox.Text) ? default(string) : PositionTextBox.Text.Trim()
            };

            if (!(string.IsNullOrWhiteSpace(eventEntityToAdd.Name)))
                GenericRepo<EventEntity>.Insert(eventEntityToAdd);

            RootFrame.Navigate(typeof(LecturersViewPage), e);
        }

        private async void CancelButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(LecturersViewPage), e);
        }
    }
}
