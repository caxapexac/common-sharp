using System;
using System.Collections;
using System.Collections.Generic;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMethodReturnValue.Global


namespace Caxapexac.Common.Sharp.Collections
{
    public class CircularArray<T> : IEnumerable<T>
    {
        private readonly T[] _array;
        private int _headIndex;
        private int _tailIndex;

        public CircularArray(int capacity)
        {
            if (capacity < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "must be positive");
            }
            _array = new T[capacity];
            Clear();
        }


        public void Clear()
        {
            _headIndex = Capacity - 1;
            _tailIndex = 0;
            Count = 0;
        }

        public int IndexOf(T obj)
        {
            for (int i = 0; i < Count; ++i)
                if (Equals(obj, this[i]))
                    return i;
            return -1;
        }

        public T Push(T obj)
        {
            IncrementHead();
            T overwritten = Head;
            Head = obj;
            if (Count == Capacity)
                IncrementTail();
            else
                Count++;
            return overwritten;
        }

        public T Pop()
        {
            if (Count == 0) throw new InvalidOperationException("queue empty");
            T popped = Tail;
            Tail = default;
            IncrementTail();
            Count--;
            return popped;
        }

        public void InsertAt(T obj, int index)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index), "not in range");
            if (Count == index)
            {
                Push(obj);
            }
            else
            {
                T last = this[Count - 1];
                for (int i = index; i < Count - 2; ++i)
                {
                    this[i + 1] = this[i];
                }
                this[index] = obj;
                Push(last);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index), "not in range");
            for (int i = index; i > 0; --i) this[i] = this[i - 1];
            Pop();
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0 || Capacity == 0) yield break;
            for (int i = 0; i < Count; ++i) yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void IncrementHead()
        {
            _headIndex = (_headIndex + 1) % _array.Length;
        }

        private void IncrementTail()
        {
            _tailIndex = (_tailIndex + 1) % Capacity;
        }

        public int Count { private set; get; }

        public int Capacity
        {
            get => _array.Length;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index), "not in range");
                return _array[(_tailIndex + index) % Capacity];
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index), "not in range");
                _array[(_tailIndex + index) % Capacity] = value;
            }
        }

        private T Head
        {
            get => _array[_headIndex];
            set => _array[_headIndex] = value;
        }

        private T Tail
        {
            get => _array[_tailIndex];
            set => _array[_tailIndex] = value;
        }
    }
}