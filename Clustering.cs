using System;
using System.Collections.Generic;
using System.Linq;

namespace webIntFriendNetwork
{
    public class Clustering
    {
        public List<User> Users;
        public int[,] AdjacencyMatrix;
        public double[,] SimilarityMatrix;
        public Clustering(List<User> users, int[,] adjacencyMatrix)
        {
            Users = users;
            AdjacencyMatrix = adjacencyMatrix;
            SimilarityMatrix = new double[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(1)];
            CalcualteSimilarityMatrix();
            //CreateClusters(Centroids);
        }

        private void CalcualteSimilarityMatrix()
        {
            for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AdjacencyMatrix.GetLength(0); j++)
                {
                    if (AdjacencyMatrix[i, j] == 1)
                    {
                        SimilarityMatrix[i, j] = CosineSimilarity(GetColumn(AdjacencyMatrix, i), GetColumn(AdjacencyMatrix, j));
                    }
                    else if (i == j)
                    {
                        SimilarityMatrix[i, j] = 1;
                    }
                }
            }
        }

        private int[] GetColumn(int[,] matrix, int col)
        {
            var colLength = matrix.GetLength(0);
            var colVector = new int[colLength];

            for (var i = 0; i < colLength; i++)
            {
                colVector[i] = matrix[i, col];
            }
            return colVector;
        }

        public double CosineSimilarity(int[] v1, int[] v2)
        {
            int similarity = VertexSimilarity(v1, v2);
            int v1Friends = 0;
            int v2Friends = 0;

            foreach (int i in v1)
            {
                if (i == 1)
                {
                    v1Friends++;
                }
            }
            foreach (int i in v2)
            {
                if (i == 1)
                {
                    v2Friends++;
                }
            }

            return similarity / Math.Sqrt(v1Friends * v2Friends);
        }

        // public double Jaccard(int[] v1, int[] v2){
        //     int similarity = VertexSimilarity(v1, v2);
        //     int totalFriends = 0;

        //     foreach(int i in v1){
        //         if(v1[i] == 1){
        //             totalFriends++;
        //         }
        //         else if(v2[i] == 1){
        //             totalFriends++;
        //         }
        //     }

        //     return similarity /totalFriends;
        // }

        public int VertexSimilarity(int[] v1, int[] v2)
        {
            int similarity = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] == v2[i] && v1[i] == 1)
                {
                    similarity++;
                }
            }
            return similarity;
        }

    }
}