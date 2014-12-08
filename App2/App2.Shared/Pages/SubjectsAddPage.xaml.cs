using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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
using App2.Extensions;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectsAddPage : NavBar
    {
        private const string NameTextBoxResourceName = "NameTextBox";
        private const string DescriptionTextBoxResourceName = "DescriptionTextBox";
        private const string EvaluationTypeComboboxPlaceholderResourceName = "EvaluationTypeString";
        private const string AddButtonTextResourceName = "AddButtonText";
        private const string CancelButtonTextResourceName = "CancelButtonText";

        private readonly string _nameTextBoxDefaultString = GlobalResourceLoader.GetString(NameTextBoxResourceName);
        private readonly string _descriptionTextBoxDefaultString = GlobalResourceLoader.GetString(DescriptionTextBoxResourceName);

        private bool _isEditMode = false;
        private TaskEntity editingTaskEntity;

        public SubjectsAddPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SetButtonNames(TasksButton, EventsButton, LecturersButton, SubjectsButton);

            AddButton.Content = GlobalResourceLoader.GetString(AddButtonTextResourceName);
            CancelButton.Content = GlobalResourceLoader.GetString(CancelButtonTextResourceName);
            EvaluationTypeComboBox.PlaceholderText = GlobalResourceLoader.GetString(EvaluationTypeComboboxPlaceholderResourceName);

            NameTextBox.Text = _nameTextBoxDefaultString;
            DescriptionTextBox.Text = _descriptionTextBoxDefaultString;

            EvaluationTypeComboBox.Items.Insert(0, EvaluationType.None.ToString().Localize());
            EvaluationTypeComboBox.Items.Insert(1, EvaluationType.Test.ToString().Localize());
            EvaluationTypeComboBox.Items.Insert(2, EvaluationType.Exam.ToString().Localize());
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

        private void AddButtonTap(object sender, TappedRoutedEventArgs e)
        {
            var subjectEntityToAdd = new SubjectEntity
            {
                Name = string.IsNullOrWhiteSpace(NameTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? default(string) : DescriptionTextBox.Text.Trim(),
                EvaluationType = EvaluationTypeComboBox.SelectedItem == null ? EvaluationType.None : (EvaluationType)Enum.ToObject(typeof(EvaluationType), EvaluationTypeComboBox.Items.IndexOf(EvaluationTypeComboBox.SelectedItem)),
                //UserId = GenericRepo<ServerCredentials>.GetFirst().Id,
                Updated = DateTime.Now
            };

            if (!(string.IsNullOrWhiteSpace(subjectEntityToAdd.Name) && !(string.IsNullOrWhiteSpace(subjectEntityToAdd.Description))))
                GenericRepo<SubjectEntity>.Insert(subjectEntityToAdd);

            RootFrame.Navigate(typeof(SubjectsViewPage), e);
        }


        private void CancelButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(SubjectsViewPage), e);
        }
    }
}
