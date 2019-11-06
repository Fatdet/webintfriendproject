using System.Collections.Generic;
using System.Linq;

namespace webIntFriendNetwork
{
    public class UserReader
    {
        public List<User> Users {get; private set;}
        public UserReader(){
            Users = new List<User>();
        }
        public void readFromFile()
        {
            
            string[] friendshipsreviews = System.IO.File.ReadAllLines(@"./friendships.reviews.txt");
            for(int i = 0; i < friendshipsreviews.Length; i+=5)
            {
                Users.Add(
                    new User(
                        friendshipsreviews[i].Remove(0,6),
                        friendshipsreviews[i+1].Remove(0,9),
                        friendshipsreviews[i+2].Remove(0,9),
                        friendshipsreviews[i+3].Remove(0,8)
                    )
                );
            }
            foreach(User user in Users)
            {
                foreach(string stringFriend in user.StringFriends)
                {
                    foreach (User friend in Users)
                    {
                        if (friend.Name == stringFriend)
                        {
                            user.Friends.Add(friend);
                        }
                    }
                }
            }
            
        }
    }
}