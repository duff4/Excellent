// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

using System;
using System.Linq;
using System.Xml.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App2.Entities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TasksViewPage : NavBar
    {
        private const string AddTaskResourceName = "AddTaskButtonText";
        private const string EditTaskResourceName = "EditTaskButtonText";
        private const string DeleteTaskResourceName = "DeleteTaskButtonText";

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
            SetButtonNames(TasksButton, EventsButton, LecturersButton, SubjectsButton);

            AddTaskButton.Content = GlobalResourceLoader.GetString(AddTaskResourceName);
            EditTaskButton.Content = GlobalResourceLoader.GetString(EditTaskResourceName);
            DeleteTaskButton.Content = GlobalResourceLoader.GetString(DeleteTaskResourceName);

            var items = GenericRepo<TaskEntity>.GetAll();

            TasksGridView.ItemsSource = items.Select(x => string.Format("{0,-30}{1,-70}{2, 100}", /*items.IndexOf(x).ToString(), */x.Name/*, x.Description*/, x.DeadLine.Date.ToString("d"), x.Id));

            DeleteTaskButton.IsEnabled = false;
            EditTaskButton.IsEnabled = false;
            AddTaskButton.IsEnabled = true;
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
            var selectedItemString = TasksGridView.SelectedItem.ToString();

            GenericRepo<TaskEntity>.Delete(Guid.Parse(selectedItemString.Substring(selectedItemString.Length - GuidLength, GuidLength)));

            RootFrame.Navigate(typeof (TasksViewPage));
        }

        private void EditTaskButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof (TasksAddPage), TasksGridView.SelectedItem);
        }
    }
}
