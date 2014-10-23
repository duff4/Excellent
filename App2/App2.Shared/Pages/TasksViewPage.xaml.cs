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
using App1.Pages;
using App2.Entities;

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TasksViewPage : NavBar
    {
        public TasksViewPage()
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
            var items = GenericRepo<TaskEntity>.GetSome();

            TasksGridView.ItemsSource = items.Select(x => string.Format("{0,-15}{1,-15}{2,-10}", /*items.IndexOf(x).ToString(), */x.Name, x.Description, x.DeadLine.Date.ToString("d")));

            DeleteTaskButton.IsEnabled = false;
            EditTaskButton.IsEnabled = false;
            AddTask.IsEnabled = true;
        }

        private void AddTaskButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof (TasksAddPage), e);
        }

        private void TasksGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteTaskButton.IsEnabled = true;
            EditTaskButton.IsEnabled = true;
        }

        private void DeleteTaskButtonTap(object sender, TappedRoutedEventArgs e)
        {
            //var selectedItem = TasksGridView.SelectedItem;

            //GenericRepo<TaskEntity>.Delete(selectedItem);
            var items = GenericRepo<TaskEntity>.GetSome();

            TasksGridView.ItemsSource = items.Select(x => string.Format("{0,-4}{1,-10}{2,30}", items.IndexOf(x).ToString(), x.Name, x.Description));

            DeleteTaskButton.IsEnabled = false;
            EditTaskButton.IsEnabled = false;
        }

        private void EditTaskButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof (TasksAddPage), TasksGridView.SelectedItem);
        }
    }
}
