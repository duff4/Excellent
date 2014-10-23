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
            TasksGridView.ItemsSource = GenericRepo<ActivityEntity>.GetSome().Select(x => x.Description);
            DeleteTaskButton.IsEnabled = false;
            EditTaskButton.IsEnabled = false;
            AddTask.IsEnabled = true;
        }

        private void AddTaskButtonTap(object sender, TappedRoutedEventArgs e)
        {
            //var someActivityEntity = new ActivityEntity { Description = "this is a description", Name = "this is a name" };

            //GenericRepo<ActivityEntity>.Insert(someActivityEntity);

            //var checkActivityEntity = GenericRepo<ActivityEntity>.Get(someActivityEntity.Id);
            //TextBox1.Text = checkActivityEntity.Description;

            //TasksGridView.ItemsSource = GenericRepo<ActivityEntity>.GetSome();
        }

        private void AddTaskButtonClick(object sender, RoutedEventArgs e)
        {
            var someActivityEntity = new ActivityEntity { Description = "this is a description", Name = "this is a name" };

            GenericRepo<ActivityEntity>.Insert(someActivityEntity);

            var checkActivityEntity = GenericRepo<ActivityEntity>.Get(someActivityEntity.Id);
            TextBox1.Text = checkActivityEntity.Description;

            TasksGridView.ItemsSource = GenericRepo<ActivityEntity>.GetSome().Select(x => x.Id);

            DeleteTaskButton.IsEnabled = false;
            EditTaskButton.IsEnabled = false;
            //var rootFrame = Window.Current.Content as Frame;

            //rootFrame.Navigate(typeof(TasksAddPage), e);
        }

        private void DeleteTaskButtonClick(object sender, RoutedEventArgs e)
        {
            var selectedItem = TasksGridView.SelectedItem;

            GenericRepo<ActivityEntity>.Delete(selectedItem);

            TasksGridView.ItemsSource = GenericRepo<ActivityEntity>.GetSome().Select(x => x.Id);

            DeleteTaskButton.IsEnabled = false;
            EditTaskButton.IsEnabled = false;
        }

        private void TasksGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteTaskButton.IsEnabled = true;
            EditTaskButton.IsEnabled = true;
        }

        private void RefreshGridView()
        {
            
        }
    }
}
