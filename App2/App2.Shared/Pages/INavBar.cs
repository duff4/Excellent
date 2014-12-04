using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;

namespace App2.Pages
{
    interface INavBar
    {
        void TasksButtonClick(object sender, RoutedEventArgs e);
        void TasksButtonTap(object sender, TappedRoutedEventArgs e);

        void EventsButtonClick(object sender, RoutedEventArgs e);
        void EventsButtonTap(object sender, TappedRoutedEventArgs e);

        void LecturersButtonClick(object sender, RoutedEventArgs e);
        void LecturersButtonTap(object sender, TappedRoutedEventArgs e);

        void SubjectsButtonClick(object sender, RoutedEventArgs e);
        void SubjectsButtonTap(object sender, TappedRoutedEventArgs e);
    }
}
