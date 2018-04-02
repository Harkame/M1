using System;
using Microsoft.AspNetCore.Mvc;
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
        public bool Authentificate(int p_user_id, String p_password)
        {
            if (p_password == null)
                return false;

            foreach (Librarian t_librarian in Library.Librarians)
                if (t_librarian.ID == p_user_id && t_librarian.Password.Equals(p_password))
                {
                    Library.Connections.Add(t_librarian);
                    return true;
                }

            foreach (Subscriber t_subscriber in Library.Subscribers)
                if (t_subscriber.ID == p_user_id && t_subscriber.Password.Equals(p_password))
                {
                    Library.Connections.Add(t_subscriber);
                    return true;
                }

            return false;
        }

        /// <summary>
        /// Remove an user from the list of connected users
        /// </summary>
        /// <param name="p_User">User to disconnect</param>
        [HttpPost]
        public void Disconnect(int p_user_id)
        {
            if (Library.IsValid(p_user_id))
                foreach(User t_user in Library.Connections)
                    if(t_user.ID == p_user_id)
                    {
                        Library.Connections.Remove(t_user);
                        return;
                    }
                
        }

        /// <summary>
        /// Return all of the possible commands for each kind of User
        /// </summary>
        /// <param name="p_user">User for check if he is connected and get his type (Librarian or Subscriber)</param>
        /// <returns>Return an String who represent possible commands for each kind of User</returns>
        [HttpGet]
        public String GetCommands(int p_user_id)
        {
            if (!Library.IsValid(p_user_id))
                return null;

            StringBuilder t_commands = new StringBuilder();

            if (Library.IsValidLibrarian(p_user_id))
            {
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
            }
            else if (Library.IsValidSubscriber(p_user_id))
            {
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
            }

            t_commands.Append("[5] : Disconnect");
            t_commands.Append(Environment.NewLine);

            return t_commands.ToString();
        }
    }
}
