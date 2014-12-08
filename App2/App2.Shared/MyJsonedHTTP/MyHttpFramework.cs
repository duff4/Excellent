using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Animation;
using App2.Entities;
using App2.Pages;
using App2.ServerEntities;
using Newtonsoft.Json;

namespace App2.MyJsonedHTTP
{
    internal class MyHttpFramework
    {
        public static async Task<DataAndCookies> SerializeObjectPostItToServerAndGetResponse(object objectToSerialize,
            string path)
        {
            var serializedCredentialsAsbytes =
                Encoding.UTF8.GetBytes(
                    JsonConvert.SerializeObject(objectToSerialize));

            HttpWebRequest clientRequest = (HttpWebRequest) WebRequest.Create(path);

            clientRequest.Method = "POST";

            clientRequest.ContentType = "application/json";

            var dataStream = await clientRequest.GetRequestStreamAsync();

            dataStream.Write(serializedCredentialsAsbytes, 0, serializedCredentialsAsbytes.Length);

            WebResponse serverResponse = null;
            Exception possibleException = null;

            try
            {
                serverResponse = await clientRequest.GetResponseAsync();
            }
            catch (Exception webEx)
            {
                possibleException = webEx;
            }

            if (possibleException != null)
            {
                var errorMessageDialog = new MessageDialog("There was an exception: \n" + possibleException.Message);

                await errorMessageDialog.ShowAsync();

                return null;
            }

            var serverResponseReader = serverResponse.GetResponseStream();

            var serverResponseAsBytes = new byte[500];

            serverResponseReader.Read(serverResponseAsBytes, 0, 500);

            var serverResponseAsString = Encoding.UTF8.GetString(serverResponseAsBytes, 0, serverResponseAsBytes.Length);
            var serverCookies = string.IsNullOrEmpty(serverResponse.Headers["Set-Cookie"])
                ? string.Empty
                : serverResponse.Headers["Set-Cookie"];
            return new DataAndCookies {Data = serverResponseAsString, Cookies = serverCookies};
        }

        public static async Task<IEnumerable<IEntity>> Sync (ServerGeneralRequest request, ServerCredentials usersCredentials)
        {
            var serializedObjectsAsbytes =
                   Encoding.UTF8.GetBytes(
                       JsonConvert.SerializeObject(request));

            var clientRequest = (HttpWebRequest)WebRequest.Create("http://178.62.237.79:8080/sync");

            clientRequest.Headers[HttpRequestHeader.Cookie] = usersCredentials.Cookies;

            clientRequest.Method = "POST";

            clientRequest.ContentType = "application/json";

            var dataStream = await clientRequest.GetRequestStreamAsync();

            dataStream.Write(serializedObjectsAsbytes, 0, serializedObjectsAsbytes.Length);

            WebResponse serverResponse = null;
            Exception possibleException = null;

            try
            {
                serverResponse = await clientRequest.GetResponseAsync();
            }
            catch (WebException webEx)
            {
                possibleException = webEx;
            }

            if (possibleException != null)
            {
                var errorMessageDialog = new MessageDialog("There was an exception: \n" + possibleException.Message);

                await errorMessageDialog.ShowAsync();

                return null;
            }

            var serverResponseReader = serverResponse.GetResponseStream();

            var serverResponseAsBytes = new byte[5000];

            serverResponseReader.Read(serverResponseAsBytes, 0, 5000);

            var serverResponseAsString = Encoding.UTF8.GetString(serverResponseAsBytes, 0, serverResponseAsBytes.Length);

            return JsonConvert.DeserializeObject<IEnumerable<IEntity>>(serverResponseAsString);
        }

        public class DataAndCookies
        {
            public string Data { get; set; }
            public string Cookies { get; set; }
        }
    }
}
