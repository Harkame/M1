namespace LibrarianClient
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
        private static String g_response;
        private static int g_id;

        static void Main(string[] args)
        {

            Console.WriteLine("[Librarian client]");

            bool t_authentificated = false;

            while (!t_authentificated)
            {
                Console.Write("ID : ");

                g_id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Password : ");

                String t_password = Console.ReadLine();

                UriBuilder t_uri_builder = new UriBuilder("http://localhost:49416/User/Authentificate");
                //t_uri_builder.Query = "p_id=" + t_id + "&p_password=" + t_password;

                Dictionary<String, String> t_parameters = new Dictionary<String, String>
                {
                    { "p_user_id", g_id + ""},
                    { "p_password", t_password}
                };
                
                PostRequest(t_uri_builder.Uri, new FormUrlEncodedContent(t_parameters));

                t_authentificated = Convert.ToBoolean(g_response);
            }



            Console.WriteLine("");

            Console.WriteLine("Authentification successfull");

            Console.WriteLine("");



            /*
             * All the tempory variables who can be necessary
             */
            int t_isbn;
            int t_stock;

            String t_editor;
            String t_author;
            String t_title;


            while (true)
            {

                Console.Write("Action : ");

                int t_action = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("");

                switch (t_action)
                {
                    case 1:
                        UriBuilder t_uri_builder = new UriBuilder("http://localhost:49416/User/Authentificate");
                        t_uri_builder.Query = "p_user_id=" + g_id;
                        GetRequest(t_uri_builder.Uri);
                        break;
                   /*
                    case 2:
                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine(a_proxy.GetBookDescription(t_librarian, t_isbn));

                        break;

                    case 3:
                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.WriteLine("");

                        t_books = a_proxy.SearchBooksByAuthor(t_librarian, t_author);

                        Console.WriteLine("[" + t_books.Length + "]");

                        foreach (Book t_book_iterator in t_books)
                            Console.WriteLine(a_proxy.GetBookDescription(t_librarian, t_book_iterator.ISBN));

                        break;

                    case 4:
                        Console.Write("Title : ");

                        t_title = Console.ReadLine();

                        Console.Write("Author : ");

                        t_author = Console.ReadLine();

                        Console.Write("ISBN : ");

                        t_isbn = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Stock : ");

                        t_stock = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Editor : ");

                        t_editor = Console.ReadLine();

                        Console.WriteLine("");

                        if (a_proxy.AddBook(t_librarian, t_title, t_author, t_isbn, t_stock, t_editor))
                            Console.WriteLine("Book added");
                        else
                            Console.WriteLine("Fail to add book");
                        break;
                        */
                    case 5:
                        goto end_of_loop;
                }
            }

        end_of_loop: { } //To quit the loop
        }

        async static void GetRequest(Uri p_uri)
        {
            using (HttpResponseMessage t_response = await g_client.GetAsync(p_uri))
            {
                using (HttpContent t_http_content = t_response.Content)
                {
                    g_response = await t_http_content.ReadAsStringAsync();
                }
            }
    }

        async static void PostRequest(Uri p_uri, FormUrlEncodedContent p_parameters)
        {
            using (HttpResponseMessage t_response = await g_client.PostAsync(p_uri, p_parameters))
            {
                using (HttpContent t_http_content = t_response.Content)
                {
                    g_response = await t_http_content.ReadAsStringAsync();
                }
            }
        }
    }
}
