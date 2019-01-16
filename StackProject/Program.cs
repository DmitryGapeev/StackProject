using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("stack base on list");
			TestStack();
			Console.WriteLine(new string('=', 50));
			Console.WriteLine("stack base on linked list");
			TestStackBaseOnLinkedList();
			Console.WriteLine(new string('=', 50));

			string string1 = "(()((())()))";
			string string2 = "(()()(())";
			string string3 = "())(";
			string string4 = "))((";

			bool isBalance = IsBalanceBrackets(string1);
			Console.WriteLine(string1 + " is balance = " + isBalance);

			isBalance = IsBalanceBrackets(string2);
			Console.WriteLine(string2 + " is balance = " + isBalance);

			isBalance = IsBalanceBrackets(string3);
			Console.WriteLine(string3 + " is balance = " + isBalance);

			isBalance = IsBalanceBrackets(string4);
			Console.WriteLine(string4 + " is balance = " + isBalance);

			Console.WriteLine(new string('=', 50));

			string expression1 = "1 2 + 3 * =";
			string expression2 = "8 2 + 5 * 9 + =";

			Console.WriteLine("compute expression");
			int result1 = ComputePostfixExpression(expression1);
			Console.WriteLine(expression1 + " " + result1);
			int result2 = ComputePostfixExpression(expression2);
			Console.WriteLine(expression2 + " " + result2);

			Console.WriteLine(new string('=', 50));

			Console.ReadKey();
		}

		static void TestStack()
		{
			Console.Write("test push");
			Console.WriteLine();

			Stack<int> stack = new Stack<int>();

			Console.Write("push into stack ");
			for (int i = 1; i <= 10; i++)
			{
				Console.Write(i + " ");
				stack.Push(i);
			}

			Console.WriteLine();
			Console.WriteLine("size after push = " + stack.Size());

			Console.WriteLine();
			Console.WriteLine("test peek");
			int peekResult = stack.Peek();
			Console.WriteLine("peek result = " + peekResult);
			Console.WriteLine("size after peek = " + stack.Size());

			Console.WriteLine();
			Console.WriteLine("test pop");


			Console.Write("pop from stack ");
			for (int i = 1; i <= 10; i++)
			{
				int item = stack.Pop();
				Console.Write(item + " ");
			}
			Console.WriteLine();
			Console.WriteLine("size after pop = " + stack.Size());

			Console.WriteLine();
			Console.WriteLine("try to pop, size = 0");
			int result = stack.Pop();
			Console.WriteLine("pop result = " + result);
		}

		//задание 4
		static bool IsBalanceBrackets(string row)
		{
			Stack<char> stack = new Stack<char>();
			bool result = true;
			foreach (char bracket in row)
			{
				if(bracket == '(')
					stack.Push(bracket);
				else if (bracket == ')' && stack.Size() != 0)
					stack.Pop();
				else
				{
					result = false;
					break;
				}
			}


			return result;
		}

		//задание 5
		static int ComputePostfixExpression(string expression)
		{
			Stack<string> stack1 = new Stack<string>();
			Stack<int> stack2 = new Stack<int>();

			string[] expressionItems = expression.Split(' ');

			foreach (string expItem in expressionItems.Reverse())
				stack1.Push(expItem);

			while (stack1.Size() != 0)
			{
				string expressionItem = stack1.Pop();

				if (expressionItem == "*")
				{
					if(stack2.Size()<2)
						throw new InvalidOperationException("недостаточно значений для умножения");

					int val1 = stack2.Pop();
					int val2 = stack2.Pop();
					stack2.Push(val1 * val2);
				}
				else if (expressionItem == "+")
				{
					if (stack2.Size() < 2)
						throw new InvalidOperationException("недостаточно значений для сложения");

					int val1 = stack2.Pop();
					int val2 = stack2.Pop();
					stack2.Push(val1 + val2);
				}
				else if(expressionItem == "=")
					break;
				else
				{
					stack2.Push(int.Parse(expressionItem));
				}
			}

			if(stack2.Size() > 1)
				throw new InvalidOperationException("не удалось вычислить выражение");

			return stack2.Pop();
		}

		static void TestStackBaseOnLinkedList()
		{
			Console.Write("test push");
			Console.WriteLine();

			StackBaseOnLinkedList<int> stack = new StackBaseOnLinkedList<int>();

			Console.Write("push into stack ");
			for (int i = 1; i <= 10; i++)
			{
				Console.Write(i + " ");
				stack.Push(i);
			}

			Console.WriteLine();
			Console.WriteLine("size after push = " + stack.Size());

			Console.WriteLine();
			Console.WriteLine("test peek");
			int peekResult = stack.Peek();
			Console.WriteLine("peek result = " + peekResult);
			Console.WriteLine("size after peek = " + stack.Size());

			Console.WriteLine();
			Console.WriteLine("test pop");


			Console.Write("pop from stack ");
			for (int i = 1; i <= 10; i++)
			{
				int item = stack.Pop();
				Console.Write(item + " ");
			}
			Console.WriteLine();
			Console.WriteLine("size after pop = " + stack.Size());

			Console.WriteLine();
			Console.WriteLine("try to pop, size = 0");
			int result = stack.Pop();
			Console.WriteLine("pop result = " + result);
		}
	}
}
