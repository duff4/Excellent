using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using App2.Entities;

namespace App2.Pages
{
    public class NavBar : Page, INavBar
    {
        protected const short GuidLength = 36;

        private const string TasksButtonResourceName = "TasksStringInUpperCase";
        private const string EventsButtonResourceName = "EventsStringInUpperCase";
        private const string LecturersButtonResourceName = "LecturersStringInUpperCase";
        private const string SubjectsButtonResourceName = "SubjectsStringInUpperCase";

        public static readonly ResourceLoader GlobalResourceLoader = new ResourceLoader(GenericRepo<Language>.GetFirst().SelectedCultureString);

        private static readonly string TasksButtonString = GlobalResourceLoader.GetString(TasksButtonResourceName);
        private static readonly string EventsButtonString = GlobalResourceLoader.GetString(EventsButtonResourceName);
        private static readonly string LecturersButtonString = GlobalResourceLoader.GetString(LecturersButtonResourceName);
        private static readonly string SubjectsButtonString = GlobalResourceLoader.GetString(SubjectsButtonResourceName);

        protected static void SetButtonNames(Button tasksButton, 
            Button eventsButton, 
            Button LecturersButton,
            Button subjectsButton)
        {
            tasksButton.Content = TasksButtonString;
            eventsButton.Content = EventsButtonString;
            LecturersButton.Content = LecturersButtonString;
            subjectsButton.Content = SubjectsButtonString;
        }

        protected static Frame RootFrame
        {
            get { return Window.Current.Content as Frame; }
        }

        public void TasksButtonClick(object sender, RoutedEventArgs e)
        {
            if(Window.Current.Content.GetType() != typeof(TasksViewPage))
            RootFrame.Navigate(typeof(TasksViewPage), e);
        }

        public void TasksButtonTap(object sender, TappedRoutedEventArgs e)
        {
            if (Window.Current.Content.GetType() != typeof(TasksViewPage))
            RootFrame.Navigate(typeof(TasksViewPage), e);
        }

        public void EventsButtonClick(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(EventsViewPage), e);
        }

        public void EventsButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(EventsViewPage), e);
        }

        public void LecturersButtonClick(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(LecturersViewPage), e);
        }

        public void LecturersButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(LecturersViewPage), e);
        }

        public void SubjectsButtonClick(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(SubjectsViewPage), e);
        }

        public void SubjectsButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(SubjectsViewPage), e);
        }
    }
}
