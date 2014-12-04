// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556
using System;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Xml.Linq;
using Windows.ApplicationModel.Contacts;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using App1;
using App2.Entities;
using App2.Extensions;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TasksAddPage : NavBar
    {

        private const string NameTextBoxResourceName = "NameTextBox";
        private const string DescriptionTextBoxResourceName = "DescriptionTextBox";
        private const string DifficiltyComboboxPlaceholderResourceName = "DifficultyString";
        private const string SubjectComboboxPlaceholderResourceName = "SubjectString";
        private const string LecturerComboboxPlaceholderResourceName = "LecturerString";
        private const string CompletedTextBoxResourceName = "CompletedString";
        private const string AddButtonTextResourceName = "AddButtonText";
        private const string CancelButtonTextResourceName = "CancelButtonText";
        private const string EditButtonResourceName = "EditButtonText";

        private readonly string _nameTextBoxDefaultString = GlobalResourceLoader.GetString(NameTextBoxResourceName);
        private readonly string _descriptionTextBoxDefaultString = GlobalResourceLoader.GetString(DescriptionTextBoxResourceName);
        private readonly string _difficultyComboBoxDefaultPlaceholder = GlobalResourceLoader.GetString(DifficiltyComboboxPlaceholderResourceName);
        private readonly string _subjectComboBoxDefaultPlaceholder = GlobalResourceLoader.GetString(SubjectComboboxPlaceholderResourceName);
        private readonly string _lecturerComboBoxDefaultPlaceholder = GlobalResourceLoader.GetString(LecturerComboboxPlaceholderResourceName);

        private bool _isEditMode = false;
        private TaskEntity _editingTaskEntity;


        public TasksAddPage()
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

            if (e.Parameter is string)
            {
                _isEditMode = true;
                var rawIdForAnItemToEdit = e.Parameter as string;

                _editingTaskEntity =
                    GenericRepo<TaskEntity>.Get(
                        Guid.Parse(rawIdForAnItemToEdit.Substring(rawIdForAnItemToEdit.Length - GuidLength, GuidLength)));

                NameTextBox.Text = string.IsNullOrEmpty(_editingTaskEntity.Name)
                    ? _nameTextBoxDefaultString
                    : _editingTaskEntity.Name;

                DescriptionTextBox.Text = string.IsNullOrEmpty(_editingTaskEntity.Description)
                    ? _descriptionTextBoxDefaultString
                    : _editingTaskEntity.Description;

                DifficultyComboBox.PlaceholderText = string.IsNullOrEmpty(_editingTaskEntity.Difficulty.ToString())
                    ? _difficultyComboBoxDefaultPlaceholder.Localize()
                    : _editingTaskEntity.Difficulty.ToString().Localize();

                SubjectComboBox.PlaceholderText = string.IsNullOrEmpty(_editingTaskEntity.Subject)
                    ? _subjectComboBoxDefaultPlaceholder
                    : _editingTaskEntity.Subject;

                LecturerComboBox.PlaceholderText = string.IsNullOrEmpty(_editingTaskEntity.Lecturer)
                    ? _lecturerComboBoxDefaultPlaceholder
                    : _editingTaskEntity.Lecturer;

                IsCompletedCheckBox.IsChecked = _editingTaskEntity.IsCompleted;
            }
            else
            {
                NameTextBox.Text = _nameTextBoxDefaultString;
                DescriptionTextBox.Text = _descriptionTextBoxDefaultString;
                DifficultyComboBox.PlaceholderText = _difficultyComboBoxDefaultPlaceholder;
                SubjectComboBox.PlaceholderText = _subjectComboBoxDefaultPlaceholder;
                LecturerComboBox.PlaceholderText = _lecturerComboBoxDefaultPlaceholder;
            }

            IsCompletedCheckBox.Content = GlobalResourceLoader.GetString(CompletedTextBoxResourceName);
            AddButton.Content = _isEditMode ? GlobalResourceLoader.GetString(EditButtonResourceName) : GlobalResourceLoader.GetString(AddButtonTextResourceName);
            CancelButton.Content = GlobalResourceLoader.GetString(CancelButtonTextResourceName);


            DifficultyComboBox.Items.Insert(0, TaskEntityDifficulty.Easy.ToString().Localize());
            DifficultyComboBox.Items.Insert(1, TaskEntityDifficulty.Medium.ToString().Localize());
            DifficultyComboBox.Items.Insert(2, TaskEntityDifficulty.Hard.ToString().Localize());

            var Subjects = GenericRepo<SubjectEntity>.GetAll();

            for (var i = 0; i < Subjects.Count; i++)
            {
                SubjectComboBox.Items.Insert(i, Subjects[i].Name);
            }

            var Lecturers = GenericRepo<LecturerEntity>.GetAll();

            for (var i = 0; i < Lecturers.Count; i++)
            {
                LecturerComboBox.Items.Insert(i, Lecturers[i].Name);
            }

        }

        private void NameTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text.Trim() == _nameTextBoxDefaultString)
                NameTextBox.Text = string.Empty;
        }

        private void NameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                NameTextBox.Text = _nameTextBoxDefaultString;
        }

        private void DescriptionTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (DescriptionTextBox.Text.Trim() == _descriptionTextBoxDefaultString)
                DescriptionTextBox.Text = string.Empty;
        }

        private void DescriptionTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
                DescriptionTextBox.Text = _descriptionTextBoxDefaultString;
        }

        private void AddButtonTap(object sender, TappedRoutedEventArgs e)
        {
            var taskEntityToAdd = new TaskEntity
            {
                Name = string.IsNullOrWhiteSpace(NameTextBox.Text) ? default(string) : NameTextBox.Text.Trim(),
                Description = string.IsNullOrWhiteSpace(DescriptionTextBox.Text) ? default(string) : DescriptionTextBox.Text.Trim(),
                Difficulty = DifficultyComboBox.SelectedItem == null ? TaskEntityDifficulty.Easy : (TaskEntityDifficulty)Enum.ToObject(typeof(TaskEntityDifficulty), DifficultyComboBox.Items.IndexOf(DifficultyComboBox.SelectedItem)),
                Subject = SubjectComboBox.SelectedItem == null ? default(string) : SubjectComboBox.SelectedItem.ToString(),
                Lecturer = LecturerComboBox.SelectedItem == null ? default(string) : LecturerComboBox.SelectedItem.ToString(),
                DeadLine = DatePicker.Date,
                IsCompleted = IsCompletedCheckBox.IsChecked.Value
            };

            if (!(string.IsNullOrWhiteSpace(taskEntityToAdd.Name) && !(string.IsNullOrWhiteSpace(taskEntityToAdd.Description))))
            {
                if (_isEditMode)
                {
                    GenericRepo<TaskEntity>.Delete(_editingTaskEntity.Id);
                }
                GenericRepo<TaskEntity>.Insert(taskEntityToAdd);
            }

            RootFrame.Navigate(typeof(TasksViewPage), e);
        }

        private void CancelButtonTap(object sender, TappedRoutedEventArgs e)
        {
            RootFrame.Navigate(typeof(TasksViewPage), e);
        }
    }
}
