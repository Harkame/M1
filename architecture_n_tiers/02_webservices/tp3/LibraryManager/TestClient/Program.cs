using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestClient
{
    class Program
    {
        private static readonly HttpClient g_client = new HttpClient(); //HTTP client who are used to send HTTP request

        private static UriBuilder g_uri_builder; //Build of HTTP request's URI
        private static Dictionary<String, String> g_parameters; //Parameters of HTTP Post request

        static void Main(string[] args)
        {
            Console.WriteLine("--- Librarian test ---");
            TestLibrarian();

            Console.WriteLine("--- Subscriber test ---");
            TestSubscriber();

            Console.WriteLine("Please, press enter to continue");

            Console.ReadLine();
        }

        public static void TestLibrarian()
        {
            Console.WriteLine("Add book unauthenfied");
            g_uri_builder = new UriBuilder("http://localhost:49416/Book/AddBook");

            g_parameters = new Dictionary<String, String>
            {
                {"p_librarian_id", "0"},
                {"p_title", "newBook"},
                {"p_author", "author12"},
                {"p_stock", "27"},
                {"p_editor", "editor12"}
            };

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));

            g_uri_builder = new UriBuilder("http://localhost:49416/User/Authentificate");

            g_parameters = new Dictionary<String, String>
                {
                    { "p_user_id", "0"},
                    { "p_password", "123"}
                };

            Console.WriteLine("Authentification");

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));

            Console.WriteLine("Add book authenfied");
            g_uri_builder = new UriBuilder("http://localhost:49416/Book/AddBook");

            g_parameters = new Dictionary<String, String>
            {
                {"p_librarian_id", "0"},
                {"p_title", "newBook"},
                {"p_author", "author12"},
                {"p_stock", "27"},
                {"p_editor", "editor12"}
            };

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));

            Console.WriteLine("Librarian comment book");
            g_uri_builder = new UriBuilder("http://localhost:49416/Book/CommentBook");

            g_parameters = new Dictionary<String, String>
            {
                {"p_subscriber_id", "0"},
                {"p_isbn", "4"},
                {"p_description", "comment"},
            };

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));
        }



        public static void TestSubscriber()
        {
            Console.WriteLine("Comment book unauthenfied");
            g_uri_builder = new UriBuilder("http://localhost:49416/Book/CommentBook");

            g_parameters = new Dictionary<String, String>
            {
                {"p_subscriber_id", "2"},
                {"p_isbn", "4"},
                {"p_description", "comment"},
            };

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));

            g_uri_builder = new UriBuilder("http://localhost:49416/User/Authentificate");

            g_parameters = new Dictionary<String, String>
                {
                    { "p_user_id", "2"},
                    { "p_password", "123"}
                };

            Console.WriteLine("Authentification");

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));

            Console.WriteLine("Comment book authenfied");
            g_uri_builder = new UriBuilder("http://localhost:49416/Book/CommentBook");

            g_parameters = new Dictionary<String, String>
            {
                {"p_subscriber_id", "2"},
                {"p_isbn", "4"},
                {"p_description", "comment"},
            };

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));

            Console.WriteLine("Subscriber add book");
            g_uri_builder = new UriBuilder("http://localhost:49416/Book/AddBook");

            g_parameters = new Dictionary<String, String>
            {
                {"p_librarian_id", "2"},
                {"p_title", "newBook"},
                {"p_author", "author12"},
                {"p_stock", "27"},
                {"p_editor", "editor12"}
            };

            Console.WriteLine(Convert.ToBoolean(PostRequest(g_uri_builder.Uri, new FormUrlEncodedContent(g_parameters)).Result));
        }

            /// <summary>
            /// Method who are used to send HTTP Get request
            /// </summary>
            /// <param name="p_uri">The URI address where send the request (Be carrefull, the parameter need to be added directly in the URI)</param>
            /// <returns>The Result of the request, an String (Can be json)</returns>
            async static Task<String> GetRequest(Uri p_uri)
        {
            using (HttpResponseMessage t_response = await g_client.GetAsync(p_uri))
            {
                using (HttpContent t_http_content = t_response.Content)
                {
                    return await t_http_content.ReadAsStringAsync();
                }
            }
        }

        /// <summary>
        /// Method who are used to send HTTP Post request
        /// </summary>
        /// <param name="p_uri">The URI address where send the request</param>
        /// <param name="p_parameters">The parameters of the request</param>
        /// <returns>The Result of the request, an String (Can be json)</returns>
        async static Task<String> PostRequest(Uri p_uri, FormUrlEncodedContent p_parameters)
        {
            using (HttpResponseMessage t_response = await g_client.PostAsync(p_uri, p_parameters))
            {
                using (HttpContent t_http_content = t_response.Content)
                {
                    return await t_http_content.ReadAsStringAsync();
                }
            }
        }
    }
}
