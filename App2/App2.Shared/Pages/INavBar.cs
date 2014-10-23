using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace App1.Pages
{
    interface INavBar
    {
        void TasksButtonClick(object sender, RoutedEventArgs e);
        void TasksButtonTap(object sender, TappedRoutedEventArgs e);

        void EventsButtonClick(object sender, RoutedEventArgs e);
        void EventsButtonTap(object sender, TappedRoutedEventArgs e);

        void CalendarButtonClick(object sender, RoutedEventArgs e);
        void CalendarButtonTap(object sender, TappedRoutedEventArgs e);

        void SubjectsButtonClick(object sender, RoutedEventArgs e);
        void SubjectsButtonTap(object sender, TappedRoutedEventArgs e);
    }
}
