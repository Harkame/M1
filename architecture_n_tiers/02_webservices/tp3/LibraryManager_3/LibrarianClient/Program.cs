using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibrarianClient
{
    class Program
    {
        private static readonly HttpClient g_client = new HttpClient(); //HTTP client who are used to send HTTP request
        private static readonly string SERVER_URL = "http://localhost:";
        private static readonly int PORT = 31101;
        private static readonly string SERVER_COMPLETE_URL = SERVER_URL + PORT + "/";
        private static readonly string TOKEN_URL = SERVER_COMPLETE_URL + "oauth2/token";
        private static readonly string SERVER_API_URL = SERVER_COMPLETE_URL + "api/";
        private static readonly string BOOKS_CONTROLLER_URL = SERVER_API_URL + "books/";
        private static readonly string LIBRARIANS_CONTROLLER_URL = SERVER_API_URL + "librarians/";

        private static String g_access_token;

        static void Main(string[] args)
        {
            Console.WriteLine("[Librarian client]");

            /*
            * Tempory variables who can be necessary in differend case
            */
            UriBuilder t_uri_builder; //Build of HTTP request's URI
            Dictionary<String, String> t_parameters; //Parameters of HTTP Post request
            HttpRequestResult t_http_request_result = new HttpRequestResult { State = HttpStatusCode.NotFound }; //Initialize (All but not HttpStatusCode.OK)

            while (t_http_request_result.State != HttpStatusCode.OK)
            {
                Console.Write("Username : ");

                string t_username = Console.ReadLine();

                Console.Write("Password : ");

                String t_paswword = Console.ReadLine();

                t_uri_builder = new UriBuilder(TOKEN_URL);

                t_parameters = new Dictionary<String, String>
                        {
                            {"grant_type", "password"},
                            {"username", t_username},
                            {"password", t_paswword}
                        };


                t_http_request_result = SendPostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result;

                if (t_http_request_result.State == HttpStatusCode.OK)
                {
                    var t_j_object = JObject.Parse(t_http_request_result.Content);
                    g_access_token = t_j_object["access_token"].ToString();
                    break;
                }
                else
                    Console.WriteLine(t_http_request_result.State);
            }

            Console.WriteLine("Token : " + g_access_token);

            g_client.DefaultRequestHeaders.Add("Authorization", "Bearer " + g_access_token);

            t_uri_builder = new UriBuilder(LIBRARIANS_CONTROLLER_URL + "GetCommands");

            string t_actions = SendGetRequest(t_uri_builder.Uri).Result.Content;

            /*
             * Tempory variables who can be necessary in differend case
             */
            int t_id;

            String t_author;

            while (true)
            {
                Console.WriteLine(t_actions);

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("");

                switch (t_action)
                {
                    case 1: //Get all books
                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBooks");
                        Console.WriteLine(SendGetRequest(t_uri_builder.Uri).Result.Content);
                        break;

                    case 2: //Search book by ISBN
                        Console.Write("ID : ");

                        t_id = Convert.ToInt32(Console.ReadLine());
                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBookByID/" + t_id);
                        Console.WriteLine(SendGetRequest(t_uri_builder.Uri).Result.Content);

                        break;

                    case 3: //Search books by author
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.WriteLine("");

                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "GetBooksByAuthor/" + t_author);
                        Console.WriteLine(SendGetRequest(t_uri_builder.Uri).Result.Content);

                        break;

                    case 4: //Add an new book (Librarian only)
                        Console.Write("Title : ");

                        String t_title = Console.ReadLine();

                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.Write("Stock : ");

                        int t_stock = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Editor : ");

                        String t_editor = Console.ReadLine();

                        Console.WriteLine("");

                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER_URL + "PostBook");

                        t_parameters = new Dictionary<String, String>
                        {
                            {"ID", 0 + ""}, //If not, parse error
                            {"Title", t_title},
                            {"Author", t_author},
                            {"Stock", t_stock + ""},
                            {"Editor", t_editor}
                        };
                        break;

                    case 5: //Quit the program
                        goto end_of_loop;
                }
            }

            end_of_loop: { } //To quit the loop

            Console.ReadLine();
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
        public async static Task<HttpRequestResult> SendGetRequest(Uri p_uri)
        {
            using (HttpResponseMessage t_response = await g_client.GetAsync(p_uri))
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
        public async static Task<HttpRequestResult> SendPostRequest(Uri p_uri, FormUrlEncodedContent p_parameters)
        {
            using (HttpResponseMessage t_response = await g_client.PostAsync(p_uri, p_parameters))
            {
                HttpRequestResult httpRequestResult = new HttpRequestResult();

                httpRequestResult.State = t_response.StatusCode;

                httpRequestResult.Content = await t_response.Content.ReadAsStringAsync();

                return httpRequestResult;
            }
        }
    }
}