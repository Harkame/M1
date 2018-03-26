namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.SqlClient;

    public static class Library
    {
        [Required]
        [DisplayName("Book")]
        public static List<Book> Books { get; set; }

        [Required]
        [DisplayName("Librarians")]
        public static List<Librarian> Librarians { get; set; }

        [Required]
        [DisplayName("Subscribers")]
        public static List<Subscriber> Subscribers { get; set; }

        [Required]
        [DisplayName("Connections")]
        public static List<User> Connections { get; set; }

        static Library()
        {
            string connectionString =
            "Data Source=(local);Initial Catalog=Northwind;"
            + "Integrated Security=true";

            // Provide the query string with a parameter placeholder.
            string queryString =
            "SELECT ProductID, UnitPrice, ProductName from dbo.products "
            + "WHERE UnitPrice > @pricePoint "
            + "ORDER BY UnitPrice DESC;";

            // Specify the parameter value.
            int paramValue = 5;

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection =
            new SqlConnection(connectionString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@pricePoint", paramValue);

                // Open the connection in a try/catch block. 
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                        reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


                Books = new List<Book>();

            Librarians = new List<Librarian>();

            Subscribers = new List<Subscriber>();

            Connections = new List<User>();

            Books.Add(new Book("book1", "author1", 1, "editor1"));
            Books.Add(new Book("book2", "author1", 10, "editor1"));
            Books.Add(new Book("book3", "author2", 5, "editor2"));
            Books.Add(new Book("book4", "author3", 9, "editor3"));
            Books.Add(new Book("book5", "author4", 0, "editor2"));

            Librarians.Add(new Librarian("123"));
            Librarians.Add(new Librarian("toto"));

            Subscribers.Add(new Subscriber("123"));
            Subscribers.Add(new Subscriber("toto"));
            Subscribers.Add(new Subscriber("yolo"));
            Subscribers.Add(new Subscriber("test"));
            Subscribers.Add(new Subscriber("password"));
        }

        public static bool IsValid(int p_user_id)
        {
            foreach(User t_user in Connections)
                if(p_user_id == t_user.ID)
                    return true;

            return false;
        }

        public static bool IsValidLibrarian(int p_librarian_id)
        {
            foreach (User t_user in Connections)
                if (t_user.ID == p_librarian_id && t_user.GetType().Name.Equals("Librarian"))
                    return true;

            return false;
        }

        public static bool IsValidSubscriber(int p_subscriber_id)
        {
            foreach (User t_user in Connections)
                if (t_user.ID == p_subscriber_id && t_user.GetType().Name.Equals("Subscriber"))
                    return true;

            return false;
        }
    }
}