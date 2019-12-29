using System;
using System.Collections.Generic;
using System.Text;

namespace webIntFriendNetwork
{
    class SpectralClustering
    {
        private int centroids = 3;
        public int[,] AdjacencyMatrix;
        public int[] Diagonal;
        // Vælg centroids antal personer.
        // Cluster de venner som er tættest på
        public SpectralClustering(int[,] adjacencyMatrix)
        {
            AdjacencyMatrix = adjacencyMatrix;
            Diagonal = new int[adjacencyMatrix.Length - 1];
            ComputeDiag(adjacencyMatrix);
        }


        public void ComputeDiag(int[,] adjacencyMatrix)
        {
            int temp = 0;
            for (int i = 0; i < adjacencyMatrix.Length; i++)
            {
                temp = 0;
                for (int k = 0; k < adjacencyMatrix.Length; k++)
                {
                    temp = i + k + temp;
                }
                Diagonal[i] = temp;
            }
        }



    }
}
