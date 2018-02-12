using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Book
/// </summary>
public class Book
{
    public String a_title
    {
        get
        {
            return a_title;
        }
        set
        {
            a_title = value;
        }
    }

    public String a_author
    {
        get
        {
            return a_author;
        }
        set
        {
            a_author = value;
        }
    }

    public int a_isbn
    {
        get
        {
            return a_isbn;
        }
        set
        {
            a_isbn = value;
        }
    }

    public int a_stock
    {
        get
        {
            return a_stock;
        }
        set
        {
            a_stock = value;
        }
    }

    public String a_editor
    {
        get
        {
            return a_editor;
        }
        set
        {
            a_editor = value;
        }
    }

	public Book()
	{

	}

    public Book(String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
    {
        a_title  = p_title;
        a_author = p_author;
        a_isbn   = p_isbn;
        a_stock  = p_stock;
        a_editor = p_editor;
    }
}