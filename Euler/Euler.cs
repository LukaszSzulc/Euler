using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    public class Euler
    {
        private readonly int[][] _graph;

        public Euler()
        {
            _graph = new int[5][];
            _graph[0] = new int[5]{ 0, 1, 1, 0, 0 };
            _graph[1] = new int[5] { 1, 0, 1, 0, 0 };
            _graph[2] = new int[5] { 1, 1, 0, 1, 1 };
            _graph[3] = new int[5] { 0, 0, 1, 0, 1 };
            _graph[4] = new int[5] { 0, 0, 1, 1, 0 };

        }

        public Euler(int[][] graph)
        {
            this._graph = graph;
            IsGraphValid();
        }


        public List<char> FindEulerCycle(int startVertex)
        {
            var stack = new Stack<int>();
            var result = new List<char>();
            stack.Push(startVertex);
            while(stack.Count > 0)
            {
                var vertex = stack.First();
                var neighborInfo = GetNeighborInfo(vertex);
                if(!neighborInfo.Exists)
                {
                    var v = stack.Pop();
                    result.Insert(0, (char)(vertex+65));
                }
                else
                {
                    stack.Push(neighborInfo.Index);
                    _graph[neighborInfo.Index][vertex]--;
                    _graph[vertex][neighborInfo.Index]--;

                }
            }

            return result;
        }

        private void IsGraphValid()
        {
            foreach (var item in _graph)
            {
                if(item.Sum() % 2 != 0)
                {
                    throw new ArgumentException("Graph Should contain odd number of outcomming edges from each vertex");
                }
            }
        } 

        private Neighbor GetNeighborInfo(int vertex)
        {
            var neighbor = new Neighbor();
            for (var i = 0; i < this._graph[vertex].Length; i++)
            {
                if(this._graph[vertex][i] == 1)
                {
                    neighbor.Exists = true;
                    neighbor.Index = i;
                    return neighbor;
                }
            }

            return neighbor;
        }
    }
}
