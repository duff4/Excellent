using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace App1.Pages
{
    public class NavBar : Page, INavBar
    {
        private static Frame RootFrame
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

        public void CalendarButtonClick(object sender, RoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(CalendarViewPage), e);
        }

        public void CalendarButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(CalendarViewPage), e);
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
