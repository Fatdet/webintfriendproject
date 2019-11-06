using System.Collections.Generic;
using System.Linq;

namespace webIntFriendNetwork
{
    public class User
    {
        private static int Id = 0;
        public int UserId {get; private set;}
        public string Name { get; private set; }
        public List<User> Friends { get; set; }
        public string Summary { get; private set; }
        public string Review { get; private set; }

        public List<string> StringFriends {get; private set;}

        public User(string name,string friends, string summary, string review)
        {
            UserId = Id++;
            Name = name;
            Summary = summary;
            Review = review;

            StringFriends = friends.Split(null).ToList();
            Friends = new List<User>();
        }
    }
}