using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using App2.ServerEntities;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Windows.Web.Http;
using App2.Entities;
using App2.MyJsonedHTTP;
using Newtonsoft.Json;
using HttpClient = System.Net.Http.HttpClient;

namespace App2.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LogInPage : NavBar
    {
        public LogInPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LogInButton.Content = GlobalResourceLoader.GetString("LogInButtonString");
            LogInTextBox.PlaceholderText = GlobalResourceLoader.GetString("UserNameTextBoxString");
            LogInTextBlock.Text = GlobalResourceLoader.GetString("LogInTextBlockString");
        }

        private async void LogInButtonTap(object sender, TappedRoutedEventArgs e)
        {
            /*
            var response = await MyHttpFramework.SerializeObjectPostItToServerAndGetResponse(new ClientCredentials
            {
                login = LogInTextBox.Text,
                password = PasswordPasswordBox.Password
            }, "http://178.62.237.79:8080/login");

            if (response == null)
            {
                return;
            }

            var cleanServerCredentials = JsonConvert.DeserializeObject<ServerCredentials>(response.Data);

            cleanServerCredentials.Cookies = response.Cookies;

            GenericRepo<ServerCredentials>.Insert(cleanServerCredentials);

            var a = new List<IEntity>();

            var subjects =
                GenericRepo<SubjectEntity>.GetAll().Where(x => x.Updated > cleanServerCredentials.LastUpdated && x.UserId == cleanServerCredentials.Id);
            var events = GenericRepo<EventEntity>.GetAll().Where(x => x.Updated > cleanServerCredentials.LastUpdated && x.UserId == cleanServerCredentials.Id);
            var lecturers = GenericRepo<LecturerEntity>.GetAll().Where(x => x.Updated > cleanServerCredentials.LastUpdated && x.UserId == cleanServerCredentials.Id);
            var tasks = GenericRepo<TaskEntity>.GetAll().Where(x => x.Updated > cleanServerCredentials.LastUpdated && x.UserId == cleanServerCredentials.Id);



            a.AddRange(subjects);
            a.AddRange(events);
            a.AddRange(lecturers);
            a.AddRange(tasks);

            var b = new ServerGeneralRequest {LastUpdate = cleanServerCredentials.LastUpdated, Entities = a};

            var c = await MyHttpFramework.Sync(b, cleanServerCredentials);
            */
            Frame.Navigate(typeof (TasksViewPage));
        }
    }
}
