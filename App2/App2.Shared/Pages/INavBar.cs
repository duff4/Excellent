/*
 * Excellent - Student Organizer
 * Copyright (c ) 2014, Alexander Davydov, All rights reserved.
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3.0 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library.
 */

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
