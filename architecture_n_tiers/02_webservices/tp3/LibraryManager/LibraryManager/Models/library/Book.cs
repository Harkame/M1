namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        [Required]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [DisplayName("Author")]
        public string Author { get; set; }

        [Required]
        [DisplayName("ISBN")]
        public int ISBN { get; set; }

        [Required]
        [DisplayName("Stock")]
        public int Stock { get; set; }

        [Required]
        [DisplayName("Editor")]
        public string Editor { get; set; }

        private List<Comment> a_comments;

        public Book(String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
        {
            Title = p_title;

            Author = p_author;

            ISBN = p_isbn;

            Stock = p_stock;

            Editor = p_editor;
        }

        public void Comment(int p_user_id, String p_comment)
        {
            a_comments.Add(new Comment(p_user_id, p_comment));
        }

        public override bool Equals(object p_book)
        {
            if(p_book == null)
                return false;

            Book t_book = p_book as Book;

            return Title.Equals(t_book.Title) &&
                Author.Equals(t_book.Author) &&
                ISBN == t_book.ISBN &&
                //a_stock = t_book.a_stock &&
                Editor.Equals(t_book.Editor);
        }

        public override String ToString()
        {
            StringBuilder r_to_string = new StringBuilder();

            r_to_string.Append("Title    : ");
            r_to_string.Append(Title);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Author   : ");
            r_to_string.Append(Author);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("ISBN     : ");
            r_to_string.Append(ISBN);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Stock    : ");
            r_to_string.Append(Stock);
            r_to_string.Append(Environment.NewLine);

            r_to_string.Append("Editor   : ");
            r_to_string.Append(Editor);
            r_to_string.Append(Environment.NewLine);

            /*
            r_to_string.Append("Comments (");
            r_to_string.Append(a_comments.Count);
            r_to_string.Append(")");
            r_to_string.Append(Environment.NewLine);

            foreach (Comment t_comment in a_comments)
            {
                r_to_string.Append(t_comment.ToString());
                r_to_string.Append(Environment.NewLine);
            }
             * */

            return r_to_string.ToString();
        }
    }
}