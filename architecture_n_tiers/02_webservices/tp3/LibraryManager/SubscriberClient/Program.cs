namespace SubscriberCient
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Net;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    class Program
    {
        private static readonly HttpClient g_client = new HttpClient();
        private static int g_id;

        static void Main(string[] args)
        {

            Console.WriteLine("[Librarian client]");

            bool t_authentificated = false;

            UriBuilder t_uri_builder;
            while (!t_authentificated)
            {
                Console.Write("ID : ");

                g_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                t_uri_builder = new UriBuilder("http://localhost:49416/User/Authentificate");

                Dictionary<String, String> t_parameters = new Dictionary<String, String>
                {
                    { "p_user_id", g_id + ""},
                    { "p_password", t_password}
                };

                t_authentificated = Convert.ToBoolean(PostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result);
            }

            Console.WriteLine("");

            Console.WriteLine("Authentification successfull");

            Console.WriteLine("");

            t_uri_builder = new UriBuilder("http://localhost:49416/User/GetCommands");
            t_uri_builder.Query = "p_user_id=" + g_id;

            String t_actions = GetRequest(t_uri_builder.Uri).Result;

            /*


            /*
             * All the tempory variables who can be necessary
             */
            int t_isbn;
            int t_stock;

            String t_editor;
            String t_author;
            String t_title;

            String t_comment;

            while (true)
            {
                Console.WriteLine(t_actions);

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("");

                switch (t_action)
                {
                    case 1:
                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/GetBooks");
                        t_uri_builder.Query = "p_user_id=" + g_id;
                        Console.WriteLine(GetRequest(t_uri_builder.Uri).Result);
                        break;

                    case 2:
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/SearchBookByISBN");
                        t_uri_builder.Query = "p_user_id=" + g_id + "&p_isbn=" + t_isbn;
                        Console.WriteLine(GetRequest(t_uri_builder.Uri).Result);

                        break;

                    case 3:
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.WriteLine("");

                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/SearchBooksByAuthor");
                        t_uri_builder.Query = "p_user_id=" + g_id + "&p_author=" + t_author;
                        Console.WriteLine(GetRequest(t_uri_builder.Uri).Result);

                        break;

                    case 4:
                        Console.Write("Title : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Comment : ");

                        t_comment = Console.ReadLine();

                        t_uri_builder = new UriBuilder("http://localhost:49416/Book/Comment");

                        Dictionary<String, String> t_parameters = new Dictionary<String, String>
                        {
                            {"p_subscriber_id", g_id + ""},
                            {"p_isbn", t_isbn + ""},
                            {"p_description", t_comment},
                        };

                        Console.WriteLine(Convert.ToBoolean(PostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters)).Result));
                        break;

                    case 5:
                        goto end_of_loop;
                }
            }

        end_of_loop: { } //To quit the loop
        }

        static String SendRequest(Uri p_uri)
        {
            return GetRequest(p_uri).Result;
        }

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
