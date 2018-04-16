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
        private static readonly HttpClient g_client = new HttpClient(); //HTTP client who are used to send HTTP request
        private const string BOOKS_CONTROLLER = "http://localhost:6670/api/books/";
        private const string COMMENTS_CONTROLLER = "http://localhost:6670/api/comments/";
        private const string LIBRARIANS_CONTROLLER = "http://localhost:6670/api/librarians/";
        private const string SUBSCRIBERS_CONTROLLER = "http://localhost:6670/api/subscribers/";

        private static UriBuilder g_uri_builder; //Build of HTTP request's URI
        private static Dictionary<String, String> g_parameters; //Parameters of HTTP Post request

        static void Main(string[] args)
        {
            TestLibrarian();

            Console.WriteLine("------------------------");

            TestSubscriber();

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();
        }

        public static void TestLibrarian()
        {
            Console.WriteLine("GetBooks : UnAuthentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBooks/1");
            Console.WriteLine(GetRequestStatus(g_uri_builder.Uri).Result);

            Console.WriteLine("Authentification : Wrong id/password");
            g_parameters = new Dictionary<String, String>
            {
                { "ID", 1 + ""},
                { "Password", "yolo"}
            };
            g_uri_builder = new UriBuilder(LIBRARIANS_CONTROLLER + "Authentificate");
            Console.WriteLine(PutRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);

            Console.WriteLine("AddBook : Unauthentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "PostBook/7");
            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Title", "TitleTest"},
                {"Author", "AuthorTest"},
                {"Stock", 42 + ""},
                {"Editor", "EditorTest"}
            };
            Console.WriteLine(PostRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);

            Console.WriteLine("Authentification : Right id/password");
            g_parameters = new Dictionary<String, String>
                {
                    { "ID", 7 + ""},
                    { "Password", "librarian2"}
                };

            g_uri_builder = new UriBuilder(LIBRARIANS_CONTROLLER + "Authentificate");
            Console.WriteLine(PutRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);

            Console.WriteLine("GetBooks : Authentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBooks/7");
            Console.WriteLine(GetRequestStatus(g_uri_builder.Uri).Result);

            Console.WriteLine("AddBook : Authentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "PostBook/7");
            g_parameters = new Dictionary<String, String>
            {
                {"ID", 0 + ""}, //If not, parse error
                {"Title", "TitleTest"},
                {"Author", "AuthorTest"},
                {"Stock", 42 + ""},
                {"Editor", "EditorTest"}
            };
            Console.WriteLine(PostRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);
        }

        public static void TestSubscriber()
        {
            Console.WriteLine("GetBooks : UnAuthentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBooks/1");
            Console.WriteLine(GetRequestStatus(g_uri_builder.Uri).Result);

            Console.WriteLine("Authentification : Wrong id/password");
            g_uri_builder = new UriBuilder(SUBSCRIBERS_CONTROLLER + "Authentificate");
            g_parameters = new Dictionary<String, String>
            {
                { "ID", 1 + ""},
                { "Password", "yolo"}
            };
            Console.WriteLine(PutRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);

            Console.WriteLine("CommentBook : Unauthentified");
            g_uri_builder = new UriBuilder(COMMENTS_CONTROLLER + "PostComment/5");
            g_parameters = new Dictionary<String, String>
            {
                {"Description", "CommentTest"}, //If not, parse error
                {"BookID", "2"},
                {"SubscriberID", "5"},
            };
            Console.WriteLine(PostRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);

            Console.WriteLine("Authentification : Right id/password");
            g_uri_builder = new UriBuilder(SUBSCRIBERS_CONTROLLER + "Authentificate");
            g_parameters = new Dictionary<String, String>
                {
                    { "ID", 5 + ""},
                    { "Password", "subscriber"}
                };
            Console.WriteLine(PutRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);

            Console.WriteLine("GetBooks : Authentified");
            g_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBooks/7");
            Console.WriteLine(GetRequestStatus(g_uri_builder.Uri).Result);

            Console.WriteLine("CommentBook : Authentified");
            g_uri_builder = new UriBuilder(COMMENTS_CONTROLLER + "PostComment/5");
            g_parameters = new Dictionary<String, String>
            {
                {"Description", "CommentTest"}, //If not, parse error
                {"BookID", "2"},
                {"SubscriberID", "5"},
            };
            Console.WriteLine(PostRequestStatus(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result);
        }

        /// <summary>
        /// Send an Get request et return the response value
        /// </summary>
        /// <param name="p_uri">URL of the request (Don't forgot to include the parameters into the URL)</param>
        /// <returns>An Task of string, use attribute Result to get the response (JSON Format)</returns>
        public async static Task<string> GetRequestContent(Uri p_uri)
        {
            using (HttpResponseMessage t_response = await g_client.GetAsync(p_uri))
            {
                return await t_response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Send an Get request et return the response value
        /// </summary>
        /// <param name="p_uri">URL of the request (Don't forgot to include the parameters into the URL)</param>
        /// <returns>An Task of string, use attribute Result to get the response (JSON Format)</returns>
        public async static Task<HttpStatusCode> GetRequestStatus(Uri p_uri)
        {
            using (HttpResponseMessage t_response = await g_client.GetAsync(p_uri))
            {
                return t_response.StatusCode;
            }
        }

        /// <summary>
        /// Send an Post request and return the status value
        /// </summary>
        /// <param name="p_uri">URL of the request</param>
        /// <param name="p_parameters">The parameters of the request</param>
        /// <returns>The status of the request</returns>
        public async static Task<HttpStatusCode> PostRequestStatus(Uri p_uri, FormUrlEncodedContent p_parameters)
        {
            using (HttpResponseMessage t_response = await g_client.PostAsync(p_uri, p_parameters))
            {
                return t_response.StatusCode;
            }
        }

        /// <summary>
        /// Send an Put request and return the status value
        /// </summary>
        /// <param name="p_uri">URL of the request</param>
        /// <param name="p_parameters">The parameters of the request</param>
        /// <returns>The status of the request</returns>
        public static async Task<HttpStatusCode> PutRequestStatus(Uri p_uri, FormUrlEncodedContent p_parameters)
        {
            using (HttpResponseMessage t_response = await g_client.PutAsync(p_uri, p_parameters))
            {
                return t_response.StatusCode;
            }
        }
    }
}
