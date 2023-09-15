using System;

namespace GenericType
{
    public class GenericList<T>
    {
        private T[] elements;
        private int size;

        public GenericList(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException("Capacity must be greater than zero.");
            }

            elements = new T[capacity];
            size = 0;
        }

        private void AutoGrow()
        {
            int capacity = elements.Length * 2;
            T[] newElements = new T[capacity];

            for (int i = 0; i < size; i++)
            {
                newElements[i] = elements[i];
            }

            elements = newElements;
        }

        public int Size
        {
            get { return size; }
        }

        public T GetOf(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            return elements[index];
        }

        public void AddElement(T element)
        {
            if (size >= elements.Length)
            {
                AutoGrow();
            }

            elements[size++] = element;
        }

        public void RemoveElementAtIndex(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            for (int i = index; i < size - 1; i++)
            {
                elements[i] = elements[i + 1];
            }

            size--;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            if (size >= elements.Length)
            {
                AutoGrow();
            }

            for (int i = size; i > index; i--)
            {
                elements[i] = elements[i - 1];
            }

            elements[index] = element;
            size++;
        }

        public void ClearList()
        {
            for (int i = 0; i < size; i++)
            {
                elements[i] = default(T);
            }

            size = 0;
        }

        public int GetOf(T element)
        {
            int result = -1;

            for (int i = 0; i < size; i++)
            {
                if (elements[i].Equals(element))
                {
                    result = i;
                    break;
                }
            }

            return result;
        }


        public override string ToString()
        {
            string str = "[";
            for (int i = 0; i < size; i++)
            {
                str += elements[i];
                if (i < size - 1)
                {
                    str += ", ";
                }
            }
            str += "]";
            return str;
        }

        public T GetMin()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            T minElement = elements[0];

            for (int i = 1; i < size; i++)
            {
                if (Comparer<T>.Default.Compare(elements[i], minElement) < 0)
                {
                    minElement = elements[i];
                }
            }

            return minElement;
        }

        public T GetMax()
        {
            if (size == 0)
            {
                throw new InvalidOperationException("The list is empty.");
            }

            T maxElement = elements[0];

            for (int i = 1; i < size; i++)
            {
                if (Comparer<T>.Default.Compare(elements[i], maxElement) > 0)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }
    }

}