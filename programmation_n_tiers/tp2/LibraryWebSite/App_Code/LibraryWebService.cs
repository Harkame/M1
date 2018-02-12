using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Description résumée de LibraryWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
// [System.Web.Script.Services.ScriptService]
public class LibraryWebService : System.Web.Services.WebService {

    private Library a_library
    {
        get
        {
            return a_library;
        }
        set
        {
            a_library = value;
        }
    }

    public LibraryWebService () {
        a_library = new Library();

        a_library.a_books.Add(new Book("book1", "author1", 0, 0, "editor1"));
        a_library.a_books.Add(new Book("booK2", "author2", 1, 5, "editor2"));
        a_library.a_books.Add(new Book("book3", "author3", 2, 3, "editor1"));
        a_library.a_books.Add(new Book("book4", "author4", 3, 1, "editor3"));

        a_library.a_subscribers.Add(new Subscriber(0, "123"));
        a_library.a_subscribers.Add(new Subscriber(1, "abc"));
        a_library.a_subscribers.Add(new Subscriber(2, "42"));
    }

    [WebMethod]
    public String test()
    {
        //Book b =  new Book("book1", "author1", 0, 0, "editor1");

        return "yolo";
    }

    /*
    [WebMethod]
    public bool Authentification(int p_id, String p_password)
    {
        Subscriber t_subscriber = a_library.a_subscribers[p_id];

        if(t_subscriber.a_password.Equals(p_password))
            return true;

        return false;
    }

    [WebMethod]
    public String SearchByISBN(int p_isbn) {
        foreach (Book t_book in a_library.a_books)
            if (t_book.a_isbn == (p_isbn))
                return t_book.ToString();

        return null;
    }

    [WebMethod]
    public String SearchByAuthor(String p_author)
    {
        foreach (Book t_book in a_library.a_books)
            if (t_book.a_author.Equals(p_author))
                return t_book.ToString();

        return null;
    }
     * */
}
