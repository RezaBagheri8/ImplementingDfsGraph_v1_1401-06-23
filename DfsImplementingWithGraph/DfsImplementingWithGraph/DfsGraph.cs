﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DfsImplementingWithGraph
{
    public class DfsGraph
    {
        public int[,] numArray = { { 0, 0, 0, 1, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 1, 1, 0 }, { 0, 0, 0, 0, 0, 1, 1, 0 }, { 1, 0, 0, 0, 0, 0, 0, 0 }, { 0, 0, 0, 0, 0, 0, 0, 0 }, { 0, 1, 1, 0, 0, 0, 0, 0 }, { 0, 1, 1, 0, 0, 0, 0, 1 }, { 0, 0, 0, 0, 0, 0, 1, 0 } };
        public int nodeQuantity = 8;
        public Stack<int> stack;

        public DfsGraph()
        {
            stack = new Stack<int>();
        }

        int k = 0;
        public void Search(int index, int[] visited)
        {
            visited[k] = index;
            k++;
            if (stack.Count > 0)
                stack.Pop();

            for (int i = nodeQuantity - 1; i >= 0; i--)
            {
                if (numArray[index, i] == 1)
                {
                    bool flag = false;
                    for (int j = 0; j < visited.Length; j++)
                    {
                        if (visited[j] == i)
                            flag = true;
                    }
                    if (!flag)
                    {
                        if (stack.Count > 0)
                        {
                            if (stack.Peek() != i)
                                stack.Push(i);
                        }
                        else
                        {
                            stack.Push(i);
                        }
                    }
                }
            }

            if (stack.Count == 0)
            {
                foreach (var item in visited)
                {
                    Console.WriteLine(item + "   ");
                }
                return;
            }

            Search(stack.Peek(), visited);
        }
    }
}
