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

namespace App1.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TasksAddPage : NavBar
    {
        public TasksAddPage()
        {
            this.InitializeComponent();
        }

        private const string NameTextBoxDefaultString = "Name";
        private const string DescriptionTextBoxDefaultString = "Description";

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NameTextBox.Text = NameTextBoxDefaultString;
            DescriptionTextBox.Text = DescriptionTextBoxDefaultString;

            DifficultyComboBox.Items.Insert(0, TaskEntityDifficulty.Easy.ToString());
            DifficultyComboBox.Items.Insert(1, TaskEntityDifficulty.Medium.ToString());
            DifficultyComboBox.Items.Insert(2, TaskEntityDifficulty.Hard.ToString());

            var Subjects = GenericRepo<SubjectEntity>.GetSome();

            for (var i = 0; i < Subjects.Count; i++)
            {
                SubjectComboBox.Items.Insert(i, Subjects[i].Name);
            }

            var Lecturers = GenericRepo<LecturerEntity>.GetSome();

            for (var i = 0; i < Lecturers.Count; i++)
            {
                LecturerComboBox.Items.Insert(i, Lecturers[i].Name);
            }

        }

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

        private void AddButtonTap(object sender, TappedRoutedEventArgs e)
        {
            var taskEntityToAdd = new TaskEntity
            {
                Name = string.IsNullOrWhiteSpace(NameTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? default(string) : DescriptionTextBox.Text.Trim(),
                Difficulty = DifficultyComboBox.SelectedItem == null ? TaskEntityDifficulty.Easy : (TaskEntityDifficulty)Enum.ToObject(typeof(TaskEntityDifficulty), DifficultyComboBox.Items.IndexOf(DifficultyComboBox.SelectedItem)),
                Subject = SubjectComboBox.SelectedItem == null ? default(string) : SubjectComboBox.SelectedItem.ToString(),
                Lecturer = LecturerComboBox.SelectedItem == null ? default(string) : LecturerComboBox.SelectedItem.ToString(),
                DeadLine = DatePicker.Date,
                IsCompleted = IsCompletedCheckBox.IsChecked.Value
            };

            if (!(string.IsNullOrWhiteSpace(taskEntityToAdd.Name) && !(string.IsNullOrWhiteSpace(taskEntityToAdd.Description))))
                GenericRepo<TaskEntity>.Insert(taskEntityToAdd);

            RootFrame.Navigate(typeof (TasksViewPage), e);
        }

        private void CancelButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(TasksViewPage), e);
        }
    }
}
