namespace LibraryManager
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Book
    {
        public String Title { get; set; }

        public String Author { get; set; }

        public int ISBN { get; set; }

        public int Stock { get; set; }

        public String Editor { get; set; }

        public List<Comment> Comments { get; set; }

        public Book()
        {
        }

        public Book(String p_title, String p_author, int p_isbn, int p_stock, String p_editor)
        {
            Title = p_title;

            Author = p_author;

            ISBN = p_isbn;

            Stock = p_stock;

            Editor = p_editor;

            Comments = new List<Comment>();
        }

        public void Comment(User p_User, String p_comment)
        {
            Comments.Add(new Comment(p_User, p_comment));
        }

        public override bool Equals(object p_book)
        {
            if(p_book == null)
                return false;

            Book t_book = p_book as Book;

            return Title.Equals(t_book.Title) &&
                Author.Equals(t_book.Author) &&
                ISBN == t_book.ISBN &&
                //Stock = t_book.Stock &&
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

            foreach (Comment t_comment in Comments)
            {
                r_to_string.Append(t_comment.ToString());
                r_to_string.Append(Environment.NewLine);
            }

            return r_to_string.ToString();
        }

        public override int GetHashCode()
        {
            var hashCode = -1717003308;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + ISBN.GetHashCode();
            hashCode = hashCode * -1521134295 + Stock.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Editor);
            hashCode = hashCode * -1521134295 + EqualityComparer<List<Comment>>.Default.GetHashCode(Comments);
            return hashCode;
        }
    }
}