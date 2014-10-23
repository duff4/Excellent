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
    public sealed partial class SubjectsViewPage : NavBar
    {
        public SubjectsViewPage()
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
            var items = GenericRepo<SubjectEntity>.GetSome();

            SubjectsGridView.ItemsSource = items.Select(x => string.Format("{0,-15}{1,-15}{2,-10}", /*items.IndexOf(x).ToString(), */x.Name, x.Description, x.EvaluationType));

            EditSubjectButton.IsEnabled = false;
            AddSubjectButton.IsEnabled = true;
        }

        private void SubjectsGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EditSubjectButton.IsEnabled = true;
        }

        private void AddSubjectButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof (SubjectsAddPage), e);
        }

        private void EditSubjectButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(SubjectsAddPage), SubjectsGridView.SelectedItem);
        }
    }
}
