using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace LibraryManager.Controllers
{
    public class UserController : Controller
    {
        /// <summary>
        /// Authentificate a User (Return an object and add it into the list of connected users)
        /// </summary>
        /// <param name="p_id">The ID of the Librarian</param> 
        /// <param name="p_password">The password of the Librarian</param>
        /// <returns>A object User designed by p_id and p_password, null if the authentification has failed</returns>
        [HttpPost]
        public User Authentificate(int p_id, String p_password)
        {
            if (p_password == null)
                return null;

            foreach (Librarian t_librarian in Library.a_librarians)
                if (t_librarian.ID == p_id && t_librarian.Password.Equals(p_password))
                {
                    Library.a_connections.Add(t_librarian);
                    return t_librarian;
                }

            foreach (Subscriber t_subscriber in Library.a_subscribers)
                if (t_subscriber.ID == p_id && t_subscriber.Password.Equals(p_password))
                {
                    Library.a_connections.Add(t_subscriber);
                    return t_subscriber;
                }

            return null;
        }

        /// <summary>
        /// Authentificate a Librarian (Return an object and add it into the list of connected users)
        /// </summary>
        /// <param name="p_id">The ID of the Librarian</param> 
        /// <param name="p_password">The password of the Librarian</param>
        /// <returns>A object Librarian designed by p_id and p_password, null if the authentification has failed</returns>
        [HttpPost]
        public Librarian AuthentificateAsLibrarian(int p_id, String p_password)
        {
            if (p_password == null)
                return null;

            foreach (Librarian t_librarian in Library.a_librarians)
                if (t_librarian.ID == p_id && t_librarian.Password.Equals(p_password))
                {
                    Library.a_connections.Add(t_librarian);
                    return t_librarian;
                }

            return null;
        }

        /// <summary>
        /// Authentificate a Subscriber (Return an object and add it into the list of connected users)
        /// </summary>
        /// <param name="p_id">The ID of the Subscriber</param> 
        /// <param name="p_password">The password of the Subscriber</param>
        /// <returns>A object Subscriber designed by p_id and p_password, null if the authentification has failed</returns>
        [HttpPost]
        public Subscriber AuthentificateAsSubscriber(int p_id, String p_password)
        {
            if (p_password == null)
                return null;

            foreach (Subscriber t_subscriber in Library.a_subscribers)
                if (t_subscriber.ID == p_id && t_subscriber.Password.Equals(p_password))
                {
                    Library.a_connections.Add(t_subscriber);
                    return t_subscriber;
                }

            return null;
        }

        /// <summary>
        /// Remove an user from the list of connected users
        /// </summary>
        /// <param name="p_User">User to disconnect</param>
        [HttpPost]
        public void Disconnect(User p_user)
        {
            if (Library.IsValid(p_user))
                Library.a_connections.Remove(p_user);
        }

        /// <summary>
        /// Return all of the possible commands for each kind of User
        /// </summary>
        /// <param name="p_user">User for check if he is connected and get his type (Librarian or Subscriber)</param>
        /// <returns>Return an String who represent possible commands for each kind of User</returns>
        [HttpPost]
        public String GetCommands(User p_user)
        {
            if (!Library.IsValid(p_user))
                return null;

            StringBuilder t_commands = new StringBuilder();

            switch (p_user.GetType().Name)
            {
                case "Librarian":
                    t_commands.Append("Action :");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[1] : Show books");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[2] : Search book by ISBN");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[3] : Search book by Author");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[4] : Add book");
                    t_commands.Append(Environment.NewLine);
                    break;

                case "Subscriber":
                    t_commands.Append("Action :");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[1] : Show books");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[2] : Search book by ISBN");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[3] : Search book by Author");
                    t_commands.Append(Environment.NewLine);
                    t_commands.Append("[4] : Comment book");
                    t_commands.Append(Environment.NewLine);
                    break;
            }

            t_commands.Append("[5] : Disconnect");
            t_commands.Append(Environment.NewLine);

            return t_commands.ToString();
        }
    }
}
