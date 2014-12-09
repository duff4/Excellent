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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

using System;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App2.Entities;
using App2.MyJsonedHTTP;
using App2.ServerEntities;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectsViewPage : NavBar
    {
        private const string AddSubjectResourceName = "AddSubjectButtonText";
        private const string EditSubjectResourceName = "EditSubjectButtonText";
        private const string DeleteSubjectsResourceName = "DeleteSubjectsButtonText";

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
            SetButtonNames(TasksButton, EventsButton, LecturersButton, SubjectsButton);

            AddSubjectButton.Content = GlobalResourceLoader.GetString(AddSubjectResourceName);
            EditSubjectButton.Content = GlobalResourceLoader.GetString(EditSubjectResourceName);
            DeleteSubjectButton.Content = GlobalResourceLoader.GetString(DeleteSubjectsResourceName);

            var items = GenericRepo<SubjectEntity>.GetAll();

            SubjectsGridView.ItemsSource = items.Select(x => string.Format("{0,-15}{1,-15}{2,200}", /*items.IndexOf(x).ToString(), */x.Name, x.EvaluationType, x.Id.ToString()));

            DeleteSubjectButton.IsEnabled = false;
            EditSubjectButton.IsEnabled = false;
            AddSubjectButton.IsEnabled = true;
        }

        private void SubjectsGridViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteSubjectButton.IsEnabled = true;
            EditSubjectButton.IsEnabled = true;
        }

        private void DeleteSubjectButtonTap(object sender, TappedRoutedEventArgs e)
        {
            var selectedItemString = SubjectsGridView.SelectedItem.ToString();

            GenericRepo<SubjectEntity>.Delete(Guid.Parse(selectedItemString.Substring(selectedItemString.Length - GuidLength, GuidLength)));

            RootFrame.Navigate(typeof(SubjectsViewPage));
        }

        private void AddSubjectButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof (SubjectsAddPage), e);
        }

        private void EditSubjectButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof (SubjectsAddPage), SubjectsGridView.SelectedItem);
        }
    }
}
