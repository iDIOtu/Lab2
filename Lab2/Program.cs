using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace LabTwo
{
    internal class Program
    {

        public static void Main()
        {
            Console.Write("Введите математическое выражение: ");
            string mathExpression = Console.ReadLine().Replace(" ", null);

            List<int> numbers = new List<int>();
            List<char> operators = new List<char>();

            int i = 0;
            string number = null;

            while (i < mathExpression.Length)
            {
                if (char.IsDigit(mathExpression[i]))
                {
                    number += Convert.ToString(mathExpression[i]);

                    if (i == mathExpression.Length - 1)
                        numbers.Add(int.Parse(number));

                    i++;
                }
                else
                {
                    numbers.Add(int.Parse(number));
                    number = null;

                    operators.Add(mathExpression[i]);
                    i++;
                }
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(numbers[0]);

            for (i = 0; i < operators.Count; i++)
            {
                int operation = operators[i];
                int num = numbers[i + 1];

                if (operators[i] == '*' || operators[i] == '/')
                {
                    int prevasion = stack.Pop();
                    int result = operation == '*' ? prevasion * num : prevasion / num;
                    stack.Push(result);
                }

                else if (operators[i] == '+')
                    stack.Push(num);

                else if (operators[i] == '-')
                    stack.Push(-num);
            }

            int finalResult = 0;
            while (0 < stack.Count)
            {
                finalResult += stack.Pop();
            }

            Console.WriteLine(finalResult);
        }
    }
}