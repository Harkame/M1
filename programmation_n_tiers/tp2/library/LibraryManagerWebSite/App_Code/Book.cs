using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace LibraryManager
{
    public class Book
    {
        public String a_title;

        public String a_author;

        public int a_isbn;

        public int a_stock;

        public String a_editor;

        public List<Comment> a_comments;

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

            a_comments = new List<Comment>();
        }

        public void Comment(Subscriber p_subscriber, String p_comment)
        {
            a_comments.Add(new Comment(p_subscriber, p_comment));
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

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append("Title : ");
            r_to_string.Append(a_title);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Author : ");
            r_to_string.Append(a_author);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("ISBN : ");
            r_to_string.Append(a_isbn);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Stock : ");
            r_to_string.Append(a_stock);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Editor : ");
            r_to_string.Append(a_editor);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Comments : ");
            r_to_string.Append(Environment.NewLine);

            foreach (Comment t_comment in a_comments)
            {
                r_to_string.Append(t_comment.ToString());
                r_to_string.Append(Environment.NewLine);
            }

            return r_to_string.ToString();
        }
    }
}