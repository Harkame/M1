using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManager
{
    public class Book
    {
        public String a_title;

        public String a_author;

        public int a_isbn;

        public int a_stock;

        public String a_editor;

        public Dictionary<Subscriber, String> a_comments;

        public Book()
        {


        }

        public Book(String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
        {
            a_title = p_title;

            a_author = p_author;

            a_isbn = p_isbn;

            a_stock = p_stock;

            a_editor = p_editor;

            a_comments = new Dictionary<Subscriber, string>();
        }

        public void Comment(Subscriber p_subscriber, String p_comment)
        {
            a_comments.Add(p_subscriber, p_comment);
        }

        public override bool Equals(object p_book)
        {
            if(p_book == null)
                return false;

            Book t_book = p_book as Book;

            return a_title.Equals(t_book.a_title) &&
                a_author.Equals(t_book.a_author) &&
                a_isbn == t_book.a_isbn &&
                //a_stock = t_book.a_stock &&
                a_editor.Equals(t_book.a_editor);
        }
    }
}