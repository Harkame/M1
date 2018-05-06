using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace LibrarianClient
{
    /*
     * Because of problems with parsing from JSON to class (Like Book with an attribute Dictionary), all results of HTTP Request are simply String
     */

    class Program
    {
        private static readonly HttpClient g_client = new HttpClient(); //HTTP client who are used to send HTTP request
        private static int g_id; //ID of the current User
        private const string BOOKS_CONTROLLER = "http://localhost:31101/api/books/";
        private const string COMMENTS_CONTROLLER = "http://localhost:31101/api/comments/";
        private const string LIBRARIANS_CONTROLLER = "http://localhost:31101/api/librarians/";

        static void Main(string[] args)
        {

            Console.WriteLine("[Librarian client]");

            /*
            * Tempory variables who can be necessary in differend case
            */
            UriBuilder t_uri_builder; //Build of HTTP request's URI
            Dictionary<String, String> t_parameters; //Parameters of HTTP Post request
            HttpStatusCode t_response = HttpStatusCode.NotFound; //Initialize (All but not HttpStatusCode.OK)

            while (t_response != HttpStatusCode.OK)
            {
                Console.Write("ID : ");

                g_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_uri_builder = new UriBuilder(LIBRARIANS_CONTROLLER + "Authentificate");

                t_parameters = new Dictionary<String, String>
                {
                    { "ID", g_id + ""},
                    { "Password", t_password}
                };

                t_response = PutRequestStatus(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result;

                Console.WriteLine(t_response);
            }

            /*
             * Get the authorised actions
             */
            t_uri_builder = new UriBuilder(LIBRARIANS_CONTROLLER + "GetCommands/" + g_id);
            string t_actions = GetRequestContent(t_uri_builder.Uri).Result;

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
                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBooks/" + g_id);
                        Console.WriteLine(GetRequestContent(t_uri_builder.Uri).Result);
                        break;

                    case 2: //Search book by ISBN
                        Console.Write("ID : ");

                        t_id = Convert.ToInt32(Console.ReadLine());
                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBookByID/" + g_id + "/" + t_id);
                        Console.WriteLine(GetRequestContent(t_uri_builder.Uri).Result);

                        break;

                    case 3: //Search books by author
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.WriteLine("");

                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "GetBooksByAuthor/" + g_id + "/" + t_author);
                        Console.WriteLine(GetRequestContent(t_uri_builder.Uri).Result);

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

                        t_uri_builder = new UriBuilder(BOOKS_CONTROLLER + "PostBook/" + g_id);

                        t_parameters = new Dictionary<String, String>
                        {
                            {"ID", 0 + ""}, //If not, parse error
                            {"Title", t_title},
                            {"Author", t_author},
                            {"Stock", t_stock + ""},
                            {"Editor", t_editor}
                        };

                        Console.WriteLine(PostRequestStatus(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result);
                        break;

                    case 5: //Quit the program
                        goto end_of_loop;
                }
            }

            end_of_loop: { } //To quit the loop

            /*
             * Before exit, we remove the user from connected users
             */
            t_uri_builder = new UriBuilder(LIBRARIANS_CONTROLLER + "Disconnect/" + g_id);

            t_parameters = new Dictionary<String, String>
                        {
                        };

            Console.WriteLine(PutRequestStatus(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result);
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