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
using App1.Entities;
using App1.Pages;
using App2.Entities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectsAddPage : NavBar
    {
        public SubjectsAddPage()
        {
            this.InitializeComponent();
        }
        private const string NameTextBoxDefaultString = "Name";
        private const string DescriptionTextBoxDefaultString = "Description";

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            NameTextBox.Text = NameTextBoxDefaultString;
            DescriptionTextBox.Text = DescriptionTextBoxDefaultString;

            EvaluationTypeComboBox.Items.Insert(0, EvaluationType.None.ToString());
            EvaluationTypeComboBox.Items.Insert(1, EvaluationType.Test.ToString());
            EvaluationTypeComboBox.Items.Insert(2, EvaluationType.Exam.ToString());
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
            var subjectEntityToAdd = new SubjectEntity
            {
                Name = string.IsNullOrWhiteSpace(NameTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? default(string) : DescriptionTextBox.Text.Trim(),
                EvaluationType = EvaluationTypeComboBox.SelectedItem == null ? EvaluationType.None : (EvaluationType)Enum.ToObject(typeof(EvaluationType), EvaluationTypeComboBox.Items.IndexOf(EvaluationTypeComboBox.SelectedItem)),
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
