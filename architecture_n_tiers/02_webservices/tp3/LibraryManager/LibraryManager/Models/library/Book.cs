using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager
{
    public class Book
    {
        private static int g_isbn = 0;

        [Key]
        [Required]
        public int ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public string Editor { get; set; }

        private Dictionary<int, String> Comments;

        public Book(String p_title, String p_author, int p_stock, String p_editor)
        {
            Title = p_title;

            Author = p_author;

            ISBN = g_isbn++;

            Stock = p_stock;

            Editor = p_editor;

            Comments = new Dictionary<int, string>();
        }

        public void Comment(int p_user_id, String p_comment)
        {
            Comments.Add(p_user_id, p_comment);
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

            r_to_string.Append("Comments (");
            r_to_string.Append(Comments.Count);
            r_to_string.Append(")");
            r_to_string.Append(Environment.NewLine);

            foreach (KeyValuePair<int, string> t_entry in Comments)
            {
                r_to_string.Append(t_entry.Key + " - " + t_entry.Value);
                r_to_string.Append(Environment.NewLine);
            }

            r_to_string.Append(Environment.NewLine);

            return r_to_string.ToString();
        }

        public override int GetHashCode()
        {
            int r_hashcode = 1498696844;
            r_hashcode = r_hashcode * -1521134295 + ISBN.GetHashCode();
            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            r_hashcode = r_hashcode * -1521134295 + Stock.GetHashCode();
            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Editor);
            r_hashcode = r_hashcode * -1521134295 + EqualityComparer<Dictionary<int, string>>.Default.GetHashCode(Comments);
            return r_hashcode;
        }
    }
}