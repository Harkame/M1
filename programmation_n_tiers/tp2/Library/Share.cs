using System;

namespace Share
{
    public interface IComment { }

    public class IBook
    {
        void AddComment(IComment p_comment);
        String ReadComment();
    }

    public interface ILibraryrgregre
    {
        public String SearchByISBN(int p_isbn) ;

        public String SearchByAuthor(String p_author);
    }

    public interface ISubscriber
    {
        void AddComment(String p_string, IBook p_book);
    }
}