using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Share;

/// <summary>
/// Description résumée de Library
/// </summary>
public class Library : ILibrary
{
    public List<Book> a_books
    {
        get
        {
            return a_books;
        }
        set
        {
            a_books = value;
        }
    }

    public List<Subscriber> a_subscribers
    {
        get
        {
            return a_subscribers;
        }
        set
        {
            a_subscribers = value;
        }
    }

	public Library()
	{
        a_books = new List<Book>();
        a_subscribers = new List<Subscriber>();
	}
}