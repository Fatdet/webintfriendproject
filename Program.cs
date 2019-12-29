using System;
using System.Collections.Generic;

namespace webIntFriendNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            var ur = new UserReader();
            ur.readFromFile();
            var sim = new Clustering(ur.Users, ur.AdjacencyMatrix);
        }
    }
}
