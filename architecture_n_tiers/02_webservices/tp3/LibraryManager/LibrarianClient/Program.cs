using System;
using System.Collections.Generic;
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

        static void Main(string[] args)
        {

            Console.WriteLine("[Librarian client]");

            /*
            * Tempory variables who can be necessary in differend case
            */
            bool t_authentificated = false; //Use for the authentification
            UriBuilder t_uri_builder; //Build of HTTP request's URI
            Dictionary<String, String> t_parameters; //Parameters of HTTP Post request

            while (!t_authentificated)
            {
                Console.Write("ID : ");

                g_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_uri_builder = new UriBuilder("http://localhost:49416/User/Authentificate");

                t_parameters = new Dictionary<String, String>
                {
                    { "p_user_id", g_id + ""},
                    { "p_password", t_password}
                };

                t_authentificated = Convert.ToBoolean(PostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result);
            }

            Console.WriteLine("");

            Console.WriteLine("Authentification successfull");

            Console.WriteLine("");

            /*
             * Get the authorised actions, according to king of User (Librarian or Subscriber)
             */
            t_uri_builder = new UriBuilder("http://localhost:49416/User/GetCommands");
            t_uri_builder.Query = "p_user_id=" + g_id;
            String t_actions = GetRequest(t_uri_builder.Uri).Result;

            /*
             * Tempory variables who can be necessary in differend case
             */
            int t_isbn;
            
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
                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/GetBooks");
                        t_uri_builder.Query = "p_user_id=" + g_id;
                        Console.WriteLine(GetRequest(t_uri_builder.Uri).Result);
                        break;

                    case 2: //Search book by ISBN
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/SearchBookByISBN");
                        t_uri_builder.Query = "p_user_id=" + g_id + "&p_isbn=" + t_isbn;
                        Console.WriteLine(GetRequest(t_uri_builder.Uri).Result);

                        break;

                    case 3: //Search books by author
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.WriteLine("");

                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/SearchBooksByAuthor");
                        t_uri_builder.Query = "p_user_id=" + g_id + "&p_author=" + t_author;
                        Console.WriteLine(GetRequest(t_uri_builder.Uri).Result);

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

                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/AddBook");

                        t_parameters = new Dictionary<String, String>
                        {
                            {"p_librarian_id", g_id + ""},
                            {"p_title", t_title},
                            {"p_author", t_author},
                            {"p_stock", t_stock + ""},
                            {"p_editor", t_editor }
                        };

                        Console.WriteLine(Convert.ToBoolean(PostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result));
                        break;

                    case 5: //Quit the program
                        goto end_of_loop;
                }
            }

            end_of_loop: { } //To quit the loop

            /*
             * Before exit, we remove the user from connected user
             */
            t_uri_builder = new UriBuilder("http://localhost:49416/User/Disconnect");
            t_parameters = new Dictionary<String, String>
                {
                    { "p_user_id", g_id + ""}
                };
            Console.WriteLine(PostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)));
        }

        static String SendRequest(Uri p_uri)
        {
            return GetRequest(p_uri).Result;
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
