using System;
using System.Collections.Generic;

namespace Bài2
{
    internal class Bài2
    {
        static bool CheckCapDau(char a, char b)
        {
            return (a == '(' && b == ')') ||
                   (a == '[' && b == ']') ||
                   (a == '{' && b == '}');
        }

        static bool Check(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char kt in s)
            {
                if (kt == '{' || kt == '(' || kt == '[')
                {
                    stack.Push(kt);
                }
                else if (kt == '}' || kt == ')' || kt == ']')
                {
                    if (stack.Count == 0 || !CheckCapDau(stack.Pop(), kt))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap chuoi dau : ");
            string s = Console.ReadLine();
            if (Check(s))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
