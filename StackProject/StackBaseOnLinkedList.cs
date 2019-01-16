using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
	internal class StackBaseOnLinkedList<T>
	{
		private readonly LinkedList<T> _list;

		public StackBaseOnLinkedList()
		{
			_list = new LinkedList<T>();
		}

		public int Size()
		{
			return _list.Count;
		}

		public T Pop()
		{
			if (_list.Count == 0)
				return default(T);

			var result = _list.First.Value;
			_list.RemoveFirst();
			return result;
		}

		public void Push(T val)
		{
			_list.AddFirst(new LinkedListNode<T>(val));
		}

		public T Peek()
		{
			if (_list.Count == 0)
				return default(T);

			return _list.First.Value;
		}
	}
}