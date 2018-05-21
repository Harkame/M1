using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        private static readonly HttpClient g_librarian_client = new HttpClient(); //HTTP client who are used to send HTTP request
        private static readonly HttpClient g_subscriber_client = new HttpClient(); //HTTP client who are used to send HTTP request

        private static readonly string SERVER_URL = "http://localhost:";
        private static readonly int PORT = 31101;
        private static readonly string SERVER_COMPLETE_URL = SERVER_URL + PORT + "/";
        private static readonly string TOKEN_URL = SERVER_COMPLETE_URL + "oauth2/token";
        private static readonly string SERVER_API_URL = SERVER_COMPLETE_URL + "api/";
        private static readonly string BOOKS_CONTROLLER_URL = SERVER_API_URL + "books/";
        private static readonly string COMMENTS_CONTROLLER_URL = SERVER_API_URL + "comments/";
        private static readonly string LIBRARIANS_CONTROLLER_URL = SERVER_API_URL + "librarians/";
        private static readonly string SUBSCRIBERS_CONTROLLER_URL = SERVER_API_URL + "subscribers/";

        private static UriBuilder g_uri_builder; //Build of HTTP request's URI
        private static Dictionary<String, String> g_parameters; //Parameters of HTTP Post request
        private static string g_librarian_access_token;
        private static string g_subscriber_access_token;
        private static HttpRequestResult g_http_request_result;

        static void Main(string[] args)
        {
            Console.WriteLine("Librarian");

            TestLibrarian();

            Console.WriteLine("------------------------");

            Console.WriteLine("Client");

            TestSubscriber();

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();
        }

        public static void TestLibrarian()
        {
            Console.WriteLine("GetBooks : UnAuthentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBooks");
            Console.WriteLine(SendGetRequest(g_librarian_client, g_uri_builder.Uri).Result.State);

            Console.WriteLine("PostBook : Unauthentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "PostBook");
            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Title", "Title1"},
                {"Author", "Author1"},
                {"Stock", 5 + ""},
                {"Editor", "Editor1"}
            };

            Console.WriteLine(SendPostRequest(g_librarian_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result.State);

            g_uri_builder = new UriBuilder(TOKEN_URL);

            g_parameters = new Dictionary<String, String>
            {
                {"grant_type", "password"},
                {"username", "librarian0"},
                {"password", "password123"}
            };

            g_http_request_result = SendPostRequest(g_librarian_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result;

            var t_j_object = JObject.Parse(g_http_request_result.Content);
            g_librarian_access_token = t_j_object["access_token"].ToString();

            Console.WriteLine("Token : " + g_librarian_access_token);

            g_librarian_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + g_librarian_access_token);

            Console.WriteLine("GetBooks : Authentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBooks");
            Console.WriteLine(SendGetRequest(g_librarian_client, g_uri_builder.Uri).Result.State);

            Console.WriteLine("PostBook : Authentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "PostBook");
            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Title", "Title1"},
                {"Author", "Author1"},
                {"Stock", 5 + ""},
                {"Editor", "Editor1"}
            };

            Console.WriteLine(SendPostRequest(g_librarian_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result.State);

            Console.WriteLine("Postcomment : Authentified as Librarian");
            g_uri_builder = new UriBuilder(COMMENTS_CONTROLLER_URL + "PostComment");

            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Description", "UnCommentaireTest"},
                {"BookID", 2 + ""},
                {"SubscriberUsername", "librarian0"}
            };

            Console.WriteLine(SendPostRequest(g_subscriber_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result.State);
        }

        public static void TestSubscriber()
        {
            Console.WriteLine("GetBooks : UnAuthentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBooks");
            Console.WriteLine(SendGetRequest(g_subscriber_client, g_uri_builder.Uri).Result.State);

            Console.WriteLine("Postcomment : Unauthentified");
            g_uri_builder = new UriBuilder(COMMENTS_CONTROLLER_URL + "PostComment/5");
            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Description", "test"},
                {"BookID", 1 + ""}
             };

            Console.WriteLine(SendPostRequest(g_subscriber_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result.State);

            g_uri_builder = new UriBuilder(TOKEN_URL);

            g_parameters = new Dictionary<String, String>
            {
                {"grant_type", "password"},
                {"username", "subscriber0"},
                {"password", "password123"}
            };

            g_http_request_result = SendPostRequest(g_subscriber_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result;

            var t_j_object = JObject.Parse(g_http_request_result.Content);
            g_subscriber_access_token = t_j_object["access_token"].ToString();

            g_subscriber_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + g_subscriber_access_token);

            Console.WriteLine("Token : " + g_subscriber_access_token);

            Console.WriteLine("GetBooks : Authentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBooks");
            Console.WriteLine(SendGetRequest(g_subscriber_client, g_uri_builder.Uri).Result.State);

            Console.WriteLine("Postcomment : Authentified");
            g_uri_builder = new UriBuilder(COMMENTS_CONTROLLER_URL + "PostComment");

            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Description", "UnCommentaireTest"},
                {"BookID", 2 + ""},
                {"SubscriberUsername", "subscriber0"}
            };

            Console.WriteLine(SendPostRequest(g_subscriber_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result.State);

            Console.WriteLine("PostBook : Authentified as subscriber");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "PostBook");
            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Title", "Title1"},
                {"Author", "Author1"},
                {"Stock", 5 + ""},
                {"Editor", "Editor1"}
            };

            Console.WriteLine(SendPostRequest(g_subscriber_client, g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result.State);
        }

        public class HttpRequestResult
        {
            public HttpStatusCode State { get; set; }
            public string Content { get; set; }
        }

        /// <summary>
        /// Send an Get request et return the response state and content
        /// </summary>
        /// <param name="p_uri">URL of the request (Don't forgot to include the parameters into the URL)</param>
        /// <returns>An Task of HttpRequestResult</returns>
        public async static Task<HttpRequestResult> SendGetRequest(HttpClient p_client, Uri p_uri)
        {
            using (HttpResponseMessage t_response = await p_client.GetAsync(p_uri))
            {
                HttpRequestResult httpRequestResult = new HttpRequestResult();

                httpRequestResult.State = t_response.StatusCode;

                httpRequestResult.Content = await t_response.Content.ReadAsStringAsync();

                return httpRequestResult;
            }
        }

        /// <summary>
        /// Send an Get request et return the response state and content
        /// </summary>
        /// <param name="p_uri">URL of the request (Don't forgot to include the parameters into the URL)</param>
        /// <param name="p_parameters">Parameters of the request)</param>
        /// <returns>An Task of HttpRequestResult</returns>
        public async static Task<HttpRequestResult> SendPostRequest(HttpClient p_client, Uri p_uri, FormUrlEncodedContent p_parameters)
        {
            using (HttpResponseMessage t_response = await p_client.PostAsync(p_uri, p_parameters))
            {
                HttpRequestResult httpRequestResult = new HttpRequestResult();

                httpRequestResult.State = t_response.StatusCode;

                httpRequestResult.Content = await t_response.Content.ReadAsStringAsync();

                return httpRequestResult;
            }
        }
    }
}
