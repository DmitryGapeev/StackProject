using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlgorithmsDataStructures
{

	public class Stack<T>
	{
		private readonly List<T> _list;
		public Stack()
		{
			_list = new List<T>();
		}

		public int Size()
		{
			return _list.Count;
		}

		public T Pop()
		{
			if (_list.Count == 0)
				return default(T);

			T result = _list.Last();
			_list.RemoveAt(_list.Count-1);
			return result;
		}

		public void Push(T val)
		{
			_list.Add(val);
		}

		public T Peek()
		{
			if (_list.Count == 0)
				return default(T);

			return _list.Last();
		}
	}

}